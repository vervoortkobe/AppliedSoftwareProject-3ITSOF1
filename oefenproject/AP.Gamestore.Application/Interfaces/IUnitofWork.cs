using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.MyGameStore.Application.Interfaces
{
    public interface IUnitofWork
    {
        public IPeopleRepository PeopleRepository { get; }
        public IStoresRepository StoresRepository { get; }
        Task Commit();
    }
}
