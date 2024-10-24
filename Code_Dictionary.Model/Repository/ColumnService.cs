using Code_Dictionary.Model.Dto;
using Code_Dictionary.Model.Model;
using System.Collections.Generic;
using System.Linq;

namespace Code_Dictionary.Model.Repository
{
    public class ColumnService
    {
        private readonly ExDbContext _context;

        public ColumnService()
        {
            if (_context == null) _context = new ExDbContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        #region Column List Info
        public List<ColumnDto> Get_P_Columns()
        {
            return _context.P_Columns.Select(ColumnDto.P_ColumnFunc).ToList();
        }

        public List<ColumnDto> Get_C_Columns()
        {
            return _context.C_Columns.Select(ColumnDto.C_ColumnFunc).ToList();
        }

        public List<ColumnDto> Get_R_Columns()
        {
            return _context.R_Columns.Select(ColumnDto.R_ColumnFunc).ToList();
        }
        #endregion

        #region Column Get INFO
        public Column.P_Column Get_P_Column(int columnId)
        {
            return _context.P_Columns.FirstOrDefault(p => p.ColumnId == columnId);

        }

        public Column.C_Column Get_C_Column(int columnId)
        {
            return _context.C_Columns.FirstOrDefault(p => p.ColumnId == columnId);

        }

        public Column.R_Column Get_R_Column(int columnId)
        {
            return _context.R_Columns.FirstOrDefault(p => p.ColumnId == columnId);

        }
        #endregion

        #region Create Column Info
        public Column.P_Column P_CreateEntityFromDto(ColumnDto columnDto)
        {

            var table = new Column.P_Column
            {
                ColumnId = columnDto.ColumnId,
                name1 = columnDto.name1,
                name2 = columnDto.name2,  //Dto는 화면에 보여지도록 기존의 data를 변환하는 목적을 가지고 있다. 이때 화면에 패스워드를 ****로 보여지게 할 수 있다.
                name3 = columnDto.name3,
                name4 = columnDto.name4,
                name5 = columnDto.name5,
                name6 = columnDto.name6,
                Column_name = columnDto.Column_name,
                Description = columnDto.Description
            };
            return table;
        }

        public Column.C_Column C_CreateEntityFromDto(ColumnDto columnDto)
        {

            var table = new Column.C_Column
            {
                ColumnId = columnDto.ColumnId,
                name1 = columnDto.name1,
                name2 = columnDto.name2,  //Dto는 화면에 보여지도록 기존의 data를 변환하는 목적을 가지고 있다. 이때 화면에 패스워드를 ****로 보여지게 할 수 있다.
                name3 = columnDto.name3,
                name4 = columnDto.name4,
                name5 = columnDto.name5,
                name6 = columnDto.name6,
                Column_name = columnDto.Column_name,
                Description = columnDto.Description
            };
            return table;
        }
        public Column.R_Column R_CreateEntityFromDto(ColumnDto columnDto)
        {

            var table = new Column.R_Column
            {
                ColumnId = columnDto.ColumnId,
                name1 = columnDto.name1,
                name2 = columnDto.name2,  //Dto는 화면에 보여지도록 기존의 data를 변환하는 목적을 가지고 있다. 이때 화면에 패스워드를 ****로 보여지게 할 수 있다.
                name3 = columnDto.name3,
                name4 = columnDto.name4,
                name5 = columnDto.name5,
                name6 = columnDto.name6,
                Column_name = columnDto.Column_name,
                Description = columnDto.Description
            };
            return table;
        }
        public void Create_P_Column(ColumnDto columnDto)
        {
            var column = P_CreateEntityFromDto(columnDto);
            if (column != null)
            {
                _context.P_Columns.Add(column);
                _context.SaveChanges();
            }
        }

        public void Create_C_Column(ColumnDto columnDto)
        {
            var column = C_CreateEntityFromDto(columnDto);
            if (column != null)
            {
                _context.C_Columns.Add(column);
                _context.SaveChanges();
            }
        }
        public void Create_R_Column(ColumnDto columnDto)
        {
            var column = R_CreateEntityFromDto(columnDto);
            if (column != null)
            {
                _context.R_Columns.Add(column);
                _context.SaveChanges();
            }
        }
        #endregion

        #region Delete Column Info
        //DeleteUser는 오버라이딩을 사용한다. 
        public void Delete_P_Column(string columnId)
        {
            var column = _context.P_Columns.Find(columnId);
            if (column != null)
            {
                _context.P_Columns.Remove(column);
                _context.SaveChanges();
            }
        }
        public void Delete_C_Column(string columnId)
        {
            var column = _context.C_Columns.Find(columnId);
            if (column != null)
            {
                _context.C_Columns.Remove(column);
                _context.SaveChanges();
            }
        }
        public void Delete_R_Column(string columnId)
        {
            var column = _context.R_Columns.Find(columnId);
            if (column != null)
            {
                _context.R_Columns.Remove(column);
                _context.SaveChanges();
            }
        }

        public void Delete_P_Table(ColumnDto columnDto)
        {
            var column = _context.P_Columns.Find(columnDto.ColumnId);
            if (column != null)
            {
                _context.P_Columns.Remove(column);
                _context.SaveChanges();
            }

            //var user = SignOutListUser(userDto); // CreateListUser 메서드를 사용하지 않고 DeleteListUser를 따로 만들어서 Remove하는 이유는 CreateListUser에는 UserId, UserName, Email,Password 4가지 속성이 있다. 회원탈퇴는 userId랑 PW만 있으면 된다.
            //_context.Users.Remove(user);        // -> 이때, UserId(hgh1025) 랑 UserName(hgh1025) 등 동일한 값이 존재하는 경우, Error: System.InvalidOperationException: The instance of entity type ...(생략)... 오류가 나온다. 
            //_context.SaveChanges();             // -> 즉 이미 존재하는 값을(인스턴스) 이미 tracking하고 있는데 왜 또 찾아서 Remove() 하냐는 오류이다.
        }

        public void Delete_C_Table(ColumnDto columnDto)
        {
            var column = _context.C_Columns.Find(columnDto.ColumnId);
            if (column != null)
            {
                _context.C_Columns.Remove(column);
                _context.SaveChanges();
            }

            //var user = SignOutListUser(userDto); // CreateListUser 메서드를 사용하지 않고 DeleteListUser를 따로 만들어서 Remove하는 이유는 CreateListUser에는 UserId, UserName, Email,Password 4가지 속성이 있다. 회원탈퇴는 userId랑 PW만 있으면 된다.
            //_context.Users.Remove(user);        // -> 이때, UserId(hgh1025) 랑 UserName(hgh1025) 등 동일한 값이 존재하는 경우, Error: System.InvalidOperationException: The instance of entity type ...(생략)... 오류가 나온다. 
            //_context.SaveChanges();             // -> 즉 이미 존재하는 값을(인스턴스) 이미 tracking하고 있는데 왜 또 찾아서 Remove() 하냐는 오류이다.
        }

        public void Delete_R_Table(ColumnDto columnDto)
        {
            var column = _context.R_Columns.Find(columnDto.ColumnId);
            if (column != null)
            {
                _context.R_Columns.Remove(column);
                _context.SaveChanges();
            }

            //var user = SignOutListUser(userDto); // CreateListUser 메서드를 사용하지 않고 DeleteListUser를 따로 만들어서 Remove하는 이유는 CreateListUser에는 UserId, UserName, Email,Password 4가지 속성이 있다. 회원탈퇴는 userId랑 PW만 있으면 된다.
            //_context.Users.Remove(user);        // -> 이때, UserId(hgh1025) 랑 UserName(hgh1025) 등 동일한 값이 존재하는 경우, Error: System.InvalidOperationException: The instance of entity type ...(생략)... 오류가 나온다. 
            //_context.SaveChanges();             // -> 즉 이미 존재하는 값을(인스턴스) 이미 tracking하고 있는데 왜 또 찾아서 Remove() 하냐는 오류이다.
        }
        #endregion

        #region Update Column Info
        public void P_UpdateEntityFromDto(Column.P_Column column, ColumnDto columnDto)
        {
            column.name1 = columnDto.name1;
            column.name2 = columnDto.name2;
            column.name3 = columnDto.name3;
            column.name4 = columnDto.name4;
            column.name5 = columnDto.name5;
            column.name6 = columnDto.name6;
            column.Table_name = columnDto.Column_name;
            column.Description = columnDto.Description;

        }

        public void C_UpdateEntityFromDto(Column.C_Column column, ColumnDto columnDto)
        {
            column.name1 = columnDto.name1;
            column.name2 = columnDto.name2;
            column.name3 = columnDto.name3;
            column.name4 = columnDto.name4;
            column.name5 = columnDto.name5;
            column.name6 = columnDto.name6;
            column.Table_name = columnDto.Column_name;
            column.Description = columnDto.Description;

        }

        public void R_UpdateEntityFromDto(Column.R_Column column, ColumnDto columnDto)
        {
            column.name1 = columnDto.name1;
            column.name2 = columnDto.name2;
            column.name3 = columnDto.name3;
            column.name4 = columnDto.name4;
            column.name5 = columnDto.name5;
            column.name6 = columnDto.name6;
            column.Table_name = columnDto.Column_name;
            column.Description = columnDto.Description;

        }

        public void Update_P_Column(ColumnDto columnDto)
        {
            var column = _context.P_Columns.Find(columnDto.ColumnId);  //수정 삭제는 Find 메서드로 해당 하나의 값만 수정, 삭제해야한다.
            if (column != null)
            {
                P_UpdateEntityFromDto(column, columnDto);  //userDto(화면에서 오는 매개변수 데이터) 를 user(실제 DB에 반영 덮어씌운다.)
                //_context.Members.Update(user); // 덮어 씌워진 user를 update한다.
                _context.SaveChanges();
            }
        }

        public void Update_C_Column(ColumnDto columnDto)
        {
            var column = _context.C_Columns.Find(columnDto.ColumnId);  //수정 삭제는 Find 메서드로 해당 하나의 값만 수정, 삭제해야한다.
            if (column != null)
            {
                C_UpdateEntityFromDto(column, columnDto);  //userDto(화면에서 오는 매개변수 데이터) 를 user(실제 DB에 반영 덮어씌운다.)
                //_context.Members.Update(user); // 덮어 씌워진 user를 update한다.
                _context.SaveChanges();
            }
        }

        public void Update_R_Column(ColumnDto columnDto)
        {
            var column = _context.R_Columns.Find(columnDto.ColumnId);  //수정 삭제는 Find 메서드로 해당 하나의 값만 수정, 삭제해야한다.
            if (column != null)
            {
                R_UpdateEntityFromDto(column, columnDto);  //userDto(화면에서 오는 매개변수 데이터) 를 user(실제 DB에 반영 덮어씌운다.)
                //_context.Members.Update(user); // 덮어 씌워진 user를 update한다.
                _context.SaveChanges();
            }
        }
        #endregion

    }
}