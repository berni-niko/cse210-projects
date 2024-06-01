
public class Reception : Event
{
    private string _rsvpEmail;

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        _rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"Type: Reception\n{GetStandardDetails()}\nEmail: {_rsvpEmail}";
    }
}

