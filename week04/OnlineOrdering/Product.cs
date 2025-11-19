//Contains the name, product id, price, and quantity of each product.
public class Product
{
    private string _name;
    private string _id;
    private double _price;
    private int _quantity;

    public Product(string name, string id, double price, int quantity)
    {
        _name = name;
        _id = id;
        _price = price;
        _quantity = quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetId()
    {
        return _id;
    }

    // Price * quantity
    public double GetTotalCost()
    {
        return _price * _quantity;
    }
}



//(If the price per unit was $3 and they bought 5 of them, the product total cost would be $15.)

