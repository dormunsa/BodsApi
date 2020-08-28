using BodsEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BodsLogic
{
    public class UserLogic
    {
        public UserLogic()
        {
            this.userCRUDService = new UserCRUDService();
            Response = new BaseResponse();
            loginResponse = null;
            cameraLogic = new CameraLogic();
            userCameraLogic = new UserCameraLogic();
        }

        public UserCRUDService userCRUDService { get; set; }
        public BaseResponse Response { get; set; }
        public LoginResponse loginResponse { get; set; }
        public UserCameraLogic userCameraLogic { get; set; }
        public CameraLogic cameraLogic { get; set; }
        public async Task Login(string guid, LoginRequest request = null)
        {
            // validate request values
            if ((string.IsNullOrEmpty(request?.UserName) || string.IsNullOrEmpty(request?.Password)) && string.IsNullOrEmpty(guid))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "Bad Request";
                return;
            }
            // check if login by guid or by credentials
            if (string.IsNullOrEmpty(guid))
            {
                // get user by user name
                User user = await userCRUDService.GetByUserName(request?.UserName);
                if (user == null)
                {
                    Response.IsSuccessful = false;
                    Response.ErrorMessage = "UserName is Incorrect.";
                    return;
                }
                // check hashed password by credentails
                string requestPassword = CryptographyHelper.HashPassword(request.Password, user.SaltPassword);

                if (user.HashedPassword != requestPassword)
                {
                    Response.IsSuccessful = false;
                    Response.ErrorMessage = "UserName/Password is Incorrect.";
                    return;
                }
                // init login response
                Response.IsSuccessful = true;
                loginResponse = new LoginResponse(user.UserId, user.UserName, user.IsAdmin, user.AdminId, user.IsSetPasswordAllowed, user.UserGuid);
                return;
            }

            else
            {
                // get user by guid
                User user = await userCRUDService.GetByUserGuid(guid);
                if (user == null)
                {
                    Response.IsSuccessful = false;
                    Response.ErrorMessage = "guid is Incorrect.";
                    return;
                }
                // init login resposne
                Response.IsSuccessful = true;
                loginResponse = new LoginResponse(user.UserId, user.UserName, user.IsAdmin, user.AdminId, user.IsSetPasswordAllowed, user.UserGuid);
                return;
            }
        }

        public async Task<bool> UpdatePortalUserPassword(string newPassword, string guid)
        {
            // validate guid
            if (string.IsNullOrEmpty(guid))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "You must provide guid";
                return Response.IsSuccessful;
            }
            // validate password
            if ( string.IsNullOrEmpty(newPassword))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "you must provide user name or password";
                return Response.IsSuccessful;
            }
            // get user by guid
            User user = await userCRUDService.GetByUserGuid(guid);
            if (user == null || user?.IsSetPasswordAllowed == false )
                return false;

            //get hash password
            byte[] salt = CryptographyHelper.GenerateRandomSalt();

            string hashedPassword = CryptographyHelper.HashPassword(newPassword, salt);

            //update password
            return await userCRUDService.UpdatePassword(hashedPassword, guid, salt);
        }

        public async Task ResetPassword(string usreName, string guid)
        {
            Response.IsSuccessful = true;
            // validate request
            if (string.IsNullOrEmpty(usreName) || string.IsNullOrEmpty(guid))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "you must provide user name and guid ";
                return;
            }
            // get user by guid
            User user = await userCRUDService.GetByUserGuid(guid);
            if (user == null || user?.UserName != usreName)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "user is not exist or user name is not correct";
                return;
            }
            // reset password by user id
            if (!await userCRUDService.ResetPassword(user.UserId))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "Cannot Reset Password";
                return;
            }
        }

        public async Task SetUserAsAdmin(int usreId, string guid)
        {
            Response.IsSuccessful = true;
            // validate request
            if (usreId == 0 || string.IsNullOrEmpty(guid))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "you must provide user Id and guid ";
                return;
            }
            // get user by guid
            User user = await userCRUDService.GetByUserGuid(guid);
            // get user by user id request value
            User userToSetAsAdmin = await userCRUDService.GetByUserId(usreId);
            if (user == null || userToSetAsAdmin == null || userToSetAsAdmin?.AdminId != user?.UserId)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "Ilegale operation";
                return;
            }
            // set user by as admin 
            if (!await userCRUDService.SetUserAsAdmin(userToSetAsAdmin.UserId))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "Cannot Set  as admin";
                return;
            }
        }
        public async Task UpdateUserDetails(UpdateUserDetails userDetails, string guid)
        {
            Response.IsSuccessful = true;
            // validate request
            if (userDetails.UserId == 0 || string.IsNullOrEmpty(guid))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "you must provide user Id and guid ";
                return;
            }
            // get user by guid
            User user = await userCRUDService.GetByUserGuid(guid);
            // get user by user id request value
            User userToUpdate = await userCRUDService.GetByUserId(userDetails.UserId);

            if (user == null || userToUpdate == null || user?.UserId != userToUpdate?.AdminId)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "Ilegale operation";
                return;
            }
            //update user
            if (!await userCRUDService.UpdateUser(userDetails))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "Cannot Update User";
                return;
            }
        }
        public async Task DeleteUser(DeleteRequest request, string guid)
        {
            Response.IsSuccessful = true;
            // validate request
            if (request.UserId == 0 || string.IsNullOrEmpty(guid))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "you must provide user Id and guid ";
                return;
            }
            // get user by guid
            User user = await userCRUDService.GetByUserGuid(guid);
            // get user by user id request value
            User userToDelete = await userCRUDService.GetByUserId(request.UserId);

            if (user == null || userToDelete == null || user?.UserId != userToDelete?.AdminId)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "Ilegale operation";
                return;
            }
            // delete user
            if (!await userCRUDService.DeleteUser(userToDelete.UserId))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "Cannot Delete User";
                return;
            }
        }
        public async Task InsertUser(InsertUser request, string guid)
        {
            Response.IsSuccessful = true;
            // validate request
            if (request.AdminId == 0 || string.IsNullOrEmpty(guid))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "you must provide Admin Id and guid ";
                return;
            }
            // get user by guid and validate permisions
            User user = await userCRUDService.GetByUserGuid(guid);

            if (user == null ||  user?.UserId != request.AdminId)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "Ilegale operation";
                return;
            }


            User userToCreate = new User()
            {
                UserId = 0,
                UserName = request.UserName,
                HashedPassword = null,
                UserGuid = Guid.NewGuid().ToString("N"),
                IsSetPasswordAllowed = true,
                SaltPassword = null,
                IsAdmin = request.IsAdmin,
                CreationDate = DateTime.UtcNow,
                FirstName = request.FirstName,
                LastName = request.LastName,
                AdminId= user.UserId,
                Phone = request.Phone,
                SlackWebHook = request.SlackWebHook
            };

            //insert user
            if (!await userCRUDService.InsertUser(userToCreate))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "Cannot Insert User";
                return;
            }
        }
        public async Task<List<UserResponse>> GetAllChildUsers(int userId, string guid)
        {
            // validate request
            if (userId == 0 || string.IsNullOrEmpty(guid))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "you must provide Admin Id and guid ";
                return null;
            }
            // get user by guid and validate permisions
            User user = await userCRUDService.GetByUserGuid(guid);

            if (user == null || user?.UserId != userId)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "Ilegale operation";
                return null;
            }
            List<User> users =  await userCRUDService.GetAllChildUsers(user.UserId);
            List<UserResponse> userResponses = new List<UserResponse>();

            //read all users that asigend to this user
            if (users.Count > 0)
            {
                foreach (User indexUser in users)
                {
                    userResponses.Add(new UserResponse(indexUser.UserId, indexUser.UserName, indexUser.IsAdmin, indexUser.FirstName, indexUser.LastName , indexUser.Phone , indexUser.SlackWebHook));
                }

            }
            return userResponses;
        }
        public async Task<string> GetPhoneByCameraId(int cameraId)
        {
            // validate request
            if (cameraId == 0 )
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "you must provide Camera Id  ";
                return null;
            }
            // get user camera by camera id 
            UserCamera userCamera = await userCameraLogic.GetCameraById(cameraId);

            if (userCamera == null || userCamera?.UserId == 0)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "Ilegale operation";
                return null;
            }

            // get user  by user id 
            User user = await userCRUDService.GetByUserId(userCamera.UserId);
            if (user == null || user.Phone ==null)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "Ilegale operation";
                return null;

            }
            return user.Phone;
        }
        public async Task<string> GetHookByCameraId(int cameraId)
        {
            // validate request
            if (cameraId == 0)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "you must provide Camera Id  ";
                return null;
            }
            // get user camera by camera id 
            UserCamera userCamera = await userCameraLogic.GetCameraById(cameraId);

            if (userCamera == null || userCamera?.UserId == 0)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "Ilegale operation";
                return null;
            }
            // get user  by user id 
            User user = await userCRUDService.GetByUserId(userCamera.UserId);
            if (user == null || user.SlackWebHook == null)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "Ilegale operation";
                return null;

            }
            return user.SlackWebHook;
        }

    }
}
