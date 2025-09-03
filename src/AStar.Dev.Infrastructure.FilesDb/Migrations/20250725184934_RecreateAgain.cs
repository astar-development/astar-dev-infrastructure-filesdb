﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AStar.Dev.Infrastructure.FilesDb.Migrations;

/// <inheritdoc />
public partial class RecreateAgain : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.EnsureSchema(
                                          name: "files");

        _ = migrationBuilder.CreateTable(
                                         name: "Event",
                                         schema: "files",
                                         columns: table => new
                                                           {
                                                               Id = table.Column<int>(type: "int", nullable: false)
                                                                         .Annotation("SqlServer:Identity", "1, 1"),
                                                               EventOccurredAt  = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                                                               FileName         = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                                                               DirectoryName    = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                                                               Handle           = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                                                               Width            = table.Column<int>(type: "int", nullable: true),
                                                               Height           = table.Column<int>(type: "int", nullable: true),
                                                               FileSize         = table.Column<long>(type: "bigint", nullable: false),
                                                               FileCreated      = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                                                               FileLastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                                                               UpdatedBy        = table.Column<string>(type: "nvarchar(30)",  maxLength: 30, nullable: false),
                                                               EventName        = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                                               EventType        = table.Column<int>(type: "int", nullable: false)
                                                           },
                                         constraints: table => _ = table.PrimaryKey("PK_Event", x => x.Id));

        _ = migrationBuilder.CreateTable(
                                         name: "FileClassification",
                                         schema: "files",
                                         columns: table => new
                                                           {
                                                               Id = table.Column<int>(type: "int", nullable: false)
                                                                         .Annotation("SqlServer:Identity", "1, 1"),
                                                               Name      = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                                                               Celebrity = table.Column<bool>(type: "bit", nullable: false)
                                                           },
                                         constraints: table => _ = table.PrimaryKey("PK_FileClassification", x => x.Id));

        _ = migrationBuilder.CreateTable(
                                         name: "FileDetail",
                                         schema: "files",
                                         columns: table => new
                                                           {
                                                               Id                = table.Column<int>(type: "int", nullable: false),
                                                               FileName          = table.Column<string>(type: "nvarchar(256)", nullable: false),
                                                               FileSize          = table.Column<long>(type: "bigint", nullable: false),
                                                               IsImage           = table.Column<bool>(type: "bit", nullable: false),
                                                               FileHandle        = table.Column<string>(type: "nvarchar(256)", nullable: false),
                                                               FileCreated       = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                                                               FileLastModified  = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                                                               FileLastViewed    = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                                                               MoveRequired      = table.Column<bool>(type: "bit", nullable: false),
                                                               HardDeletePending = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                                                               SoftDeletePending = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                                                               SoftDeleted       = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                                                               ImageHeight       = table.Column<int>(type: "int", nullable: true),
                                                               ImageWidth        = table.Column<int>(type: "int", nullable: true),
                                                               UpdatedBy         = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                                               UpdatedOn         = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                                                           },
                                         constraints: table => _ = table.PrimaryKey("PK_FileDetail", x => x.Id));

        _ = migrationBuilder.CreateTable(
                                         name: "FileNamePart",
                                         schema: "files",
                                         columns: table => new
                                                           {
                                                               Id = table.Column<int>(type: "int", nullable: false)
                                                                         .Annotation("SqlServer:Identity", "1, 1"),
                                                               Text                 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                                                               FileClassificationId = table.Column<int>(type: "int", nullable: true)
                                                           },
                                         constraints: table =>
                                                      {
                                                          _ = table.PrimaryKey("PK_FileNamePart", x => x.Id);

                                                          _ = table.ForeignKey(
                                                                               name: "FK_FileNamePart_FileClassification_FileClassificationId",
                                                                               column: x => x.FileClassificationId,
                                                                               principalSchema: "files",
                                                                               principalTable: "FileClassification",
                                                                               principalColumn: "Id");
                                                      });

        _ = migrationBuilder.CreateTable(
                                         name: "FileClassificationFileDetail",
                                         schema: "files",
                                         columns: table => new
                                                           {
                                                               FileClassificationsId = table.Column<int>(type: "int", nullable: false),
                                                               FileDetailsId         = table.Column<int>(type: "int", nullable: false)
                                                           },
                                         constraints: table =>
                                                      {
                                                          _ = table.PrimaryKey("PK_FileClassificationFileDetail", x => new { x.FileClassificationsId, x.FileDetailsId });

                                                          _ = table.ForeignKey(
                                                                               name: "FK_FileClassificationFileDetail_FileClassification_FileClassificationsId",
                                                                               column: x => x.FileClassificationsId,
                                                                               principalSchema: "files",
                                                                               principalTable: "FileClassification",
                                                                               principalColumn: "Id",
                                                                               onDelete: ReferentialAction.Cascade);

                                                          _ = table.ForeignKey(
                                                                               name: "FK_FileClassificationFileDetail_FileDetail_FileDetailsId",
                                                                               column: x => x.FileDetailsId,
                                                                               principalSchema: "files",
                                                                               principalTable: "FileDetail",
                                                                               principalColumn: "Id",
                                                                               onDelete: ReferentialAction.Cascade);
                                                      });

        _ = migrationBuilder.CreateTable(
                                         name: "FileClassificationFileNamePart",
                                         schema: "files",
                                         columns: table => new
                                                           {
                                                               FileClassificationsId = table.Column<int>(type: "int", nullable: false),
                                                               FileNamePartsId       = table.Column<int>(type: "int", nullable: false)
                                                           },
                                         constraints: table =>
                                                      {
                                                          _ = table.PrimaryKey("PK_FileClassificationFileNamePart", x => new { x.FileClassificationsId, x.FileNamePartsId });

                                                          _ = table.ForeignKey(
                                                                               name: "FK_FileClassificationFileNamePart_FileClassification_FileClassificationsId",
                                                                               column: x => x.FileClassificationsId,
                                                                               principalSchema: "files",
                                                                               principalTable: "FileClassification",
                                                                               principalColumn: "Id",
                                                                               onDelete: ReferentialAction.Cascade);

                                                          _ = table.ForeignKey(
                                                                               name: "FK_FileClassificationFileNamePart_FileNamePart_FileNamePartsId",
                                                                               column: x => x.FileNamePartsId,
                                                                               principalSchema: "files",
                                                                               principalTable: "FileNamePart",
                                                                               principalColumn: "Id",
                                                                               onDelete: ReferentialAction.Cascade);
                                                      });

        _ = migrationBuilder.CreateIndex(
                                         name: "IX_FileClassificationFileDetail_FileDetailsId",
                                         schema: "files",
                                         table: "FileClassificationFileDetail",
                                         column: "FileDetailsId");

        _ = migrationBuilder.CreateIndex(
                                         name: "IX_FileClassificationFileNamePart_FileNamePartsId",
                                         schema: "files",
                                         table: "FileClassificationFileNamePart",
                                         column: "FileNamePartsId");

        _ = migrationBuilder.CreateIndex(
                                         name: "IX_FileDetail_FileHandle",
                                         schema: "files",
                                         table: "FileDetail",
                                         column: "FileHandle");

        _ = migrationBuilder.CreateIndex(
                                         name: "IX_FileDetail_FileName",
                                         schema: "files",
                                         table: "FileDetail",
                                         column: "FileName");

        _ = migrationBuilder.CreateIndex(
                                         name: "IX_FileDetail_FileSize",
                                         schema: "files",
                                         table: "FileDetail",
                                         column: "FileSize");

        _ = migrationBuilder.CreateIndex(
                                         name: "IX_FileNamePart_FileClassificationId",
                                         schema: "files",
                                         table: "FileNamePart",
                                         column: "FileClassificationId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropTable(
                                       name: "Event",
                                       schema: "files");

        _ = migrationBuilder.DropTable(
                                       name: "FileClassificationFileDetail",
                                       schema: "files");

        _ = migrationBuilder.DropTable(
                                       name: "FileClassificationFileNamePart",
                                       schema: "files");

        _ = migrationBuilder.DropTable(
                                       name: "FileDetail",
                                       schema: "files");

        _ = migrationBuilder.DropTable(
                                       name: "FileNamePart",
                                       schema: "files");

        _ = migrationBuilder.DropTable(
                                       name: "FileClassification",
                                       schema: "files");
    }
}