using Ordering.Domain.Abstraction;

namespace Ordering.Domain.Models;

public class Order : Aggregate<Guid>
{
    private readonly List<OrderItem> _orderITems = new();
    public IReadOnlyList<OrderItem> OrderITems => _orderITems.AsReadOnly();

    public Guid CustomerId { get; set; } = default!;
    public string OrderName { get; set; } = default!;
    public Address ShippingAddress { get; private set; } = default!;
    public Address BillingAddress { get; private set; } = default;
    public Payment Payment { get; private set; } = default!;
    public OrderStatus Status { get; private set; } = OrderStatus.Pending;
    public decimal TotalPrice
    {
        get => OrderItems.Sum(x => x.Price * x.Quantity);
        private set { }
    }
    
    
}