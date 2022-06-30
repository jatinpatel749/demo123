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
    public class UserController : ApiController
    {
        private IUserRepository _IUserRepository;
        public UserController()
        {
            _IUserRepository = new UserRepository();
        }

        [HttpPost]
        public IHttpActionResult CreateUser(UserModel model)
        {
            UserRepository _userRepository = new UserRepository();

            _IUserRepository.CreateUserNew(model);


            bool result = true; //_authService.CreateUser(user, model.Role);
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
