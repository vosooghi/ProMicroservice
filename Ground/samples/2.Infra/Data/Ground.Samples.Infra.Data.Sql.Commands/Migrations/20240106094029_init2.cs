﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ground.Samples.Infra.Data.Sql.Commands.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Person",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Person",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUserId",
                table: "Person",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "Person",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "Person");
        }
    }
}
