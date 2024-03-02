using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Infrastructure.Data.Migrations
{
	/// <inheritdoc />
	public partial class NewStart : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Categories",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Categories", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "TaskItems",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					TaskMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Completed = table.Column<bool>(type: "bit", nullable: false),
					DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
					DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
					CategoryId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_TaskItems", x => x.Id);
					table.ForeignKey(
						name: "FK_TaskItems_Categories_CategoryId",
						column: x => x.CategoryId,
						principalTable: "Categories",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_TaskItems_CategoryId",
				table: "TaskItems",
				column: "CategoryId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "TaskItems");

			migrationBuilder.DropTable(
				name: "Categories");
		}
	}
}
