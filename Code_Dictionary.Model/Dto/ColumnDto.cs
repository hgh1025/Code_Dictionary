using Code_Dictionary.Model.Model;
using System;

namespace Code_Dictionary.Model.Dto
{
    public class ColumnDto
    {
        public int ColumnId { get; set; }
        public string Table_name { get; set; }
        public string name1 { get; set; }
        public string name2 { get; set; }
        public string name3 { get; set; }
        public string name4 { get; set; }
        public string name5 { get; set; }
        public string name6 { get; set; }
        public string Column_name { get; set; }
        public string Description { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool use_yn { get; set; }
        public bool del_yn { get; set; }

        public static Func<Column.P_Column, ColumnDto> P_ColumnFunc = (cm) =>
           new ColumnDto
           {
               ColumnId = cm.ColumnId,
               Table_name = cm.Table_name,
               name1 = cm.name1,
               name2 = cm.name2,  //Dto는 화면에 보여지도록 기존의 data를 변환하는 목적을 가지고 있다. 이때 화면에 패스워드를 ****로 보여지게 할 수 있다.
               name3 = cm.name3,
               name4 = cm.name4,
               name5 = cm.name5,
               name6 = cm.name6,
               Column_name = cm.Column_name,
               Description = cm.Description
           };

        public static Func<Column.C_Column, ColumnDto> C_ColumnFunc = (cm) =>
          new ColumnDto
          {
              ColumnId = cm.ColumnId,
              Table_name = cm.Table_name,
              name1 = cm.name1,
              name2 = cm.name2,  //Dto는 화면에 보여지도록 기존의 data를 변환하는 목적을 가지고 있다. 이때 화면에 패스워드를 ****로 보여지게 할 수 있다.
              name3 = cm.name3,
              name4 = cm.name4,
              name5 = cm.name5,
              name6 = cm.name6,
              Column_name = cm.Column_name,
              Description = cm.Description
          };

        public static Func<Column.R_Column, ColumnDto> R_ColumnFunc = (cm) =>
          new ColumnDto
          {
              ColumnId = cm.ColumnId,
              Table_name = cm.Table_name,
              name1 = cm.name1,
              name2 = cm.name2,  //Dto는 화면에 보여지도록 기존의 data를 변환하는 목적을 가지고 있다. 이때 화면에 패스워드를 ****로 보여지게 할 수 있다.
              name3 = cm.name3,
              name4 = cm.name4,
              name5 = cm.name5,
              name6 = cm.name6,
              Column_name = cm.Column_name,
              Description = cm.Description
          };
    }
}