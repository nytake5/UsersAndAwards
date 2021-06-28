using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using SovcomTech.UsersAndAwards.DAL_Award_Interface;
using SovcomTech.UsersAndAwards.Entity_Award;
using System.Configuration;

namespace SovcomTech.UsersAndAwards.DAL_Award
{
    public class Award_DAO : IAward_DAO
    {
        private string _connectionString;

        public Award_DAO()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
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
        public IEnumerable<Award> GetAwardsAtUser(int id)
        {
            var res = new List<Award>();
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
                    res.Add(new Award
                    {
                        Id = (int)reader["Id"],
                        Title = (string)reader["Title"]
                    });
                }
            }
            return res;
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
    }
}
