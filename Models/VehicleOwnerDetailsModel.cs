using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class VehicleOwnerDetailsModel
    {
        public VehicleOwnerDetailsModel()
        {
            this.VehicleDetailsModels = new HashSet<VehicleDetailsModel>();
        }
        public int OwnerId { get; set; }
        [Required(ErrorMessage = "Please Enter OwnerName")]
        public string OwnerName { get; set; }
        [Required(ErrorMessage = "Please Enter ContactNo")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Enter City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please Enter Pincode")]
        public string Pincode { get; set; }
        [Required(ErrorMessage = "Please Enter State")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please Enter Country")]
        public string Country { get; set; }


        public virtual ICollection<VehicleDetailsModel> VehicleDetailsModels { get; set; }
    }
}
