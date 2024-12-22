using AP.MyGameStore.Application.Interfaces;
using AP.MyGameStore.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.MyGameStore.Infrastructure.UoW
{
    public class UnitofWork : IUnitofWork
    {
        private readonly MyGameStoreContext ctxt;
        private readonly IPeopleRepository peopleRepo;
        private readonly IStoresRepository storesRepo;

        public UnitofWork(MyGameStoreContext ctxt, IPeopleRepository peopleRepo, IStoresRepository storesRepo)
        {
            this.ctxt = ctxt;
            this.peopleRepo = peopleRepo;
            this.storesRepo = storesRepo;
        }
        public IPeopleRepository PeopleRepository => peopleRepo;

        public IStoresRepository StoresRepository => storesRepo;

        public async Task Commit()
        {
            await ctxt.SaveChangesAsync();
        }
    }
}
