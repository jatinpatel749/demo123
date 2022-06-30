using System;

namespace Models
{
    public class VehicleSearchModel
    {
        public Nullable<int> UserId { get; set; }
        public string RegNo { get; set; }
        public string OwnerName { get; set; }
        public string ModelNo { get; set; }
        public string MakeYear { get; set; }

    }
}
