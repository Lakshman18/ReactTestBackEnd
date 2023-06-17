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
    public class TeacherBLL : ITeacherBLL
    {
        private readonly ITeacherDAL _TeacherDAL;
        private Mapper _Mapper;


        public TeacherBLL(ITeacherDAL TeacherDAL)
        {
            _TeacherDAL = TeacherDAL;
            var _config = new MapperConfiguration(cfg => cfg.CreateMap<Teacher, TeacherModel>().ReverseMap());
            _Mapper = new Mapper(_config);
        }

        public IList<TeacherModel> GetAll()
        {
            IList<Teacher> entities = _TeacherDAL.GetAll();
            IList<TeacherModel> entityModels = _Mapper.Map<IList<Teacher>, IList<TeacherModel>>(entities);
            return entityModels;
        }

        public int SaveOrUpdate(TeacherModel teacher)
        {
            Teacher entityModel = _Mapper.Map<TeacherModel, Teacher>(teacher);
            return _TeacherDAL.SaveOrUpdate(entityModel);
        }

        public void Delete(int id)
        {
            _TeacherDAL.Delete(id);
        }

        

    }
}
