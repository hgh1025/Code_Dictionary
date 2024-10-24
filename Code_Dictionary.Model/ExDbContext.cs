using Code_Dictionary.Model.Model;
using System.Data.Entity;
using static Code_Dictionary.Model.Model.Column;
using static Code_Dictionary.Model.Model.StoreProcedure;
using static Code_Dictionary.Model.Model.Table;
using static Code_Dictionary.Model.Model.Word;

namespace Code_Dictionary.Model
{
    public class ExDbContext : DbContext
    {
        public ExDbContext() : base("name=ExDbContext")
        {

        }


        public DbSet<Member> Members { get; set; }

        public DbSet<P_Word> P_Words { get; set; }

        public DbSet<C_Word> C_Words { get; set; }

        public DbSet<R_Word> R_Words { get; set; }

        public DbSet<P_Table> P_Tables { get; set; }
        public DbSet<C_Table> C_Tables { get; set; }
        public DbSet<R_Table> R_Tables { get; set; }

        public DbSet<P_Column> P_Columns { get; set; }
        public DbSet<C_Column> C_Columns { get; set; }
        public DbSet<R_Column> R_Columns { get; set; }

        public DbSet<P_StoreProcedure> P_StoreProcedures { get; set; }
        public DbSet<C_StoreProcedure> C_StoreProcedures { get; set; }
        public DbSet<R_StoreProcedure> R_StoreProcedures { get; set; }
    }
}
