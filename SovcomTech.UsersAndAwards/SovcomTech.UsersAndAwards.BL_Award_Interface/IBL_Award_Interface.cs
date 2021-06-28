using SovcomTech.UsersAndAwards.Entity_Award;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SovcomTech.UsersAndAwards.BL_Award_Interface
{
    public interface IBL_Award_Interface
    {
        void AddAward(string title);
        IEnumerable<Award> DeleteAward(int id);
        IEnumerable<Award> GetAwards();
        IEnumerable<Award> GetAwardsAtUser(int id);
    }
}
