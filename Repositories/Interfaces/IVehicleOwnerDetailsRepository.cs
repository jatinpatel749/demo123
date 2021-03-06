using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
   public interface IVehicleOwnerDetailsRepository
    {
        bool CreateVehicleOwnerDetails(VehicleOwnerDetailsModel model);
        IEnumerable<VehicleOwnerDetailsModel> GelAllVehicleOwnerDetails();
        bool UpdateVehicleOwnerDetails(VehicleOwnerDetailsModel model);
        VehicleOwnerDetailsModel GelVehicleOwnerDetailsByOwnerId(int OwnerId);
    }
}
