using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KnerdyKnitter.Migrations
{
    public partial class removeKnitterIdColOnColors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colors_Knitters_KnitterId",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "KnitterId",
                table: "Colors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colors_Knitters_KnitterId",
                table: "Colors");

            migrationBuilder.AlterColumn<int>(
                name: "KnitterId",
                table: "Colors",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Colors_Knitters_KnitterId",
                table: "Colors",
                column: "KnitterId",
                principalTable: "Knitters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
