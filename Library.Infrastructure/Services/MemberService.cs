using Library.Application.Interfaces;
using Library.Domain;
using Library.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Infrastructure.Services
{
    public class MemberService : IMemberService
    {
        private readonly ApplicationDbContext context;
        public MemberService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void AddMember(Member member)
        {
            context.Add(member);
            context.SaveChanges();
        }

        public IList<Member> GetAllMembers()
        {
            return context.Members.OrderBy(x => x.Name).ToList();
        }

        public Author GetMember(int id)
        {
            throw new NotImplementedException();
        }
    }
}
