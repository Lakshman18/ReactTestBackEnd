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
    public class ClassRoomBLL : IClassRoomBLL
    {
        private readonly IClassRoomDAL _ClassRoomDAL;
        private Mapper _Mapper;
        private Mapper _MapperAS;

        public ClassRoomBLL(IClassRoomDAL ClassRoomDAL)
        {
            _ClassRoomDAL = ClassRoomDAL;
            var _config = new MapperConfiguration(cfg => cfg.CreateMap<ClassRoom, ClassRoomModel>().ReverseMap());
            _Mapper = new Mapper(_config);

            var _config1 = new MapperConfiguration(cfg => cfg.CreateMap<AllocateClassRoom, AllocateClassRoomModel>().ReverseMap());
            _MapperAS = new Mapper(_config1);
        }

        public IList<ClassRoomModel> GetAll()
        {
            IList<ClassRoom> entities = _ClassRoomDAL.GetAll();
            IList<ClassRoomModel> entityModels = _Mapper.Map<IList<ClassRoom>, IList<ClassRoomModel>>(entities);
            return entityModels;
        }

        public int SaveOrUpdate(ClassRoomModel classRoom)
        {
            ClassRoom entityModel = _Mapper.Map<ClassRoomModel, ClassRoom>(classRoom);
            return _ClassRoomDAL.SaveOrUpdate(entityModel);
        }

        public void Delete(int id)
        {
            _ClassRoomDAL.Delete(id);
        }

        // ALLOCATE CLASS ROOM

        public IList<ClassRoomModel> GetByTeacher(int id)
        {
            IList<ClassRoom> entities = _ClassRoomDAL.GetByTeacher(id);
            IList<ClassRoomModel> entityModels = _Mapper.Map<IList<ClassRoom>, IList<ClassRoomModel>>(entities);
            return entityModels;
        }

        public void DelocateClassRoom(int tId, int sId)
        {
            _ClassRoomDAL.DelocateClassRoom(tId, sId);
        }

        public int AllocateClassRoom(AllocateClassRoomModel allocateClassRoom)
        {
            AllocateClassRoom entityModel = _MapperAS.Map<AllocateClassRoomModel, AllocateClassRoom>(allocateClassRoom);
            return _ClassRoomDAL.AllocateClassRoom(entityModel);
        }

    }
}
