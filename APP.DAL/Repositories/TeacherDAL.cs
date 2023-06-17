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
    public class TeacherDAL : ITeacherDAL
    {
        private readonly SchoolDbContext db;

        public TeacherDAL()
        {
            db = new SchoolDbContext();
        }

        public IList<Teacher> GetAll()
        {
            return db.Teachers.ToList();
        }

        public int SaveOrUpdate(Teacher teacher)
        {
            if (teacher.Id > 0)
            {
                Teacher c = new Teacher();
                c = db.Teachers.AsNoTracking().FirstOrDefault(x => x.Id == teacher.Id);

                if (c == null)
                    throw new Exception("Not Found");

                db.Teachers.Update(teacher);
                db.SaveChanges();
            }
            else
            {
                db.Teachers.Add(teacher);
                db.SaveChanges();
            }

            return teacher.Id;
        }

        public void Delete(int id)
        {
            Teacher c = new Teacher();
            c = db.Teachers.FirstOrDefault(x => x.Id == id);

            if (c == null)
                throw new Exception("Not Found");

            db.Teachers.Remove(c);
            db.SaveChanges();
        }
         
    }
}
