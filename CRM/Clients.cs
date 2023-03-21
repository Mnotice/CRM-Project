public class Client
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public ClientStatus Status { get; set; } = ClientStatus.Active;
}

public enum ClientStatus
{
    Active,
    Inactive,
    Pending
}
