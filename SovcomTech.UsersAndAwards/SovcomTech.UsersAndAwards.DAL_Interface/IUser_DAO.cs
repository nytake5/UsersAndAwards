using Entity_User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SovcomTech.UsersAndAwards.DAL_Interface
{
    public interface IUser_DAO
    {
		void AddUser(User user);
		void AddAward(Award award);
		void AddUserAward(int UserId, int AwardId);
		IEnumerable<User> DeleteUser(int id);
		IEnumerable<Award> DeleteAward(int id);
		void DeleteUserAward(int userId, int awardId);
		User GetById(int id);
		IEnumerable<User> GetAll();
		IEnumerable<Award> GetAwards();
		IEnumerable<KeyValuePair<int, int>> GetUserAward();
		string GetAwardsAtUser(int id);
		string FindAtAwards(int awardId);

	}
}
