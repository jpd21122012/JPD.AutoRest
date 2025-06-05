namespace JPD.AutoRest.Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add standard services (keep these if needed)
            builder.Services.AddControllers();
            builder.Services.AddOpenApi(); // Optional for Swagger

            var app = builder.Build();

            // =============================================
            // 🔥 CRITICAL SOURCE GENERATOR INTEGRATION CHECK
            // =============================================
            try
            {
                app.MapProductEndpoints(); // ← Auto-generated!
                System.Diagnostics.Debug.WriteLine("✅ Successfully mapped ProductEndpoints");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ Failed to map endpoints: {ex.Message}");

#if DEBUG
                // Fallback for development debugging
                app.MapGroup("api/products")
                    .MapGet("/", () => "Fallback: Source generator not working");
#endif
            }

            // Standard pipeline (customize as needed)
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi(); // For Swagger
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}