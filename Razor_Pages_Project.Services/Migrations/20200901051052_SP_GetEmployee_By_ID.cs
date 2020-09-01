using Microsoft.EntityFrameworkCore.Migrations;

namespace Razor_Pages_Project.Services.Migrations
{
    public partial class SP_GetEmployee_By_ID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string Procudre = @"Create procedure sp_Get_Employee_By_ID
                    @ID int

                    AS
                    Begin
                       Select * from Employees Where ID= @ID
                    END";
            migrationBuilder.Sql(Procudre);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string Procudre = @"Drop procedure sp_Get_Employee_By_ID ";
            migrationBuilder.Sql(Procudre);
        }
    }
}
