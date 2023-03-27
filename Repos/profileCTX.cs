using Dapper;
using kursyonetimi.Models;
using MySql.Data.MySqlClient;

namespace kursyonetimi.Repos
{
    public class profileCTX
    {
        public List<Profile> profileList(string sorgu, object param)
        {
            using (var connection = new MySqlConnection("Server=localhost;Database=kursyonetimi;User Id=root;Password=Muhamm3d!1;"))
            {
                var list = connection.Query<Profile>(sorgu, param).ToList();

                return list;
            }
        }

        public Profile profilTek(string sorgu, object param)
        {
            using (var connection = new MySqlConnection("Server=localhost;Database=kursyonetimi;User Id=root;Password=Muhamm3d!1;"))
            {
                var item = connection.Query<Profile>(sorgu, param).FirstOrDefault();

                return item;
            }
        }

        public int profileEkle(Profile profile)
        {
            using (var connection = new MySqlConnection("Server=localhost;Database=kursyonetimi;User Id=root;Password=Muhamm3d!1;"))
            {
                var item = connection.Execute("insert into profile (userid, name, surname, avatar, bddate, school) values (@userid, @name, @surname, @avatar, @bddate, @school)", profile);
                return item;
            }
        }

        public int profilGuncelle(Profile profil)
        {
            using (var connection = new MySqlConnection("Server=localhost;Database=kursyonetimi;User Id=root;Password=Muhamm3d!1;"))
            {
                var item = connection.Execute("update profile set userid = @userid, name= @name, surname= @surname, avatar= @avatar, bddate= @bddate, school= @school, isActive = @isActive where id = @id", profil);
                return item;
            }
        }
    }
}
