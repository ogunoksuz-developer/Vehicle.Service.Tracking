using Car.Service.Web.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Service.Web.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ServiceVehicleContext _context;

        public UnitOfWork(ServiceVehicleContext context)
        {
            _context = context;
        }

        // Diğer metotlar ve repository'ler burada tanımlanır

        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepository<T> Repository<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
