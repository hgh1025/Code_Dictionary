using Code_Dictionary.Model;
using NUnit.Framework;
using System;
using System.Data.Entity.Validation;
using static Code_Dictionary.Model.Model.Column;
using static Code_Dictionary.Model.Model.StoreProcedure;
using static Code_Dictionary.Model.Model.Table;
using static Code_Dictionary.Model.Model.Word;

namespace HuniShop.Tests
{
    public class DefaultSampleDataTests
    {
        private string _connectionString;
        [SetUp]
        public void Setup()
        {
            // SQL Server 연결 문자열 설정


        }


        [Test]
        public void Insert_P_Table()
        {
            using (var db = new ExDbContext())
            {
                try
                {
                    // 엑셀에 있는 데이터를 기반으로 테이블 엔터티에 삽입할 데이터를 설정
                    var table = new P_Table
                    {
                        TableId = 1,
                        name1 = "Accident",      // 엑셀의 첫 번째 행 데이터를 예시로 사용
                        name2 = null,            // NULL 값으로 채워진 부분
                        name3 = null,            // NULL 값으로 채워진 부분
                        Table_name = "Accident", // 테이블 이름
                        Description = "사고처리현황" // 설명
                    };

                    // 데이터베이스에 테이블 엔터티 추가
                    db.P_Tables.Add(table);

                    // 변경된 데이터 저장
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Console.WriteLine($"Property: {validationError.PropertyName}, Error: {validationError.ErrorMessage}");
                        }
                    }

                    // Assert.Fail로 테스트 실패 처리
                    Assert.Fail("Entity validation failed.");
                }
            }
        }

        [Test]
        public void Insert_C_Table()
        {
            using (var db = new ExDbContext())
            {
                try
                {
                    // 엑셀에 있는 데이터를 기반으로 테이블 엔터티에 삽입할 데이터를 설정
                    var table = new C_Table
                    {
                        TableId = 2,
                        name1 = "TB",            // NULL 값으로 채워진 부분
                        name2 = "ATTACH",      // 엑셀의 첫 번째 행 데이터를 예시로 사용
                        name3 = "FILE",            // NULL 값으로 채워진 부분
                        name4 = null,            // NULL 값으로 채워진 부분
                        name5 = null,            // NULL 값으로 채워진 부분
                        name6 = null,            // NULL 값으로 채워진 부분
                        Table_name = "TB_ATTACH_FILE", // 테이블 이름
                        Description = "첨부파일", // 설명
                        UpdateTime = DateTime.Now,
                        use_yn = false,
                        del_yn = false
                    };

                    // 데이터베이스에 테이블 엔터티 추가
                    db.C_Tables.Add(table);

                    // 변경된 데이터 저장
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Console.WriteLine($"Property: {validationError.PropertyName}, Error: {validationError.ErrorMessage}");
                        }
                    }

                    // Assert.Fail로 테스트 실패 처리
                    Assert.Fail("Entity validation failed.");
                }
            }
        }

        [Test]
        public void Insert_R_Table()
        {
            using (var db = new ExDbContext())
            {
                try
                {
                    // 엑셀에 있는 데이터를 기반으로 테이블 엔터티에 삽입할 데이터를 설정
                    var table = new R_Table
                    {
                        TableId = 2,
                        name1 = "TBL",            // NULL 값으로 채워진 부분
                        name2 = "PARKING",      // 엑셀의 첫 번째 행 데이터를 예시로 사용
                        name3 = "INFO",            // NULL 값으로 채워진 부분
                        name4 = "LOG",            // NULL 값으로 채워진 부분
                        Table_name = "TBL_PARKING_INFO_LOG", // 테이블 이름
                        Description = "주차장정보 로그" // 설명
                    };

                    // 데이터베이스에 테이블 엔터티 추가
                    db.R_Tables.Add(table);

                    // 변경된 데이터 저장
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Console.WriteLine($"Property: {validationError.PropertyName}, Error: {validationError.ErrorMessage}");
                        }
                    }

                    // Assert.Fail로 테스트 실패 처리
                    Assert.Fail("Entity validation failed.");
                }
            }
        }

        [Test]
        public void Insert_P_Column()
        {
            using (var db = new ExDbContext())
            {
                try
                {
                    // 엑셀에 있는 데이터를 기반으로 테이블 엔터티에 삽입할 데이터를 설정
                    var column = new P_Column
                    {
                        ColumnId = 1,
                        Table_name = "",      // 엑셀의 첫 번째 행 데이터를 예시로 사용
                        name1 = "Reserv",      // 엑셀의 첫 번째 행 데이터를 예시로 사용
                        name2 = "Id",            // NULL 값으로 채워진 부분
                        name3 = null,            // NULL 값으로 채워진 부분
                        name4 = null,            // NULL 값으로 채워진 부분
                        name5 = null,            // NULL 값으로 채워진 부분
                        name6 = null,            // NULL 값으로 채워진 부분
                        Column_name = "ReservId", // 테이블 이름
                        Description = "예약번호", // 설명
                        UpdateTime = DateTime.Now,
                        use_yn = false,
                        del_yn = false
                    };

                    // 데이터베이스에 테이블 엔터티 추가
                    db.P_Columns.Add(column);

                    // 변경된 데이터 저장
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Console.WriteLine($"Property: {validationError.PropertyName}, Error: {validationError.ErrorMessage}");
                        }
                    }

                    // Assert.Fail로 테스트 실패 처리
                    Assert.Fail("Entity validation failed.");
                }
            }
        }

        [Test]
        public void Insert_P_StoreProcedure()
        {
            using (var db = new ExDbContext())
            {
                try
                {
                    // 엑셀에 있는 데이터를 기반으로 테이블 엔터티에 삽입할 데이터를 설정
                    var table = new P_StoreProcedure
                    {
                        SpId = 1,
                        name1 = "usp",      // 엑셀의 첫 번째 행 데이터를 예시로 사용
                        name2 = "api",            // NULL 값으로 채워진 부분
                        name3 = "Penalty",            // NULL 값으로 채워진 부분
                        name4 = null,            // NULL 값으로 채워진 부분
                        name5 = null,            // NULL 값으로 채워진 부분
                        Sp_name = "usp_api_Penalty_PenaltyByUserId", // 테이블 이름
                        Description = "회원의 페널티 총점수", // 설명
                        UpdateTime = DateTime.Now,
                        use_yn = false,
                        del_yn = false
                    };

                    // 데이터베이스에 테이블 엔터티 추가
                    db.P_StoreProcedures.Add(table);

                    // 변경된 데이터 저장
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Console.WriteLine($"Property: {validationError.PropertyName}, Error: {validationError.ErrorMessage}");
                        }
                    }

                    // Assert.Fail로 테스트 실패 처리
                    Assert.Fail("Entity validation failed.");
                }
            }
        }

        [Test]
        public void Insert_P_Word()
        {
            using (var db = new ExDbContext())
            {
                try
                {
                    // 엑셀에 있는 데이터를 기반으로 테이블 엔터티에 삽입할 데이터를 설정
                    var word = new P_Word
                    {
                        WordId = 1,
                        name = "Accident",      // 엑셀의 첫 번째 행 데이터를 예시로 사용
                        full_Name = null,            // NULL 값으로 채워진 부분
                        Description = "사고처리현황", // 설명
                        UpdateDt = DateTime.Now,
                        use_yn = false,
                        del_yn = false
                    };

                    // 데이터베이스에 테이블 엔터티 추가
                    db.P_Words.Add(word);

                    // 변경된 데이터 저장
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Console.WriteLine($"Property: {validationError.PropertyName}, Error: {validationError.ErrorMessage}");
                        }
                    }

                    // Assert.Fail로 테스트 실패 처리
                    Assert.Fail("Entity validation failed.");
                }
            }
        }
    }
}
