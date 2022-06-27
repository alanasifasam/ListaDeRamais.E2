using Microsoft.EntityFrameworkCore.Migrations;

namespace ListaDeRamais.E2.Migrations
{
    public partial class tel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_funcionario_telefone_CodigoFunFk",
                table: "funcionario");

            migrationBuilder.DropIndex(
                name: "IX_funcionario_CodigoFunFk",
                table: "funcionario");

            migrationBuilder.AlterColumn<string>(
                name: "sobrenome",
                table: "funcionario",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "funcionario",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "funcionario",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cargo",
                table: "funcionario",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_telefone_codigo_fun_Fk",
                table: "telefone",
                column: "codigo_fun_Fk");

            migrationBuilder.AddForeignKey(
                name: "fk_telefone",
                table: "telefone",
                column: "codigo_fun_Fk",
                principalTable: "funcionario",
                principalColumn: "codigo_fun_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_telefone",
                table: "telefone");

            migrationBuilder.DropIndex(
                name: "IX_telefone_codigo_fun_Fk",
                table: "telefone");

            migrationBuilder.AlterColumn<string>(
                name: "sobrenome",
                table: "funcionario",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "funcionario",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "funcionario",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "cargo",
                table: "funcionario",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "IX_funcionario_CodigoFunFk",
                table: "funcionario",
                column: "CodigoFunFk",
                unique: true,
                filter: "[CodigoFunFk] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_funcionario_telefone_CodigoFunFk",
                table: "funcionario",
                column: "CodigoFunFk",
                principalTable: "telefone",
                principalColumn: "codigo_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
