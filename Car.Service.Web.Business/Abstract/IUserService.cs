using Car.Service.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Car.Service.Web.Business.Abstract
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int id);

        Task<IEnumerable<User>> GetAllUsersAsync();

        Task CreateUserAsync(User user);

        void UpdateUser(User user);

        void DeleteUser(User user);

        Task<IEnumerable<User>> SearchUsersAsync(Expression<Func<User, bool>> predicate);


    }
}
