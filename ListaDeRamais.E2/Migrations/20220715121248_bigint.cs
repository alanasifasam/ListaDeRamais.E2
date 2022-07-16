using Microsoft.EntityFrameworkCore.Migrations;

namespace ListaDeRamais.E2.Migrations
{
    public partial class bigint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ramais_departamento_DepartamentoCodigoDepId",
                table: "ramais");

            migrationBuilder.DropIndex(
                name: "IX_ramais_DepartamentoCodigoDepId",
                table: "ramais");

            migrationBuilder.DropColumn(
                name: "CodigoDepId",
                table: "ramais");

            migrationBuilder.DropColumn(
                name: "DepartamentoCodigoDepId",
                table: "ramais");

            migrationBuilder.AlterColumn<string>(
                name: "numero_telefone",
                table: "telefone",
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

            migrationBuilder.AlterColumn<int>(
                name: "numero_ramal",
                table: "ramais",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "host_ip",
                table: "ramais",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "departamento",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "numero_telefone",
                table: "telefone",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "numero_ramal",
                table: "ramais",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "host_ip",
                table: "ramais",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CodigoDepId",
                table: "ramais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoCodigoDepId",
                table: "ramais",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "departamento",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "IX_ramais_DepartamentoCodigoDepId",
                table: "ramais",
                column: "DepartamentoCodigoDepId");

            migrationBuilder.AddForeignKey(
                name: "FK_ramais_departamento_DepartamentoCodigoDepId",
                table: "ramais",
                column: "DepartamentoCodigoDepId",
                principalTable: "departamento",
                principalColumn: "codigo_dep_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
