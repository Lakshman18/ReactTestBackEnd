﻿using APP.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.BLL.Interfaces
{
    public interface IStudentBLL
    {
        IList<StudentModel> GetAll();

        int SaveOrUpdate(StudentModel student);
        void Delete(int id)
;    }
}
