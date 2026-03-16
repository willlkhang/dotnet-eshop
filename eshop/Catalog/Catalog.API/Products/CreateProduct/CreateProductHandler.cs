using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace Catalog.API.Products.CreateProduct;
//DTO
public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    : ICommand<CreateProductResult>;
//DTO response
public record CreateProductResult(Guid Id);

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Product name is required");
        RuleFor(x => x.Category).NotNull().NotEmpty().WithMessage("Category is required");
        //RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("Description is required");
        //RuleFor(x => x.ImageFile).NotNull().NotEmpty().WithMessage("Image file is required");
        RuleFor(x => x.Price).NotNull().NotEmpty().WithMessage("Price is required");
    }
}
internal class CreateProductHandler(IDocumentSession session, IValidator<CreateProductCommand> validator) 
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {   
        var result = await validator.ValidateAsync(command, cancellationToken);
        var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
        if (errors.Any())
        {
            throw new ValidationException(errors.FirstOrDefault());
        }
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