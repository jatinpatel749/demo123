using Models;
using System.Collections.Generic;

namespace Repositories.Interfaces
{
    public interface IVehicleDetailsRepository
    {
        bool CreateVehicleDetails(VehicleDetailsModel model);
        IEnumerable<VehicleDetailsModel> GelAllVehicleDetailsByUserId(int UserId);
        VehicleDetailsModel GelVehicleDetailsByVehicleId(int VehicleId);
        int DeleteVehicleDetailsByVehicleId(int VehicleId);
        bool UpdateVehicleDetails(VehicleDetailsModel model);

        IEnumerable<VehicleDetailsModel> GelSearchAllVehicleDetailsByUserId(VehicleSearchModel model);
    }
}
