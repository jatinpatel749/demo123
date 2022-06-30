using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class VehicleDetailsModel
    {
        public VehicleDetailsModel()
        {
            this.VehicleOwnerDetailsModels =new VehicleOwnerDetailsModel();
        }
        public int VehicleId { get; set; }
        [Required(ErrorMessage = "Please Select OwnerName")]
        public int? OwnerId { get; set; }
        [Required(ErrorMessage = "Please Enter RegNo")]
        public string RegNo { get; set; }
        [Required(ErrorMessage = "Please Enter ModelNo")]
        public string ModelNo { get; set; }
        [Required(ErrorMessage = "Please Enter MakeYear")]
        [MaxLength(4)]
        [RegularExpression(@"^[0-9]{4,4}$", ErrorMessage = "Year Must Be in 4 Digit")]
        public string MakeYear { get; set; }
        public int? UserId { get; set; }



        public virtual VehicleOwnerDetailsModel VehicleOwnerDetailsModels { get; set; }
    }
}
