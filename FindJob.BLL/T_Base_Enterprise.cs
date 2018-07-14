using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.BLL
{
    public class T_Base_Enterpirse
    {
        public int AddInfoSave(FindJob.Model.T_Base_Enterprise enterprise)
        {
            return new FindJob.DAL.T_Base_Enterprise().AddInfoSave(enterprise);
        }
    }
}