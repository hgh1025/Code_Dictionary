using Code_Dictionary.Model.Dto;
using Code_Dictionary.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Code_Dictionary.Model.Repository
{
    public class MemberService
    {
        private readonly ExDbContext _context;

        public MemberService()
        {
            if (_context == null) _context = new ExDbContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        //public List<User> ListUser()
        //{
        //    return _context.Users.Any();
        //}
        public List<MemberDto> GetUsers()
        {
            return _context.Members.Select(MemberDto.MemberFunc).ToList();
        }
        public Member GetLoginUser(string userId, string pw)
        {
            return _context.Members.FirstOrDefault(p => p.UserId == userId && p.UserPass == pw);

        }
        public Member CreateEntityFromDto(MemberDto userDto)
        {
            SHA256Managed sha = new SHA256Managed();
            byte[] encryptBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(userDto.UserPass)); //sha256를 사용하기 위해 바이트로 변환해줘야한다.
            String encryptStringPW = Convert.ToBase64String(encryptBytes); //바이트로 변환된 pw를 64비트 문자열로 다시 변환한다.
            var users = new Member
            {
                UserId = userDto.UserId,
                MemberName = userDto.MemberName,
                Email = userDto.Email,
                UserPass = encryptStringPW

            };
            return users;
        }



        public void CreateMember(MemberDto userDto)
        {
            var user = CreateEntityFromDto(userDto);
            if (user != null)
            {
                _context.Members.Add(user);
                _context.SaveChanges();
            }
        }


        //DeleteUser는 오버라이딩을 사용한다. 
        public void DeleteMember(string userId)
        {
            var user = _context.Members.Find(userId);
            if (user != null)
            {
                _context.Members.Remove(user);
                _context.SaveChanges();
            }
        }

        public void DeleteMember(MemberDto userDto)
        {
            var user = _context.Members.Find(userDto.UserId);
            if (user != null)
            {
                _context.Members.Remove(user);
                _context.SaveChanges();
            }

            //var user = SignOutListUser(userDto); // CreateListUser 메서드를 사용하지 않고 DeleteListUser를 따로 만들어서 Remove하는 이유는 CreateListUser에는 UserId, UserName, Email,Password 4가지 속성이 있다. 회원탈퇴는 userId랑 PW만 있으면 된다.
            //_context.Users.Remove(user);        // -> 이때, UserId(hgh1025) 랑 UserName(hgh1025) 등 동일한 값이 존재하는 경우, Error: System.InvalidOperationException: The instance of entity type ...(생략)... 오류가 나온다. 
            //_context.SaveChanges();             // -> 즉 이미 존재하는 값을(인스턴스) 이미 tracking하고 있는데 왜 또 찾아서 Remove() 하냐는 오류이다.
        }

        //public User SignOutListUser(UserDto userDto)     --->> 이렇게 하면 코드가 길어지고 번거롭기 때문에, Find 메서드로 userid를 찾고 이에 해당하는 정보를 삭제하도록한다.
        //{
        //    var users = new User
        //    {
        //        UserId = userDto.UserId,

        //        Password = userDto.Password
        //    };
        //    return users;
        //}

        public void UpdateEntityFromDto(Member user, MemberDto userDto)
        {
            SHA256Managed sha = new SHA256Managed();
            byte[] encryptBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(userDto.UserPass)); //sha256를 사용하기 위해 바이트로 변환해줘야한다.
            String encryptStringPW = Convert.ToBase64String(encryptBytes); //바이트로 변환된 pw를 64비트 문자열로 다시 변환한다.
            //user.UserId = userDto.UserId;   userid는 PK로 설정되어 있기 때문에, 수정을 해도 DB에 반영이 안된다.
            user.MemberName = userDto.MemberName;
            user.Email = userDto.Email;
            user.UserPass = encryptStringPW;

        }

        public void UpdateUser(MemberDto userDto)
        {
            var user = _context.Members.Find(userDto.UserId);  //수정 삭제는 Find 메서드로 해당 하나의 값만 수정, 삭제해야한다.
            if (user != null)
            {
                UpdateEntityFromDto(user, userDto);  //userDto(화면에서 오는 매개변수 데이터) 를 user(실제 DB에 반영 덮어씌운다.)
                //_context.Members.Update(user); // 덮어 씌워진 user를 update한다.
                _context.SaveChanges();
            }
        }


    }
}