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
    public class UserController : Controller
    {
        HttpClient client;
        Uri baseAddress;
        private IUserRepository _IUserRepository;

        public UserController()
        {
            _IUserRepository = new UserRepository();
            baseAddress = new Uri(ConfigurationManager.AppSettings["ApiAddress"].ToString());
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            ViewBag.ErroMsg = null;

            if (ModelState.IsValid)
            {
                string strData = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(strData, Encoding.UTF8, "application/json");
                //var response1 = client.PostAsync(baseAddress + "/CreateUser").Result;
                var response = client.PostAsync(client.BaseAddress + "/Login/ValidateUser", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    if (response.Content.ReadAsStringAsync().Result != "null")
                    {
                        // return RedirectToAction("Index");
                        var dataAnswer = response.Content.ReadAsStringAsync().Result;
                        //  model = JsonSerializer.Deserialize<LoginModel>("");

                        //JObject studentObj = JObject.Parse(dataAnswer);
                        //var u = JsonSerializer.Deserialize<LoginModel>(dataAnswer, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        UserModel UserResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(dataAnswer);
                        Session["UserModel"] = UserResponse;
                        return RedirectToAction("Index", "Vehicle", new { area = "" });
                    }
                    else
                    {
                        ViewBag.ErroMsg = "Invalid Email-Id and Password";
                    }
                }
                else
                {
                    ViewBag.ErroMsg = "Invalid Email-Id and Password";
                }


            }
            else
            {
                ViewBag.ErroMsg = "Invalid Email-Id and Password";
            }

            return View();
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            Session["UserModel"] = null;
            return RedirectToAction("Index", "User", new { area = "" });
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            try
            {

                string strData = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(strData, Encoding.UTF8, "application/json");
                var response = client.PostAsync(client.BaseAddress + "/Login/CreateUser", content).Result;
                if (response.ReasonPhrase == "Bad Request")
                {
                    ViewBag.ErroMsg = "User Already Exists.";
                }
                else if (response.IsSuccessStatusCode)
                {
                    if (response.Content.ReadAsStringAsync().Result != "null")
                    {
                        ViewBag.ErroMsg = "User Created Successfully.";
                        TempData["SuccessMessage"] = "User Created Successfully.";

                       // return RedirectToAction("Index", "User", new { area = "" });
                    }
                    else
                    {
                        ViewBag.ErroMsg = "Error In Inserting.";
                    }
                }
                else
                {
                    ViewBag.ErroMsg = "Error In Inserting.";
                }
                
            }
            catch (Exception ex)
            {
                ViewBag.ErroMsg = ex.Message;
                // throw;
            }
            return View();
        }
    }
}