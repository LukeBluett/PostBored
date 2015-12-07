using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostBored
{
    interface MemberDAO
    {
        List<Member> GetAllMember();
        Member GetPost(int postId);
        void CreateMember();
        void DeleteMember();
    }
}
