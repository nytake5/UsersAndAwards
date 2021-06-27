﻿using SovcomTech.UsersAndAwards.BL_Interface;
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

        private static IBL_Interface _userLogic;
        public static IBL_Interface userLogic => _userLogic ?? (new UsersLogic(user_DAO));
    }
}
