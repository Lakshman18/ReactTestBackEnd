using APP.BLL.Interfaces;
using APP.BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherBLL _TeacherBLL;

        public TeacherController(ITeacherBLL TeacherBLL)
        {
            _TeacherBLL = TeacherBLL;
        }

        [HttpGet]
        [Route("GetAll")]
        public IList<TeacherModel> GetAll()
        {
            return _TeacherBLL.GetAll();
        }

        [HttpPost]
        [Route("SaveOrUpdate")]
        public int SaveOrUpdate(TeacherModel teacherModel)
        {
            return _TeacherBLL.SaveOrUpdate(teacherModel);
        }

        [HttpDelete]
        [Route("Delete")]
        public void Delete(int id)
        {
            _TeacherBLL.Delete(id);
        }


    }
}
