using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Tej_WebApp_Core.Models.UnDelivered
{
    public class UnDeliveredModel
    {
        public int pk_consmt_key { get; set; }
        public int pk_deliver_by { get; set; }
        public int pk_branch_key { get; set; }

        [Display(Name = "Consmt No")]
        public string consmt_no { get; set; }
        [Display(Name = "Reason")]

        [Required(ErrorMessage = "Select Reason")]
        public string reason { get; set; }
        public string remark { get; set; }
        //public int crt_by { get; set; }
    }
}
