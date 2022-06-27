using Microsoft.EntityFrameworkCore.Migrations;

namespace ListaDeRamais.E2.Migrations
{
    public partial class n : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "empresa",
                columns: table => new
                {
                    codigo_emp_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__empresa__06E01EEBD776268B", x => x.codigo_emp_id);
                });

            migrationBuilder.CreateTable(
                name: "telefone",
                columns: table => new
                {
                    codigo_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero_telefone = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    codigo_fun_Fk = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__telefone__75B12964F04ABC52", x => x.codigo_id);
                });

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    codigo_dep_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    codigo_emp_FK = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__departam__4A80D52132E81028", x => x.codigo_dep_id);
                    table.ForeignKey(
                        name: "FK_empresa_dep",
                        column: x => x.codigo_emp_FK,
                        principalTable: "empresa",
                        principalColumn: "codigo_emp_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "funcionario",
                columns: table => new
                {
                    codigo_fun_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    sobrenome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    cargo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CodigoFunFk = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__funciona__11EC4FC4F4B61F7A", x => x.codigo_fun_id);
                    table.ForeignKey(
                        name: "FK_funcionario_telefone_CodigoFunFk",
                        column: x => x.CodigoFunFk,
                        principalTable: "telefone",
                        principalColumn: "codigo_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ramais",
                columns: table => new
                {
                    codigo_ramal_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero_ramal = table.Column<int>(type: "int", nullable: true),
                    senha = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    host_ip = table.Column<int>(type: "int", nullable: true),
                    codigo_dep_FK = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ramais__16F01D351FA7E035", x => x.codigo_ramal_id);
                    table.ForeignKey(
                        name: "FK_DEP_RAMAIS",
                        column: x => x.codigo_dep_FK,
                        principalTable: "departamento",
                        principalColumn: "codigo_dep_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "fun_ramais",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo_fun_FK = table.Column<int>(type: "int", nullable: true),
                    codigo_ramal_FK = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fun_ramais", x => x.id);
                    table.ForeignKey(
                        name: "fk_fun_ramal",
                        column: x => x.codigo_fun_FK,
                        principalTable: "funcionario",
                        principalColumn: "codigo_fun_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ramal_fun",
                        column: x => x.codigo_ramal_FK,
                        principalTable: "ramais",
                        principalColumn: "codigo_ramal_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_departamento_codigo_emp_FK",
                table: "departamento",
                column: "codigo_emp_FK");

            migrationBuilder.CreateIndex(
                name: "IX_fun_ramais_codigo_fun_FK",
                table: "fun_ramais",
                column: "codigo_fun_FK");

            migrationBuilder.CreateIndex(
                name: "IX_fun_ramais_codigo_ramal_FK",
                table: "fun_ramais",
                column: "codigo_ramal_FK");

            migrationBuilder.CreateIndex(
                name: "IX_funcionario_CodigoFunFk",
                table: "funcionario",
                column: "CodigoFunFk",
                unique: true,
                filter: "[CodigoFunFk] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ramais_codigo_dep_FK",
                table: "ramais",
                column: "codigo_dep_FK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fun_ramais");

            migrationBuilder.DropTable(
                name: "funcionario");

            migrationBuilder.DropTable(
                name: "ramais");

            migrationBuilder.DropTable(
                name: "telefone");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "empresa");
        }
    }
}
