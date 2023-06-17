using APP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.DAL.Interfaces
{
    public interface IClassRoomDAL
    {
        IList<ClassRoom> GetAll();
        int SaveOrUpdate(ClassRoom classRoom);
        void Delete(int id);

        // ALLOCATE ClassRoom
        IList<ClassRoom> GetByTeacher(int id);
        void DelocateClassRoom(int tId, int sId);
        int AllocateClassRoom(AllocateClassRoom allocateClassRoom);
    }
}
