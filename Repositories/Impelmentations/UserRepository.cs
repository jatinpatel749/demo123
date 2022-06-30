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
