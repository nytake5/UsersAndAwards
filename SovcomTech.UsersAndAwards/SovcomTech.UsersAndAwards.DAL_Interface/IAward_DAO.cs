using SovcomTech.UsersAndAwards.Entity_Award;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SovcomTech.UsersAndAwards.DAL_Interface
{
    public interface IAward_DAO
    {
        void AddAward(Award award);
        IEnumerable<Award> DeleteAward(int id);
        IEnumerable<Award> GetAwards();
        IEnumerable<Award> GetAwardsAtUser(int id);
    }
}
