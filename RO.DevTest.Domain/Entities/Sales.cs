using RO.DevTest.Domain.Abstract;
using RO.DevTest.Domain.Entities;

public class Sale : BaseEntity {
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public int Quantity { get; set; }
    public float TotalPrice { get; set; }

    public DateTime SaleDate { get; set; } = DateTime.UtcNow;
}