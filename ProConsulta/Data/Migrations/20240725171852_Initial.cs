using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProConsulta.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Documento = table.Column<string>(type: "NVARCHAR(11)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Celular = table.Column<string>(type: "NVARCHAR(11)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Documento = table.Column<string>(type: "NVARCHAR(11)", nullable: false),
                    CRM = table.Column<string>(type: "NVARCHAR(8)", nullable: false),
                    Celular = table.Column<string>(type: "NVARCHAR(11)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EspecialidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicos_Especialidades_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observacao = table.Column<string>(type: "VARCHAR(250)", nullable: true),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    HoraConsulta = table.Column<TimeSpan>(type: "time", nullable: false),
                    DataConsulta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b9cc004d-9d36-4cf4-a00b-ec696f2c7443", null, "Medico", "MEDICO" },
                    { "e9a8e208-d1d1-45c5-95a1-dd8055532261", null, "Atendente", "ATENDENTE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6f471be3-3fff-4ded-9a50-75b8632eb5e1", 0, "259d2783-e014-456f-909d-b35d71d50559", "Atendente", "proconsulta@hotmail.com.br", true, false, null, "Pro Consulta", "PROCONSULTA@HOTMAIL.COM.BR", "PROCONSULTA@HOTMAIL.COM.BR", "AQAAAAIAAYagAAAAED0ZMXkVF2peZzwl5XEkPta147OZFgdPtruUo59WoE3F9bepXCL4KuhGgEGSAvUzWw==", null, false, "f9317f9b-6d1c-4af8-9948-107198c98981", false, "proconsulta@hotmail.com.br" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, "Especialidade que lida com o diagnóstico e tratamento de doenças cardíacas", "Cardiologia" },
                    { 2, "Especialidade que se concentra no diagnóstico e tratamento de condições da pele", "Dermatologia" },
                    { 3, "Especialidade que lida com o diagnóstico e tratamento de distúrbios hormonais", "Endocrinologia" },
                    { 4, "Especialidade que se concentra no diagnóstico e tratamento de distúrbios do sistema digestivo", "Gastroenterologia" },
                    { 5, "Especialidade que lida com o diagnóstico e tratamento de distúrbios do sistema reprodutor feminino", "Ginecologia" },
                    { 6, "Especialidade que se concentra no diagnóstico e tratamento de doenças infecciosas", "Infectologia" },
                    { 7, "Especialidade que lida com o diagnóstico e tratamento de distúrbios do sistema nervoso", "Neurologia" },
                    { 8, "Especialidade que se concentra no diagnóstico e tratamento de distúrbios oculares", "Oftalmologia" },
                    { 9, "Especialidade que lida com o diagnóstico e tratamento de distúrbios do sistema musculoesquelético", "Ortopedia" },
                    { 10, "Especialidade que se concentra no diagnóstico e tratamento de distúrbios do ouvido, nariz e garganta", "Otorrinolaringologia" },
                    { 11, "Especialidade que lida com o atendimento médico de bebês, crianças e adolescentes", "Pediatria" },
                    { 12, "Especialidade que se concentra no diagnóstico e tratamento de distúrbios do sistema respiratório", "Pneumologia" },
                    { 13, "Especialidade que lida com o diagnóstico e tratamento de distúrbios mentais", "Psiquiatria" },
                    { 14, "Especialidade que se concentra no diagnóstico e tratamento de doenças reumáticas", "Reumatologia" },
                    { 15, "Especialidade que lida com o diagnóstico e tratamento de distúrbios do sistema urinário", "Urologia" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e9a8e208-d1d1-45c5-95a1-dd8055532261", "6f471be3-3fff-4ded-9a50-75b8632eb5e1" });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_MedicoId",
                table: "Agendamentos",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_PacienteId",
                table: "Agendamentos",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_Documento",
                table: "Medicos",
                column: "Documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_EspecialidadeId",
                table: "Medicos",
                column: "EspecialidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_Documento",
                table: "Pacientes",
                column: "Documento",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9cc004d-9d36-4cf4-a00b-ec696f2c7443");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e9a8e208-d1d1-45c5-95a1-dd8055532261", "6f471be3-3fff-4ded-9a50-75b8632eb5e1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9a8e208-d1d1-45c5-95a1-dd8055532261");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6f471be3-3fff-4ded-9a50-75b8632eb5e1");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "AspNetUsers");
        }
    }
}
