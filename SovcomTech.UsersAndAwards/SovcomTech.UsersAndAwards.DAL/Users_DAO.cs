using Entity_User;
using SovcomTech.UsersAndAwards.DAL_Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using Entity_User.MyException;

namespace SovcomTech.UsersAndAwards.DAL
{
    public class Users_DAO : IUser_DAO
    {
        private string _connectionString;

        public Users_DAO()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }
        public void AddUser(User user)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "AddUser";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(@"Name", user.Name);
                command.Parameters.AddWithValue(@"DOB", user.DateOfBirth);
                command.Parameters.AddWithValue(@"age", user.Age);
                var id = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "ID_WORKER",
                    Direction = ParameterDirection.Output
                };
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void AddAward(Award award)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "AddAward";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(@"title", award.Title);
                var id = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "ID_WORKER",
                    Direction = ParameterDirection.Output
                };
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void AddUserAward(int UserId, int AwardId)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    var command = sqlConnection.CreateCommand();
                    command.CommandText = "AddUserAward";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(@"userId", UserId);
                    command.Parameters.AddWithValue(@"awardId", AwardId);
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch(DependenciesEx ex)
            {
                throw ex;
            }
           
        }
        public IEnumerable<User> DeleteUser(int id)
        {
            var res = new List<User>();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RemoveUser";
                command.Parameters.AddWithValue(@"userId", id);
                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    res.Add(new User
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                        Age = (int)reader["Age"]
                    });
                }
            }
            return res;
        }
        public IEnumerable<Award> DeleteAward(int id)
        {
            var res = new List<Award>();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RemoveAward";
                command.Parameters.AddWithValue(@"awardId", id);
                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    res.Add(new Award
                    {
                        Id = (int)reader["Id"],
                        Title = (string)reader["Title"]
                    });
                }
            }
            return res;
        }
        public void DeleteUserAward(int userId, int awardId)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RemoveUserAward";
                command.Parameters.AddWithValue(@"userId", userId);
                command.Parameters.AddWithValue(@"awardId", awardId);
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }
        public string FindAtAwards(int awardId)
        {
            StringBuilder res = new StringBuilder("");
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetUsersAtAward";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(@"awardId", awardId);
                sqlConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res.Append((string)reader["Name"]).Append(" ");
                }
            }
            return res.ToString();
        }

        public IEnumerable<User> GetAll()
        {
            var res = new List<User>();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetAll";
                command.CommandType = CommandType.StoredProcedure;

                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    res.Add(new User
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                        Age = (int)reader["Age"]
                    });
                }
            }
            return res;
        }

        public string GetAwardsAtUser(int id)
        {
            StringBuilder res = new StringBuilder("");
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetAwardsAtUser";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(@"UserId", id);
                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    res.Append((string)reader["Title"]).Append(" ");
                }
            }
            return res.ToString();
        }
        public IEnumerable<Award> GetAwards()
        {
            var res = new List<Award>();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetAward";
                command.CommandType = CommandType.StoredProcedure;

                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    res.Add(new Award
                    {
                        Id = (int)reader["Id"],
                        Title = (string)reader["Title"]
                    });
                }
            }
            return res;
        }
        public User GetById(int id)
        {
            var res = new User();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetUserAtID";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue(@"userId", id);

                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    res.Id = (int)reader["Id"];
                    res.Name = (string)reader["Name"];
                    res.DateOfBirth = (DateTime)reader["DateOfBirth"];
                    res.Age = (int)reader["Age"];
                }
            }
            return res;
        }

        public IEnumerable<KeyValuePair<int, int>> GetUserAward()
        {
            var res = new List<KeyValuePair<int, int>>();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetUserAward";
                command.CommandType = CommandType.StoredProcedure;

                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    KeyValuePair<int, int> temp = 
                        new KeyValuePair<int, int>((int)reader["UserId"], (int)reader["AwardId"]);
                    res.Add(temp);
                }
            }
            return res;
        }

    }
}
