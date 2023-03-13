using Dapper;
using System.Data.SqlClient;
using System.Data;
using Tej_WebApp_Core.Interfaces;
using Tej_WebApp_Core.Models.DbConnection;
using Tej_WebApp_Core.Models.UnDelivered;

namespace Tej_WebApp_Core.Repositories.UnDelivered
{
    public class UnDeliveredRepository : IUnDelivered
    {
        private readonly ILogger<UnDeliveredModel> _logger;

        public UnDeliveredRepository(ILogger<UnDeliveredModel> logger)
        {
            _logger = logger;
        }
        public void UnDeliveredUpdate(UnDeliveredModel undlv)
        {

            try
            {
                using var con = new SqlConnection(ShareConection.ConValue);

                con.Open();
                var transaction = con.BeginTransaction();
                var param = new DynamicParameters();
                param.Add("pk_consmt_key", undlv.pk_consmt_key);
                param.Add("consmt_no", undlv.consmt_no);
                param.Add("pk_deliver_by", undlv.pk_deliver_by);
                param.Add("pk_branch_key", undlv.pk_branch_key);
                param.Add("reason", undlv.reason);
                param.Add("remark", undlv.remark);
                param.Add("crt_by", undlv.pk_deliver_by);

                var result = con.Execute("Mai_SP_Cnote_UnDelivered_Insert", param, transaction, null, CommandType.StoredProcedure);
                if (result > 0)
                {
                    transaction.Commit();
                }
                else
                {
                    transaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Page : UnDlvRepository.cs Method - UnDeliveredUpdate(UnDeliveredModel dlv) " + " Error :" + ex);
                throw;
            }

        }
    }
}