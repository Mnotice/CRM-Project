public class ClientService
{
    private readonly List<Client> _clients;

    public ClientService()
    {
        _clients = new List<Client>();
    }

    public IEnumerable<Client> GetClients()
    {
        return _clients;
    }

    public void AddClient(Client client)
    {
        client.Id = _clients.Count + 1;
        _clients.Add(client);
    }

    public void DeleteClient(int id)
    {
        var client = _clients.FirstOrDefault(c => c.Id == id);
        if (client != null)
        {
            _clients.Remove(client);
        }
    }

    public void UpdateClientStatus(int id, ClientStatus status)
    {
        var client = _clients.FirstOrDefault(c => c.Id == id);
        if (client != null)
        {
            client.Status = status;
        }
    }
}
