using SovcomTech.UsersAndAwards.BL_Interface;
using SovcomTech.UsersAndAwards.DAL_Interface;
using SovcomTech.UsersAndAwards.Entity_Award;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SovcomTech.UsersAndAwards.BLL
{
    public class AwardLogic : IBL_Award_Interface
    {
        private readonly IAward_DAO _award_DAO;
        public AwardLogic(IAward_DAO award_DAO)
        {
            try
            {
                _award_DAO = award_DAO;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void AddAward(string title)
        {
            var award = new Award(title);
            _award_DAO.AddAward(award);
        }
        public IEnumerable<Award> GetAwardsAtUser(int id)
        {
            return _award_DAO.GetAwardsAtUser(id);
        }
        public IEnumerable<Award> DeleteAward(int id)
        {
            return _award_DAO.DeleteAward(id);
        }
        public IEnumerable<Award> GetAwards()
        {
            return _award_DAO.GetAwards();
        }
    }
}
