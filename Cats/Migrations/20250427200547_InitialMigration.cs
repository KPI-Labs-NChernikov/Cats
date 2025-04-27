using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cats.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    MinWeight = table.Column<decimal>(type: "numeric", nullable: false),
                    MaxWeight = table.Column<decimal>(type: "numeric", nullable: false),
                    Size = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personalities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatsCoats",
                columns: table => new
                {
                    CatsId = table.Column<Guid>(type: "uuid", nullable: false),
                    CoatsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatsCoats", x => new { x.CatsId, x.CoatsId });
                    table.ForeignKey(
                        name: "FK_CatsCoats_Cats_CatsId",
                        column: x => x.CatsId,
                        principalTable: "Cats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatsCoats_Coats_CoatsId",
                        column: x => x.CoatsId,
                        principalTable: "Coats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatsPersonalities",
                columns: table => new
                {
                    CatsId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonalitiesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatsPersonalities", x => new { x.CatsId, x.PersonalitiesId });
                    table.ForeignKey(
                        name: "FK_CatsPersonalities_Cats_CatsId",
                        column: x => x.CatsId,
                        principalTable: "Cats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatsPersonalities_Personalities_PersonalitiesId",
                        column: x => x.PersonalitiesId,
                        principalTable: "Personalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cats_Name",
                table: "Cats",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CatsCoats_CoatsId",
                table: "CatsCoats",
                column: "CoatsId");

            migrationBuilder.CreateIndex(
                name: "IX_CatsPersonalities_PersonalitiesId",
                table: "CatsPersonalities",
                column: "PersonalitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Coats_Name",
                table: "Coats",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personalities_Name",
                table: "Personalities",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatsCoats");

            migrationBuilder.DropTable(
                name: "CatsPersonalities");

            migrationBuilder.DropTable(
                name: "Coats");

            migrationBuilder.DropTable(
                name: "Cats");

            migrationBuilder.DropTable(
                name: "Personalities");
        }
    }
}
