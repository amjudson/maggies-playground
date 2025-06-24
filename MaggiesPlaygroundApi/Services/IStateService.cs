using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public interface IStateService
{
    Task<(IEnumerable<StateDto> States, int TotalCount)> GetStatesAsync(StateQueryParameters queryParams);
    Task<StateDto?> GetStateByIdAsync(int id);
    Task<StateDto> CreateStateAsync(CreateStateDto stateDto, string currentUser);
    Task<StateDto?> UpdateStateAsync(int id, UpdateStateDto stateDto, string currentUser);
    Task<bool> DeleteStateAsync(int id, string currentUser);
} 