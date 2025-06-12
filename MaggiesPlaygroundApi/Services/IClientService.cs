using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public interface IClientService
{
    Task<(IEnumerable<ClientDto> Clients, int TotalCount)> GetClientsAsync(ClientQueryParameters queryParams);
    Task<ClientDto?> GetClientByIdAsync(Guid id);
    Task<ClientDto> CreateClientAsync(CreateClientDto clientDto, string currentUser);
    Task<ClientDto?> UpdateClientAsync(Guid id, UpdateClientDto clientDto, string currentUser);
    Task<bool> DeleteClientAsync(Guid id, string currentUser);
} 