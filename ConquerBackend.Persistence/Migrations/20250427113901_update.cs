using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConquerBackend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CONQUERBACKEND");

            migrationBuilder.CreateTable(
                name: "Actions",
                schema: "CONQUERBACKEND",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ISACTIVED = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    UPDATEBY = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UPDATEDDATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATEDBY = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CREATEDDATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ORDERID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Functions",
                schema: "CONQUERBACKEND",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    URL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CSSCLASS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ISACTIVED = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    UPDATEBY = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UPDATEDDATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATEDBY = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CREATEDDATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ORDERID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "CONQUERBACKEND",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "VARCHAR(4000)", nullable: true, defaultValue: ""),
                    ClaimValue = table.Column<string>(type: "VARCHAR(4000)", nullable: true, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "CONQUERBACKEND",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ROLECODE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CREATEDBY = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CREATEDDATE = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ORDERID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISDELETED = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ROLENAME = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "CONQUERBACKEND",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "VARCHAR(4000)", nullable: true, defaultValue: ""),
                    ClaimValue = table.Column<string>(type: "VARCHAR(4000)", nullable: true, defaultValue: ""),
                    Discriminator = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "CONQUERBACKEND",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "CONQUERBACKEND",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RoleId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "CONQUERBACKEND",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FIRSTNAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LASTNAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FULLNAME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DATEOFBIRTH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ISDIRECTOR = table.Column<bool>(type: "bit", nullable: false),
                    ISHEADOFDEPARTMENT = table.Column<bool>(type: "bit", nullable: false),
                    MANAGERID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    POSITIONID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MODIFIEDBY = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MODIFIEDAT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATEDBY = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CREATEAT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ORDERID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "CONQUERBACKEND",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ActionInFunction",
                schema: "CONQUERBACKEND",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ROLEID = table.Column<int>(type: "int", nullable: false),
                    FUNCTIONID = table.Column<int>(type: "int", nullable: false),
                    ActionsModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FunctionsModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UPDATEBY = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UPDATEDDATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATEDBY = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CREATEDDATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ORDERID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionInFunction", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ActionInFunction_Actions_ActionsModelId",
                        column: x => x.ActionsModelId,
                        principalSchema: "CONQUERBACKEND",
                        principalTable: "Actions",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ActionInFunction_Functions_FunctionsModelId",
                        column: x => x.FunctionsModelId,
                        principalSchema: "CONQUERBACKEND",
                        principalTable: "Functions",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                schema: "CONQUERBACKEND",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ROLEID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FUNCTIONID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ACTIONID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionsModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FunctionsModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RolesModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Permissions_Actions_ActionsModelId",
                        column: x => x.ActionsModelId,
                        principalSchema: "CONQUERBACKEND",
                        principalTable: "Actions",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Permissions_Functions_FunctionsModelId",
                        column: x => x.FunctionsModelId,
                        principalSchema: "CONQUERBACKEND",
                        principalTable: "Functions",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Permissions_Roles_RolesModelId",
                        column: x => x.RolesModelId,
                        principalSchema: "CONQUERBACKEND",
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionInFunction_ActionsModelId",
                schema: "CONQUERBACKEND",
                table: "ActionInFunction",
                column: "ActionsModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionInFunction_FunctionsModelId",
                schema: "CONQUERBACKEND",
                table: "ActionInFunction",
                column: "FunctionsModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ActionsModelId",
                schema: "CONQUERBACKEND",
                table: "Permissions",
                column: "ActionsModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_FunctionsModelId",
                schema: "CONQUERBACKEND",
                table: "Permissions",
                column: "FunctionsModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RolesModelId",
                schema: "CONQUERBACKEND",
                table: "Permissions",
                column: "RolesModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionInFunction",
                schema: "CONQUERBACKEND");

            migrationBuilder.DropTable(
                name: "Permissions",
                schema: "CONQUERBACKEND");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "CONQUERBACKEND");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "CONQUERBACKEND");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "CONQUERBACKEND");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "CONQUERBACKEND");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "CONQUERBACKEND");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "CONQUERBACKEND");

            migrationBuilder.DropTable(
                name: "Actions",
                schema: "CONQUERBACKEND");

            migrationBuilder.DropTable(
                name: "Functions",
                schema: "CONQUERBACKEND");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "CONQUERBACKEND");
        }
    }
}
