namespace Catalog.API.Products.CreateProduct;
//DTO
public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    : ICommand<CreateProductResult>;
//DTO response
public record CreateProductResult(Guid Id);

internal class CreateProductHandler(IDocumentSession session) 
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
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);
        
        //return createProductResult result
        return new CreateProductResult(product.Id);
    }
}