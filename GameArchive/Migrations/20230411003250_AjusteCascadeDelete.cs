using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameArchive.Migrations
{
    /// <inheritdoc />
    public partial class AjusteCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Desenvolvedoras_DesenvolvedoraId",
                table: "Jogos");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Generos_GeneroId",
                table: "Jogos");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Plataformas_PlataformaId",
                table: "Jogos");

            migrationBuilder.DropForeignKey(
                name: "FK_PlataformasUsuarios_Plataformas_PlataformaId",
                table: "PlataformasUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_PlataformasUsuarios_Usuarios_UsuarioId",
                table: "PlataformasUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosJogos_Jogos_JogoId",
                table: "UsuariosJogos");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosJogos_Usuarios_UsuarioId",
                table: "UsuariosJogos");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Desenvolvedoras_DesenvolvedoraId",
                table: "Jogos",
                column: "DesenvolvedoraId",
                principalTable: "Desenvolvedoras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Generos_GeneroId",
                table: "Jogos",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Plataformas_PlataformaId",
                table: "Jogos",
                column: "PlataformaId",
                principalTable: "Plataformas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlataformasUsuarios_Plataformas_PlataformaId",
                table: "PlataformasUsuarios",
                column: "PlataformaId",
                principalTable: "Plataformas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlataformasUsuarios_Usuarios_UsuarioId",
                table: "PlataformasUsuarios",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosJogos_Jogos_JogoId",
                table: "UsuariosJogos",
                column: "JogoId",
                principalTable: "Jogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosJogos_Usuarios_UsuarioId",
                table: "UsuariosJogos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Desenvolvedoras_DesenvolvedoraId",
                table: "Jogos");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Generos_GeneroId",
                table: "Jogos");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Plataformas_PlataformaId",
                table: "Jogos");

            migrationBuilder.DropForeignKey(
                name: "FK_PlataformasUsuarios_Plataformas_PlataformaId",
                table: "PlataformasUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_PlataformasUsuarios_Usuarios_UsuarioId",
                table: "PlataformasUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosJogos_Jogos_JogoId",
                table: "UsuariosJogos");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosJogos_Usuarios_UsuarioId",
                table: "UsuariosJogos");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Desenvolvedoras_DesenvolvedoraId",
                table: "Jogos",
                column: "DesenvolvedoraId",
                principalTable: "Desenvolvedoras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Generos_GeneroId",
                table: "Jogos",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Plataformas_PlataformaId",
                table: "Jogos",
                column: "PlataformaId",
                principalTable: "Plataformas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlataformasUsuarios_Plataformas_PlataformaId",
                table: "PlataformasUsuarios",
                column: "PlataformaId",
                principalTable: "Plataformas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlataformasUsuarios_Usuarios_UsuarioId",
                table: "PlataformasUsuarios",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosJogos_Jogos_JogoId",
                table: "UsuariosJogos",
                column: "JogoId",
                principalTable: "Jogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosJogos_Usuarios_UsuarioId",
                table: "UsuariosJogos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
