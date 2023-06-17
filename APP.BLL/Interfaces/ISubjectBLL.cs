using APP.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.BLL.Interfaces
{
    public interface ISubjectBLL
    {
        IList<SubjectModel> GetAll();
        int SaveOrUpdate(SubjectModel subject);
        void Delete(int id);

        // ALLOCATE SUBJECT
        IList<SubjectModel> GetByTeacher(int id);
        void DelocateSubject(int tId, int sId);
        int AllocateSubject(AllocateSubjectModel allocateSubject);
    }
}
