using Models;
using Newtonsoft.Json;
using Repositories.Impelmentations;
using Repositories.Interfaces;
using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        HttpClient client;
        Uri baseAddress;
        // IConfiguration _configuration;


        private IUserRepository _IUserRepository;

        public HomeController()
        {
            _IUserRepository = new UserRepository();
            baseAddress = new Uri(ConfigurationManager.AppSettings["ApiAddress"].ToString());
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }


        public ActionResult Index()
        {
            //UserModel _user = new UserModel();
            //_user.Name = "jatin";
            //_user.EmailId = "jatinpatel749@gmail.com";
            //_user.Password = "123";
            //_user.MobileNo = "9275100801";

            //string strData = JsonConvert.SerializeObject(_user);
            //StringContent content = new StringContent(strData, Encoding.UTF8, "application/json");
            //var response = client.PostAsync(client.BaseAddress + "/Login/CreateUser", content).Result;
            //if (response.IsSuccessStatusCode)
            //{
            //   // return RedirectToAction("Index");
            //}

          
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

//client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "Token Here");