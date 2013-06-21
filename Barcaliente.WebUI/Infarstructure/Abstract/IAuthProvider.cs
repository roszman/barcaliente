using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcaliente.WebUI.Infarstructure.Abstract
{
    public interface IAuthProvider
    {
        bool AuthenticateAndLogIn(string username, string password);
        void LogOff();
    }
}
