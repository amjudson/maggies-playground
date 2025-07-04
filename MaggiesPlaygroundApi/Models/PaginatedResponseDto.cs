using System.Collections.Generic;

namespace MaggiesPlaygroundApi.Models;

public class PaginatedResponseDto<T>
{
    public int TotalCount { get; set; }
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    public IEnumerable<T> Items { get; set; } = new List<T>();
} 