using SovcomTech.UsersAndAwards.BL_Interface;
using SovcomTech.UsersAndAwards.BLL;
using SovcomTech.UsersAndAwards.DAL;
using SovcomTech.UsersAndAwards.DAL_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SovcomTech.UsersAndAwards.Common
{
    public static class Dependencies
    {
        private static IUser_DAO _usersDao;
        public static IUser_DAO user_DAO => _usersDao ?? (new Users_DAO());

        private static IAward_DAO _awardDao;
        public static IAward_DAO award_Dao => _awardDao ?? (new Award_DAO());


        private static IBL_User_Interface _userLogic;
        public static IBL_User_Interface userLogic => _userLogic ?? (new UsersLogic(user_DAO));

        private static IBL_Award_Interface _awardLogic;
        public static IBL_Award_Interface awardLogic => _awardLogic ?? (new AwardLogic(award_Dao));
    }
}
