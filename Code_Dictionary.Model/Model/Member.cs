using System;

namespace Code_Dictionary.Model.Model
{
    public class Member
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public string UserPass { get; set; }
        public DateTime BirthDate { get; set; }
        public int Status { get; set; }
        public string Gubun { get; set; }
        public string MobilePhone { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string Gender { get; set; }
        public DateTime Joindt { get; set; }
        public DateTime CreateDt { get; set; }
        public DateTime UpdateDt { get; set; }
        public DateTime LastLoginDt { get; set; }
        public bool Deleted { get; set; }

    }
}