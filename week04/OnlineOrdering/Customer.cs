public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string GetName()
    {
        return _name;
    }

    public Address GetAddress()
    {
        return _address;
    }

    // Calls the Address method
    public bool LivesInUSA()
    {
        return _address.IsInUSA();
    }


}

//(Hint this should call a method on the address to find this.)