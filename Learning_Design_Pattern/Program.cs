// See https://aka.ms/new-console-template for more information

public class Subscribe
{
    public string? _name { get; set; }
    public string? _email { get; set; }

    public Subscribe(string name , string email)
    {
        _name = name;
        _email = email;
    }


}

public class EmailNotification
{
    Subscribe? _subscribe;
    public string? subscribed { get; set; }
}

public class SMSNotification
{
    Subscribe? _subscribe;
    public string? messagedelived { get; set; }
}


