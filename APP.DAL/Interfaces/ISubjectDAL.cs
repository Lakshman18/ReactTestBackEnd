using APP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.DAL.Interfaces
{
    public interface ISubjectDAL
    {
        IList<Subject> GetAll();
        int SaveOrUpdate(Subject subject);
        void Delete(int id);

        // ALLOCATE SUBJECT
        IList<Subject> GetByTeacher(int id);
        void DelocateSubject(int tId, int sId);
        int AllocateSubject(AllocateSubject allocateSubject);
    }
}
