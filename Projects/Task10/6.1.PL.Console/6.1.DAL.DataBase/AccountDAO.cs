using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6._1.Common.Entities;
using _6._1.DAL.Interfaces;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace _6._1.DAL.DataBase
{
    public class AccountDAO : IAccountDAO
    {
        private readonly string _connectionString;
        private Dictionary<int, string> _roleContainer;
        private int maxId;
        public DateTime Birthday { get; private set; }
        public int MaxId
        {
            get
            {
                using (var connection = new SqlConnection(_connectionString))
                {

                    var command = new SqlCommand("SELECT TOP 1 [Id] FROM dbo.[Accounts] ORDER BY [Id] DESC ", connection);
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
        public AccountDAO()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            _roleContainer = new Dictionary<int, string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT [Id], [Name] FROM dbo.[Roles]", connection);
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    _roleContainer[(int)reader["Id"]] = (string)reader["Name"];
                }
            }
        }

        public bool AddUser(string login, string password, string name, DateTime birthday, byte[] image)
        {
            if (Get(login) != null)
            {
                return false;
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                //ПРОВЕРКА ЕСТЬ ЛИ ТАКОЙ ПОЛЬЗОВАТЕЛЬ В БД
                var commandSelect = new SqlCommand("SELECT [Login], [Password] FROM dbo.[Accounts] WHERE [Login] = @Login", connection);
                commandSelect.Parameters.AddWithValue("@Login", login);
                connection.Open();
                var reader = commandSelect.ExecuteReader();

                if (reader.Read() && reader["Login"] == login)
                {
                    return false;//если такой пользователь уже есть в бд
                }
                connection.Close();

                var commandInsert = new SqlCommand("INSERT INTO dbo.[Accounts] ([Id],[Login], [Password], [Name], [Birthday], [Image]) VALUES (@Id, @Login, @Password, @Name, @Birthday, @Image) SELECT SCOPE_IDENTITY()", connection);
                commandInsert.Parameters.AddWithValue("@Id", MaxId + 1);
                commandInsert.Parameters.AddWithValue("@Login", login);
                commandInsert.Parameters.AddWithValue("@Password", password);
                commandInsert.Parameters.AddWithValue("@Name", name);
                commandInsert.Parameters.AddWithValue("@Birthday", birthday);
                commandInsert.Parameters.AddWithValue("@Image", image);
                connection.Open();

                int id = int.Parse(commandInsert.ExecuteScalar().ToString());
                connection.Close();
                return true;
            }
        }

        public bool AddRole(string login, string role)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                //ПРОВЕРКА ЕСТЬ ЛИ ТАКОЙ ПОЛЬЗОВАТЕЛЬ В БД
                var user = Get(login);

                if (user == null)
                {
                    return false;
                }

                //ПРОВЕРКА ЕСЛИ ЛИ У ЭТОГО ПОЛЬЗОВАТЕЛЯ ТАКАЯ РОЛЬ В БД
                if (user.Roles.Contains(role))
                {
                    return false;
                }

                //ДОБАВЛЕНИЕ РОЛИ ПОЛЬЗОВАТЕЛЮ
                #region Add_Role

                var commandInsert = new SqlCommand("INSERT INTO dbo.[AccountRole] ([Id_account], [Id_role]) VALUES (@Id_account, @Id_role) ", connection);
                commandInsert.Parameters.AddWithValue("@Id_account", user.Id);
                commandInsert.Parameters.AddWithValue("@Id_role", _roleContainer.FirstOrDefault(x => x.Value == role).Key);
                connection.Open();
                var result = commandInsert.ExecuteNonQuery();
                return true;

                #endregion

            }
        }

        public Account Get(string login)
        {
            Account ent = null;

            using (var connection = new SqlConnection(_connectionString))//запоминаем только пользователей с паролями
            {
                var command = new SqlCommand("SELECT [Id], [Login], [Password], [Name], [Birthday], [Image] FROM dbo.[Accounts] WHERE [Login] = @Login", connection);
                command.Parameters.AddWithValue("@Login", login);
                connection.Open();
                var reader = command.ExecuteReader();

                byte[] image = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Content\user.png"));

                if (!reader.Read()) return null;

                var temp = reader["Image"];
                if (!(temp is DBNull))
                {
                    image = (byte[])temp;
                }
                ent = new Account((int)reader["Id"], (string)reader["Login"], (string)reader["Password"], (string)reader["Name"],
                                    (DateTime)reader["Birthday"], image, new List<string>());
            }

            using (var connection = new SqlConnection(_connectionString))//для каждому пользователю присваиваем роли из БД
            {
                var command = new SqlCommand("SELECT [Id_account], [Id_role] FROM dbo.[AccountRole] WHERE [Id_account] = @Id", connection);
                command.Parameters.AddWithValue("@Id", ent.Id);
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ent.Roles.Add(_roleContainer[(int)reader["Id_role"]]);
                }
            }

            return ent;
        }

        public Account Get(int accountId)
        {
            Account ent = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT [Id], [Login], [Password], [Name], [Birthday], [Image] FROM dbo.[Account] WHERE [Id] = @Id", connection);
                command.Parameters.AddWithValue("@Id", accountId);
                connection.Open();
                var reader = command.ExecuteReader();
                byte[] image = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Content\user.png"));

                if (!reader.Read()) return null;
                var temp = reader["Image"];
                if (!(temp is DBNull))
                {
                    image = (byte[])temp;
                }
                ent = new Account((int)reader["Id"], (string)reader["Login"], (string)reader["Password"], (string)reader["Name"],
                                    (DateTime)reader["Birthday"], image, new List<string>());
            }

            using (var connection = new SqlConnection(_connectionString))//для каждому пользователю присваиваем роли из БД
            {
                var command = new SqlCommand("SELECT [Id_account], [Id_role] FROM dbo.[AccountRole] WHERE [Id_accounts] = @Id", connection);
                command.Parameters.AddWithValue("@Id", ent.Id);
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ent.Roles.Add(_roleContainer[(int)reader["Id_role"]]);
                }
            }

            return ent;
        }

        public IEnumerable<Account> GetAll()
        {
            List<Account> accounts = new List<Account>();


            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT [Id], [Login], [Name], [Birthday], [Image] FROM dbo.[Accounts]", connection);
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
                    accounts.Add(new Account((int)reader["Id"], (string)reader["Login"], Password: "", name: (string)reader["Name"],
                             birthday: (DateTime)reader["Birthday"], image: image, roles: new List<string>()));
                }
            }


            foreach (var item in accounts)
            {
                using (var connection = new SqlConnection(_connectionString))//для каждому пользователю присваиваем роли из БД
                {
                    var command = new SqlCommand("SELECT [Id_account], [Id_role] FROM dbo.[AccountRole] WHERE [Id_account] = @Id_account", connection);
                    command.Parameters.AddWithValue("@Id_account", item.Id);
                    connection.Open();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        item.Roles.Add(_roleContainer[(int)reader["Id_role"]]);
                    }
                }
            }


            foreach (var item in accounts)
            {
                yield return item;
            }
        }
        public void EditAccount(Account user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("UPDATE dbo.[Accounts] SET [Password] = @Password, [Name] = @Name, [Birthday] = @Birthday, [Image] = @Image WHERE [Login] = @Login ", connection);
                command.Parameters.AddWithValue("@Login", user.Login);
                command.Parameters.AddWithValue("@Password", user.password);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Birthday", user.Birthday);
                command.Parameters.AddWithValue("@Image", user.Image);
                connection.Open();
                var result = command.ExecuteNonQuery();
            }
        }

        public bool AddUserToRole(string name, string roleName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmdAddRelationship = connection.CreateCommand();
                cmdAddRelationship.CommandText = @"INSERT INTO dbo.AccountRole (Id_account, Id_role) VALUES (
                                                  (SELECT Id FROM dbo.Accounts WHERE dbo.Accounts.Login = @Login),
                                                  (SELECT Id FROM dbo.Roles WHERE dbo.Roles.Name = @Role)
                                                  )";
                cmdAddRelationship.Parameters.AddWithValue("@Login", name);
                cmdAddRelationship.Parameters.AddWithValue("@Role", roleName);
                connection.Open();
                var result = cmdAddRelationship.ExecuteNonQuery();
                if (result == 0)
                {
                    return false;
                }
                return true;
            }
        }

        public bool RemoveUserFromRole(string login, string roleName)
        {
            var user = Get(login);
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("DELETE FROM dbo.[AccountRole] WHERE [Id_account] = @Id_account And [Id_role] = @Id_role ", connection);
                command.Parameters.AddWithValue("@Id_account", user.Id);
                command.Parameters.AddWithValue("@Id_role", _roleContainer.FirstOrDefault(x => x.Value == roleName).Key);
                connection.Open();

                var result = command.ExecuteNonQuery();
            }
            return true;
        }

        public bool IsUserInRole(string name, string roleName)
        {
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var cmdReadRelationship = connection.CreateCommand();
                    cmdReadRelationship.CommandText = @"SELECT Id FROM dbo.AccountRole WHERE ( 
                                                    Id_account=(SELECT Id FROM dbo.Accounts WHERE dbo.Accounts.Login = @Login) 
                                                    AND
                                                    Id_role=(SELECT Id FROM dbo.Roles WHERE dbo.Roles.Name = @Name)
                                                    )";
                    cmdReadRelationship.Parameters.AddWithValue("@Login", name);
                    cmdReadRelationship.Parameters.AddWithValue("@Name", roleName);
                    connection.Open();
                    var reader = cmdReadRelationship.ExecuteScalar();
                    if (reader == null)
                    {
                        return false;
                    }
                    return true;
                }
            }
        }

        public bool IsUserRegistrated(string login)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmdReadUsers = connection.CreateCommand();
                cmdReadUsers.CommandText = @"SELECT Id FROM dbo.Accounts WHERE Login=@Login";
                cmdReadUsers.Parameters.AddWithValue("@Login", login);
                connection.Open();
                var reader = cmdReadUsers.ExecuteScalar();
                if (reader == null)
                {
                    return false;
                }
                return true;
            }
        }

        public bool IsUserRegistrated(string login, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmdReadUsers = connection.CreateCommand();
                cmdReadUsers.CommandText = @"SELECT Id FROM dbo.Accounts WHERE Login=@Login AND Password=@Password";
                cmdReadUsers.Parameters.AddWithValue("@Login", login);
                cmdReadUsers.Parameters.AddWithValue("@Password", password);
                connection.Open();
                var reader = cmdReadUsers.ExecuteScalar();
                if (reader == null)
                {
                    return false;
                }
                return true;
            }
        }

        public string[] GetRolesForUser(string username)
        {
            List<string> temp = new List<string>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmdReadRelationship = connection.CreateCommand();
                cmdReadRelationship.CommandText = @"SELECT z.Name as Role FROM dbo.Accounts p 
                                                    JOIN dbo.AccountRole r ON p.Id = r.Id_account
                                                    JOIN dbo.Roles z ON r.Id_role = z.Id 
                                                    WHERE p.Name=@Name";
                cmdReadRelationship.Parameters.AddWithValue("@Name", username);
                connection.Open();
                var reader = cmdReadRelationship.ExecuteReader();
                while (reader.Read())
                {
                    temp.Add((string)reader["Role"]);
                }
            }
            return temp.ToArray();
        }
    }
}