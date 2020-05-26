using BodsEntity;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace BodsData
{
    public class UserData
    {
        public async Task<User> GetByUserGuid(string userGuid)
        {
            DynamicParameters _params = new DynamicParameters();

            _params.Add("@UserGuid", userGuid);

            string sql = " SELECT * FROM  " + bods.bods.Tuser
                            + " WHERE " + bods.bods.Tuser.FUserGuid.Cn + " =@UserGuid";

            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return (await conn.QueryAsync<User>(sql, _params)).ToList().FirstOrDefault();
            }

        }

        public async Task<User> GetByUserName(string userName)
        {
            DynamicParameters _params = new DynamicParameters();

            _params.Add("@UserName", userName);

            string sql = " SELECT * FROM  " + bods.bods.Tuser
                            + " WHERE " + bods.bods.Tuser.FUserName.Cn + " =@UserName";

            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return (await conn.QueryAsync<User>(sql, _params)).ToList().FirstOrDefault();
            }

        }

        public async Task<User> GetByUserId(int userId)
        {
            DynamicParameters _params = new DynamicParameters();

            _params.Add("@UserId", userId);

            string sql = " SELECT * FROM  " + bods.bods.Tuser
                            + " WHERE " + bods.bods.Tuser.FUserId.Cn + " =@UserId";


            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return (await conn.QueryAsync<User>(sql, _params)).ToList().FirstOrDefault();
            }

        }

        public async Task<bool> InsertUser(User user)
        {
            DynamicParameters _params = new DynamicParameters();
            _params.Add("@AdminId", user.AdminId);
            _params.Add("@CreationDate", user.CreationDate);
            _params.Add("@FirstName", user.FirstName);
            _params.Add("@LastName", user.LastName);
            _params.Add("@UserName", user.UserName);
            _params.Add("@IsAdmin", user.IsAdmin);
            _params.Add("@IsSetPasswordAllowed", user.IsSetPasswordAllowed);
            _params.Add("@UserGuid", user.UserGuid);
            _params.Add("@Phone", user.Phone);
            _params.Add("@SlackWebHook", user.SlackWebHook);

            string sql = " INSERT INTO " + bods.bods.Tuser
                                       + "    (" + bods.bods.Tuser.FAdminId.Cn
                                       + "    ," + bods.bods.Tuser.FCreationDate.Cn
                                       + "    ," + bods.bods.Tuser.FFirstName.Cn
                                       + "    ," + bods.bods.Tuser.FLastName.Cn
                                       + "    ," + bods.bods.Tuser.FUserName.Cn
                                       + "    ," + bods.bods.Tuser.FIsAdmin.Cn
                                       + "    ," + bods.bods.Tuser.FIsSetPasswordAllowed.Cn
                                       + "    ," + bods.bods.Tuser.FUserGuid.Cn
                                       + "    ," + bods.bods.Tuser.FPhone.Cn
                                       + "    ," + bods.bods.Tuser.FSlackWebHook.Cn
                                       + ")"
                                     + " VALUES"
                                     + " (@AdminId"
                                     + " ,@CreationDate"
                                     + " ,@FirstName"
                                     + " ,@LastName"
                                     + " ,@UserName"
                                     + " ,@IsAdmin"
                                     + " ,@IsSetPasswordAllowed"
                                     + " ,@UserGuid"
                                     + " ,@Phone"
                                     + " ,@SlackWebHook"
                                     + ");";

            
            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return Convert.ToBoolean(await conn.ExecuteAsync(sql, _params));
            }

        }
        public async Task<bool> UpdateUser(UpdateUserDetails user)
        {
            DynamicParameters _params = new DynamicParameters();
            _params.Add("@FirstName", user.FirstName);
            _params.Add("@LastName", user.LastName);
            _params.Add("@UserName", user.UserName);
            _params.Add("@UserId", user.UserId);
            _params.Add("@Phone", user.Phone);
            _params.Add("@SlackWebHook", user.SlackWebHook);

            string sql = " UPDATE " + bods.bods.Tuser + " SET "
                                       + bods.bods.Tuser.FFirstName.Cn + " =@FirstName, "
                                       + bods.bods.Tuser.FLastName.Cn + " =@LastName, "
                                       + bods.bods.Tuser.FPhone.Cn + " =@Phone, "
                                       + bods.bods.Tuser.FSlackWebHook.Cn + " =@SlackWebHook, "
                                       + bods.bods.Tuser.FUserName.Cn + " =@UserName "
                                       +" WHERE " + bods.bods.Tuser.FUserId.Cn + " =@UserId ";

            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return Convert.ToBoolean(await conn.ExecuteAsync(sql, _params));
            }

        }

       
        public async Task<bool> UpdatePassword(string hashedPassword, string UserGuid, byte[] saltPassword)
        {
            DynamicParameters _params = new DynamicParameters();

            _params.Add("@HashedPassword", hashedPassword);
            _params.Add("@Guid", UserGuid);
            _params.Add("@SaltPassword", saltPassword);
            _params.Add("@IsSetPasswordAllowed", false);


            string sql = " Update " +  bods.bods.Tuser + " SET "
                                       + bods.bods.Tuser.FHashedPassword.Cn + " =@HashedPassword, "
                                       + bods.bods.Tuser.FSaltPassword.Cn + " =@SaltPassword, "
                                       + bods.bods.Tuser.FIsSetPasswordAllowed.Cn + " =@IsSetPasswordAllowed"
                                       + "  WHERE " + bods.bods.Tuser.FUserGuid.Cn + " =@Guid;";

            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return Convert.ToBoolean(await conn.ExecuteAsync(sql, _params));
            }
        }

        public async Task<bool> ResetPassword(int UserId)
        {
            DynamicParameters _params = new DynamicParameters();
            _params.Add("@UserId", UserId);
            _params.Add("@IsSetPasswordAllowed", true);

            string sql = " Update " + bods.bods.Tuser + " SET " 
                                       + bods.bods.Tuser.FIsSetPasswordAllowed.Cn + " =@IsSetPasswordAllowed"
                                       + "  WHERE " + bods.bods.Tuser.FUserId.Cn + " =@UserId;";

            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return Convert.ToBoolean(await conn.ExecuteAsync(sql, _params));
            }
        }

        public async Task<bool> SetUserAsAdmin(int UserId)
        {
            DynamicParameters _params = new DynamicParameters();
            _params.Add("@UserId", UserId);
            _params.Add("@IsAdmin", true);

            string sql = " Update " + bods.bods.Tuser + " SET "
                                       + bods.bods.Tuser.FIsAdmin.Cn + " =@IsAdmin"
                                       + "  WHERE " + bods.bods.Tuser.FUserId.Cn + " =@UserId;";

            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return Convert.ToBoolean(await conn.ExecuteAsync(sql, _params));
            }
        }
        public async Task<bool> DeleteUser(int UserId)
        {
            DynamicParameters _params = new DynamicParameters();
            _params.Add("@UserId", UserId);

            string sql = " DELETE FROM " + bods.bods.Tuser 
                                       + "  WHERE " + bods.bods.Tuser.FUserId.Cn + " =@UserId;";

            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return Convert.ToBoolean(await conn.ExecuteAsync(sql, _params));
            }
        }
        public async Task<List<User>> GetAllChildUsers(int adminId)
        {
            DynamicParameters _params = new DynamicParameters();
            _params.Add("@AdminId", adminId);

            string sql = " SELECT * FROM " + bods.bods.Tuser
                                       + "  WHERE " + bods.bods.Tuser.FAdminId.Cn + " =@AdminId;";

            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return (await conn.QueryAsync<User>(sql, _params)).ToList();
            }
        }
    }
}
