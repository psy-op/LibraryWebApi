﻿using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models.Entities
{
    public class UserEntity
    {
        public string SDate { get; set; }
        public string EDate { get; set; }
        public string Name { get; set; }
        public int ID { get; set; }
        public int Phone { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public virtual BookEntity book { get; set; }


    }
}
