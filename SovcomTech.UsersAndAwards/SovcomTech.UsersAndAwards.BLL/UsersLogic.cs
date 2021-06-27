using Entity_User;
using Entity_User.MyException;
using SovcomTech.UsersAndAwards.BL_Interface;
using SovcomTech.UsersAndAwards.DAL_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SovcomTech.UsersAndAwards.BLL
{
    public class UsersLogic : IBL_Interface
    {
        private readonly IUser_DAO _user_DAO;
        public UsersLogic(IUser_DAO user_DAO)
        {
            try
            {
                _user_DAO = user_DAO;
            }
            catch (ConnectionEx ex)
            {
                throw ex;
            }
            
        }
        public void AddUser(string name, DateTime dateOfBirht)
        {
            
            DateTime now = DateTime.Today;
            int age = now.Year - dateOfBirht.Year;
            var user = new User(name, dateOfBirht, age);
            _user_DAO.AddUser(user);
        }
        public void AddAward(string title)
        {
            var award = new Award(title);
            _user_DAO.AddAward(award);
        }
        public void AddUserAward(int UserId, int AwardId)
        {
            try
            {
                _user_DAO.AddUserAward(UserId, AwardId);
            }
            catch (DependenciesEx ex)
            {
                throw ex;
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _user_DAO.GetAll();
        }

        public string GetAwardsAtUser(int id)
        {
            return _user_DAO.GetAwardsAtUser(id);
        }

        public IEnumerable<User> DeleteUser(int id)
        {
            return _user_DAO.DeleteUser(id);
        }

        public IEnumerable<Award> DeleteAward(int id)
        {
            
            return _user_DAO.DeleteAward(id);
            
        }
        public void DeleteUserAward(int userId, int awardId)
        {
            _user_DAO.DeleteUserAward(userId, awardId);
        }

        public User GetById(int id)
        {
            return _user_DAO.GetById(id);
        }

        public IEnumerable<Award> GetAwards()
        {
            return _user_DAO.GetAwards();
        }

        public IEnumerable<KeyValuePair<int, int>> GetUserAward()
        {
            return _user_DAO.GetUserAward();
        }

        public string FindAtAwards(int awardId)
        {
            return _user_DAO.FindAtAwards(awardId);
        }
    }
}
