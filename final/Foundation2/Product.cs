class Product
{
    private string Name;
    private string ProductID;
    private decimal Price;
    private int Quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        Name = name;
        ProductID = productId;
        Price = price;
        Quantity = quantity;
    }

    public decimal GetTotalCost()
    {
        return Price * Quantity;
    }

    public string GetName()
    {
        return Name;
    }

    public string GetProductID()
    {
        return ProductID;
    }
}
