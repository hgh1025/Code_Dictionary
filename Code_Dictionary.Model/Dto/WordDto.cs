using System;

namespace Code_Dictionary.Model.Model
{
    public class WordDto
    {
        public int WordId { get; set; }
        public string name { get; set; }
        public string full_Name { get; set; }
        public string Description { get; set; }

        public static Func<Word.P_Word, WordDto> P_WordFunc = (tb) =>
        new WordDto
        {
            WordId = tb.WordId,
            name = tb.name,
            full_Name = tb.full_Name,
            Description = tb.Description,
        };

        public static Func<Word.C_Word, WordDto> C_WordFunc = (tb) =>
        new WordDto
        {
            WordId = tb.WordId,
            name = tb.name,
            full_Name = tb.full_Name,
            Description = tb.Description,
        };

        public static Func<Word.R_Word, WordDto> R_WordFunc = (tb) =>
        new WordDto
        {
            WordId = tb.WordId,
            name = tb.name,
            full_Name = tb.full_Name,
            Description = tb.Description,
        };
    }
}