using APP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.DAL.Interfaces
{
    public interface ITeacherDAL
    {
        IList<Teacher> GetAll();
        int SaveOrUpdate(Teacher teacher);
        void Delete(int id);

    }
}
