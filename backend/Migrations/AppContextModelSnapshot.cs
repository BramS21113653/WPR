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
                            Id = new Guid("a6ce7b40-5f15-4442-a6ff-1926817c4d09"),
                            ConductorId = new Guid("5dcefc08-f364-46b8-ac58-9e87938ccaf9"),
                            DateTime = new DateTime(2024, 1, 16, 0, 21, 11, 59, DateTimeKind.Local).AddTicks(4810),
                            Description = "Exploring the impact of AI technologies in medical diagnostics",
                            LocationOnline = "Zoom Meeting",
                            ResearchType = "Qualitative",
                            Reward = "100 USD Amazon Voucher",
                            Status = "Open",
                            Title = "AI in Healthcare"
                        },
                        new
                        {
                            Id = new Guid("a22147f8-8a54-4ca6-ad66-34ecaa636696"),
                            ConductorId = new Guid("62f5a822-9367-4f5b-8335-02e11fc21174"),
                            DateTime = new DateTime(2024, 2, 16, 0, 21, 11, 59, DateTimeKind.Local).AddTicks(4890),
                            Description = "Studying the latest trends in renewable energy technologies",
                            LocationOnline = "Microsoft Teams",
                            ResearchType = "Quantitative",
                            Reward = "Participation Certificate",
                            Status = "Planning",
                            Title = "Renewable Energy Innovations"
                        },
                        new
                        {
                            Id = new Guid("5b760850-c24f-457b-97aa-2d966e94072b"),
                            ConductorId = new Guid("c171a09f-9fd7-4b31-a350-c4e6b4f2a545"),
                            DateTime = new DateTime(2024, 3, 16, 0, 21, 11, 59, DateTimeKind.Local).AddTicks(4910),
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
                            Id = new Guid("5dcefc08-f364-46b8-ac58-9e87938ccaf9"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "17cde92e-c2e9-4d9b-b790-1384b83b11f6",
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
                            Id = new Guid("62f5a822-9367-4f5b-8335-02e11fc21174"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f7d032d1-cd4b-43c0-8c2c-89c0e46e8a7b",
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
                            Id = new Guid("c171a09f-9fd7-4b31-a350-c4e6b4f2a545"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "fa92b4ca-91a6-4671-bcdf-5260f3c75fd4",
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
                        .OnDelete(DeleteBehavior.Restrict)
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
