using Models;
using Repositories.Impelmentations;
using Repositories.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace CarAPI.Controllers
{
    public class VehicleDetailsController : ApiController
    {
        private IVehicleDetailsRepository _IVehicleDetailsRepository;
        public VehicleDetailsController()
        {
            _IVehicleDetailsRepository = new VehicleDetailsRepository();
        }


        [Route("api/VehicleDetails/CreateVehicleDetails")]
        [HttpPost]
        public IHttpActionResult CreateVehicleDetails(VehicleDetailsModel model)
        {
            bool result = _IVehicleDetailsRepository.CreateVehicleDetails(model);

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

        [Route("api/VehicleDetails/GelAllVehicleDetailsByUserId")]
        [HttpGet]
        public IEnumerable<VehicleDetailsModel> GelAllVehicleDetailsByUserId(int UserId)
        {
            return _IVehicleDetailsRepository.GelAllVehicleDetailsByUserId(UserId);
        }

        [Route("api/VehicleDetails/GelSearchAllVehicleDetailsByUserId")]
        [HttpPost]
        public IEnumerable<VehicleDetailsModel> GelSearchAllVehicleDetailsByUserId(VehicleSearchModel model)
        {
            return _IVehicleDetailsRepository.GelSearchAllVehicleDetailsByUserId(model);
        }


        [Route("api/VehicleDetails/GelVehicleDetailsByVehicleId")]
        [HttpGet]
        public VehicleDetailsModel GelVehicleDetailsByVehicleId(int VehicleId)
        {
            return _IVehicleDetailsRepository.GelVehicleDetailsByVehicleId(VehicleId);
        }

        [Route("api/VehicleDetails/DeleteVehicleDetailsByVehicleId")]
        [HttpDelete]
        public IHttpActionResult DeleteVehicleDetailsByVehicleId(int VehicleId)
        {
            int n1 = _IVehicleDetailsRepository.DeleteVehicleDetailsByVehicleId(VehicleId);
            if (n1 != 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("api/VehicleDetails/UpdateVehicleDetails")]
        [HttpPost]
        public IHttpActionResult UpdateVehicleDetails(VehicleDetailsModel model)
        {
            bool result = _IVehicleDetailsRepository.UpdateVehicleDetails(model);

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

    }
}
