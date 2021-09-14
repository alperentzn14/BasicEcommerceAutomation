namespace TicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 10, unicode: false),
                        UserPassword = c.String(maxLength: 30, unicode: false),
                        Authorization = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(maxLength: 30, unicode: false),
                        Brand = c.String(maxLength: 30, unicode: false),
                        Stock = c.Short(nullable: false),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Boolean(nullable: false),
                        ProductImage = c.String(maxLength: 150, unicode: false),
                        Category_CategoryId = c.Int(),
                        SalesMove_SalesMoveId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .ForeignKey("dbo.SalesMoves", t => t.SalesMove_SalesMoveId)
                .Index(t => t.Category_CategoryId)
                .Index(t => t.SalesMove_SalesMoveId);
            
            CreateTable(
                "dbo.SalesMoves",
                c => new
                    {
                        SalesMoveId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SalesMoveId);
            
            CreateTable(
                "dbo.Currents",
                c => new
                    {
                        CurrentId = c.Int(nullable: false, identity: true),
                        CurrentName = c.String(maxLength: 30, unicode: false),
                        CurrentSurName = c.String(maxLength: 30, unicode: false),
                        CurrentCity = c.String(maxLength: 15, unicode: false),
                        CurrentMail = c.String(maxLength: 30, unicode: false),
                        SalesMove_SalesMoveId = c.Int(),
                    })
                .PrimaryKey(t => t.CurrentId)
                .ForeignKey("dbo.SalesMoves", t => t.SalesMove_SalesMoveId)
                .Index(t => t.SalesMove_SalesMoveId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        PersonName = c.String(maxLength: 30, unicode: false),
                        PersonSurName = c.String(maxLength: 30, unicode: false),
                        PersonImage = c.String(maxLength: 150, unicode: false),
                        Department_DepartmentId = c.Int(),
                        SalesMove_SalesMoveId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId)
                .ForeignKey("dbo.SalesMoves", t => t.SalesMove_SalesMoveId)
                .Index(t => t.Department_DepartmentId)
                .Index(t => t.SalesMove_SalesMoveId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmantName = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ExpenseId = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100, unicode: false),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ExpenseId);
            
            CreateTable(
                "dbo.InvoicePens",
                c => new
                    {
                        InvoicePenId = c.Int(nullable: false, identity: true),
                        InvoiceDescription = c.String(maxLength: 100, unicode: false),
                        InvoiceQuantity = c.Int(nullable: false),
                        InvoiceUnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Invoice_InvoiceId = c.Int(),
                    })
                .PrimaryKey(t => t.InvoicePenId)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceId)
                .Index(t => t.Invoice_InvoiceId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        InvoiceSerialNumber = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        InvoiceOrderNumber = c.String(maxLength: 10, unicode: false),
                        InvoiceDate = c.DateTime(nullable: false),
                        InvoiceTaxOffice = c.String(maxLength: 60, unicode: false),
                        InvoiceHour = c.DateTime(nullable: false),
                        InvoiceToSubmit = c.String(maxLength: 30, unicode: false),
                        InvoiceReceive = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.InvoiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoicePens", "Invoice_InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Products", "SalesMove_SalesMoveId", "dbo.SalesMoves");
            DropForeignKey("dbo.People", "SalesMove_SalesMoveId", "dbo.SalesMoves");
            DropForeignKey("dbo.People", "Department_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Currents", "SalesMove_SalesMoveId", "dbo.SalesMoves");
            DropForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.InvoicePens", new[] { "Invoice_InvoiceId" });
            DropIndex("dbo.People", new[] { "SalesMove_SalesMoveId" });
            DropIndex("dbo.People", new[] { "Department_DepartmentId" });
            DropIndex("dbo.Currents", new[] { "SalesMove_SalesMoveId" });
            DropIndex("dbo.Products", new[] { "SalesMove_SalesMoveId" });
            DropIndex("dbo.Products", new[] { "Category_CategoryId" });
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoicePens");
            DropTable("dbo.Expenses");
            DropTable("dbo.Departments");
            DropTable("dbo.People");
            DropTable("dbo.Currents");
            DropTable("dbo.SalesMoves");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Admins");
        }
    }
}
