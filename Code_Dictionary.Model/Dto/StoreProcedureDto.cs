using System;

namespace Code_Dictionary.Model.Model
{
    public class StoreProcedureDto
    {
        public int SpId { get; set; }
        public string name1 { get; set; }
        public string name2 { get; set; }
        public string name3 { get; set; }
        public string name4 { get; set; }
        public string name5 { get; set; }
        public string name6 { get; set; }
        public string Sp_name { get; set; }
        public string Description { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool use_yn { get; set; }
        public bool del_yn { get; set; }

        public static Func<StoreProcedure.P_StoreProcedure, StoreProcedureDto> P_SpFunc = (tb) =>
        new StoreProcedureDto
        {
            SpId = tb.SpId,
            name1 = tb.name1,
            name2 = tb.name2,
            name3 = tb.name3,
            name4 = tb.name4,
            name5 = tb.name5,
            name6 = tb.name6,
            Sp_name = tb.Sp_name,
            Description = tb.Description,
        };
        public static Func<StoreProcedure.C_StoreProcedure, StoreProcedureDto> C_SpFunc = (tb) =>
        new StoreProcedureDto
        {
            SpId = tb.SpId,
            name1 = tb.name1,
            name2 = tb.name2,
            name3 = tb.name3,
            name4 = tb.name4,
            name5 = tb.name5,
            name6 = tb.name6,
            Sp_name = tb.Sp_name,
            Description = tb.Description,
        };
        public static Func<StoreProcedure.R_StoreProcedure, StoreProcedureDto> R_SpFunc = (tb) =>
        new StoreProcedureDto
        {
            SpId = tb.SpId,
            name1 = tb.name1,
            name2 = tb.name2,
            name3 = tb.name3,
            name4 = tb.name4,
            name5 = tb.name5,
            name6 = tb.name6,
            Sp_name = tb.Sp_name,
            Description = tb.Description,
        };
    }
}