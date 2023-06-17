using APP.BLL.Interfaces;
using APP.BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectBLL _SubjectBLL;

        public SubjectController(ISubjectBLL SubjectBLL)
        {
            _SubjectBLL = SubjectBLL;
        }

        [HttpGet]
        [Route("GetAll")]
        public IList<SubjectModel> GetAll()
        {
            return _SubjectBLL.GetAll();
        }

        [HttpPost]
        [Route("SaveOrUpdate")]
        public int SaveOrUpdate(SubjectModel subjectModel)
        {
            return _SubjectBLL.SaveOrUpdate(subjectModel);
        }

        [HttpDelete]
        [Route("Delete")]
        public void Delete(int id)
        {
            _SubjectBLL.Delete(id);
        }

        // ALLOCATE SUBJECT

        [HttpGet]
        [Route("GetByTeacher")]
        public IList<SubjectModel> GetByTeacher(int id)
        {
            return _SubjectBLL.GetByTeacher(id);
        }

        [HttpDelete]
        [Route("DelocateSubject")]
        public void DelocateSubject(int tId, int sId)
        {
            _SubjectBLL.DelocateSubject(tId, sId);
        }

        [HttpPost]
        [Route("AllocateSubject")]
        public int AllocateSubject(AllocateSubjectModel allocateSubjectModel)
        {
            return _SubjectBLL.AllocateSubject(allocateSubjectModel);
        }

    }
}
