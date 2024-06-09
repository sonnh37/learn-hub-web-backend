using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWD.SmartThrive.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Student",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Provider_UserId",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Subject",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Student",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Session",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Package",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Order",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "Location",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Course",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Category",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CategorytName",
                table: "Category",
                newName: "CategoryName");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Subject",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Subject",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Student",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Student",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Student",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Session",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Session",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Role",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Role",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                table: "Role",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Role",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Provider",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Provider",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Provider",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Provider",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                table: "Provider",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Provider",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Package",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Package",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Order",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Location",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Location",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                table: "Location",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Location",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CoursePackage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CoursePackage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "CoursePackage",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CoursePackage",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                table: "CoursePackage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "CoursePackage",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Course",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Course",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Course",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Category",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Category",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Provider_UserId",
                table: "Provider",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Student",
                table: "Student",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Student",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Provider_UserId",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastUpdatedDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "LastUpdatedDate",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "LastUpdatedDate",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "LastUpdatedDate",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CoursePackage");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CoursePackage");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CoursePackage");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CoursePackage");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "CoursePackage");

            migrationBuilder.DropColumn(
                name: "LastUpdatedDate",
                table: "CoursePackage");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Subject",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Student",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Session",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Package",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Order",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Location",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Course",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Category",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Category",
                newName: "CategorytName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Subject",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Subject",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Student",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Student",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Student",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Session",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Session",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Provider",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Package",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Package",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Order",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Course",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Course",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Course",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Category",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Category",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Provider_UserId",
                table: "Provider",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Student",
                table: "Student",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
