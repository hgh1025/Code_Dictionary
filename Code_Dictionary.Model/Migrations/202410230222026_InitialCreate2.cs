namespace Code_Dictionary.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.C_Column", "Description", c => c.String());
            AddColumn("dbo.C_StoreProcedure", "Description", c => c.String());
            AddColumn("dbo.C_Table", "Description", c => c.String());
            AddColumn("dbo.C_Word", "Description", c => c.String());
            AddColumn("dbo.P_Column", "Description", c => c.String());
            AddColumn("dbo.P_StoreProcedure", "Description", c => c.String());
            AddColumn("dbo.P_Table", "Description", c => c.String());
            AddColumn("dbo.P_Word", "Description", c => c.String());
            AddColumn("dbo.R_Column", "Description", c => c.String());
            AddColumn("dbo.R_StoreProcedure", "Description", c => c.String());
            AddColumn("dbo.R_Table", "Description", c => c.String());
            AddColumn("dbo.R_Word", "Description", c => c.String());
            DropColumn("dbo.C_Column", "Desc");
            DropColumn("dbo.C_StoreProcedure", "Desc");
            DropColumn("dbo.C_Table", "Desc");
            DropColumn("dbo.C_Word", "Desc");
            DropColumn("dbo.P_Column", "Desc");
            DropColumn("dbo.P_StoreProcedure", "Desc");
            DropColumn("dbo.P_Table", "Desc");
            DropColumn("dbo.P_Word", "Desc");
            DropColumn("dbo.R_Column", "Desc");
            DropColumn("dbo.R_StoreProcedure", "Desc");
            DropColumn("dbo.R_Table", "Desc");
            DropColumn("dbo.R_Word", "Desc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.R_Word", "Desc", c => c.String());
            AddColumn("dbo.R_Table", "Desc", c => c.String());
            AddColumn("dbo.R_StoreProcedure", "Desc", c => c.String());
            AddColumn("dbo.R_Column", "Desc", c => c.String());
            AddColumn("dbo.P_Word", "Desc", c => c.String());
            AddColumn("dbo.P_Table", "Desc", c => c.String());
            AddColumn("dbo.P_StoreProcedure", "Desc", c => c.String());
            AddColumn("dbo.P_Column", "Desc", c => c.String());
            AddColumn("dbo.C_Word", "Desc", c => c.String());
            AddColumn("dbo.C_Table", "Desc", c => c.String());
            AddColumn("dbo.C_StoreProcedure", "Desc", c => c.String());
            AddColumn("dbo.C_Column", "Desc", c => c.String());
            DropColumn("dbo.R_Word", "Description");
            DropColumn("dbo.R_Table", "Description");
            DropColumn("dbo.R_StoreProcedure", "Description");
            DropColumn("dbo.R_Column", "Description");
            DropColumn("dbo.P_Word", "Description");
            DropColumn("dbo.P_Table", "Description");
            DropColumn("dbo.P_StoreProcedure", "Description");
            DropColumn("dbo.P_Column", "Description");
            DropColumn("dbo.C_Word", "Description");
            DropColumn("dbo.C_Table", "Description");
            DropColumn("dbo.C_StoreProcedure", "Description");
            DropColumn("dbo.C_Column", "Description");
        }
    }
}
