using Code_Dictionary.Model.Model;
using System;

namespace Code_Dictionary.Model.Dto
{
    public class TableDto
    {
        public int TableId { get; set; }
        public string name1 { get; set; }
        public string name2 { get; set; }
        public string name3 { get; set; }
        public string name4 { get; set; }
        public string name5 { get; set; }
        public string name6 { get; set; }
        public string Table_name { get; set; }
        public string Description { get; set; }

        public static Func<Table.P_Table, TableDto> P_TableFunc = (tb) =>
        new TableDto
        {
            TableId = tb.TableId,
            name1 = tb.name1,
            name2 = tb.name2,  //Dto는 화면에 보여지도록 기존의 data를 변환하는 목적을 가지고 있다. 이때 화면에 패스워드를 ****로 보여지게 할 수 있다.
            name3 = tb.name3,
            name4 = tb.name4,
            name5 = tb.name5,
            name6 = tb.name6,
            Table_name = tb.Table_name,
            Description = tb.Description,
        };
        public static Func<Table.C_Table, TableDto> C_TableFunc = (tb) =>
        new TableDto
        {
            TableId = tb.TableId,
            name1 = tb.name1,
            name2 = tb.name2,  //Dto는 화면에 보여지도록 기존의 data를 변환하는 목적을 가지고 있다. 이때 화면에 패스워드를 ****로 보여지게 할 수 있다.
            name3 = tb.name3,
            name4 = tb.name4,
            name5 = tb.name5,
            name6 = tb.name6,
            Table_name = tb.Table_name,
            Description = tb.Description,
        };
        public static Func<Table.R_Table, TableDto> R_TableFunc = (tb) =>
        new TableDto
        {
            TableId = tb.TableId,
            name1 = tb.name1,
            name2 = tb.name2,  //Dto는 화면에 보여지도록 기존의 data를 변환하는 목적을 가지고 있다. 이때 화면에 패스워드를 ****로 보여지게 할 수 있다.
            name3 = tb.name3,
            name4 = tb.name4,
            name5 = tb.name5,
            name6 = tb.name6,
            Table_name = tb.Table_name,
            Description = tb.Description,
        };

    }
}