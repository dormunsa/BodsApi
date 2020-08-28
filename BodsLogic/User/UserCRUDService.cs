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

        // get user by user guid
        public async Task<User> GetByUserGuid(string userGuid)
        {
            return await userData.GetByUserGuid(userGuid);

        }
        // get user by user id
        public async Task<User> GetByUserId(int userId)
        {
            return await userData.GetByUserId(userId);
        }
        // get user by user name
        public async Task<User> GetByUserName(string guid)
        {
            return await userData.GetByUserName(guid);
        }
        // insert user 
        public async Task<bool> InsertUser(User user)
        {
            return await userData.InsertUser(user);
        }
        // update user
        public async Task<bool> UpdateUser(UpdateUserDetails user)
        {
            return await userData.UpdateUser(user);
        }
        // update user password
        public async Task<bool> UpdatePassword(string hashedPassword, string UserGuid, byte[] saltPassword)
        {
            return await userData.UpdatePassword(hashedPassword , UserGuid , saltPassword);
        }
        // update IsSetPasswordAllowed value 
        public async Task<bool> ResetPassword(int UserId)
        {
            return await userData.ResetPassword(UserId);
        }
        // update IsAdmin to true
        public async Task<bool> SetUserAsAdmin(int UserId)
        {
            return await userData.SetUserAsAdmin(UserId);
        }
        // delete user
        public async Task<bool> DeleteUser(int UserId)
        {
            return await userData.DeleteUser(UserId);
        }
        // get users by admin id
        public async Task<List<User>> GetAllChildUsers(int adminId)
        {
            return await userData.GetAllChildUsers(adminId);
        }
    }
}
