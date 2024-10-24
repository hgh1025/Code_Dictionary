using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_Dictionary.Model.Model
{
    public class Word
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WordId { get; set; }
        public string name { get; set; }
        public string full_Name { get; set; }
        public string Description { get; set; }
        public DateTime UpdateDt { get; set; }
        public bool use_yn { get; set; }
        public bool del_yn { get; set; }

        public class P_Word : Word
        {

        }
        public class C_Word : Word
        {

        }

        public class R_Word : Word
        {

        }

    }
}