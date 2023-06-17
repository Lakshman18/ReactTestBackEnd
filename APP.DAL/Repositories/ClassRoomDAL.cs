using APP.DAL.Entities;
using APP.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.DAL.Repositories
{
    public class ClassRoomDAL : IClassRoomDAL
    {
        private readonly SchoolDbContext db;

        public ClassRoomDAL()
        {
            db = new SchoolDbContext();
        }

        public IList<ClassRoom> GetAll()
        {
            return db.ClassRooms.ToList();
        }

        public int SaveOrUpdate(ClassRoom classRoom)
        {
            if (classRoom.Id > 0)
            {
                ClassRoom c = new ClassRoom();
                c = db.ClassRooms.AsNoTracking().FirstOrDefault(x => x.Id == classRoom.Id);

                if (c == null)
                    throw new Exception("Not Found");

                db.ClassRooms.Update(classRoom);
                db.SaveChanges();
            }
            else
            {
                db.ClassRooms.Add(classRoom);
                db.SaveChanges();
            }

            return classRoom.Id;
        }

        public void Delete(int id)
        {
            ClassRoom c = new ClassRoom();
            c = db.ClassRooms.FirstOrDefault(x => x.Id == id);

            if (c == null)
                throw new Exception("Not Found");

            db.ClassRooms.Remove(c);
            db.SaveChanges();
        }

        // ALLOCATE CLASS ROOM
        public IList<ClassRoom> GetByTeacher(int id)
        {
            IList<int> subList = db.AllocateClassRooms.Where(t => t.TeacherId == id).Select(x => x.ClassRoomId).ToList();
            IList<ClassRoom> result = db.ClassRooms.Where(item => subList.Contains(item.Id)).ToList();
            return result;
        }

        public void DelocateClassRoom(int tId, int sId)
        {
            AllocateClassRoom c = new AllocateClassRoom();
            c = db.AllocateClassRooms.FirstOrDefault(x => x.TeacherId == tId && x.ClassRoomId == sId);

            if (c == null)
                throw new Exception("Not Found");

            db.AllocateClassRooms.Remove(c);
            db.SaveChanges();
        }

        public int AllocateClassRoom(AllocateClassRoom allocateClassRoom)
        {
            if (allocateClassRoom.Id > 0)
            {
                throw new Exception("Exists");
            }
            else
            {
                AllocateClassRoom c = new AllocateClassRoom();
                c = db.AllocateClassRooms.FirstOrDefault(x => x.TeacherId == allocateClassRoom.TeacherId && x.ClassRoomId == allocateClassRoom.ClassRoomId);

                if (c != null)
                    throw new Exception("Exists");

                db.AllocateClassRooms.Add(allocateClassRoom);
                db.SaveChanges();
            }

            return allocateClassRoom.Id;
        }

    }
}
