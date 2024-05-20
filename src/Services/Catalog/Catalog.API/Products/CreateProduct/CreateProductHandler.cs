using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Catalog.API.Products.CreateProduct
{

    public record CreateProductCommand(string Name, List<string> Catagory, string Description, string ImageFime, decimal Price)
        : IRequest<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    internal class CreateProductHandler
    {
    }
}
