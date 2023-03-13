using Dapper;
using System.Data.SqlClient;
using System.Data;
using Tej_WebApp_Core.Interfaces;
using Tej_WebApp_Core.Models.DbConnection;
using Tej_WebApp_Core.Models.DlvTaskList;

namespace Tej_WebApp_Core.Repositories.DlvTaskList
{
    public class DlvTaskListRepository : IDlvTaskList
    {
        private readonly ILogger<DlvTaskListRepository> _logger;
        public DlvTaskListRepository(ILogger<DlvTaskListRepository> logger)
        {
            _logger = logger;
        }
        public List<DlvTaskListModel> GetList(int app_users_key, string consmt_no)
        {
            using var con = new SqlConnection(ShareConection.ConValue);
            var param = new DynamicParameters();
            param.Add("app_users_key", app_users_key);
            param.Add("consmt_no", consmt_no);
            var result = con.Query<DlvTaskListModel>("Mai_SP_PND_Runsheet_Consmt_Bind_Data", param, null, false, 0, CommandType.StoredProcedure).ToList();
            return result;
        }

        //public List<DlvTaskListModel> GetSearchData(int app_users_key, string cnoteno)
        //{
        //    using var con = new SqlConnection(ShareConection.ConValue);
        //    var param = new DynamicParameters();
        //    param.Add("app_users_key", app_users_key);
        //    param.Add("consmt_no", cnoteno);
        //    var result = con.Query<DlvTaskListModel>("Mai_SP_PND_Runsheet_Consmt_Bind_Data", param, null, false, 0, CommandType.StoredProcedure).ToList();
        //    return result;
        //}
    }
}
