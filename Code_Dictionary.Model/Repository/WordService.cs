using Code_Dictionary.Model.Model;
using System.Collections.Generic;
using System.Linq;

namespace Code_Dictionary.Model.Repository
{
    public class WordService
    {
        private readonly ExDbContext _context;

        public WordService()
        {
            if (_context == null) _context = new ExDbContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        #region Word List Info
        public List<WordDto> Get_P_Words()
        {
            return _context.P_Words.Select(WordDto.P_WordFunc).ToList();
        }

        public List<WordDto> Get_C_Words()
        {
            return _context.C_Words.Select(WordDto.C_WordFunc).ToList();
        }

        public List<WordDto> Get_R_Words()
        {
            return _context.R_Words.Select(WordDto.R_WordFunc).ToList();
        }
        #endregion

        #region Word Get Info
        public Word.P_Word Get_P_Word(int wordId)
        {
            return _context.P_Words.FirstOrDefault(p => p.WordId == wordId);

        }
        public Word.C_Word Get_C_Word(int wordId)
        {
            return _context.C_Words.FirstOrDefault(p => p.WordId == wordId);

        }
        public Word.R_Word Get_R_Word(int wordId)
        {
            return _context.R_Words.FirstOrDefault(p => p.WordId == wordId);

        }
        #endregion

        #region create Word Info
        public Word.P_Word P_CreateEntityFromDto(WordDto wordDto)
        {

            var word = new Word.P_Word
            {
                WordId = wordDto.WordId,
                name = wordDto.name,
                full_Name = wordDto.full_Name,  //Dto는 화면에 보여지도록 기존의 data를 변환하는 목적을 가지고 있다. 이때 화면에 패스워드를 ****로 보여지게 할 수 있다.
                Description = wordDto.Description,
            };
            return word;
        }

        public Word.C_Word C_CreateEntityFromDto(WordDto wordDto)
        {

            var word = new Word.C_Word
            {
                WordId = wordDto.WordId,
                name = wordDto.name,
                full_Name = wordDto.full_Name,  //Dto는 화면에 보여지도록 기존의 data를 변환하는 목적을 가지고 있다. 이때 화면에 패스워드를 ****로 보여지게 할 수 있다.
                Description = wordDto.Description,
            };
            return word;
        }
        public Word.R_Word R_CreateEntityFromDto(WordDto wordDto)
        {

            var word = new Word.R_Word
            {
                WordId = wordDto.WordId,
                name = wordDto.name,
                full_Name = wordDto.full_Name,  //Dto는 화면에 보여지도록 기존의 data를 변환하는 목적을 가지고 있다. 이때 화면에 패스워드를 ****로 보여지게 할 수 있다.
                Description = wordDto.Description,
            };
            return word;
        }

        public void Create_P_Word(WordDto wordDto)
        {
            var word = P_CreateEntityFromDto(wordDto);
            if (word != null)
            {
                _context.P_Words.Add(word);
                _context.SaveChanges();
            }
        }
        public void Create_C_Word(WordDto wordDto)
        {
            var word = C_CreateEntityFromDto(wordDto);
            if (word != null)
            {
                _context.C_Words.Add(word);
                _context.SaveChanges();
            }
        }
        public void Create_R_Word(WordDto wordDto)
        {
            var word = R_CreateEntityFromDto(wordDto);
            if (word != null)
            {
                _context.R_Words.Add(word);
                _context.SaveChanges();
            }
        }
        #endregion

        #region Delete Word Info
        //DeleteUser는 오버라이딩을 사용한다. 
        public void Delete_P_Word(string wordId)
        {
            var word = _context.P_Words.Find(wordId);
            if (word != null)
            {
                _context.P_Words.Remove(word);
                _context.SaveChanges();
            }
        }

        public void Delete_P_Word(WordDto wordDto)
        {
            var word = _context.P_Words.Find(wordDto.WordId);
            if (word != null)
            {
                _context.P_Words.Remove(word);
                _context.SaveChanges();
            }

            //var user = SignOutListUser(userDto); // CreateListUser 메서드를 사용하지 않고 DeleteListUser를 따로 만들어서 Remove하는 이유는 CreateListUser에는 UserId, UserName, Email,Password 4가지 속성이 있다. 회원탈퇴는 userId랑 PW만 있으면 된다.
            //_context.Users.Remove(user);        // -> 이때, UserId(hgh1025) 랑 UserName(hgh1025) 등 동일한 값이 존재하는 경우, Error: System.InvalidOperationException: The instance of entity type ...(생략)... 오류가 나온다. 
            //_context.SaveChanges();             // -> 즉 이미 존재하는 값을(인스턴스) 이미 tracking하고 있는데 왜 또 찾아서 Remove() 하냐는 오류이다.
        }
        #endregion

        #region Update Word Info
        public void P_UpdateEntityFromDto(Word.P_Word word, WordDto wordDto)
        {
            word.name = wordDto.name;
            word.full_Name = wordDto.full_Name;
            word.Description = wordDto.Description;
        }

        public void C_UpdateEntityFromDto(Word.C_Word word, WordDto wordDto)
        {
            word.name = wordDto.name;
            word.full_Name = wordDto.full_Name;
            word.Description = wordDto.Description;
        }
        public void R_UpdateEntityFromDto(Word.R_Word word, WordDto wordDto)
        {
            word.name = wordDto.name;
            word.full_Name = wordDto.full_Name;
            word.Description = wordDto.Description;
        }

        public void Update_P_Word(WordDto wordDto)
        {
            var word = _context.P_Words.Find(wordDto.WordId);  //수정 삭제는 Find 메서드로 해당 하나의 값만 수정, 삭제해야한다.
            if (word != null)
            {
                P_UpdateEntityFromDto(word, wordDto);  //userDto(화면에서 오는 매개변수 데이터) 를 user(실제 DB에 반영 덮어씌운다.)
                //_context.Members.Update(user); // 덮어 씌워진 user를 update한다.
                _context.SaveChanges();
            }
        }

        public void Update_C_Word(WordDto wordDto)
        {
            var word = _context.C_Words.Find(wordDto.WordId);  //수정 삭제는 Find 메서드로 해당 하나의 값만 수정, 삭제해야한다.
            if (word != null)
            {
                C_UpdateEntityFromDto(word, wordDto);  //userDto(화면에서 오는 매개변수 데이터) 를 user(실제 DB에 반영 덮어씌운다.)
                //_context.Members.Update(user); // 덮어 씌워진 user를 update한다.
                _context.SaveChanges();
            }
        }

        public void Update_R_Word(WordDto wordDto)
        {
            var word = _context.R_Words.Find(wordDto.WordId);  //수정 삭제는 Find 메서드로 해당 하나의 값만 수정, 삭제해야한다.
            if (word != null)
            {
                R_UpdateEntityFromDto(word, wordDto);  //userDto(화면에서 오는 매개변수 데이터) 를 user(실제 DB에 반영 덮어씌운다.)
                //_context.Members.Update(user); // 덮어 씌워진 user를 update한다.
                _context.SaveChanges();
            }
        }
        #endregion

    }
}