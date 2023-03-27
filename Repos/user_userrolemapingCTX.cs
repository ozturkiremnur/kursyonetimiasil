using Dapper;
using kursyonetimi.Models;
using MySql.Data.MySqlClient;

namespace kursyonetimi.Repos
{
    public class user_userrolemappingCTX
    {
        public List<user_userrolemapping> uurmlist(string sorgu, object param)
        {
            using (var connection = new MySqlConnection("Server=localhost;Database=kursyonetimi;User Id=root;Password=Muhamm3d!1;"))
            {
                var list = connection.Query<user_userrolemapping>(sorgu, param).ToList();

                return list;
            }
        }

        public user_userrolemapping uurmtek(string sorgu, object param)
        {
            using (var connection = new MySqlConnection("Server=localhost;Database=kursyonetimi;User Id=root;Password=Muhamm3d!1;"))
            {
                var item = connection.Query<user_userrolemapping>(sorgu, param).FirstOrDefault();

                return item;
            }
        }

        public int uurmekle(user_userrolemapping uurm)
        {
            using (var connection = new MySqlConnection("Server=localhost;Database=kursyonetimi;User Id=root;Password=Muhamm3d!1;"))
            {
                var item = connection.Execute("insert into user_userrolemapping (userid,userroleid) values (@userid,@userroleid)", uurm);
                return item;
            }
        }

        public int uurmguncelle(user_userrolemapping uurm)
        {
            using (var connection = new MySqlConnection("Server=localhost;Database=kursyonetimi;User Id=root;Password=Muhamm3d!1;"))
            {
                var item = connection.Execute("update user_userrolemapping set userid = @userid,userroleid = @userroleid,isactive = @isactive, where id = @id", uurm);
                return item;
            }
        }
    }
}
