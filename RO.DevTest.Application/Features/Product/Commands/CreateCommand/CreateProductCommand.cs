using MediatR;

public class CreateProductCommand: IRequest<CreateProductResult>{
    public string Name {get; set;} = string.Empty;
    public float Price {get; set;}
    public int Stock {get; set;}
    public string Description {get; set;} = string.Empty;
    public Product AssignTo() {
        return new Product{
            Name = Name,
            Price = Price,
            Stock = Stock,
            Description = Description
        };
    }
}