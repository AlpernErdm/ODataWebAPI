using Bogus;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using ODataWebAPI.Context;
using ODataWebAPI.Controllers;
using ODataWebAPI.Models;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddControllers().AddOData(opt =>
opt.
EnableQueryFeatures() //Odatanýn izin verdiði query paramslarý parametre olarak gönderebilememizi saðlar
//Select()
//.Filter() //bu þekilde odata sorgularýný kullanabiliriz
//.Count()
//.Expand()
//.OrderBy()
//.SetMaxTop(null)
.AddRouteComponents("odata", CategoryController.GetEdmModel())
);
builder.Services.AddOpenApi();


var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();
app.MapControllers();


////100 tane fake kategori verisi ekleyecek
//app.MapGet("seed-data/categories", async (ApplicationDbContext dbContext) =>
//{
//Faker faker = new();

//var categoryNames = faker.Commerce.Categories(100);
//List<Category> categories = categoryNames.Select(s => new Category
//{
//    Name = s,
//}).ToList();

//dbContext.AddRange(categories);

//await dbContext.SaveChangesAsync();

//return Results.NoContent();
//}).Produces(204).WithTags("SeedCategories");
//app.MapGet("seed-data/products", async (ApplicationDbContext dbContext) =>
//{
//var categories = dbContext.Categories.ToList();

//List<Product> products = new();
//for (int i = 0; i < 10000; i++)
//{
//    Faker faker = new();
//    Product product = new()
//    {
//        CategoryId = categories[new Random().Next(categories.Count)].Id,
//        Name = faker.Commerce.ProductName(),
//        Price = Convert.ToDecimal(faker.Commerce.Price(100, 1000000, 2))
//    };

//    products.Add(product);
//}
//dbContext.AddRange(products);
//await dbContext.SaveChangesAsync();
// return Results.NoContent();
//}).Produces(204).WithTags("SeedProducts");

app.MapGet("seed-data/users", async (ApplicationDbContext dbContext) =>
{
    List<User> users = new();
    for (int i = 0; i < 10000; i++)
    {
        Faker faker = new();

        Random random = new();
        var typeValue = random.Next(0, 2);
        var userType = UserTypeEnum.FromValue(typeValue);

        User user = new()
        {
            FirstName = faker.Person.FirstName,
            LastName = faker.Person.LastName,
            UserType = userType,
            Address = new(faker.Address.City(), faker.Address.State(), faker.Address.FullAddress())
        };

        users.Add(user);
    }

    dbContext.AddRange(users);

    await dbContext.SaveChangesAsync();

    return Results.NoContent();
});


app.Run();
