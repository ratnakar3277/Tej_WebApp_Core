using Dapper;
using System.Data;
using System.Data.SqlClient;
using Tej_WebApp_Core.Interfaces;
using Tej_WebApp_Core.Models.DbConnection;
using Tej_WebApp_Core.Repositories.DlvTaskList;
using Tej_WebApp_Core.ViewModels;

namespace Tej_WebApp_Core.Repositories.Login
{
    public class LoginRepository : ILogin
    {
        private readonly ILogger<LoginRepository> _logger;
        public LoginRepository(ILogger<LoginRepository> logger)
        {
            _logger = logger;
        }
        public List<LoginVM> LoginCheck(string user_name)
        {
            using var con = new SqlConnection(ShareConection.ConValue);
            var param = new DynamicParameters();
            param.Add("@user_name", user_name);
            //param.Add("@password", password);
            //return con.Query<LoginViewModel>("Select * from Mai_Tbl_PNDBoy_Login_Create where user_name= '" + user_name + "' and password='" + password + "';").ToList();
            var result = con.Query<LoginVM>("Mai_SP_Shipsy_Android_Login_New", param, null, false, 0, CommandType.StoredProcedure).ToList();
            return result;
        }
    }
}
