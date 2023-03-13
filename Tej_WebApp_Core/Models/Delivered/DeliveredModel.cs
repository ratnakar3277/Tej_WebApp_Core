using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Xml.Linq;

namespace Tej_WebApp_Core.Models.Delivered
{
    public class DeliveredModel
    {
        public int pk_consmt_key { get; set; }
        public int pk_deliver_by { get; set; }
        public int pk_branch_key { get; set; }

        [Required(ErrorMessage = "Enter Received By name")]
        [Display(Name = "Received By")]
        public string received_by { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Select Relation")]
        [Display(Name = "Relation")]
        public string relation { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Select ID Proof")]
        [Display(Name = "ID Proof")]
        public string id_proof { get; set; }

        [Required(ErrorMessage = "Enter ID Details")]
        [Display(Name = "ID Details")]
        public string id_no_details { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string FileType { get; set; }
        [MaxLength]
        public byte[] DataFiles { get; set; }

        public int crt_by { get; set; }
    }
}
