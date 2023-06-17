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
    public class StudentDAL : IStudentDAL
    {
        private readonly SchoolDbContext db;

        public StudentDAL()
        {
            db = new SchoolDbContext();
        }

        public IList<Student> GetAll()
        {
            return db.Students.Include("ClassRoom").ToList();
        }

        public int SaveOrUpdate(Student student)
        {
            if (student.Id > 0)
            {
                Student c = new Student();
                c = db.Students.AsNoTracking().FirstOrDefault(x => x.Id == student.Id);

                if (c == null)
                    throw new Exception("Not Found");
                db.Students.Update(student);
                db.SaveChanges();
            }
            else
            {
                db.Students.Add(student);
                db.SaveChanges();
            }

            return student.Id;
        }

        public void Delete(int id)
        {
            Student c = new Student();
            c = db.Students.FirstOrDefault(x => x.Id == id);

            if (c == null)
                throw new Exception("Not Found");

            db.Students.Remove(c);
            db.SaveChanges();
        }
    }
}
