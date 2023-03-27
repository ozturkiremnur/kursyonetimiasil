using Dapper;
using kursyonetimi.Models;
using MySql.Data.MySqlClient;

namespace kursyonetimi.Repos
{
    public class userCTX
    {
        public List<user> userList(string sorgu, object param)
        {
            using (var connection = new MySqlConnection("Server=localhost;Database=kursyonetimi;User Id=root;Password=Muhamm3d!1;"))
            {
                var list = connection.Query<user>(sorgu, param).ToList();
                profileCTX pctx = new profileCTX();
                foreach(var item in list)
                {
                    item.profile = pctx.profilTek("select * from Profile where userId = @userId", new { userId = item.id });
                }
                return list;
            }
        }

        public user usertek(string sorgu, object param)
        {
            using (var connection = new MySqlConnection("Server=localhost;Database=kursyonetimi;User Id=root;Password=Muhamm3d!1;"))
            {
                var item = connection.Query<user>(sorgu, param).FirstOrDefault();
                profileCTX pctx = new profileCTX();
                item.profile = pctx.profilTek("select * from Profile where userId = @userId", new { userId = item.id });
                return item;
            }
        }

        public int userekle(user User)
        {
            using (var connection = new MySqlConnection("Server=localhost;Database=kursyonetimi;User Id=root;Password=Muhamm3d!1;"))
            {
                var item = connection.Execute("insert into User (username, password, email) values (@username, @password, @email)", User);
                return item;
            }
        }

        public int userguncelle(user User)
        {
            using (var connection = new MySqlConnection("Server=localhost;Database=kursyonetimi;User Id=root;Password=Muhamm3d!1;"))
            {
                var item = connection.Execute("update user set username=@username, password=@password, email= @email, isactive=@isactive where id = @id", User);
                return item;
            }
        }
     
    }
}
