using Code_Dictionary.Model.Model;
using System;

namespace Code_Dictionary.Model.Dto
{
    public class MemberDto
    {
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public string UserPass { get; set; }
        public DateTime BirthDate { get; set; }
        public string Status { get; set; }
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

        public static Func<Member, MemberDto> MemberFunc = (user) =>
        new MemberDto
        {
            Email = user.Email,
            MemberName = user.MemberName,
            UserPass = "****",  //Dto는 화면에 보여지도록 기존의 data를 변환하는 목적을 가지고 있다. 이때 화면에 패스워드를 ****로 보여지게 할 수 있다.
            UserId = user.UserId
        };
    }

}