using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MemberDAO
    {
        FStoreDBAssignmentContext FStoreContext = new FStoreDBAssignmentContext();
        List<Member> MemberList = new List<Member>();


        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();



        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }

        public List<Member> Members()
        {

            var memberList = (from mem in FStoreContext.Members.Include(m => m.Orders) select mem).ToList();

            return memberList;
        }

        public List<Member> GetMemberList => (from mem in FStoreContext.Members.Include(m => m.Orders) select mem).ToList();

        public void DeleteMember(int memberId)
        {
            if (GetMemberByID(memberId) != null)
            {
                FStoreContext.Remove(FStoreContext.Members.First<Member>(p => p.MemberId == memberId));
                FStoreContext.SaveChanges();
            }
            else
            {
                throw new Exception("Invalid ID");
            }
        }

        public Member GetMemberByEmail(string email)
        {
            Member member = FStoreContext.Members.SingleOrDefault(p => p.Email.Equals(email));
            return member;
        }

        public Member GetMemberByID(int memberid)
        {
            Member member = FStoreContext.Members.Include(p=>p.Orders).SingleOrDefault(p => p.MemberId == memberid);
            return member;
        }

        public void InsertMember(Member member)
        {
            if (GetMemberByID(member.MemberId) == null && GetMemberByEmail(member.Email) == null)
            {
                member.Orders = new List<Order>();
                FStoreContext.Members.Add(member);
                FStoreContext.SaveChanges();
            }
            else
            {
                throw new Exception("Member ID/Email is already exists.");

            }
        }

        public void UpdateMember(Member member)
        {
            var mem = (from u in FStoreContext.Members where u.MemberId == member.MemberId select u).SingleOrDefault();
            List<Order> orders = (from a in FStoreContext.Orders where a.MemberId == member.MemberId select a).ToList();
            if (mem != null)
            {
                mem.CompanyName = member.CompanyName;
                mem.Email = member.Email;
                mem.Country = member.Country;
                mem.City = member.City;
                mem.Password = member.Password;
                mem.Orders = orders;
                FStoreContext.SaveChanges();
            }
            else
            {
                throw new Exception("Member does not exitst");
            }
        }


    }
}
