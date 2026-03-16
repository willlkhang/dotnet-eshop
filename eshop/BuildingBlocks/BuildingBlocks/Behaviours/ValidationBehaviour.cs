using BuildingBlocks.CQRS;
using MediatR;
using FluentValidation;

namespace BuildingBlocks.Behaviours;

public class ValidationBehaviour<TRequest, TResponse>
(IEnumerable<IValidationRule<TRequest>> validator)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand
{
    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}