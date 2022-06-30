using Models;
using System.Web.Http;

namespace CarAPI.Controllers
{
    public class UserLoginDataController : ApiController
    {
        [Route("api/UserLoginData/PostCreateUser")]
        [HttpPost]
        public IHttpActionResult PostCreateUser(UserModel model)
        {
            return Ok(model);
        }

        [Route("api/UserLoginData/PostValidateUser")]
        [HttpPost]
        public IHttpActionResult PostValidateUser(LoginModel model)
        {
            return Ok(model);
        }
        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
