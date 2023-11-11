using WebApi.Data.Models;
using WebApi.ViewModels;

namespace WebApi.Repository
{
    public interface IUserRepository
    {
        List<UserVM> GetAllUsers();
        UserVM GetUserById(int id);
        Task<UserModel> Add(UserModel user);
        Task UpdateUser(int id,UserModel user);
        void DeleteUser(int userId);
    }
}
