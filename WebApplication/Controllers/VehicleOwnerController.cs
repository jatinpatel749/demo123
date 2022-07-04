using Models;
using Newtonsoft.Json;
using Repositories.Impelmentations;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;
using WebApplication.CustomeAttributes;

namespace WebApplication.Controllers
{
    [SessionTimeout]
    public class VehicleOwnerController : Controller
    {
        HttpClient client;
        Uri baseAddress;
        private IVehicleOwnerDetailsRepository _IVehicleOwnerDetailsRepository;

        public VehicleOwnerController()
        {
            _IVehicleOwnerDetailsRepository = new VehicleOwnerDetailsRepository();
            baseAddress = new Uri(ConfigurationManager.AppSettings["ApiAddress"].ToString());
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }


        // GET: VehicleOwner
        public ActionResult Index()
        {

            IEnumerable<VehicleOwnerDetailsModel> model = new List<VehicleOwnerDetailsModel>();
            var response = client.GetAsync(baseAddress + "/VehicleOwnerDetail/GelAllVehicleOwnerDetails").Result;
            if (response.IsSuccessStatusCode)
            {
                var data =      response.Content.ReadAsStringAsync().Result;

                //UserModel UserResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(data);
                model = JsonConvert.DeserializeObject<IEnumerable<VehicleOwnerDetailsModel>>(data);
            }
            return View(model);

            //return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VehicleOwnerDetailsModel model)
        {

            string strData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(strData, Encoding.UTF8, "application/json");
            var response = client.PostAsync(client.BaseAddress + "/VehicleOwnerDetail/CreateVehicleOwnerDetails", content).Result;
            if (response.IsSuccessStatusCode)
            {
                if (response.Content.ReadAsStringAsync().Result != "null")
                {
                    TempData["SuccessMessage"] = "Vehicle Owner Created Successfully.";
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
            return View();
        }


        public ActionResult Edit(int id)
        {
            VehicleOwnerDetailsModel model = new VehicleOwnerDetailsModel();
            var response = client.GetAsync(baseAddress + "/VehicleOwnerDetail/GelVehicleOwnerDetailsByOwnerId?OwnerId=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                //UserModel UserResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(data);
                model = JsonConvert.DeserializeObject<VehicleOwnerDetailsModel>(data);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(VehicleOwnerDetailsModel model)
        {
            string strData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(strData, Encoding.UTF8, "application/json");
            var response = client.PostAsync(client.BaseAddress + "/VehicleOwnerDetail/UpdateVehicleOwnerDetails", content).Result;
            if (response.IsSuccessStatusCode)
            {
                if (response.Content.ReadAsStringAsync().Result != "null")
                {
                    TempData["SuccessMessage"] = "Vehicle Owner Updated Successfully.";
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
            return View();
        }
    }
}