# 🚀 AutoApiGenerator

> Automatically generate RESTful CRUD endpoints in ASP.NET Core using C# Source Generators.

![.NET Version](https://img.shields.io/badge/.NET-9.0-blueviolet)
---

## ✨ Overview

`AutoApiGenerator` is a **Roslyn Source Generator** that scans your entity classes at compile-time and auto-generates full REST API endpoints (CRUD) for them — with **zero runtime reflection**, **no controllers**, and **customizable output** via partial classes.

🎯 Perfect for:
- Rapid prototyping
- Admin dashboards
- Reducing repetitive code
- Enforcing consistency across services

---

## 🛠️ Features

✅ Auto-generates endpoints for classes marked with `[AutoApi]`  
✅ EF Core support for database operations  
✅ Partial class extensions for customization  
✅ Clean, minimal API style (uses endpoint routing, not controllers)  
✅ 100% compile-time — no runtime reflection or performance penalties

---

## 📦 Installation

Make sure your project targets .NET 8 or higher and is an SDK-style project.

🧪 Example Usage
1. Define an Entity
```
using JPD.AutoRest.Attributes;

[AutoApi(RoutePrefix = "api/products", DbContextType = typeof(AppDbContext))]
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

2. Register Endpoints in Program.cs

```
app.MapProductEndpoints(); // This is generated for you!
```
That’s it — the following endpoints are generated automatically:

| Verb   | Route                | Description      |
| ------ | -------------------- | ---------------- |
| GET    | `/api/products`      | Get all products |
| GET    | `/api/products/{id}` | Get by ID        |
| POST   | `/api/products`      | Create a product |
| PUT    | `/api/products/{id}` | Update product   |
| DELETE | `/api/products/{id}` | Delete product   |


🧩 Customization
Extend the generated behavior via partial classes:

```
public static partial class ProductEndpoints
{
    public static WebApplication MapProductEndpoints(this WebApplication app)
    {
        app.MapGet("/api/products/special", () => "✨ Hello from custom logic!");
        return app.MapBaseProductEndpoints(); // Call auto-generated implementation
    }
}
```
⚙️ How It Works
Compile-Time Flow
```
[Entity + [AutoApi]] → Syntax + Semantic Analysis → Endpoint Generation
```

Files Generated
ProductEndpoints.gen.cs: Auto-generated CRUD logic (DO NOT MODIFY)

ProductEndpoints.cs: Optional partial for your extensions

🧠 Requirements
.NET 8+

SDK-style project (.csproj)

Minimal API style (WebApplication)

🙋 FAQ
❓ Does it support nested or related entities?
Currently, only top-level flat entities are supported. Support for relations (e.g. includes) may be added in a future version.

❓ Can I disable generation for certain methods?
Not yet, but configuration flags via attribute parameters are planned.\

📄 License
This project is licensed under the MIT License — see the LICENSE file for details.

💬 Support & Feedback
If this project saves you time or improves your workflow, consider giving it a ⭐ on GitHub and sharing it!
You can also reach out via GitHub Issues for suggestions or bugs.
