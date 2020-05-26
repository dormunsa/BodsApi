using BodsData;
using BodsEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BodsLogic
{
    public class UserCRUDService
    {
        public UserCRUDService()
        {
            this.userData = new UserData();
        }

        public UserData userData { get; set; }

        public async Task<User> GetByUserGuid(string userGuid)
        {
            return await userData.GetByUserGuid(userGuid);

        }

        public async Task<User> GetByUserId(int userId)
        {
            return await userData.GetByUserId(userId);
        }

        public async Task<User> GetByUserName(string guid)
        {
            return await userData.GetByUserName(guid);
        }

        public async Task<bool> InsertUser(User user)
        {
            return await userData.InsertUser(user);
        }

        public async Task<bool> UpdateUser(UpdateUserDetails user)
        {
            return await userData.UpdateUser(user);
        }
        public async Task<bool> UpdatePassword(string hashedPassword, string UserGuid, byte[] saltPassword)
        {
            return await userData.UpdatePassword(hashedPassword , UserGuid , saltPassword);
        }

        public async Task<bool> ResetPassword(int UserId)
        {
            return await userData.ResetPassword(UserId);
        }

        public async Task<bool> SetUserAsAdmin(int UserId)
        {
            return await userData.SetUserAsAdmin(UserId);
        }

        public async Task<bool> DeleteUser(int UserId)
        {
            return await userData.DeleteUser(UserId);
        }
        public async Task<List<User>> GetAllChildUsers(int adminId)
        {
            return await userData.GetAllChildUsers(adminId);
        }
    }
}
