using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Infrastructure.Data.Migrations
{
	/// <inheritdoc />
	public partial class YourMigration : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<DateTime>(
				name: "DateChosen",
				table: "TaskItems",
				type: "datetime2",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

			migrationBuilder.AddColumn<string>(
				name: "DaysSelected",
				table: "TaskItems",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "");

			migrationBuilder.AddColumn<bool>(
				name: "Recurring",
				table: "TaskItems",
				type: "bit",
				nullable: false,
				defaultValue: false);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "DateChosen",
				table: "TaskItems");

			migrationBuilder.DropColumn(
				name: "DaysSelected",
				table: "TaskItems");

			migrationBuilder.DropColumn(
				name: "Recurring",
				table: "TaskItems");
		}
	}
}
