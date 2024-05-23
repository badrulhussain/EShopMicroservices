namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductRequest(string Name, List<string> Catagory, string Description, string ImageFime, decimal Price);
    public record CreateProductResponse(Guid Id);

    public class CreateProductEndpoint
    {
    }
}
