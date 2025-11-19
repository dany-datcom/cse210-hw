using System.Collections.Generic;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Total cost = total product cost + shipping
    public double GetTotalCost()
    {
        double total = 0;

        foreach (Product p in _products)
        {
            total += p.GetTotalCost();
        }

        // Shipping cost
        if (_customer.LivesInUSA())
        {
            total += 5;
        }
        else
        {
            total += 35;
        }

        return total;
    }

    // Packing label: name + ID
    public string GetPackingLabel()
    {
        string label = "";

        foreach (Product p in _products)
        {
            label += $"{p.GetName()} (ID: {p.GetId()})\n";
        }

        return label;
    }

    // Shipping label: customer name + full address
    public string GetShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}



//retur dtring for the shipping label

//The total price is calculated as the sum of the total cost of each product plus a one-time shipping cost.

//This company is based in the USA. If the customer lives in the USA, then the shipping cost is $5. If the customer does not live in the USA, then the shipping cost is $35.

//A packing label should list the name and product id of each product in the order.

//A shipping label should list the name and address of the customer