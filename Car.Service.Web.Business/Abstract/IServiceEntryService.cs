using Car.Service.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Service.Web.Business.Abstract
{
    public interface IServiceEntryService
    {
        Task<ServiceEntry> GetServiceEntryByIdAsync(int id);

        Task<IEnumerable<ServiceEntry>> GetAllServiceEntriesAsync();

        Task<IEnumerable<ServiceEntry>> GetAllServiceEntriesFromStoreProcedureAsync();

        Task CreateServiceEntryAsync(ServiceEntry serviceEntry);

        void UpdateServiceEntry(ServiceEntry serviceEntry);

        void DeleteServiceEntry(ServiceEntry serviceEntry);
    }
}
