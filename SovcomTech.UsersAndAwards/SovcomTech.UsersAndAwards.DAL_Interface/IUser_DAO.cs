using Entity_User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SovcomTech.UsersAndAwards.Entity_Award;

namespace SovcomTech.UsersAndAwards.DAL_Interface
{
    public interface IUser_DAO
    {
		void AddUser(User user);
		void AddUserAward(int UserId, int AwardId);
		IEnumerable<User> DeleteUser(int id);
		void DeleteUserAward(int userId, int awardId);
		User GetById(int id);
		IEnumerable<User> GetAll();
		IEnumerable<KeyValuePair<int, int>> GetUserAward();
		IEnumerable<User> FindAtAwards(int awardId);

	}
}
