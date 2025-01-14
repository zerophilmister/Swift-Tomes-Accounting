﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Swift_Tomes_Accounting.Data;

namespace Swift_Tomes_Accounting.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211204181801_freshdb")]
    partial class freshdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Swift_Tomes_Accounting.Models.ViewModels.AccountDB", b =>
                {
                    b.Property<double>("AccountNumber")
                        .HasColumnType("float");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ChartOfAccounts")
                        .HasColumnType("bit");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Contra")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<double>("Credit")
                        .HasColumnType("float");

                    b.Property<double>("Debit")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Initial")
                        .HasColumnType("float");

                    b.Property<string>("NormSide")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Statement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountNumber");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("Swift_Tomes_Accounting.Models.ViewModels.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DOB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastPass1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastPass2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("PasswordDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isApproved")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Swift_Tomes_Accounting.Models.ViewModels.ErrorTable", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ErrorTable");
                });

            modelBuilder.Entity("Swift_Tomes_Accounting.Models.ViewModels.EventAccount", b =>
                {
                    b.Property<int>("eventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AfterAccountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("AfterAccountNumber")
                        .HasColumnType("float");

                    b.Property<double>("AfterBalance")
                        .HasColumnType("float");

                    b.Property<string>("AfterCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AfterComments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("AfterCredit")
                        .HasColumnType("float");

                    b.Property<double>("AfterDebit")
                        .HasColumnType("float");

                    b.Property<string>("AfterDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("AfterInitial")
                        .HasColumnType("float");

                    b.Property<string>("AfterNormSide")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AfterOrder")
                        .HasColumnType("int");

                    b.Property<string>("AfterStatement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AfterSubCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AfterUserID")
                        .HasColumnType("int");

                    b.Property<bool>("AfterisActive")
                        .HasColumnType("bit");

                    b.Property<bool>("AfterisContra")
                        .HasColumnType("bit");

                    b.Property<string>("BeforeAccountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("BeforeAccountNumber")
                        .HasColumnType("float");

                    b.Property<double>("BeforeBalance")
                        .HasColumnType("float");

                    b.Property<string>("BeforeCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BeforeComments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("BeforeCredit")
                        .HasColumnType("float");

                    b.Property<double>("BeforeDebit")
                        .HasColumnType("float");

                    b.Property<string>("BeforeDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("BeforeInitial")
                        .HasColumnType("float");

                    b.Property<string>("BeforeNormSide")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BeforeOrder")
                        .HasColumnType("int");

                    b.Property<string>("BeforeStatement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BeforeSubCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BeforeUserID")
                        .HasColumnType("int");

                    b.Property<bool>("BeforeisActive")
                        .HasColumnType("bit");

                    b.Property<bool>("BeforeisContra")
                        .HasColumnType("bit");

                    b.Property<string>("eventPerformedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("eventTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("eventType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("eventID");

                    b.ToTable("EventAccount");
                });

            modelBuilder.Entity("Swift_Tomes_Accounting.Models.ViewModels.EventJournal", b =>
                {
                    b.Property<int>("eventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("eventPerformedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("eventTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("eventType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isApproved")
                        .HasColumnType("bit");

                    b.Property<bool>("isDenied")
                        .HasColumnType("bit");

                    b.Property<int>("journalId")
                        .HasColumnType("int");

                    b.Property<string>("reason")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("eventID");

                    b.ToTable("EventJournal");
                });

            modelBuilder.Entity("Swift_Tomes_Accounting.Models.ViewModels.EventUser", b =>
                {
                    b.Property<int>("eventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AfterAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AfterDOB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AfterFname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AfterLname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AfterRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AfterisActive")
                        .HasColumnType("bit");

                    b.Property<string>("AfteruserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BeforeAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BeforeDOB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BeforeFname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BeforeLname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BeforeRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("BeforeisActive")
                        .HasColumnType("bit");

                    b.Property<string>("BeforeuserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("eventPerformedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("eventTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("eventType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("eventID");

                    b.ToTable("EventUser");
                });

            modelBuilder.Entity("Swift_Tomes_Accounting.Models.ViewModels.Journal_Accounts", b =>
                {
                    b.Property<int>("JAId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountName1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountName2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<double>("Credit")
                        .HasColumnType("float");

                    b.Property<double>("Debit")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRejected")
                        .HasColumnType("bit");

                    b.Property<int>("JournalId")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JAId");

                    b.HasIndex("JournalId");

                    b.ToTable("Journal_Accounts");
                });

            modelBuilder.Entity("Swift_Tomes_Accounting.Models.ViewModels.Journalize", b =>
                {
                    b.Property<int>("JournalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRejected")
                        .HasColumnType("bit");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("docUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isApproved")
                        .HasColumnType("bit");

                    b.Property<bool>("isCJE")
                        .HasColumnType("bit");

                    b.HasKey("JournalId");

                    b.ToTable("Journalizes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Swift_Tomes_Accounting.Models.ViewModels.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Swift_Tomes_Accounting.Models.ViewModels.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Swift_Tomes_Accounting.Models.ViewModels.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Swift_Tomes_Accounting.Models.ViewModels.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Swift_Tomes_Accounting.Models.ViewModels.Journal_Accounts", b =>
                {
                    b.HasOne("Swift_Tomes_Accounting.Models.ViewModels.Journalize", "Journalize")
                        .WithMany("Journal_Accounts")
                        .HasForeignKey("JournalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Journalize");
                });

            modelBuilder.Entity("Swift_Tomes_Accounting.Models.ViewModels.Journalize", b =>
                {
                    b.Navigation("Journal_Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
