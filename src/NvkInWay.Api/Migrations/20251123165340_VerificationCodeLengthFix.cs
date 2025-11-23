using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NvkInWay.Api.Migrations
{
    /// <inheritdoc />
    public partial class VerificationCodeLengthFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VerificationCode",
                table: "Verifications");

            migrationBuilder.AlterColumn<string>(
                name: "UnconfirmedEmailCode",
                table: "Verifications",
                type: "character varying(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UnconfirmedEmailCode",
                table: "Verifications",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(64)",
                oldMaxLength: 64);

            migrationBuilder.AddColumn<string>(
                name: "VerificationCode",
                table: "Verifications",
                type: "character varying(10)",
                maxLength: 10,
                nullable: true);
        }
    }
}
