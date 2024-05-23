using BuildingBlocks.CQRS;
using Catalog.API.Models;
using MediatR;

namespace Catalog.API.Products.CreateProduct
{

    public record CreateProductCommand(string Name, List<string> Catagory, string Description, string ImageFime, decimal Price)
        : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    internal class CreateProductCommandHandler 
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // Create Product from command object
            // Save to databse
            // Return CreateProductResult

            var product = new Product()
            {
                Name = command.Name,
                Catagory = command.Catagory,
                Description = command.Description,
                ImageFime = command.ImageFime,
                Price = command.Price


            };

            // Todo
            // Save to databse

            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
