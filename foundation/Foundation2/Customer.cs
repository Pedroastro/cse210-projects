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

    public string GetAddress()
    {
        return _address.GetAddress();
    }

    public bool LivesInUSA()
    {
        if (_address.InUSA())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}