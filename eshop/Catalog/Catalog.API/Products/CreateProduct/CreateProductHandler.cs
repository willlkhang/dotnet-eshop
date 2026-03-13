using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct;

using BuildingBlocks.CQRS;
using MediatR;

//DTO
public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    : ICommand<CreateProductResult>;
//DTO response
public record CreateProductResult(Guid Id);

internal class CreateProductHandler 
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {   
        //create product entity from command object
        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };
        //Todo
        //save to database
        //return createProductResult result
        return new CreateProductResult(Guid.NewGuid());
    }
}