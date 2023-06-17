using APP.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.BLL.Interfaces
{
    public interface IClassRoomBLL
    {
        IList<ClassRoomModel> GetAll();
        int SaveOrUpdate(ClassRoomModel classRoom);
        void Delete(int id);

        // ALLOCATE CLASS ROOM
        IList<ClassRoomModel> GetByTeacher(int id);
        void DelocateClassRoom(int tId, int sId);
        int AllocateClassRoom(AllocateClassRoomModel allocateClassRoomModel);
    }
}
