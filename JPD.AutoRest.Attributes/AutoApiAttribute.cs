namespace JPD.AutoRest.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AutoApiAttribute : Attribute
    {
        public string RoutePrefix { get; set; } = "api";
    }
}
