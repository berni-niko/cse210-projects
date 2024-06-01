using System.Text;

class Order
{
    private List<Product> Products;
    private Customer Customer;

    public Order(List<Product> products, Customer customer)
    {
        Products = products;
        Customer = customer;
    }

    public decimal CalculateTotalCost()
    {
        decimal totalCost = 0;
        foreach (var product in Products)
        {
            totalCost += product.GetTotalCost();
        }
        if (Customer.IsInUSA())
        {
            totalCost += 5;
        }
        else
        {
            totalCost += 35;
        }
        return totalCost;
    }

    public string GetPackingLabel()
    {
        StringBuilder packingLabel = new StringBuilder();
        foreach (var product in Products)
        {
            packingLabel.AppendLine($"{product.GetName()} ({product.GetProductID()})");
        }
        return packingLabel.ToString();
    }

    public string GetShippingLabel()
    {
        return $"{Customer.GetName()}\n{Customer.GetAddress().GetFullAddress()}";
    }
}
