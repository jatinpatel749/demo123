using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter EmailId")]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Enter MobileNo")]
        [MaxLength(10)]
        [MinLength(10)]
        [RegularExpression(@"^[0-9]{10,10}$", ErrorMessage = "Year Must Be in 10 Digit")]
        public string MobileNo { get; set; }
    }
}
