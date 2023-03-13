using Tej_WebApp_Core.Models.DlvTaskList;

namespace Tej_WebApp_Core.Interfaces
{
    public interface IDlvTaskList
    {
        List<DlvTaskListModel> GetList(int app_users_key, string consmt_no);

       // List<DlvTaskListModel> GetSearchData(int app_users_key, string cnoteno);
    }
}
