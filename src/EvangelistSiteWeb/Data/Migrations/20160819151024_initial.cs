using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EvangelistSiteWeb.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    FAIconClass = table.Column<string>(nullable: true),
                    ShortUrl = table.Column<string>(nullable: true),
                    TargetUrl = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    VisibleOnSite = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CssClass = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    VisibleOnSite = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Talk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Audience = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Technologies = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceResourceGroup",
                columns: table => new
                {
                    ResourceGroupId = table.Column<int>(nullable: false),
                    ResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceResourceGroup", x => new { x.ResourceGroupId, x.ResourceId });
                    table.ForeignKey(
                        name: "FK_ResourceResourceGroup_ResourceGroup_ResourceGroupId",
                        column: x => x.ResourceGroupId,
                        principalTable: "ResourceGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceResourceGroup_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceTalk",
                columns: table => new
                {
                    TalkId = table.Column<int>(nullable: false),
                    ResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceTalk", x => new { x.TalkId, x.ResourceId });
                    table.ForeignKey(
                        name: "FK_ResourceTalk_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceTalk_Talk_TalkId",
                        column: x => x.TalkId,
                        principalTable: "Talk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResourceResourceGroup_ResourceGroupId",
                table: "ResourceResourceGroup",
                column: "ResourceGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceResourceGroup_ResourceId",
                table: "ResourceResourceGroup",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceTalk_ResourceId",
                table: "ResourceTalk",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceTalk_TalkId",
                table: "ResourceTalk",
                column: "TalkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceResourceGroup");

            migrationBuilder.DropTable(
                name: "ResourceTalk");

            migrationBuilder.DropTable(
                name: "ResourceGroup");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "Talk");
        }
    }
}
