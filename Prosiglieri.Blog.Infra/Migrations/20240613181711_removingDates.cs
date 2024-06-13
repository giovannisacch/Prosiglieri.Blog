using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prosiglieri.Blog.Infra.Migrations
{
    /// <inheritdoc />
    public partial class removingDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "Updated_at",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "blog_post");

            migrationBuilder.DropColumn(
                name: "Updated_at",
                table: "blog_post");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "comments",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated_at",
                table: "comments",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "blog_post",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated_at",
                table: "blog_post",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
