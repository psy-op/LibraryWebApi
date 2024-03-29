﻿using LMS.Models.Dto;
using LMS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Interface
{
    public interface IBookManager
    {
       
        public void Create(CreateBookRequest book);
        public void Update(int id, Book book);
        public void Delete(int id);
        public Book GetBook(int id);
        public void CopiesChange(int id,string opp);

    }
}