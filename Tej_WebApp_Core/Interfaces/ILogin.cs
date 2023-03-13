using Tej_WebApp_Core.ViewModels;

namespace Tej_WebApp_Core.Interfaces
{
    public interface ILogin
    {
        public List<LoginVM> LoginCheck(string user_name);
    }
}
