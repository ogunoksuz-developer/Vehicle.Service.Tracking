using Car.Service.Web.Business.Abstract;
using Car.Service.Web.Data.Abstract;
using Car.Service.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Car.Service.Web.Business.Concrete
{

    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            await _userRepository.AddAsync(user);
        }

        public void DeleteUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _userRepository.Delete(user);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public void UpdateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _userRepository.Update(user);
        }

        public async Task<IEnumerable<User>> SearchUsersAsync(Expression<Func<User, bool>> predicate)
        {

            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return await _userRepository.SearchAsync(predicate).ToListAsync();

        }

    }


}
