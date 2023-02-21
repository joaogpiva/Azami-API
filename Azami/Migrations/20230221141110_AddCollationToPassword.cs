using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Azami.Migrations
{
    /// <inheritdoc />
    public partial class AddCollationToPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MasterPassword",
                table: "Users",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                collation: "latin1_general_cs",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MasterPassword",
                table: "Users",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldCollation: "latin1_general_cs")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
