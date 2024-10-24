using Code_Dictionary.Model.Model;
using System.Collections.Generic;
using System.Linq;

namespace Code_Dictionary.Model.Repository
{
    public class StoreProcedureService
    {
        private readonly ExDbContext _context;

        public StoreProcedureService()
        {
            if (_context == null) _context = new ExDbContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        #region SP List Info
        public List<StoreProcedureDto> Get_P_SPs()
        {
            return _context.P_StoreProcedures.Select(StoreProcedureDto.P_SpFunc).ToList();
        }

        public List<StoreProcedureDto> Get_C_SPs()
        {
            return _context.C_StoreProcedures.Select(StoreProcedureDto.C_SpFunc).ToList();
        }

        public List<StoreProcedureDto> Get_R_SPs()
        {
            return _context.R_StoreProcedures.Select(StoreProcedureDto.R_SpFunc).ToList();
        }
        #endregion

        #region SP Get Info
        public StoreProcedure.P_StoreProcedure Get_P_SP(int spId)
        {
            return _context.P_StoreProcedures.FirstOrDefault(p => p.SpId == spId);

        }
        public StoreProcedure.C_StoreProcedure Get_C_SP(int spId)
        {
            return _context.C_StoreProcedures.FirstOrDefault(p => p.SpId == spId);

        }
        public StoreProcedure.R_StoreProcedure Get_R_SP(int spId)
        {
            return _context.R_StoreProcedures.FirstOrDefault(p => p.SpId == spId);

        }
        #endregion

        #region Creatae SP Info
        public StoreProcedure.P_StoreProcedure P_CreateEntityFromDto(StoreProcedureDto spDto)
        {

            var sp = new StoreProcedure.P_StoreProcedure
            {
                SpId = spDto.SpId,
                name1 = spDto.name1,
                name2 = spDto.name2,  //Dto는 화면에 보여지도록 기존의 data를 변환하는 목적을 가지고 있다. 이때 화면에 패스워드를 ****로 보여지게 할 수 있다.
                name3 = spDto.name3,
                name4 = spDto.name4,
                name5 = spDto.name5,
                name6 = spDto.name6,
                Sp_name = spDto.Sp_name,
                Description = spDto.Description
            };
            return sp;
        }
        public StoreProcedure.C_StoreProcedure C_CreateEntityFromDto(StoreProcedureDto spDto)
        {

            var sp = new StoreProcedure.C_StoreProcedure
            {
                SpId = spDto.SpId,
                name1 = spDto.name1,
                name2 = spDto.name2,  //Dto는 화면에 보여지도록 기존의 data를 변환하는 목적을 가지고 있다. 이때 화면에 패스워드를 ****로 보여지게 할 수 있다.
                name3 = spDto.name3,
                name4 = spDto.name4,
                name5 = spDto.name5,
                name6 = spDto.name6,
                Sp_name = spDto.Sp_name,
                Description = spDto.Description
            };
            return sp;
        }
        public StoreProcedure.R_StoreProcedure R_CreateEntityFromDto(StoreProcedureDto spDto)
        {

            var sp = new StoreProcedure.R_StoreProcedure
            {
                SpId = spDto.SpId,
                name1 = spDto.name1,
                name2 = spDto.name2,  //Dto는 화면에 보여지도록 기존의 data를 변환하는 목적을 가지고 있다. 이때 화면에 패스워드를 ****로 보여지게 할 수 있다.
                name3 = spDto.name3,
                name4 = spDto.name4,
                name5 = spDto.name5,
                name6 = spDto.name6,
                Sp_name = spDto.Sp_name,
                Description = spDto.Description
            };
            return sp;
        }

        public void Create_P_SP(StoreProcedureDto spDto)
        {
            var sp = P_CreateEntityFromDto(spDto);
            if (sp != null)
            {
                _context.P_StoreProcedures.Add(sp);
                _context.SaveChanges();
            }
        }
        public void Create_C_SP(StoreProcedureDto spDto)
        {
            var sp = C_CreateEntityFromDto(spDto);
            if (sp != null)
            {
                _context.C_StoreProcedures.Add(sp);
                _context.SaveChanges();
            }
        }
        public void Create_R_SP(StoreProcedureDto spDto)
        {
            var sp = R_CreateEntityFromDto(spDto);
            if (sp != null)
            {
                _context.R_StoreProcedures.Add(sp);
                _context.SaveChanges();
            }
        }
        #endregion

        #region Delete SP Info
        //DeleteUser는 오버라이딩을 사용한다. 
        public void Delete_P_SP(string spId)
        {
            var sp = _context.P_StoreProcedures.Find(spId);
            if (sp != null)
            {
                _context.P_StoreProcedures.Remove(sp);
                _context.SaveChanges();
            }
        }

        public void Delete_P_SP(StoreProcedureDto spDto)
        {
            var table = _context.P_StoreProcedures.Find(spDto.SpId);
            if (table != null)
            {
                _context.P_StoreProcedures.Remove(table);
                _context.SaveChanges();
            }

            //var user = SignOutListUser(userDto); // CreateListUser 메서드를 사용하지 않고 DeleteListUser를 따로 만들어서 Remove하는 이유는 CreateListUser에는 UserId, UserName, Email,Password 4가지 속성이 있다. 회원탈퇴는 userId랑 PW만 있으면 된다.
            //_context.Users.Remove(user);        // -> 이때, UserId(hgh1025) 랑 UserName(hgh1025) 등 동일한 값이 존재하는 경우, Error: System.InvalidOperationException: The instance of entity type ...(생략)... 오류가 나온다. 
            //_context.SaveChanges();             // -> 즉 이미 존재하는 값을(인스턴스) 이미 tracking하고 있는데 왜 또 찾아서 Remove() 하냐는 오류이다.
        }
        //DeleteUser는 오버라이딩을 사용한다. 
        public void Delete_C_SP(string spId)
        {
            var sp = _context.C_StoreProcedures.Find(spId);
            if (sp != null)
            {
                _context.C_StoreProcedures.Remove(sp);
                _context.SaveChanges();
            }
        }

        public void Delete_C_SP(StoreProcedureDto spDto)
        {
            var table = _context.C_StoreProcedures.Find(spDto.SpId);
            if (table != null)
            {
                _context.C_StoreProcedures.Remove(table);
                _context.SaveChanges();
            }

            //var user = SignOutListUser(userDto); // CreateListUser 메서드를 사용하지 않고 DeleteListUser를 따로 만들어서 Remove하는 이유는 CreateListUser에는 UserId, UserName, Email,Password 4가지 속성이 있다. 회원탈퇴는 userId랑 PW만 있으면 된다.
            //_context.Users.Remove(user);        // -> 이때, UserId(hgh1025) 랑 UserName(hgh1025) 등 동일한 값이 존재하는 경우, Error: System.InvalidOperationException: The instance of entity type ...(생략)... 오류가 나온다. 
            //_context.SaveChanges();             // -> 즉 이미 존재하는 값을(인스턴스) 이미 tracking하고 있는데 왜 또 찾아서 Remove() 하냐는 오류이다.
        }
        //DeleteUser는 오버라이딩을 사용한다. 
        public void Delete_R_SP(string spId)
        {
            var sp = _context.R_StoreProcedures.Find(spId);
            if (sp != null)
            {
                _context.R_StoreProcedures.Remove(sp);
                _context.SaveChanges();
            }
        }

        public void Delete_R_SP(StoreProcedureDto spDto)
        {
            var table = _context.R_StoreProcedures.Find(spDto.SpId);
            if (table != null)
            {
                _context.R_StoreProcedures.Remove(table);
                _context.SaveChanges();
            }

            //var user = SignOutListUser(userDto); // CreateListUser 메서드를 사용하지 않고 DeleteListUser를 따로 만들어서 Remove하는 이유는 CreateListUser에는 UserId, UserName, Email,Password 4가지 속성이 있다. 회원탈퇴는 userId랑 PW만 있으면 된다.
            //_context.Users.Remove(user);        // -> 이때, UserId(hgh1025) 랑 UserName(hgh1025) 등 동일한 값이 존재하는 경우, Error: System.InvalidOperationException: The instance of entity type ...(생략)... 오류가 나온다. 
            //_context.SaveChanges();             // -> 즉 이미 존재하는 값을(인스턴스) 이미 tracking하고 있는데 왜 또 찾아서 Remove() 하냐는 오류이다.
        }
        #endregion

        #region Update SP Info
        public void P_UpdateEntityFromDto(StoreProcedure.P_StoreProcedure sp, StoreProcedureDto spDto)
        {
            sp.name1 = spDto.name1;
            sp.name2 = spDto.name2;
            sp.name3 = spDto.name3;
            sp.name4 = spDto.name4;
            sp.name5 = spDto.name5;
            sp.name6 = spDto.name6;
            sp.Sp_name = spDto.Sp_name;
            sp.Description = spDto.Description;

        }

        public void C_UpdateEntityFromDto(StoreProcedure.C_StoreProcedure sp, StoreProcedureDto spDto)
        {
            sp.name1 = spDto.name1;
            sp.name2 = spDto.name2;
            sp.name3 = spDto.name3;
            sp.name4 = spDto.name4;
            sp.name5 = spDto.name5;
            sp.name6 = spDto.name6;
            sp.Sp_name = spDto.Sp_name;
            sp.Description = spDto.Description;

        }

        public void R_UpdateEntityFromDto(StoreProcedure.R_StoreProcedure sp, StoreProcedureDto spDto)
        {
            sp.name1 = spDto.name1;
            sp.name2 = spDto.name2;
            sp.name3 = spDto.name3;
            sp.name4 = spDto.name4;
            sp.name5 = spDto.name5;
            sp.name6 = spDto.name6;
            sp.Sp_name = spDto.Sp_name;
            sp.Description = spDto.Description;

        }

        public void Update_P_SP(StoreProcedureDto spDto)
        {
            var sp = _context.P_StoreProcedures.Find(spDto.SpId);  //수정 삭제는 Find 메서드로 해당 하나의 값만 수정, 삭제해야한다.
            if (sp != null)
            {
                P_UpdateEntityFromDto(sp, spDto);  //userDto(화면에서 오는 매개변수 데이터) 를 user(실제 DB에 반영 덮어씌운다.)
                //_context.Members.Update(user); // 덮어 씌워진 user를 update한다.
                _context.SaveChanges();
            }
        }

        public void Update_C_SP(StoreProcedureDto spDto)
        {
            var sp = _context.C_StoreProcedures.Find(spDto.SpId);  //수정 삭제는 Find 메서드로 해당 하나의 값만 수정, 삭제해야한다.
            if (sp != null)
            {
                C_UpdateEntityFromDto(sp, spDto);  //userDto(화면에서 오는 매개변수 데이터) 를 user(실제 DB에 반영 덮어씌운다.)
                //_context.Members.Update(user); // 덮어 씌워진 user를 update한다.
                _context.SaveChanges();
            }
        }

        public void Update_R_SP(StoreProcedureDto spDto)
        {
            var sp = _context.R_StoreProcedures.Find(spDto.SpId);  //수정 삭제는 Find 메서드로 해당 하나의 값만 수정, 삭제해야한다.
            if (sp != null)
            {
                R_UpdateEntityFromDto(sp, spDto);  //userDto(화면에서 오는 매개변수 데이터) 를 user(실제 DB에 반영 덮어씌운다.)
                //_context.Members.Update(user); // 덮어 씌워진 user를 update한다.
                _context.SaveChanges();
            }
        }
        #endregion
    }
}