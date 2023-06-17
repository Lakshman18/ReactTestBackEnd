using APP.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.BLL.Interfaces
{
    public interface ITeacherBLL
    {
        IList<TeacherModel> GetAll();

        int SaveOrUpdate(TeacherModel teacher);
        void Delete(int id);
    }
}
