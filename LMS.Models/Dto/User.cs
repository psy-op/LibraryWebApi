using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models.Dto
{
    public class User
    {
        public string SDate { get; set; }
        public string EDate { get; set; }
        public string RentedBook { get; set; }
        public string Name { get; set; }
        public int ID { get; }
        public int Phone { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public virtual Book book { get; set; }


    }
}
