public class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private float _quantity;

    public Product(string name, string productId, double price, float quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public string GetProductInformation()
    {
        return $"Product Name: {_name} Product ID: {_productId}";
    }

    public double GetTotalCost()
    {
        return _price * (double)_quantity;
    }
}