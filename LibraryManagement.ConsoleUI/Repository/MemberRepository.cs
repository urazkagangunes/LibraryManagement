using LibraryManagement.ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagement.ConsoleUI.Repository
{
    public class MemberRepository : BaseRepository, IMemberRepository
    {
        private List<Member> _members;

        public MemberRepository()
        {
            _members = Members();
        }

        public Member Add(Member created)
        {
            throw new NotImplementedException();
        }

        public List<Member> GetAll()
        {
            throw new NotImplementedException();
        }

        public Member? GetByID(string id)
        {
            throw new NotImplementedException();
        }

        public Member? Remove(string id)
        {
            throw new NotImplementedException();
        }
    }
}
