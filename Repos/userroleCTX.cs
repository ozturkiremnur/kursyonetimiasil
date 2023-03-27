
using Dapper;
using kursyonetimi.Models;
using MySql.Data.MySqlClient;

namespace kursyonetimi.Repos
{
    public class userroleCTX
    {
        public List<user_role> userroleList(string sorgu, object param)
        {
            using (var connection = new MySqlConnection("Server=localhost;Database=kursyonetimi;User Id=root;Password=Muhamm3d!1;"))
            {
                var list = connection.Query<user_role>(sorgu, param).ToList();

                return list;
            }
        }

        public user_role user_roletek(string sorgu, object param)
        {
            using (var connection = new MySqlConnection("Server=localhost;Database=kursyonetimi;User Id=root;Password=Muhamm3d!1;"))
            {
                var item = connection.Query<user_role>(sorgu, param).FirstOrDefault();

                return item;
            }
        }

        public int user_roleekle(user_role userrole)
        {
            using (var connection = new MySqlConnection("Server=localhost;Database=kursyonetimi;User Id=root;Password=Muhamm3d!1;"))
            {
                var item = connection.Execute("insert into userrole (rolename) values (@rolename)", userrole);
                return item;
            }
        }

        public int user_roleguncelle(user_role userrole)
        {
            using (var connection = new MySqlConnection("Server=localhost;Database=kursyonetimi;User Id=root;Password=Muhamm3d!1;"))
            {
                var item = connection.Execute("update user_role set rolename = @rolename, isactive= @isactive where id = @id", userrole);
                return item;
            }
        }
    }
}
