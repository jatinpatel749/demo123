using Repositories.Impelmentations;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
namespace CarAPI.Controllers
{
    public class VehicleOwnerDetailController : ApiController
    {
        private IVehicleOwnerDetailsRepository _IVehicleOwnerDetailsRepository;
        public VehicleOwnerDetailController()
        {
            _IVehicleOwnerDetailsRepository = new VehicleOwnerDetailsRepository();
        }


        [Route("api/VehicleOwnerDetail/CreateVehicleOwnerDetails")]
        [HttpPost]
        public IHttpActionResult CreateVehicleDetails(VehicleOwnerDetailsModel model)
        {
            bool result = _IVehicleOwnerDetailsRepository.CreateVehicleOwnerDetails(model);

            if (result)
            {
                return StatusCode(HttpStatusCode.Created);
            }
            else
            {
                //return StatusCode(StatusCodes.Status400BadRequest);
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }

        [Route("api/VehicleOwnerDetail/GelAllVehicleOwnerDetails")]
        [HttpGet]
        public IEnumerable<VehicleOwnerDetailsModel> GelAllVehicleOwnerDetails()
        {
            return _IVehicleOwnerDetailsRepository.GelAllVehicleOwnerDetails();


        }


        [Route("api/VehicleOwnerDetail/UpdateVehicleOwnerDetails")]
        [HttpPost]
        public IHttpActionResult UpdateVehicleOwnerDetails(VehicleOwnerDetailsModel model)
        {
            bool result = _IVehicleOwnerDetailsRepository.UpdateVehicleOwnerDetails(model);

            if (result)
            {
                return StatusCode(HttpStatusCode.Created);
            }
            else
            {
                //return StatusCode(StatusCodes.Status400BadRequest);
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }

        [Route("api/VehicleOwnerDetail/GelVehicleOwnerDetailsByOwnerId")]
        [HttpGet]
        public VehicleOwnerDetailsModel GelVehicleOwnerDetailsByOwnerId(int OwnerId)
        {
            return _IVehicleOwnerDetailsRepository.GelVehicleOwnerDetailsByOwnerId(OwnerId);

        }
    }
}
