namespace Code_Dictionary.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tables", newName: "C_Table");
            DropPrimaryKey("dbo.C_Table");
            CreateTable(
                "dbo.P_Table",
                c => new
                    {
                        TableId = c.Int(nullable: false, identity: true),
                        name1 = c.String(),
                        name2 = c.String(),
                        name3 = c.String(),
                        name4 = c.String(),
                        name5 = c.String(),
                        name6 = c.String(),
                        Table_name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.TableId);
            
            CreateTable(
                "dbo.R_Table",
                c => new
                    {
                        TableId = c.Int(nullable: false, identity: true),
                        name1 = c.String(),
                        name2 = c.String(),
                        name3 = c.String(),
                        name4 = c.String(),
                        name5 = c.String(),
                        name6 = c.String(),
                        Table_name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.TableId);
            
            AlterColumn("dbo.C_Table", "TableId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.C_Table", "TableId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.C_Table");
            AlterColumn("dbo.C_Table", "TableId", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.R_Table");
            DropTable("dbo.P_Table");
            AddPrimaryKey("dbo.C_Table", "TableId");
            RenameTable(name: "dbo.C_Table", newName: "Tables");
        }
    }
}
