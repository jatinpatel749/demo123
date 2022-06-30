using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using Repositories.Impelmentations;
using Repositories.Interfaces;

namespace CarAPI.Controllers
{
    public class LoginController : ApiController
    {
        private IUserRepository _IUserRepository;
        public LoginController()
        {
            _IUserRepository = new UserRepository();
        }


        [Route("api/Login/CreateUser")]
        [HttpPost]
        public IHttpActionResult CreateUser(UserModel model)
        {
            try
            {
                UserRepository _userRepository = new UserRepository();

                bool result = _IUserRepository.CreateUserNew(model);


                //bool result = true; //_authService.CreateUser(user, model.Role);
                if (result)
                {
                    //return StatusCode(HttpStatusCode.Status201Created);
                    return StatusCode(HttpStatusCode.Created);
                }
                else
                {
                    //return StatusCode(StatusCodes.Status400BadRequest);
                    return StatusCode(HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.BadRequest);
               
                
            }
        }
        [Route("api/Login/ValidateUser")]
        [HttpPost]
        public UserModel ValidateUser(LoginModel model)
        {
            //if (ModelState.IsValid)
            //{
            return _IUserRepository.ValidateUser(model.Username, model.Password);
            //}
            //else
            //{
            //    return StatusCode(HttpStatusCode.BadRequest);
            //}
        }
    }
}
