using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public interface IRaceService
{
    Task<(IEnumerable<RaceDto> Races, int TotalCount)> GetRacesAsync(RaceQueryParameters queryParams);
    Task<RaceDto?> GetRaceByIdAsync(int id);
    Task<RaceDto> CreateRaceAsync(CreateRaceDto raceDto, string currentUser);
    Task<RaceDto?> UpdateRaceAsync(int id, UpdateRaceDto raceDto, string currentUser);
    Task<bool> DeleteRaceAsync(int id, string currentUser);
} 