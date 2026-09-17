namespace SearchingSorting.Models;

public class Contact
{
    private string _firstName;
    private string _lastName;
    private string _mobile;
    private string _birthday;
    private string _street;
    private string _city;

    public string FirstName
    {
        get { return _firstName; }
    }

    public string LastName
    {
        get { return _lastName; }
    }

    public string Mobile
    {
        get { return _mobile; }
    }

    public string Birthday
    {
        get { return _birthday; }
    }

    public string Street
    {
        get { return _street; }
    }

    public string City
    {
        get { return _city; }
    }

    public Contact(
        string firstName,
        string lastName,
        string mobile,
        string birthday,
        string street,
        string city)
    {
        _firstName = firstName;
        _lastName = lastName;
        _mobile = mobile;
        _birthday = birthday;
        _street = street;
        _city = city;
    }
}