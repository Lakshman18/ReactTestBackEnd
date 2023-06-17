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
    public class SubjectDAL : ISubjectDAL
    {
        private readonly SchoolDbContext db;

        public SubjectDAL()
        {
            db = new SchoolDbContext();
        }

        public IList<Subject> GetAll()
        {
            return db.Subjects.ToList();
        }

        public int SaveOrUpdate(Subject subject)
        {
            if (subject.Id > 0)
            {
                Subject c = new Subject();
                c = db.Subjects.AsNoTracking().FirstOrDefault(x => x.Id == subject.Id);

                if (c == null)
                    throw new Exception("Not Found");

                db.Subjects.Update(subject);
                db.SaveChanges();
            }
            else
            {
                

                db.Subjects.Add(subject);
                db.SaveChanges();
            }

            return subject.Id;
        }

        public void Delete(int id)
        {
            Subject c = new Subject();
            c = db.Subjects.FirstOrDefault(x => x.Id == id);

            if (c == null)
                throw new Exception("Not Found");

            db.Subjects.Remove(c);
            db.SaveChanges();
        }

        // ALLOCATE SUBJECT
        public IList<Subject> GetByTeacher(int id)
        {
            IList<int> subList = db.AllocateSubjects.Where(t => t.TeacherId == id).Select(x => x.SubjectId).ToList();
            IList<Subject> result = db.Subjects.Where(item => subList.Contains(item.Id)).ToList();
            return result;
        }

        public void DelocateSubject(int tId, int sId)
        {
            AllocateSubject c = new AllocateSubject();
            c = db.AllocateSubjects.FirstOrDefault(x => x.TeacherId == tId && x.SubjectId == sId);

            if (c == null)
                throw new Exception("Not Found");

            db.AllocateSubjects.Remove(c);
            db.SaveChanges();
        }

        public int AllocateSubject(AllocateSubject allocateSubject)
        {
            if (allocateSubject.Id > 0)
            {
                throw new Exception("Exists");
            }
            else
            {
                AllocateSubject c = new AllocateSubject();
                c = db.AllocateSubjects.FirstOrDefault(x => x.TeacherId == allocateSubject.TeacherId && x.SubjectId == allocateSubject.SubjectId);

                if (c != null)
                    throw new Exception("Exists");

                db.AllocateSubjects.Add(allocateSubject);
                db.SaveChanges();
            }

            return allocateSubject.Id;
        }
    }
}
