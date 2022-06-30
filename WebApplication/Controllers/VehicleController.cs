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
    public class VehicleController : Controller
    {
        HttpClient client;
        Uri baseAddress;
        private IVehicleOwnerDetailsRepository _IVehicleOwnerDetailsRepository;
        private IVehicleDetailsRepository _IVehicleDetailsRepository;

        public VehicleController()
        {
            _IVehicleOwnerDetailsRepository = new VehicleOwnerDetailsRepository();
            _IVehicleDetailsRepository = new VehicleDetailsRepository();

            baseAddress = new Uri(ConfigurationManager.AppSettings["ApiAddress"].ToString());
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: Vehicle
        public ActionResult Index()
        {
            UserModel _UserModel = new UserModel();
            _UserModel = (UserModel)Session["UserModel"];

            IEnumerable<VehicleDetailsModel> model = new List<VehicleDetailsModel>();
            var response = client.GetAsync(baseAddress + "/VehicleDetails/GelAllVehicleDetailsByUserId?UserId=" + _UserModel.UserId).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                //UserModel UserResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(data);
                model = JsonConvert.DeserializeObject<IEnumerable<VehicleDetailsModel>>(data);
            }
            return View(model);
        }

        public ActionResult Details(int id)
        {
            VehicleDetailsModel model = new VehicleDetailsModel();
            var response = client.GetAsync(baseAddress + "/VehicleDetails/GelVehicleDetailsByVehicleId?VehicleId=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                //UserModel UserResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(data);
                model = JsonConvert.DeserializeObject<VehicleDetailsModel>(data);
            }
            return View(model);

        }
        public ActionResult Delete(int id)
        {
            var response = client.DeleteAsync(baseAddress + "/VehicleDetails/DeleteVehicleDetailsByVehicleId?VehicleId=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {

            IEnumerable<VehicleOwnerDetailsModel> model = new List<VehicleOwnerDetailsModel>();
            var response = client.GetAsync(baseAddress + "/VehicleOwnerDetail/GelAllVehicleOwnerDetails").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                //UserModel UserResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(data);
                model = JsonConvert.DeserializeObject<IEnumerable<VehicleOwnerDetailsModel>>(data);
            }
            ViewBag.VehicleOwnerDetailsList = model;

            return View();
        }
        [HttpPost]
        public ActionResult Create(VehicleDetailsModel model)
        {
            try
            {
                UserModel _UserModel = new UserModel();
                _UserModel = (UserModel)Session["UserModel"];
                model.UserId = _UserModel.UserId;

                string strData = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(strData, Encoding.UTF8, "application/json");
                var response = client.PostAsync(client.BaseAddress + "/VehicleDetails/CreateVehicleDetails", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    if (response.Content.ReadAsStringAsync().Result != "null")
                    {
                        TempData["SuccessMessage"] = "Vehicle Created Successfully.";

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
            catch (Exception)
            {

                // throw;
            }

            try
            {
                IEnumerable<VehicleOwnerDetailsModel> model1 = new List<VehicleOwnerDetailsModel>();
                var response = client.GetAsync(baseAddress + "/VehicleOwnerDetail/GelAllVehicleOwnerDetails").Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;

                    //UserModel UserResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(data);
                    model1 = JsonConvert.DeserializeObject<IEnumerable<VehicleOwnerDetailsModel>>(data);
                }
                ViewBag.VehicleOwnerDetailsList = model1;
            }
            catch (Exception)
            {

                // throw;
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            {

                IEnumerable<VehicleOwnerDetailsModel> model1 = new List<VehicleOwnerDetailsModel>();
                var response1 = client.GetAsync(baseAddress + "/VehicleOwnerDetail/GelAllVehicleOwnerDetails").Result;
                if (response1.IsSuccessStatusCode)
                {
                    var data = response1.Content.ReadAsStringAsync().Result;

                    //UserModel UserResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(data);
                    model1 = JsonConvert.DeserializeObject<IEnumerable<VehicleOwnerDetailsModel>>(data);
                }
                ViewBag.VehicleOwnerDetailsList = model1;
            }


            VehicleDetailsModel model = new VehicleDetailsModel();
            var response = client.GetAsync(baseAddress + "/VehicleDetails/GelVehicleDetailsByVehicleId?VehicleId=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                //UserModel UserResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(data);
                model = JsonConvert.DeserializeObject<VehicleDetailsModel>(data);
            }
            return View(model);
        }


        // GET: Vehicle
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            string txtSearchRegNo = Convert.ToString(Request.Form["txtSearchRegNo"]);
            string txtSearchOwnerName = Convert.ToString(Request.Form["txtSearchOwnerName"]);
            string txtSearchModelNo = Convert.ToString(Request.Form["txtSearchModelNo"]);
            string txtSearchMakeYear = Convert.ToString(Request.Form["txtSearchMakeYear"]);

            UserModel _UserModel = new UserModel();
            _UserModel = (UserModel)Session["UserModel"];

            VehicleSearchModel _VehicleSearchModel = new VehicleSearchModel();
            _VehicleSearchModel.UserId = _UserModel.UserId;
            _VehicleSearchModel.OwnerName = string.IsNullOrEmpty(txtSearchOwnerName) ? null : txtSearchOwnerName;
            _VehicleSearchModel.RegNo = string.IsNullOrEmpty(txtSearchRegNo) ? null : txtSearchRegNo;
            _VehicleSearchModel.MakeYear = string.IsNullOrEmpty(txtSearchMakeYear) ? null : txtSearchMakeYear;
            _VehicleSearchModel.ModelNo = string.IsNullOrEmpty(txtSearchModelNo) ? null : txtSearchModelNo;

            string strData = JsonConvert.SerializeObject(_VehicleSearchModel);
            StringContent content = new StringContent(strData, Encoding.UTF8, "application/json");
            IEnumerable<VehicleDetailsModel> model = new List<VehicleDetailsModel>();
            var response = client.PostAsync(baseAddress + "/VehicleDetails/GelSearchAllVehicleDetailsByUserId", content).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<IEnumerable<VehicleDetailsModel>>(data);
            }
            return View(model);


        }


    }
}