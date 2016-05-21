using _6._1.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6._1.Common.Entities;
using System.Configuration;
using System.Data.SqlClient;

namespace _6._1.DAL.DataBase
{
    public class RelationDAO : IRelationDAO
    {
        public static List<Relation> Relations;

        private string _connectionString;

        public RelationDAO()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        }

        public bool Create(Relation relation)
        {
            int result;
            using (var connection = new SqlConnection(_connectionString))
            {

                var commandInsert = new SqlCommand("INSERT INTO dbo.[UserAward] ([id_user], [id_award]) VALUES (@id_user, @id_award) ", connection);
                commandInsert.Parameters.AddWithValue("@id_user", relation.UserId);
                commandInsert.Parameters.AddWithValue("@id_award", relation.AwardId);
                connection.Open();
                result = commandInsert.ExecuteNonQuery();
            }
            if (result == 0)
            {
                return false;
            }
            return true;
        }

        public bool Create(int userId, int awardId)
        {
            int result;
            using (var connection = new SqlConnection(_connectionString))
            {

                var commandInsert = new SqlCommand("INSERT INTO dbo.[UserAward] ([id_user], [id_award]) VALUES (@id_user, @id_award) ", connection);
                commandInsert.Parameters.AddWithValue("@id_user", userId);
                commandInsert.Parameters.AddWithValue("@id_award", awardId);
                connection.Open();
                result = commandInsert.ExecuteNonQuery();
            }
            if (result == 0)
            {
                return false;
            }
            return true;
        }

        public bool DeleteAwardFromUsers(int id)
        {
            int result;
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmdDel = connection.CreateCommand();
                cmdDel.CommandText = "DELETE FROM dbo.UserAward WHERE  (Id_award=@Id_award)";
                cmdDel.Parameters.AddWithValue("@Id_award", id);
                connection.Open();
                result = cmdDel.ExecuteNonQuery();
            }
            return true;
        }

        public bool DeleteRelation(Relation relation)
        {
            int result;
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmdDel = connection.CreateCommand();
                cmdDel.CommandText = "DELETE FROM dbo.UserAward WHERE (Id_award=@Id_award) AND (Id_user=@Id_user)";
                cmdDel.Parameters.AddWithValue("@Id_award", relation.AwardId);
                cmdDel.Parameters.AddWithValue("@Id_user", relation.UserId);
                connection.Open();
                result = cmdDel.ExecuteNonQuery();
            }
            if (result == 0)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Relation> GetAll()
        {

            Relations = new List<Relation>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmdReadJoin = connection.CreateCommand();
                cmdReadJoin.CommandText = "SELECT Id_user, Id_award FROM dbo.UserAward";
                connection.Open();
                using (var reader = cmdReadJoin.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int award_id = (int)reader["Id_user"];
                        int user_id = (int)reader["Id_award"];
                        Relation temp = new Relation(user_id, award_id);
                        Relations.Add(temp);
                    }
                }
            }
            return Relations;
        }
    }
}
