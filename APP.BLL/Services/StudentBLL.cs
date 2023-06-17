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
    public class StudentBLL : IStudentBLL
    {
        private readonly IStudentDAL _StudentDAL;
        private Mapper _Mapper;


        public StudentBLL(IStudentDAL StudentDAL)
        {
            _StudentDAL = StudentDAL;
            var _config = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentModel>().ReverseMap());
            _Mapper = new Mapper(_config);
        }

        public IList<StudentModel> GetAll()
        {
            IList<Student> entities = _StudentDAL.GetAll();
            IList<StudentModel> entityModels = _Mapper.Map<IList<Student>, IList<StudentModel>>(entities);
            return entityModels;
        }

        public int SaveOrUpdate(StudentModel student)
        {
            Student entityModel = _Mapper.Map<StudentModel, Student>(student);
            return _StudentDAL.SaveOrUpdate(entityModel);
        }

        public void Delete(int id)
        {
            _StudentDAL.Delete(id);
        }

    }
}
