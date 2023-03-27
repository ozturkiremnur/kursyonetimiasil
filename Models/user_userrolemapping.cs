namespace kursyonetimi.Models
{
    public class user_userrolemapping
    {
        public int id { get; set; }
        public int userid { get; set; }
        public int userroleid { get; set; }

        public int isactive { get; set; }
        public DateTime creationDate { get; set; }
    }
}
