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
using SovcomTech.UsersAndAwards.Entity_Award;

namespace SovcomTech.UsersAndAwards.BLL
{
    public class UsersLogic : IBL_User_Interface
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

        public void AddUserAward(int UserId, int AwardId)
        {
            _user_DAO.AddUserAward(UserId, AwardId);
        }

        public IEnumerable<User> GetAll()
        {
            return _user_DAO.GetAll();
        }

        
        public IEnumerable<User> DeleteUser(int id)
        {
            return _user_DAO.DeleteUser(id);
        }

        public void DeleteUserAward(int userId, int awardId)
        {
            _user_DAO.DeleteUserAward(userId, awardId);
        }

        public User GetById(int id)
        {
            return _user_DAO.GetById(id);
        }

        public IEnumerable<KeyValuePair<int, int>> GetUserAward()
        {
            return _user_DAO.GetUserAward();
        }

        public IEnumerable<User> FindAtAwards(int awardId)
        {
            return _user_DAO.FindAtAwards(awardId);
        }
    }
}
