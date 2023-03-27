namespace kursyonetimi.Models
{
    public class Profile
    {
     public int id { get; set; }
     public int userid { get; set; }
     public string name { get; set; }
     public string surname { get; set; }   
     public byte[] avatar { get; set; }
     public string school { get; set; }
     public int isactive { get; set; }
     public DateTime creationDate { get; set; }

    }
}
