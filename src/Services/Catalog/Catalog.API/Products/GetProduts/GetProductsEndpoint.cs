namespace Catalog.API.Products.GetProduts
{
    //public record GetProductRequest();
    public record GetProductResponse(IEnumerable<Product> Products);

    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {
                var reuslt = await sender.Send(new GetProductsQuery());

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
