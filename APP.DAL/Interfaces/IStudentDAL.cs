using APP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.DAL.Interfaces
{
    public interface IStudentDAL
    {
        IList<Student> GetAll();
        int SaveOrUpdate(Student student);
        void Delete(int id);
    }
}
