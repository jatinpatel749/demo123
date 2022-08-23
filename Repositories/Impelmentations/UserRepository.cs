using Models;
using MyEntity;
using Repositories.Interfaces;
using System;
using System.Linq;

namespace Repositories.Impelmentations
{
    public class UserRepository : IUserRepository
    {
        private readonly dbChintanEntities _db;// =new dbChintanEntities();
        public UserRepository(dbChintanEntities db)
        {
            _db = db;
        }
        public UserRepository()
        {
            _db = new dbChintanEntities();
        }

        public bool CreateUserNew(UserModel user)
        {
            var userData = _db.tblLogins.Where(u => u.EmailId.ToLower() == user.EmailId.ToLower()).FirstOrDefault();
            if (userData == null)
            {
                tblLogin _tblLogin = new tblLogin();
                _tblLogin.EmailId = user.EmailId;
                _tblLogin.Password = user.Password;
                _tblLogin.Name = user.Name;
                _tblLogin.MobileNo = user.MobileNo;


                _db.tblLogins.Add(_tblLogin);
                _db.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("User Already Exists.");
            }

            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private string GenerateJSONWebToken(UserModel userInfo)
        {
            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //var claims = new[] {
            //                 new Claim(JwtRegisteredClaimNames.Sub, userInfo.Name),
            //                 new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
            //                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            //                 };

            //var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            //                                _config["Jwt:Audience"],
            //                                claims,
            //                                expires: DateTime.UtcNow.AddMinutes(60), //token expiry minutes
            //                                signingCredentials: credentials);

            //return new JwtSecurityTokenHandler().WriteToken(token);
            return "";
        }


        public UserModel ValidateUser(string Email, string Password)
        {
            var user = _db.tblLogins.Where(u => u.EmailId.ToLower() == Email.ToLower() && u.Password == Password).FirstOrDefault();
            if (user != null)
            {
                UserModel _UserModel = new UserModel();
                _UserModel.UserId = user.UserId;
                _UserModel.EmailId = user.EmailId;
                _UserModel.Password = user.Password;
                _UserModel.Name = user.Name;
                _UserModel.MobileNo = user.MobileNo;

                return _UserModel;
            }
            return null;
        }
    }
}
