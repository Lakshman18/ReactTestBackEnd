using APP.BLL.Interfaces;
using APP.BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentBLL _StudentBLL;

        public StudentController(IStudentBLL StudentBLL)
        {
            _StudentBLL = StudentBLL;
        }

        [HttpGet]
        [Route("GetAll")]
        public IList<StudentModel> GetAll()
        {
            return _StudentBLL.GetAll();
        }

        [HttpPost]
        [Route("SaveOrUpdate")]
        public int SaveOrUpdate(StudentModel studentModel)
        {
            return _StudentBLL.SaveOrUpdate(studentModel);
        }

        [HttpDelete]
        [Route("Delete")]
        public void Delete(int id)
        {
            _StudentBLL.Delete(id);
        }

    }
}
