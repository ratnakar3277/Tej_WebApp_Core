using Dapper;
using System.Data.SqlClient;
using System.Data;
using Tej_WebApp_Core.Interfaces;
using Tej_WebApp_Core.Models.DbConnection;
using Tej_WebApp_Core.Models.Delivered;
using System.Xml.Linq;

namespace Tej_WebApp_Core.Repositories.Delivered
{    
    public class DeliveredRepository : IDelivered
    {
        private readonly ILogger<DeliveredModel> _logger;
        public DeliveredRepository(ILogger<DeliveredModel> logger)
        {
            _logger = logger;
        }
        public void InsertDelvery(DeliveredModel dlv)
        {
            try
            {
                using var con = new SqlConnection(ShareConection.ConValue);
                con.Open();
                var transaction = con.BeginTransaction();
                try
                {
                    var param = new DynamicParameters();
                    param.Add("pk_consmt_key", dlv.pk_consmt_key);
                    param.Add("pk_branch_key", dlv.pk_branch_key);
                    param.Add("pk_deliver_by", dlv.pk_deliver_by);
                    param.Add("relation", dlv.relation);
                    param.Add("received_by", dlv.received_by);
                    param.Add("id_proof", dlv.id_proof);
                    param.Add("id_no_details", dlv.id_no_details);
                    param.Add("Fname", dlv.Name);
                    param.Add("Ftype", dlv.FileType);
                    param.Add("Fbyte", dlv.DataFiles);
                    param.Add("crt_by",dlv.crt_by);

                    var result = con.Execute("Mai_SP_Insert_Delivered_Data",param,transaction,null,CommandType.StoredProcedure);
                    //var result = con.Execute("", param, transaction, null, CommandType.StoredProcedure);
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
                    _logger.LogError("Error Page: DlvRepository.cs : Method - InsertDelvery(DeliveredModel dlv) " + " Error :" + ex);
                    transaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Page: DlvRepository.cs : Method - InsertDelvery(DeliveredModel dlv) " + " Error :" + ex);
                throw;
            }
        }
    }
}