namespace Code_Dictionary.Model.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Code_Dictionary.Model.ExDbContext>
    {
        public Configuration()
        {

            AutomaticMigrationsEnabled = true; // 자동 마이그레이션 활성화
            AutomaticMigrationDataLossAllowed = false; // 데이터 손실 방지 (선택 사항)
        }

        protected override void Seed(Code_Dictionary.Model.ExDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
