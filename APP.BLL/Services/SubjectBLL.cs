using APP.BLL.Interfaces;
using APP.BLL.Models;
using APP.DAL.Entities;
using APP.DAL.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.BLL.Services
{
    public class SubjectBLL : ISubjectBLL
    {
        private readonly ISubjectDAL _SubjectDAL;
        private Mapper _Mapper;
        private Mapper _MapperAS;

        public SubjectBLL(ISubjectDAL SubjectDAL)
        {
            _SubjectDAL = SubjectDAL;
            var _config = new MapperConfiguration(cfg => cfg.CreateMap<Subject, SubjectModel>().ReverseMap());
            _Mapper = new Mapper(_config);

            var _config1 = new MapperConfiguration(cfg => cfg.CreateMap<AllocateSubject, AllocateSubjectModel>().ReverseMap());
            _MapperAS = new Mapper(_config1);
        }

        public IList<SubjectModel> GetAll()
        {
            IList<Subject> entities = _SubjectDAL.GetAll();
            IList<SubjectModel> entityModels = _Mapper.Map<IList<Subject>, IList<SubjectModel>>(entities);
            return entityModels;
        }

        public int SaveOrUpdate(SubjectModel subject)
        {
            Subject entityModel = _Mapper.Map<SubjectModel, Subject>(subject);
            return _SubjectDAL.SaveOrUpdate(entityModel);
        }

        public void Delete(int id)
        {
            _SubjectDAL.Delete(id);
        }

        // ALLOCATE SUBJECT

        public IList<SubjectModel> GetByTeacher(int id)
        {
            IList<Subject> entities = _SubjectDAL.GetByTeacher(id);
            IList<SubjectModel> entityModels = _Mapper.Map<IList<Subject>, IList<SubjectModel>>(entities);
            return entityModels;
        }

        public void DelocateSubject(int tId, int sId)
        {
            _SubjectDAL.DelocateSubject(tId, sId);
        }

        public int AllocateSubject(AllocateSubjectModel allocateSubject)
        {
            AllocateSubject entityModel = _MapperAS.Map<AllocateSubjectModel, AllocateSubject>(allocateSubject);
            return _SubjectDAL.AllocateSubject(entityModel);
        }

    }
}
