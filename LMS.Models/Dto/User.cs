using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models.Dto
{
    public class User
    {
        public string SDate { get; set; }
        public string EDate { get; set; }
        public string Name { get; set; }
        public int ID { get; set; }
        public int Phone { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book book { get; set; }


    }

    public class CreateUserRequest
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public int Days { get; set; }

    }
}
