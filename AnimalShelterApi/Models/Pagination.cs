using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalShelterApi.Models
{
  public class Pagination<T>
  {
    public int TotalCount { get; set; }
    public int PageSize { get; set; } = 10;
    public int CurrentPage { get; set; } = 1;
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    public List<T> Items { get; set; }
  }
}

public static class PaginationHelper
{
  public static Pagination<T> Paging<T>(IQueryable<T> query, int pageIndex, int pageSize)
  {
    var result = new PagedResult<T>
    {
      TotalCount = query.Count();
      PageSize = pageSize,
      CurrentPage = pageIndex,
      Items = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList()
    };

    return result;
  }
}
