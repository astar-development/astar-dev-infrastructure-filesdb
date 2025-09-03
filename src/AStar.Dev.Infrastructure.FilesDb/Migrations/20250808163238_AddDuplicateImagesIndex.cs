using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AStar.Dev.Infrastructure.FilesDb.Migrations;

/// <inheritdoc />
public partial class AddDuplicateImagesIndex : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropIndex(
                                       name: "IX_FileDetail_FileHandle",
                                       schema: "files",
                                       table: "FileDetail");

        _ = migrationBuilder.CreateIndex(
                                         name: "IX_FileDetail_DuplicateImages",
                                         schema: "files",
                                         table: "FileDetail",
                                         columns: ["IsImage", "FileSize"]);

        _ = migrationBuilder.CreateIndex(
                                         name: "IX_FileDetail_FileHandle",
                                         schema: "files",
                                         table: "FileDetail",
                                         column: "FileHandle",
                                         unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropIndex(
                                       name: "IX_FileDetail_DuplicateImages",
                                       schema: "files",
                                       table: "FileDetail");

        _ = migrationBuilder.DropIndex(
                                       name: "IX_FileDetail_FileHandle",
                                       schema: "files",
                                       table: "FileDetail");

        _ = migrationBuilder.CreateIndex(
                                         name: "IX_FileDetail_FileHandle",
                                         schema: "files",
                                         table: "FileDetail",
                                         column: "FileHandle");
    }
}