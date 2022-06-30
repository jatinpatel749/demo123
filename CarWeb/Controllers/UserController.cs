using Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Web.Mvc;
using System.Net.Http;
using System.Text;

namespace CarWeb.Controllers
{
    public class UserController : Controller
    {
        private object client;

        // GET: User
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(LoginModel model)
        {

            string strData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(strData, Encoding.UTF8, "application/json");
            //var response1 = client.PostAsync(baseAddress + "/CreateUser").Result;
            //var response = client.PostAsync(client.BaseAddress + "/Login/CreateUser", content).Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    // return RedirectToAction("Index");
            //}


            return View();
        }
    }
}