using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseAI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddednewFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SequenceNumber",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Conversations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SequenceNumber",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Conversations");
        }
    }
}
