using Models;
using MyEntity;
using Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Impelmentations
{
    public class VehicleOwnerDetailsRepository : IVehicleOwnerDetailsRepository
    {

        private readonly dbChintanEntities _db;
        public VehicleOwnerDetailsRepository(dbChintanEntities db)
        {
            _db = db;
        }
        public VehicleOwnerDetailsRepository()
        {
            _db = new dbChintanEntities();
        }



        public bool CreateVehicleOwnerDetails(VehicleOwnerDetailsModel model)
        {
            tblVehicleOwnerDetail _VehicleOwnerDetailsModel = new tblVehicleOwnerDetail();
            _VehicleOwnerDetailsModel.OwnerName = model.OwnerName;
            _VehicleOwnerDetailsModel.ContactNo = model.ContactNo;
            _VehicleOwnerDetailsModel.Address = model.Address;
            _VehicleOwnerDetailsModel.City = model.City;
            _VehicleOwnerDetailsModel.Pincode = model.Pincode;
            _VehicleOwnerDetailsModel.State = model.State;
            _VehicleOwnerDetailsModel.Country = model.Country;

            _db.tblVehicleOwnerDetails.Add(_VehicleOwnerDetailsModel);
            _db.SaveChanges();


            return true;
        }


        private VehicleOwnerDetailsModel AutoMapper(tblVehicleOwnerDetail value)
        {
            VehicleOwnerDetailsModel _VehicleOwnerDetailsModel = new VehicleOwnerDetailsModel();
            _VehicleOwnerDetailsModel.OwnerId = value.OwnerId;
            _VehicleOwnerDetailsModel.OwnerName = value.OwnerName;
            _VehicleOwnerDetailsModel.ContactNo = value.ContactNo;
            _VehicleOwnerDetailsModel.Address = value.Address;
            _VehicleOwnerDetailsModel.City = value.City;
            _VehicleOwnerDetailsModel.Pincode = value.Pincode;
            _VehicleOwnerDetailsModel.State = value.State;
            _VehicleOwnerDetailsModel.Country = value.Country;
            return _VehicleOwnerDetailsModel;

        }

        public IEnumerable<VehicleOwnerDetailsModel> GelAllVehicleOwnerDetails()
        {
            IEnumerable<tblVehicleOwnerDetail> ans = _db.tblVehicleOwnerDetails.ToList();
            if (ans != null)
            {
                List<VehicleOwnerDetailsModel> Final_ans = new List<VehicleOwnerDetailsModel>();

                foreach (var value in ans)
                {
                    Final_ans.Add(AutoMapper(value));
                }

                return Final_ans;
            }
            else
            { return null; }
        }
    }
}
