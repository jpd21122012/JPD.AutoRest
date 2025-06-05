using JPD.AutoRest.Attributes;

namespace JPD.AutoRest.Demo
{
    [AutoApi(RoutePrefix = "api/products")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
