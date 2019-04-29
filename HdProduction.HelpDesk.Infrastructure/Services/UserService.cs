using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using HdProduction.HelpDesk.Domain.Exceptions;
using HdProduction.HelpDesk.Domain.Services;

namespace HdProduction.HelpDesk.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateAsync(string firstName, string lastName, string email, string pwdHash)
        {
            var pwdHelper = SecurityHelper.Create();
            var user = new User(email, firstName, lastName, "",
                pwdHelper.CreateSaltedPassword(pwdHash), pwdHelper.Salt);
            _userRepository.Add(user);
            await _userRepository.SaveAsync();
            return user;
        }

        public async Task<User> Find(long id)
        {
            return await _userRepository.FindAsync(id) 
                   ?? throw new EntityNotFoundException("User with such id not found.");
        }
    }
}