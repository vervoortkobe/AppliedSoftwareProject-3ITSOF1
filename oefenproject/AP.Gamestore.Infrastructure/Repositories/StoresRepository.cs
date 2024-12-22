using AP.MyGameStore.Application;
using AP.MyGameStore.Application.Interfaces;
using AP.MyGameStore.Domain;
using AP.MyGameStore.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AP.MyGameStore.Application.Interfaces.IStoresRepository;

namespace AP.MyGameStore.Infrastructure.Repositories
{
    public class StoresRepository : GenericRepository<Store>,  IStoresRepository
    {
        private readonly MyGameStoreContext context;

        public StoresRepository(MyGameStoreContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Store>> GetAll(string? nameFilter = null, IStoresRepository.SortBy? sortBy = null, int pageNumber = 1, int pageLength = 10)
        {
            var result = new PagedResult<Store>();
            result.PageNumber = pageNumber;
            result.PageSize = pageLength;

            //Starting to build query taking into account the parameters given
            //As long as we work with IQueryable the actual query is not performed yet (deferred execution)
            IQueryable<Store> query = context.Stores;

            //Also fill in the total number of items already.
            result.TotalRecordCount = query.Count();

            //filtering first
            if (nameFilter != null)
                query = query.Where(s => s.Name.Contains(nameFilter));

            //fill in the filtered count (paging will not change that)
            result.FilteredRecordCount = query.Count();
            //now we can calculate the total number of pages (for the filtered set of results)
            result.TotalNumberOfPages = (int)Math.Ceiling((double)result.FilteredRecordCount / result.PageSize);

            //Then sorting (if required)
            switch (sortBy)
            {
                case SortBy.ByNameAscending:
                    query = query.OrderBy(s => s.Name);
                    break;
                case SortBy.ByNameDescending:
                    query = query.OrderByDescending(s => s.Name);
                    break;
                case SortBy.ByZipCodeAscending:
                    query = query.OrderBy(s => s.Zipcode);
                    break;
                case SortBy.ByZipcodeDescending:
                    query = query.OrderByDescending(s => s.Zipcode);
                    break;
                default:
                    break;
            }
            //paging must be the last step !
            query = query.Skip((pageNumber - 1) * pageLength).Take(pageLength);

            //here the actual query for filtered stores with paging is performed on the DB !
            result.Data = await query.ToListAsync();

            return result.Data;
        }


        public Store GetByName(string name)
        {
            return context.Stores.FirstOrDefault(s => s.Name == name);
        }


    }
}
