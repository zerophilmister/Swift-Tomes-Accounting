﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Swift_Tomes_Accounting.Migrations
{
    public partial class freshdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountNumber = table.Column<double>(type: "float", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormSide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Initial = table.Column<double>(type: "float", nullable: false),
                    Debit = table.Column<double>(type: "float", nullable: false),
                    Credit = table.Column<double>(type: "float", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Statement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Contra = table.Column<bool>(type: "bit", nullable: false),
                    ChartOfAccounts = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountNumber);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isApproved = table.Column<bool>(type: "bit", nullable: false),
                    LastPass1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastPass2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErrorTable",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorTable", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EventAccount",
                columns: table => new
                {
                    eventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeforeAccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeforeAccountNumber = table.Column<double>(type: "float", nullable: false),
                    BeforeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeforeNormSide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeforeCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeforeSubCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeforeInitial = table.Column<double>(type: "float", nullable: false),
                    BeforeDebit = table.Column<double>(type: "float", nullable: false),
                    BeforeCredit = table.Column<double>(type: "float", nullable: false),
                    BeforeBalance = table.Column<double>(type: "float", nullable: false),
                    BeforeUserID = table.Column<int>(type: "int", nullable: false),
                    BeforeOrder = table.Column<int>(type: "int", nullable: false),
                    BeforeStatement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeforeComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AfterAccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AfterAccountNumber = table.Column<double>(type: "float", nullable: false),
                    AfterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AfterNormSide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AfterCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AfterSubCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AfterInitial = table.Column<double>(type: "float", nullable: false),
                    AfterDebit = table.Column<double>(type: "float", nullable: false),
                    AfterCredit = table.Column<double>(type: "float", nullable: false),
                    AfterBalance = table.Column<double>(type: "float", nullable: false),
                    AfterUserID = table.Column<int>(type: "int", nullable: false),
                    AfterOrder = table.Column<int>(type: "int", nullable: false),
                    AfterStatement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AfterComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeforeisActive = table.Column<bool>(type: "bit", nullable: false),
                    BeforeisContra = table.Column<bool>(type: "bit", nullable: false),
                    AfterisActive = table.Column<bool>(type: "bit", nullable: false),
                    AfterisContra = table.Column<bool>(type: "bit", nullable: false),
                    eventTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    eventType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    eventPerformedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAccount", x => x.eventID);
                });

            migrationBuilder.CreateTable(
                name: "EventJournal",
                columns: table => new
                {
                    eventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    journalId = table.Column<int>(type: "int", nullable: false),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isApproved = table.Column<bool>(type: "bit", nullable: false),
                    isDenied = table.Column<bool>(type: "bit", nullable: false),
                    eventTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    eventType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    eventPerformedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventJournal", x => x.eventID);
                });

            migrationBuilder.CreateTable(
                name: "EventUser",
                columns: table => new
                {
                    eventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeforeFname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeforeLname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeforeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeforeuserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeforeisActive = table.Column<bool>(type: "bit", nullable: false),
                    BeforeDOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeforeRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AfterFname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AfterLname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AfterDOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AfterAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AfteruserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AfterisActive = table.Column<bool>(type: "bit", nullable: false),
                    AfterRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    eventTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    eventType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    eventPerformedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUser", x => x.eventID);
                });

            migrationBuilder.CreateTable(
                name: "Journalizes",
                columns: table => new
                {
                    JournalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isApproved = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    docUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRejected = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isCJE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journalizes", x => x.JournalId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Journal_Accounts",
                columns: table => new
                {
                    JAId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JournalId = table.Column<int>(type: "int", nullable: false),
                    Debit = table.Column<double>(type: "float", nullable: false),
                    Credit = table.Column<double>(type: "float", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRejected = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journal_Accounts", x => x.JAId);
                    table.ForeignKey(
                        name: "FK_Journal_Accounts_Journalizes_JournalId",
                        column: x => x.JournalId,
                        principalTable: "Journalizes",
                        principalColumn: "JournalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Journal_Accounts_JournalId",
                table: "Journal_Accounts",
                column: "JournalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ErrorTable");

            migrationBuilder.DropTable(
                name: "EventAccount");

            migrationBuilder.DropTable(
                name: "EventJournal");

            migrationBuilder.DropTable(
                name: "EventUser");

            migrationBuilder.DropTable(
                name: "Journal_Accounts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Journalizes");
        }
    }
}
