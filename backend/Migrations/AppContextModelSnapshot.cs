﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("UserType").HasValue("ApplicationUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Chat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("BusinessUserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PanelMemberId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ResearchId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("BusinessUserId");

                    b.HasIndex("PanelMemberId");

                    b.HasIndex("ResearchId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("ChatMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ChatId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("SenderId");

                    b.ToTable("ChatMessages");
                });

            modelBuilder.Entity("Message", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("BusinessUserId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("BusinessUserId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Participation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("PanelMemberId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ResearchId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("PanelMemberId");

                    b.HasIndex("ResearchId");

                    b.ToTable("Participations");
                });

            modelBuilder.Entity("Research", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ConductorId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LocationOnline")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ResearchType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Reward")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ConductorId");

                    b.ToTable("Researches");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bde37409-bf63-40e7-91f4-f995eee857ac"),
                            ConductorId = new Guid("1a5d4693-ca01-4b11-9630-3b0392f4789c"),
                            DateTime = new DateTime(2024, 1, 17, 18, 26, 9, 495, DateTimeKind.Local).AddTicks(5820),
                            Description = "Exploring the impact of AI technologies in medical diagnostics",
                            LocationOnline = "Zoom Meeting",
                            ResearchType = "Qualitative",
                            Reward = "100 USD Amazon Voucher",
                            Status = "Open",
                            Title = "AI in Healthcare"
                        },
                        new
                        {
                            Id = new Guid("a848b2ff-8812-44a4-a225-4d4a18ca2dff"),
                            ConductorId = new Guid("8b0d3278-8875-46fa-8ae7-e8ba87f0e3ab"),
                            DateTime = new DateTime(2024, 2, 17, 18, 26, 9, 495, DateTimeKind.Local).AddTicks(5890),
                            Description = "Studying the latest trends in renewable energy technologies",
                            LocationOnline = "Microsoft Teams",
                            ResearchType = "Quantitative",
                            Reward = "Participation Certificate",
                            Status = "Planning",
                            Title = "Renewable Energy Innovations"
                        },
                        new
                        {
                            Id = new Guid("70bbaa63-a66d-4215-befa-9a444a958638"),
                            ConductorId = new Guid("c7252408-3a93-472d-bc45-a55575cd3477"),
                            DateTime = new DateTime(2024, 3, 17, 18, 26, 9, 495, DateTimeKind.Local).AddTicks(5910),
                            Description = "Analyzing sustainable practices in urban development",
                            LocationOnline = "WebEx",
                            ResearchType = "Mixed",
                            Reward = "150 USD Amazon Voucher",
                            Status = "Open",
                            Title = "Sustainable Urban Development"
                        });
                });

            modelBuilder.Entity("ResearchInterest", b =>
                {
                    b.Property<Guid>("PanelMemberId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ResearchId")
                        .HasColumnType("char(36)");

                    b.HasKey("PanelMemberId", "ResearchId");

                    b.HasIndex("ResearchId");

                    b.ToTable("ResearchInterests");
                });

            modelBuilder.Entity("Administrator", b =>
                {
                    b.HasBaseType("ApplicationUser");

                    b.HasDiscriminator().HasValue("Administrator");
                });

            modelBuilder.Entity("BusinessUser", b =>
                {
                    b.HasBaseType("ApplicationUser");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("WebsiteURL")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("BusinessUser");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1a5d4693-ca01-4b11-9630-3b0392f4789c"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "cecafb2e-4d6f-47a6-9cd7-3aa3feded08a",
                            Email = "john.doe@doeinnovations.com",
                            EmailConfirmed = true,
                            FirstName = "John",
                            LastName = "Doe",
                            LockoutEnabled = false,
                            NormalizedEmail = "JOHN.DOE@DOEINNOVATIONS.COM",
                            NormalizedUserName = "JOHN.DOE",
                            PasswordHash = "hashed_password_placeholder",
                            PhoneNumber = "123-456-7890",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "security_stamp_placeholder",
                            TwoFactorEnabled = false,
                            UserName = "john.doe",
                            CompanyName = "Doe Innovations",
                            ContactInfo = "john.doe@doeinnovations.com",
                            Location = "New York, USA",
                            WebsiteURL = "https://www.doeinnovations.com"
                        },
                        new
                        {
                            Id = new Guid("8b0d3278-8875-46fa-8ae7-e8ba87f0e3ab"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "247882f1-7095-4376-a42c-2b9d062d3b8b",
                            Email = "jane.smith@smithnetworking.co.uk",
                            EmailConfirmed = true,
                            FirstName = "Jane",
                            LastName = "Smith",
                            LockoutEnabled = false,
                            NormalizedEmail = "JANE.SMITH@SMITHNETWORKING.CO.UK",
                            NormalizedUserName = "JANE.SMITH",
                            PasswordHash = "hashed_password_placeholder",
                            PhoneNumber = "098-765-4321",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "security_stamp_placeholder",
                            TwoFactorEnabled = false,
                            UserName = "jane.smith",
                            CompanyName = "Smith Networking",
                            ContactInfo = "jane.smith@smithnetworking.co.uk",
                            Location = "London, UK",
                            WebsiteURL = "https://www.smithnetworking.co.uk"
                        },
                        new
                        {
                            Id = new Guid("c7252408-3a93-472d-bc45-a55575cd3477"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8708e55b-cef5-4049-986e-7478e39267ee",
                            Email = "alice.johnson@johnsonailabs.de",
                            EmailConfirmed = true,
                            FirstName = "Alice",
                            LastName = "Johnson",
                            LockoutEnabled = false,
                            NormalizedEmail = "ALICE.JOHNSON@JOHNSONAILABS.DE",
                            NormalizedUserName = "ALICE.JOHNSON",
                            PasswordHash = "hashed_password_placeholder",
                            PhoneNumber = "321-654-0987",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "security_stamp_placeholder",
                            TwoFactorEnabled = false,
                            UserName = "alice.johnson",
                            CompanyName = "Johnson AI Labs",
                            ContactInfo = "alice.johnson@johnsonailabs.de",
                            Location = "Berlin, Germany",
                            WebsiteURL = "https://www.johnsonailabs.de"
                        });
                });

            modelBuilder.Entity("PanelMember", b =>
                {
                    b.HasBaseType("ApplicationUser");

                    b.Property<Guid?>("AdministratorId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<string>("AvailabilityTimes")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ConditionDisease")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("ConsentForCommercialApproach")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("DisabilityType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("ParentGuardianId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PreferredApproach")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PreferredResearchTypes")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UsedAssistiveTools")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasIndex("AdministratorId");

                    b.HasIndex("ParentGuardianId");

                    b.HasDiscriminator().HasValue("PanelMember");
                });

            modelBuilder.Entity("ParentGuardian", b =>
                {
                    b.HasBaseType("ApplicationUser");

                    b.Property<string>("RelationToPanelMember")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("ParentGuardian");
                });

            modelBuilder.Entity("Chat", b =>
                {
                    b.HasOne("BusinessUser", "BusinessUser")
                        .WithMany()
                        .HasForeignKey("BusinessUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PanelMember", "PanelMember")
                        .WithMany()
                        .HasForeignKey("PanelMemberId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Research", "Research")
                        .WithMany()
                        .HasForeignKey("ResearchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusinessUser");

                    b.Navigation("PanelMember");

                    b.Navigation("Research");
                });

            modelBuilder.Entity("ChatMessage", b =>
                {
                    b.HasOne("Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationUser", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Message", b =>
                {
                    b.HasOne("BusinessUser", "BusinessUser")
                        .WithMany("CreatedMessages")
                        .HasForeignKey("BusinessUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ApplicationUser", "Receiver")
                        .WithMany("MessagesReceived")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ApplicationUser", "Sender")
                        .WithMany("MessagesSent")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BusinessUser");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Participation", b =>
                {
                    b.HasOne("PanelMember", "PanelMember")
                        .WithMany("Participations")
                        .HasForeignKey("PanelMemberId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Research", "Research")
                        .WithMany("Participations")
                        .HasForeignKey("ResearchId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PanelMember");

                    b.Navigation("Research");
                });

            modelBuilder.Entity("Research", b =>
                {
                    b.HasOne("BusinessUser", "Conductor")
                        .WithMany("Researches")
                        .HasForeignKey("ConductorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Conductor");
                });

            modelBuilder.Entity("ResearchInterest", b =>
                {
                    b.HasOne("PanelMember", "PanelMember")
                        .WithMany("ResearchInterests")
                        .HasForeignKey("PanelMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Research", "Research")
                        .WithMany("ResearchInterests")
                        .HasForeignKey("ResearchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PanelMember");

                    b.Navigation("Research");
                });

            modelBuilder.Entity("PanelMember", b =>
                {
                    b.HasOne("Administrator", "Administrator")
                        .WithMany("SupervisedPanelMembers")
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ParentGuardian", "ParentGuardian")
                        .WithMany("PanelMembers")
                        .HasForeignKey("ParentGuardianId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Administrator");

                    b.Navigation("ParentGuardian");
                });

            modelBuilder.Entity("ApplicationUser", b =>
                {
                    b.Navigation("MessagesReceived");

                    b.Navigation("MessagesSent");
                });

            modelBuilder.Entity("Chat", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Research", b =>
                {
                    b.Navigation("Participations");

                    b.Navigation("ResearchInterests");
                });

            modelBuilder.Entity("Administrator", b =>
                {
                    b.Navigation("SupervisedPanelMembers");
                });

            modelBuilder.Entity("BusinessUser", b =>
                {
                    b.Navigation("CreatedMessages");

                    b.Navigation("Researches");
                });

            modelBuilder.Entity("PanelMember", b =>
                {
                    b.Navigation("Participations");

                    b.Navigation("ResearchInterests");
                });

            modelBuilder.Entity("ParentGuardian", b =>
                {
                    b.Navigation("PanelMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
