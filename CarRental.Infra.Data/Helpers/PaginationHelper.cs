using CarRental.Domain.Pagination;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infra.Data.Helpers
{
    public static class PaginationHelper
    {
        public static async Task<PagedList<T>> CreateAsync<T>
            (IQueryable<T> source, int pageNumber, int pageSize) where T : class
        {
            int count = await source.CountAsync();
            List<T> items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedList<T>(items, pageNumber, pageSize, count);
        }
    }
}
