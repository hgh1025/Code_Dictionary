using Code_Dictionary.Model.Dto;
using Code_Dictionary.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Code_Dictionary.Model.Repository
{
    public class TableService
    {
        private readonly ExDbContext _context;

        public TableService()
        {
            if (_context == null) _context = new ExDbContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        #region Table List Info
        public List<TableDto> Get_P_Tables()
        {
            return _context.P_Tables.Select(TableDto.P_TableFunc).ToList();
        }

        public List<TableDto> Get_C_Tables()
        {
            return _context.C_Tables.Select(TableDto.C_TableFunc).ToList();
        }

        public List<TableDto> Get_R_Tables()
        {
            return _context.R_Tables.Select(TableDto.R_TableFunc).ToList();
        }
        #endregion

        public Table.P_Table Get_P_Table(int tbId)
        {
            return _context.P_Tables.FirstOrDefault(p => p.TableId == tbId);

        }

        public Table.C_Table Get_C_Table(int tbId)
        {
            return _context.C_Tables.FirstOrDefault(p => p.TableId == tbId);

        }

        public Table.R_Table Get_R_Table(int tbId)
        {
            return _context.R_Tables.FirstOrDefault(p => p.TableId == tbId);

        }

        #region Create Table Info
        public Table.P_Table P_CreateEntityFromDto(TableDto tableDto)
        {

            var table = new Table.P_Table
            {
                TableId = tableDto.TableId,
                name1 = tableDto.name1,
                name2 = tableDto.name2,
                name3 = tableDto.name3,
                name4 = tableDto.name4,
                name5 = tableDto.name5,
                name6 = tableDto.name6,
                Table_name = tableDto.Table_name,
                Description = tableDto.Description,
                UpdateTime = DateTime.Now
            };
            return table;
        }

        public Table.C_Table C_CreateEntityFromDto(TableDto tableDto)
        {

            var table = new Table.C_Table
            {
                TableId = tableDto.TableId,
                name1 = tableDto.name1,
                name2 = tableDto.name2,
                name3 = tableDto.name3,
                name4 = tableDto.name4,
                name5 = tableDto.name5,
                name6 = tableDto.name6,
                Table_name = tableDto.Table_name,
                Description = tableDto.Description,
                UpdateTime = DateTime.Now
            };
            return table;
        }

        public Table.R_Table R_CreateEntityFromDto(TableDto tableDto)
        {

            var table = new Table.R_Table
            {
                TableId = tableDto.TableId,
                name1 = tableDto.name1,
                name2 = tableDto.name2,
                name3 = tableDto.name3,
                name4 = tableDto.name4,
                name5 = tableDto.name5,
                name6 = tableDto.name6,
                Table_name = tableDto.Table_name,
                Description = tableDto.Description,
                UpdateTime = DateTime.Now
            };
            return table;
        }

        public void Create_P_Table(TableDto tableDto)
        {
            var table = P_CreateEntityFromDto(tableDto);
            if (table != null)
            {
                _context.P_Tables.Add(table);
                _context.SaveChanges();
            }
        }

        public void Create_C_Table(TableDto tableDto)
        {
            var table = C_CreateEntityFromDto(tableDto);
            if (table != null)
            {
                _context.C_Tables.Add(table);
                _context.SaveChanges();
            }
        }

        public void Create_R_Table(TableDto tableDto)
        {
            var table = R_CreateEntityFromDto(tableDto);
            if (table != null)
            {
                _context.R_Tables.Add(table);
                _context.SaveChanges();
            }
        }
        #endregion

        #region Delete Table Info

        //DeleteUser는 오버라이딩을 사용한다. 
        public void Delete_P_Table(int tbId)
        {
            var table = _context.P_Tables.Find(tbId);
            if (table != null)
            {
                _context.P_Tables.Remove(table);
                _context.SaveChanges();
            }
        }

        public void Delete_P_Table(TableDto tableDto)
        {
            var table = _context.P_Tables.Find(tableDto.TableId);
            if (table != null)
            {
                _context.P_Tables.Remove(table);
                _context.SaveChanges();
            }

            //var user = SignOutListUser(userDto); // CreateListUser 메서드를 사용하지 않고 DeleteListUser를 따로 만들어서 Remove하는 이유는 CreateListUser에는 UserId, UserName, Email,Password 4가지 속성이 있다. 회원탈퇴는 userId랑 PW만 있으면 된다.
            //_context.Users.Remove(user);        // -> 이때, UserId(hgh1025) 랑 UserName(hgh1025) 등 동일한 값이 존재하는 경우, Error: System.InvalidOperationException: The instance of entity type ...(생략)... 오류가 나온다. 
            //_context.SaveChanges();             // -> 즉 이미 존재하는 값을(인스턴스) 이미 tracking하고 있는데 왜 또 찾아서 Remove() 하냐는 오류이다.
        }

        public void Delete_C_Table(int tbId)
        {
            var table = _context.C_Tables.Find(tbId);
            if (table != null)
            {
                _context.C_Tables.Remove(table);
                _context.SaveChanges();
            }
        }

        public void Delete_C_Table(TableDto tableDto)
        {
            var table = _context.C_Tables.Find(tableDto.TableId);
            if (table != null)
            {
                _context.C_Tables.Remove(table);
                _context.SaveChanges();
            }

            //var user = SignOutListUser(userDto); // CreateListUser 메서드를 사용하지 않고 DeleteListUser를 따로 만들어서 Remove하는 이유는 CreateListUser에는 UserId, UserName, Email,Password 4가지 속성이 있다. 회원탈퇴는 userId랑 PW만 있으면 된다.
            //_context.Users.Remove(user);        // -> 이때, UserId(hgh1025) 랑 UserName(hgh1025) 등 동일한 값이 존재하는 경우, Error: System.InvalidOperationException: The instance of entity type ...(생략)... 오류가 나온다. 
            //_context.SaveChanges();             // -> 즉 이미 존재하는 값을(인스턴스) 이미 tracking하고 있는데 왜 또 찾아서 Remove() 하냐는 오류이다.
        }

        public void Delete_R_Table(int tbId)
        {
            var table = _context.R_Tables.Find(tbId);
            if (table != null)
            {
                _context.R_Tables.Remove(table);
                _context.SaveChanges();
            }
        }

        public void Delete_R_Table(TableDto tableDto)
        {
            var table = _context.R_Tables.Find(tableDto.TableId);
            if (table != null)
            {
                _context.R_Tables.Remove(table);
                _context.SaveChanges();
            }

            //var user = SignOutListUser(userDto); // CreateListUser 메서드를 사용하지 않고 DeleteListUser를 따로 만들어서 Remove하는 이유는 CreateListUser에는 UserId, UserName, Email,Password 4가지 속성이 있다. 회원탈퇴는 userId랑 PW만 있으면 된다.
            //_context.Users.Remove(user);        // -> 이때, UserId(hgh1025) 랑 UserName(hgh1025) 등 동일한 값이 존재하는 경우, Error: System.InvalidOperationException: The instance of entity type ...(생략)... 오류가 나온다. 
            //_context.SaveChanges();             // -> 즉 이미 존재하는 값을(인스턴스) 이미 tracking하고 있는데 왜 또 찾아서 Remove() 하냐는 오류이다.
        }
        #endregion

        #region Update Table Info
        public void P_UpdateEntityFromDto(Table.P_Table table, TableDto tableDto)
        {
            table.name1 = tableDto.name1;
            table.name2 = tableDto.name2;
            table.name3 = tableDto.name3;
            table.name4 = tableDto.name4;
            table.name5 = tableDto.name5;
            table.name6 = tableDto.name6;
            table.Table_name = tableDto.Table_name;
            table.Description = tableDto.Description;

        }

        public void C_UpdateEntityFromDto(Table.C_Table table, TableDto tableDto)
        {
            table.name1 = tableDto.name1;
            table.name2 = tableDto.name2;
            table.name3 = tableDto.name3;
            table.name4 = tableDto.name4;
            table.name5 = tableDto.name5;
            table.name6 = tableDto.name6;
            table.Table_name = tableDto.Table_name;
            table.Description = tableDto.Description;

        }
        public void R_UpdateEntityFromDto(Table.R_Table table, TableDto tableDto)
        {
            table.name1 = tableDto.name1;
            table.name2 = tableDto.name2;
            table.name3 = tableDto.name3;
            table.name4 = tableDto.name4;
            table.name5 = tableDto.name5;
            table.name6 = tableDto.name6;
            table.Table_name = tableDto.Table_name;
            table.Description = tableDto.Description;

        }

        public void Update_P_Table(TableDto tableDto)
        {
            var table = _context.P_Tables.Find(tableDto.TableId);  //수정 삭제는 Find 메서드로 해당 하나의 값만 수정, 삭제해야한다.
            if (table != null)
            {
                P_UpdateEntityFromDto(table, tableDto);  //userDto(화면에서 오는 매개변수 데이터) 를 user(실제 DB에 반영 덮어씌운다.)
                                                         //_context.Members.Update(user); // 덮어 씌워진 user를 update한다.
                _context.SaveChanges();
            }
        }

        public void Update_C_Table(TableDto tableDto)
        {
            var table = _context.C_Tables.Find(tableDto.TableId);  //수정 삭제는 Find 메서드로 해당 하나의 값만 수정, 삭제해야한다.
            if (table != null)
            {
                C_UpdateEntityFromDto(table, tableDto);  //userDto(화면에서 오는 매개변수 데이터) 를 user(실제 DB에 반영 덮어씌운다.)
                                                         //_context.Members.Update(user); // 덮어 씌워진 user를 update한다.
                _context.SaveChanges();
            }
        }

        public void Update_R_Table(TableDto tableDto)
        {
            var table = _context.R_Tables.Find(tableDto.TableId);  //수정 삭제는 Find 메서드로 해당 하나의 값만 수정, 삭제해야한다.
            if (table != null)
            {
                R_UpdateEntityFromDto(table, tableDto);  //userDto(화면에서 오는 매개변수 데이터) 를 user(실제 DB에 반영 덮어씌운다.)
                                                         //_context.Members.Update(user); // 덮어 씌워진 user를 update한다.
                _context.SaveChanges();
            }
        }
        #endregion

    }
}