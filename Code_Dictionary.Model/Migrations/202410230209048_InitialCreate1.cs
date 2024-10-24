namespace Code_Dictionary.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.C_Column", "name7", c => c.String());
            AddColumn("dbo.C_StoreProcedure", "name7", c => c.String());
            AddColumn("dbo.C_Table", "name7", c => c.String());
            AddColumn("dbo.P_Column", "name7", c => c.String());
            AddColumn("dbo.P_StoreProcedure", "name7", c => c.String());
            AddColumn("dbo.P_Table", "name7", c => c.String());
            AddColumn("dbo.R_Column", "name7", c => c.String());
            AddColumn("dbo.R_StoreProcedure", "name7", c => c.String());
            AddColumn("dbo.R_Table", "name7", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.R_Table", "name7");
            DropColumn("dbo.R_StoreProcedure", "name7");
            DropColumn("dbo.R_Column", "name7");
            DropColumn("dbo.P_Table", "name7");
            DropColumn("dbo.P_StoreProcedure", "name7");
            DropColumn("dbo.P_Column", "name7");
            DropColumn("dbo.C_Table", "name7");
            DropColumn("dbo.C_StoreProcedure", "name7");
            DropColumn("dbo.C_Column", "name7");
        }
    }
}
