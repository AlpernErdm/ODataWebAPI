using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataWebAPI.Context;
using ODataWebAPI.Dtos;
using ODataWebAPI.Models;

namespace ODataWebAPI.Controllers;

    [Route("odata")]
    [ApiController]
    [EnableQuery]
    public sealed class CategoryController(
     ApplicationDbContext context) : ODataController
    {
        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new();
        builder.EnableLowerCamelCase();//otomatik küçük harfe çevirir
        builder.EntitySet<Category>("categories");
            builder.EntitySet<Product>("products");
            builder.EntitySet<UserDto>("users");
        return builder.GetEdmModel();
        }

        [HttpGet("categories")]
        //[EnableQuery(AllowedQueryOptions=AllowedQueryOptions.All &~ AllowedQueryOptions.Select)]
        public IQueryable<Category> GetCategories()
        {
            var categories = context.Categories.AsQueryable();
            return categories;
        }
    #region Products
    [HttpGet("products")]
    public IQueryable<Product> ProductsDto()
    {
        var product = context.Products.AsQueryable();
        return product;
    }

    [HttpGet("products-dto")]
    public IQueryable<ProductDto> Products()
    {
        var response = context.Products.Select(s => new ProductDto
        {
            Id = s.Id,
            Name = s.Name,
            Price = s.Price,
            CategoryName = s.Category != null ? s.Category.Name : ""
        }).AsQueryable();
        return response;
    }
    #endregion


    #region Users
    [HttpGet("users")]
    public IActionResult Users()
    {
        var users = context.Users
            .Select(s => new UserDto
            {
                FirstName = s.FirstName,
                LastName = s.LastName,
                FullName = s.FullName,
                Address = s.Address,
                Id = s.Id,
                UserType = s.UserType,
                UserTypeName = s.UserType.Name,
                UserTypeValue = s.UserType.Value
            })
            .AsQueryable();
        return Ok(users);
    }
    #endregion


}
