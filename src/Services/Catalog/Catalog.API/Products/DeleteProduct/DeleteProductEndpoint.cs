
namespace Catalog.API.Products.DeleteProduct
{
    //public record DeleteProductRequest(Guid Id);
    public record DeleteProdcutResponse(bool IsSuccess);

    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{Id}", async (Guid Id, ISender sender) =>
            {
                var result = await sender.Send(new DeleteProductCommand(Id));

                var response = result.Adapt<DeleteProdcutResponse>();

                return Results.Ok(response);
            })
            .WithDisplayName("DeleteProduct")
            .Produces<DeleteProdcutResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete Product")
            .WithDescription("Delete Product");
        }
    }
}
