

using RO.DevTest.Domain.Abstract;

public class Product : BaseEntity{

    public string Name {get; set;} = string.Empty;
    public float Price {get; set;}
    public int Stock {get; set;}
    public string Description {get; set;} = string.Empty;
    
    public Product() : base(){}

}