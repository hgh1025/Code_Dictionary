using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_Dictionary.Model.Model
{
    public class Column
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ColumnId { get; set; }
        public string Table_name { get; set; }
        public string name1 { get; set; }
        public string name2 { get; set; }
        public string name3 { get; set; }
        public string name4 { get; set; }
        public string name5 { get; set; }
        public string name6 { get; set; }
        public string name7 { get; set; }
        public string Column_name { get; set; }
        public string Description { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool use_yn { get; set; }
        public bool del_yn { get; set; }

        public class P_Column : Column
        {

        }

        public class C_Column : Column
        {

        }

        public class R_Column : Column
        {

        }
    }
}