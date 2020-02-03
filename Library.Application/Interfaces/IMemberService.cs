using Library.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Interfaces
{
    public interface IMemberService
    {
        IList<Member> GetAllMembers();

        Author GetMember(int id);
        void AddMember(Member member);
    }
}
