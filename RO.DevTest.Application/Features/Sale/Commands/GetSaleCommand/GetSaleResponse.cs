public class GetSaleResponse
{
    public int TotalSales { get; set; }
    public float TotalRevenue { get; set; }
    public List<ProductRevenue> ProductsRevenue { get; set; } = new();
}

public class ProductRevenue
{
    public string ProductName { get; set; } = string.Empty;
    public float Revenue { get; set; }
}
