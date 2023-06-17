using APP.BLL.Interfaces;
using APP.BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomController : ControllerBase
    {
        private readonly IClassRoomBLL _ClassRoomBLL;

        public ClassRoomController(IClassRoomBLL ClassRoomBLL)
        {
            _ClassRoomBLL = ClassRoomBLL;
        }

        [HttpGet]
        [Route("GetAll")]
        public IList<ClassRoomModel> GetAll()
        {
            return _ClassRoomBLL.GetAll();
        }

        [HttpPost]
        [Route("SaveOrUpdate")]
        public int SaveOrUpdate(ClassRoomModel classRoomModel)
        {
            return _ClassRoomBLL.SaveOrUpdate(classRoomModel);
        }

        [HttpDelete]
        [Route("Delete")]
        public void Delete(int id)
        {
            _ClassRoomBLL.Delete(id);
        }

        // ALLOCATE ClassRoom

        [HttpGet]
        [Route("GetByTeacher")]
        public IList<ClassRoomModel> GetByTeacher(int id)
        {
            return _ClassRoomBLL.GetByTeacher(id);
        }

        [HttpDelete]
        [Route("DelocateClassRoom")]
        public void DelocateClassRoom(int tId, int sId)
        {
            _ClassRoomBLL.DelocateClassRoom(tId, sId);
        }

        [HttpPost]
        [Route("AllocateClassRoom")]
        public int AllocateClassRoom(AllocateClassRoomModel allocateClassRoomModel)
        {
            return _ClassRoomBLL.AllocateClassRoom(allocateClassRoomModel);
        }

    }
}
