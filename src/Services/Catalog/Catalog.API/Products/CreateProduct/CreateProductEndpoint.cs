namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductRequest(string Name, List<string> Catagory, string Description, string ImageFile, decimal Price);
    public record CreateProductResponse(Guid Id);

    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("products/", 
                async (CreateProductCommand request, ISender send) =>
                {
                    var command = request.Adapt<CreateProductCommand>();

                    var result = send.Send(command);

                    var response = result.Adapt<CreateProductResponse>();

                    return Results.Created($"products/{response.Id}", response);
                })
                .WithName("CreateProdct")
                .Produces<CreateProductResponse>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Create Prodcut")
                .WithDescription("Create Product");
        }
    }
}
