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
            // SQL Server ���� ���ڿ� ����


        }


        [Test]
        public void Insert_P_Table()
        {
            using (var db = new ExDbContext())
            {
                try
                {
                    // ������ �ִ� �����͸� ������� ���̺� ����Ƽ�� ������ �����͸� ����
                    var table = new P_Table
                    {
                        TableId = 1,
                        name1 = "Accident",      // ������ ù ��° �� �����͸� ���÷� ���
                        name2 = null,            // NULL ������ ä���� �κ�
                        name3 = null,            // NULL ������ ä���� �κ�
                        Table_name = "Accident", // ���̺� �̸�
                        Description = "���ó����Ȳ" // ����
                    };

                    // �����ͺ��̽��� ���̺� ����Ƽ �߰�
                    db.P_Tables.Add(table);

                    // ����� ������ ����
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

                    // Assert.Fail�� �׽�Ʈ ���� ó��
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
                    // ������ �ִ� �����͸� ������� ���̺� ����Ƽ�� ������ �����͸� ����
                    var table = new C_Table
                    {
                        TableId = 2,
                        name1 = "TB",            // NULL ������ ä���� �κ�
                        name2 = "ATTACH",      // ������ ù ��° �� �����͸� ���÷� ���
                        name3 = "FILE",            // NULL ������ ä���� �κ�
                        name4 = null,            // NULL ������ ä���� �κ�
                        name5 = null,            // NULL ������ ä���� �κ�
                        name6 = null,            // NULL ������ ä���� �κ�
                        Table_name = "TB_ATTACH_FILE", // ���̺� �̸�
                        Description = "÷������", // ����
                        UpdateTime = DateTime.Now,
                        use_yn = false,
                        del_yn = false
                    };

                    // �����ͺ��̽��� ���̺� ����Ƽ �߰�
                    db.C_Tables.Add(table);

                    // ����� ������ ����
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

                    // Assert.Fail�� �׽�Ʈ ���� ó��
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
                    // ������ �ִ� �����͸� ������� ���̺� ����Ƽ�� ������ �����͸� ����
                    var table = new R_Table
                    {
                        TableId = 2,
                        name1 = "TBL",            // NULL ������ ä���� �κ�
                        name2 = "PARKING",      // ������ ù ��° �� �����͸� ���÷� ���
                        name3 = "INFO",            // NULL ������ ä���� �κ�
                        name4 = "LOG",            // NULL ������ ä���� �κ�
                        Table_name = "TBL_PARKING_INFO_LOG", // ���̺� �̸�
                        Description = "���������� �α�" // ����
                    };

                    // �����ͺ��̽��� ���̺� ����Ƽ �߰�
                    db.R_Tables.Add(table);

                    // ����� ������ ����
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

                    // Assert.Fail�� �׽�Ʈ ���� ó��
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
                    // ������ �ִ� �����͸� ������� ���̺� ����Ƽ�� ������ �����͸� ����
                    var column = new P_Column
                    {
                        ColumnId = 1,
                        Table_name = "",      // ������ ù ��° �� �����͸� ���÷� ���
                        name1 = "Reserv",      // ������ ù ��° �� �����͸� ���÷� ���
                        name2 = "Id",            // NULL ������ ä���� �κ�
                        name3 = null,            // NULL ������ ä���� �κ�
                        name4 = null,            // NULL ������ ä���� �κ�
                        name5 = null,            // NULL ������ ä���� �κ�
                        name6 = null,            // NULL ������ ä���� �κ�
                        Column_name = "ReservId", // ���̺� �̸�
                        Description = "�����ȣ", // ����
                        UpdateTime = DateTime.Now,
                        use_yn = false,
                        del_yn = false
                    };

                    // �����ͺ��̽��� ���̺� ����Ƽ �߰�
                    db.P_Columns.Add(column);

                    // ����� ������ ����
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

                    // Assert.Fail�� �׽�Ʈ ���� ó��
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
                    // ������ �ִ� �����͸� ������� ���̺� ����Ƽ�� ������ �����͸� ����
                    var table = new P_StoreProcedure
                    {
                        SpId = 1,
                        name1 = "usp",      // ������ ù ��° �� �����͸� ���÷� ���
                        name2 = "api",            // NULL ������ ä���� �κ�
                        name3 = "Penalty",            // NULL ������ ä���� �κ�
                        name4 = null,            // NULL ������ ä���� �κ�
                        name5 = null,            // NULL ������ ä���� �κ�
                        Sp_name = "usp_api_Penalty_PenaltyByUserId", // ���̺� �̸�
                        Description = "ȸ���� ���Ƽ ������", // ����
                        UpdateTime = DateTime.Now,
                        use_yn = false,
                        del_yn = false
                    };

                    // �����ͺ��̽��� ���̺� ����Ƽ �߰�
                    db.P_StoreProcedures.Add(table);

                    // ����� ������ ����
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

                    // Assert.Fail�� �׽�Ʈ ���� ó��
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
                    // ������ �ִ� �����͸� ������� ���̺� ����Ƽ�� ������ �����͸� ����
                    var word = new P_Word
                    {
                        WordId = 1,
                        name = "Accident",      // ������ ù ��° �� �����͸� ���÷� ���
                        full_Name = null,            // NULL ������ ä���� �κ�
                        Description = "���ó����Ȳ", // ����
                        UpdateDt = DateTime.Now,
                        use_yn = false,
                        del_yn = false
                    };

                    // �����ͺ��̽��� ���̺� ����Ƽ �߰�
                    db.P_Words.Add(word);

                    // ����� ������ ����
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

                    // Assert.Fail�� �׽�Ʈ ���� ó��
                    Assert.Fail("Entity validation failed.");
                }
            }
        }
    }
}
