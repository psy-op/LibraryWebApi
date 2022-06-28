namespace LMS.Models.Dto
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Copies { get; set; }
        public int ID { get; set; }

    }

    public class CreateBookRequest
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Copies { get; set; }
        public int ID { get; }
    }

}
