using Models;
using MyEntity;
using Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Impelmentations
{
    public class VehicleDetailsRepository : IVehicleDetailsRepository
    {

        private readonly dbChintanEntities _db;
        public VehicleDetailsRepository(dbChintanEntities db)
        {
            _db = db;
        }
        public VehicleDetailsRepository()
        {
            _db = new dbChintanEntities();
        }


        public bool CreateVehicleDetails(VehicleDetailsModel model)
        {
            tblVehicleDetail _tblVehicleDetail = new tblVehicleDetail();
            _tblVehicleDetail.OwnerId = model.OwnerId;
            _tblVehicleDetail.RegNo = model.RegNo;
            _tblVehicleDetail.ModelNo = model.ModelNo;
            _tblVehicleDetail.MakeYear = model.MakeYear;
            _tblVehicleDetail.UserId = model.UserId;

            _db.tblVehicleDetails.Add(_tblVehicleDetail);
            _db.SaveChanges();


            return true;
        }

        public int DeleteVehicleDetailsByVehicleId(int VehicleId)
        {
            //var item = _db.CartItems.Where(ci => ci.CartId == cartId && ci.Id == itemId).FirstOrDefault();
            var item = _db.tblVehicleDetails.Where(t => t.VehicleId == VehicleId).FirstOrDefault();
            if (item != null)
            {
                _db.tblVehicleDetails.Remove(item);
                return _db.SaveChanges();
            }
            else
            {
                return 0;
            }

        }

        public IEnumerable<VehicleDetailsModel> GelAllVehicleDetailsByUserId(int UserId)
        {

            IEnumerable<tblVehicleDetail> ans = _db.tblVehicleDetails.Include("tblVehicleOwnerDetail").Where(t => t.UserId == UserId).ToList();


            if (ans != null)
            {
                List<VehicleDetailsModel> Final_ans = new List<VehicleDetailsModel>();

                foreach (var value in ans)
                {
                    //VehicleDetailsModel _VehicleDetailsModel = new VehicleDetailsModel();
                    //_VehicleDetailsModel.VehicleId = value.VehicleId;
                    //_VehicleDetailsModel.OwnerId = value.OwnerId;
                    //_VehicleDetailsModel.RegNo = value.RegNo;
                    //_VehicleDetailsModel.ModelNo = value.ModelNo;
                    //_VehicleDetailsModel.MakeYear = value.MakeYear;
                    //_VehicleDetailsModel.UserId = value.UserId;
                    //Final_ans.Add(_VehicleDetailsModel);
                    Final_ans.Add(AutoMapper(value));
                }

                return Final_ans;
            }
            else
            { return null; }

        }

        private VehicleDetailsModel AutoMapper(tblVehicleDetail value)
        {

            VehicleDetailsModel _VehicleDetailsModel = new VehicleDetailsModel();
            _VehicleDetailsModel.VehicleId = value.VehicleId;
            _VehicleDetailsModel.OwnerId = value.OwnerId;
            _VehicleDetailsModel.RegNo = value.RegNo;
            _VehicleDetailsModel.ModelNo = value.ModelNo;
            _VehicleDetailsModel.MakeYear = value.MakeYear;
            _VehicleDetailsModel.UserId = value.UserId;




            _VehicleDetailsModel.VehicleOwnerDetailsModels.OwnerId = value.tblVehicleOwnerDetail.OwnerId;
            _VehicleDetailsModel.VehicleOwnerDetailsModels.OwnerName = value.tblVehicleOwnerDetail.OwnerName;
            _VehicleDetailsModel.VehicleOwnerDetailsModels.ContactNo = value.tblVehicleOwnerDetail.ContactNo;
            _VehicleDetailsModel.VehicleOwnerDetailsModels.Address = value.tblVehicleOwnerDetail.Address;

            _VehicleDetailsModel.VehicleOwnerDetailsModels.City = value.tblVehicleOwnerDetail.City;
            _VehicleDetailsModel.VehicleOwnerDetailsModels.Pincode = value.tblVehicleOwnerDetail.Pincode;
            _VehicleDetailsModel.VehicleOwnerDetailsModels.State = value.tblVehicleOwnerDetail.State;
            _VehicleDetailsModel.VehicleOwnerDetailsModels.Country = value.tblVehicleOwnerDetail.Country;

            return _VehicleDetailsModel;

        }

        public VehicleDetailsModel GelVehicleDetailsByVehicleId(int VehicleId)
        {
            var value = _db.tblVehicleDetails.Where(t => t.VehicleId == VehicleId).FirstOrDefault();
            if (value != null)
            {
                //VehicleDetailsModel _VehicleDetailsModel = new VehicleDetailsModel();
                //_VehicleDetailsModel.VehicleId = value.VehicleId;
                //_VehicleDetailsModel.OwnerId = value.OwnerId;
                //_VehicleDetailsModel.RegNo = value.RegNo;
                //_VehicleDetailsModel.ModelNo = value.ModelNo;
                //_VehicleDetailsModel.MakeYear = value.MakeYear;
                //_VehicleDetailsModel.UserId = value.UserId;
                //return _VehicleDetailsModel;
                return AutoMapper(value);
            }
            else
            {
                return null;
            }

        }

        public bool UpdateVehicleDetails(VehicleDetailsModel model)
        {
            var value = _db.tblVehicleDetails.Where(t => t.VehicleId == model.VehicleId).FirstOrDefault();
            if (value != null)
            {
                value.OwnerId = model.OwnerId;
                value.RegNo = model.RegNo;
                value.ModelNo = model.ModelNo;
                value.MakeYear = model.MakeYear;
                value.UserId = model.UserId;
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public IEnumerable<VehicleDetailsModel> GelSearchAllVehicleDetailsByUserId(VehicleSearchModel model)
        {
            IEnumerable<tblVehicleDetail> ans = _db.tblVehicleDetails.Include("tblVehicleOwnerDetail").Where(t =>( t.RegNo.Contains(model.RegNo) || t.tblVehicleOwnerDetail.OwnerName.Contains(model.OwnerName)
                                  || t.ModelNo.Contains(model.ModelNo) || t.MakeYear.Contains(model.MakeYear)) && (t.UserId==model.UserId)).ToList();


            if (ans != null)
            {
                List<VehicleDetailsModel> Final_ans = new List<VehicleDetailsModel>();

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
