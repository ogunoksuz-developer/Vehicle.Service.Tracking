using Car.Service.Web.Business.Abstract;
using Car.Service.Web.Data.Abstract;
using Car.Service.Web.Data.Concrete;
using Car.Service.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Service.Web.Business.Concrete
{
    public class ServiceEntryService: IServiceEntryService
    {
        private readonly IRepository<ServiceEntry> _serviceEntryRepository;

        public ServiceEntryService(IRepository<ServiceEntry> serviceEntryRepository)
        {
            _serviceEntryRepository = serviceEntryRepository;
        }

        public async Task<ServiceEntry> GetServiceEntryByIdAsync(int id)
        {
            return await _serviceEntryRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ServiceEntry>> GetAllServiceEntriesAsync()
        {
            return await _serviceEntryRepository.GetAllAsync();
        }

        public async Task CreateServiceEntryAsync(ServiceEntry serviceEntry)
        {
            await _serviceEntryRepository.AddAsync(serviceEntry);
            await _serviceEntryRepository.SaveChangesAsync();
        }

        public void UpdateServiceEntry(ServiceEntry serviceEntry)
        {
            _serviceEntryRepository.Update(serviceEntry);
             _serviceEntryRepository.SaveChangesAsync().Wait();
        }

        public void DeleteServiceEntry(ServiceEntry serviceEntry)
        {
            _serviceEntryRepository.Delete(serviceEntry);
        }

        public async Task<IEnumerable<ServiceEntry>> GetAllServiceEntriesFromStoreProcedureAsync()
        {
            return await _serviceEntryRepository.ExecuteStoredProcedureAsync("EXEC GetTopServiceEntries");
        }
    }
}
