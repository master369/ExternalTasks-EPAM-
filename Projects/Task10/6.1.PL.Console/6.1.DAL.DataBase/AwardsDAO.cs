using _6._1.Common.Entities;
using _6._1.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace _6._1.DAL.DataBase
{
   public class AwardsDAO : IAwardsDAO
    {

        private int maxId;
        private string _connectionString;

        public AwardsDAO()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        }

        public IEnumerable<Award> GetAllAwards()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT [Id], [Name], [Image] FROM dbo.[Awards]", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                byte[] image;
                try
                {
                    image = (byte[])reader["Image"];
                }
                catch (Exception)
                {
                    image = noFile();
                }

                while (reader.Read())
                {
                    yield return new Award((int)reader["Id"], (string)reader["Name"], new List<int>(), image);
                }
            }
        }

        #region Operations

        public bool Update(Award award)
        {
            int result;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("UPDATE dbo.[Awards] SET [Name] = @Name WHERE [Id] = @Id ", connection);
                command.Parameters.AddWithValue("@Id", award.Id);
                command.Parameters.AddWithValue("@Name", award.Name);
                command.Parameters.AddWithValue("@Image", award.Image);
                connection.Open();
                result = command.ExecuteNonQuery();

            }
            if (result == 0)
            {
                return false;
            }
            return true;
        }
        public bool Create(Award award)
        {
            using (var connection = new SqlConnection(_connectionString))
            {

                var commandInsert = new SqlCommand("INSERT INTO dbo.[Awards] ([Name]) VALUES (@Name) ", connection);
                commandInsert.Parameters.AddWithValue("@Name", award.Name);
                connection.Open();

                var result1 = commandInsert.ExecuteNonQuery();
                connection.Close();

                var command = new SqlCommand("UPDATE dbo.[UserAward] SET [id_award] = @Id WHERE [Id] = 0 ", connection);
                command.Parameters.AddWithValue("@Id", award.Id);

                connection.Open();

                var result = commandInsert.ExecuteNonQuery();


                return true;

            }
        }

        public bool DeleteAward(int id)
        {
            int result1;
            using (var connection = new SqlConnection(_connectionString))
            {
                var commandInsert = new SqlCommand("DELETE FROM dbo.[id_award] WHERE [Id] = @Id ", connection);
                commandInsert.Parameters.AddWithValue("@Id", id);
                connection.Open();

                var result = commandInsert.ExecuteNonQuery();
                connection.Close();

                var command = new SqlCommand("UPDATE dbo.[UserAward] SET [id_award] = 0 WHERE [id_user] = @Id ", connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                result1 = command.ExecuteNonQuery();

            }
            if (result1 == 0)
            {
                return false;
            }
            return true;
        }

        public Award Get(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT [Id], [Name] FROM dbo.[Awards] WHERE [Id] = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var reader = command.ExecuteReader();

                if (!reader.Read()) return null;

                return new Award((int)reader["Id"], (string)reader["Name"], new List<int>());
            }
        }

        public byte[] noFile()
        {
            return File.ReadAllBytes(@"C:\Users\Master\Documents\Visual Studio 2015\Projects\6.1.PL.Console\Task10\Content\user.png");

        }

        public Dictionary<int, byte[]> LoadImages()
        {
            var dict = new Dictionary<int, byte[]>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT [Id], [Image] FROM dbo.[Awards]", connection);
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["Image"].ToString() != "")
                        dict[(int)reader["Id"]] = (byte[])reader["Image"];
                }
            }

            return dict;
        }

        public bool SaveImages(int id, byte[] img)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var commandInsert = new SqlCommand("UPDATE dbo.[Awards] SET [Image] = @Img WHERE [Id] = @Id ", connection);
                commandInsert.Parameters.AddWithValue("@Id", id);
                commandInsert.Parameters.AddWithValue("@Image", img);

                connection.Open();

                var result = commandInsert.ExecuteNonQuery();
            }

            return true;
        }
        #endregion




    }
}
