public interface IClientService
{
    Task<List<Client>> GetClientsAsync();
    Task<Client> GetClientAsync(int id);
    Task<Client> AddClientAsync(Client client);
    Task UpdateClientAsync(int id, Client client);
    Task DeleteClientAsync(int id);
}
public class ClientService : IClientService
{
    private readonly List<Client> _clients;

    public ClientService()
    {
        _clients = new List<Client>
        {
            new Client { Id = 1, Name = "Client 1", Email = "client1@example.com", Phone = "555-1111" },
            new Client { Id = 2, Name = "Client 2", Email = "client2@example.com", Phone = "555-2222" },
            new Client { Id = 3, Name = "Client 3", Email = "client3@example.com", Phone = "555-3333" }
        };
    }

    public Task<List<Client>> GetClientsAsync()
    {
        return Task.FromResult(_clients);
    }

    public Task<Client> GetClientAsync(int id)
    {
        return Task.FromResult(_clients.FirstOrDefault(c => c.Id == id));
    }

    public async Task<Client> AddClientAsync(Client client)
    {
        client.Id = _clients.Max(c => c.Id) + 1;
        _clients.Add(client);
        return await Task.FromResult(client);
    }

    public async Task UpdateClientAsync(int id, Client client)
    {
        var existingClient = _clients.FirstOrDefault(c => c.Id == id);
        if (existingClient != null)
        {
            existingClient.Name = client.Name;
            existingClient.Email = client.Email;
            existingClient.Phone = client.Phone;
        }

        await Task.CompletedTask;
    }

    public async Task DeleteClientAsync(int id)
    {
        var existingClient = _clients.FirstOrDefault(c => c.Id == id);
        if (existingClient != null)
        {
            _clients.Remove(existingClient);
        }

        await Task.CompletedTask;
    }
}
