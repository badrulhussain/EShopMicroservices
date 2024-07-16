namespace Catalog.API.Products.GetProduts
{
    public record GetProductRequest(int? PageNumber = 1, int? PageSize = 10);
    public record GetProductResponse(IEnumerable<Product> Products);

    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async ([AsParameters] GetProductRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetProductsQuery>();

                var reuslt = await sender.Send(query);

                var reposne = reuslt.Adapt<GetProductResponse>();

                return Results.Ok(reposne);
            })
                .WithName("GetProducts")
                .Produces<GetProductResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get Products")
                .WithDescription("Get Products");
        }
    }
}
