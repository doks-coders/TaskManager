﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Infrastructure.Identity.Migrations
{
	/// <inheritdoc />
	public partial class IdentityUserModified : Migration
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
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "Discriminator",
				table: "AspNetUsers");
		}
	}
}
