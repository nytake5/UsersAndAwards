using Entity_User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SovcomTech.UsersAndAwards.Entity_Award;

namespace SovcomTech.UsersAndAwards.BL_Interface
{
    public interface IBL_Interface
    {
		void AddUser(string name, DateTime dateOfBirht);
		void AddAward(string title);
		void AddUserAward(int UserId, int AwardId);
		IEnumerable<User> DeleteUser(int id);
		IEnumerable<Award> DeleteAward(int id);
		void DeleteUserAward(int userId, int awardId);
		User GetById(int id);
		IEnumerable<User> GetAll();
		IEnumerable<Award> GetAwards();
		IEnumerable<KeyValuePair<int, int>> GetUserAward();
		IEnumerable<Award> GetAwardsAtUser(int id);
		IEnumerable<User> FindAtAwards(int awardId);
	}
}
