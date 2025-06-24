using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuristicaAt.Data.Migrations
{
    /// <inheritdoc />
    public partial class Teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PacoteTuristico_Destino_DestinoId",
                table: "PacoteTuristico");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Cliente_ClienteId",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_PacoteTuristico_PacoteTuristicoId",
                table: "Reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PacoteTuristico",
                table: "PacoteTuristico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Destino",
                table: "Destino");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.RenameTable(
                name: "PacoteTuristico",
                newName: "PacoteTuristicos");

            migrationBuilder.RenameTable(
                name: "Destino",
                newName: "Destinos");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "Clientes");

            migrationBuilder.RenameIndex(
                name: "IX_PacoteTuristico_DestinoId",
                table: "PacoteTuristicos",
                newName: "IX_PacoteTuristicos_DestinoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PacoteTuristicos",
                table: "PacoteTuristicos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destinos",
                table: "Destinos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PacoteTuristicos_Destinos_DestinoId",
                table: "PacoteTuristicos",
                column: "DestinoId",
                principalTable: "Destinos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Clientes_ClienteId",
                table: "Reservas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_PacoteTuristicos_PacoteTuristicoId",
                table: "Reservas",
                column: "PacoteTuristicoId",
                principalTable: "PacoteTuristicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PacoteTuristicos_Destinos_DestinoId",
                table: "PacoteTuristicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Clientes_ClienteId",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_PacoteTuristicos_PacoteTuristicoId",
                table: "Reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PacoteTuristicos",
                table: "PacoteTuristicos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Destinos",
                table: "Destinos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.RenameTable(
                name: "PacoteTuristicos",
                newName: "PacoteTuristico");

            migrationBuilder.RenameTable(
                name: "Destinos",
                newName: "Destino");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "Cliente");

            migrationBuilder.RenameIndex(
                name: "IX_PacoteTuristicos_DestinoId",
                table: "PacoteTuristico",
                newName: "IX_PacoteTuristico_DestinoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PacoteTuristico",
                table: "PacoteTuristico",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destino",
                table: "Destino",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PacoteTuristico_Destino_DestinoId",
                table: "PacoteTuristico",
                column: "DestinoId",
                principalTable: "Destino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Cliente_ClienteId",
                table: "Reservas",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_PacoteTuristico_PacoteTuristicoId",
                table: "Reservas",
                column: "PacoteTuristicoId",
                principalTable: "PacoteTuristico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
