using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Tej_WebApp_Core.Models.DlvTaskList
{
    public class DlvTaskListModel
    {
        public int pk_load_sheet_key { get; set; }
        public int pk_consmt_key { get; set; }
        public int pk_branch_key { get; set; }
        public int consmt_no { get; set; }
        public string branch { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public DateTime load_date { get; set; }
        public string doc_non_doc { get; set; }
        public string cnee_add { get; set; }
        public string cnee_mob { get; set; }
        public int pk_pd_key { get; set; }
    }
}
