using _6._1.Common.Entities;
using _6._1.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;

namespace _6._1.DAL.DataBase
{
    public class UsersDAO : IUserDAO
    {
        private int maxId;
        private string _connectionString;
        public UsersDAO()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        }
        public int MaxId
        {
            get
            {
                using (var connection = new SqlConnection(_connectionString))
                {

                    var command = new SqlCommand("SELECT TOP 1 [Id] FROM dbo.[Users] ORDER BY [Id] DESC ", connection);
                    connection.Open();
                    var reader = command.ExecuteReader();

                    reader.Read();

                    maxId = (int)reader["Id"];

                }
                return maxId;
            }
            set
            {
                if (value <= maxId) throw new ArgumentException("Ошибка! Новый id должен быть больше maxId!!!");
                else maxId = value;
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT [Id], [Name], [Birthday], [Image] FROM dbo.[Users]", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                byte[] image = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Content\user.png"));
                while (reader.Read())
                {
                    var temp = reader["Image"];
                    if (!(temp is DBNull))
                    {
                        image = (byte[])temp;
                    }
                  
                    yield return new User((int)reader["Id"], (string)reader["Name"], (DateTime)reader["Birthday"], new List<int>(), image);

                }
            }
        }

        public bool Create(User user)
        {
            int result;
            using (var connection = new SqlConnection(_connectionString))
            {

                var commandInsert = new SqlCommand("INSERT INTO dbo.[Users] ([Id], [Name], [Birthday], [Image]) VALUES (@Id, @Name, @Birthday, @Image) ", connection);
                commandInsert.Parameters.AddWithValue("@Id", MaxId+1);
                commandInsert.Parameters.AddWithValue("@Name", user.Name);
                commandInsert.Parameters.AddWithValue("@Birthday", user.DoB);
                commandInsert.Parameters.AddWithValue("@Image", user.Image);
                connection.Open();
                result = commandInsert.ExecuteNonQuery();
            }
            if (result == 0)
            {
                return false;
            }
            return true;
        }

        public bool DeleteUser(int id)
        {
            int result;
            using (var connection = new SqlConnection(_connectionString))
            {
                var commandInsert = new SqlCommand("DELETE FROM dbo.[Users] WHERE [Id] = @Id ", connection);
                commandInsert.Parameters.AddWithValue("@Id", id);
                connection.Open();

                result = commandInsert.ExecuteNonQuery();
            }
            if (result == 0)
            {
                return false;
            }
            return true;
        }



        public User Get(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT [Id], [Name], [Birthday] FROM dbo.[Users] WHERE [Id] = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var reader = command.ExecuteReader();

                if (!reader.Read()) return null;

                var ent = new User((int)reader["Id"], (string)reader["Name"], (DateTime)reader["Birthday"], new List<int>());
                connection.Close();

                var commandAwards = new SqlCommand("SELECT [AwardId] FROM dbo.[UserAward] WHERE [UserId] = @Id", connection);
                commandAwards.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var readerAwards = commandAwards.ExecuteReader();

                var listOfAwards = new List<int>();
                while (readerAwards.Read())
                {
                    listOfAwards.Add((int)readerAwards["id_award"]);
                }

                ent.Awards = listOfAwards;

                return ent;
            }
        }

        public bool SaveImages(int id, byte[] img)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var commandInsert = new SqlCommand("UPDATE dbo.[Users] SET [Image] = @Img WHERE [Id] = @Id ", connection);
                commandInsert.Parameters.AddWithValue("@Id", id);
                commandInsert.Parameters.AddWithValue("@Image", img);

                connection.Open();

                var result = commandInsert.ExecuteNonQuery();
            }

            return true;
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
                var command = new SqlCommand("SELECT [Id], [Image] FROM dbo.[Users]", connection);
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


        public bool Update(User user)
        {
            byte[] image;
            int result;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("UPDATE dbo.[Users] SET  [Name] = @Name, [Birthday] = @Birthday, [Image] = @Image WHERE [Id]= @Id", connection);
                command.Parameters.AddWithValue("@Id", user.Id);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Birthday", user.DoB);
                command.Parameters.AddWithValue("@Image", user.Image);
                if (user.Image == null)
                {
                    command = new SqlCommand("UPDATE dbo.[Users] SET  [Name] = @Name, [Birthday] = @Birthday WHERE [Id]= @Id", connection);
                    command.Parameters.AddWithValue("@Id", user.Id);
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@Birthday", user.DoB);
                }
                connection.Open();
                result = command.ExecuteNonQuery();
            }
            if (result == 0)
            {
                return false;
            }
            return true;
        }
    }
}
