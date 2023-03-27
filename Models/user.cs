namespace kursyonetimi.Models
{
    public class user
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int isactive { get; set; }
        public DateTime creationDate { get; set; }
        public Profile profile { get; set; }
    }
}
