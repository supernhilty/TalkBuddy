﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TalkBuddy.DAL.Data;

#nullable disable

namespace TalkBuddy.DAL.Migrations
{
    [DbContext(typeof(TalkBuddyContext))]
    partial class TalkBuddyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TalkBuddy.Domain.Entities.ChatBox", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ChatBoxName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GroupCreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupCreatorId");

                    b.ToTable("ChatBoxes");
                });

            modelBuilder.Entity("TalkBuddy.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("TalkBuddy.Domain.Entities.ClientChatBox", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChatBoxId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLeft")
                        .HasColumnType("bit");

                    b.Property<bool>("IsModerator")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNotificationOn")
                        .HasColumnType("bit");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChatBoxId");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientChatBoxes");
                });

            modelBuilder.Entity("TalkBuddy.Domain.Entities.ClientMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("SeenDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("MessageId");

                    b.ToTable("ClientMessages");
                });

            modelBuilder.Entity("TalkBuddy.Domain.Entities.Friendship", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AcceptDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Client1Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Client2Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Client1Id");

                    b.HasIndex("Client2Id");

                    b.ToTable("Friendships");
                });

            modelBuilder.Entity("TalkBuddy.Domain.Entities.Media", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Capacity")
                        .HasColumnType("real");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("Medias");
                });

            modelBuilder.Entity("TalkBuddy.Domain.Entities.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChatBoxId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChatBoxId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("TalkBuddy.Domain.Entities.Report", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("InformantClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ReportedClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InformantClientId");

                    b.HasIndex("ReportedClientId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("TalkBuddy.Domain.Entities.ChatBox", b =>
                {
                    b.HasOne("TalkBuddy.Domain.Entities.Client", "GroupCreator")
                        .WithMany("CreatedChatBoxes")
                        .HasForeignKey("GroupCreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GroupCreator");
                });

            modelBuilder.Entity("TalkBuddy.Domain.Entities.ClientChatBox", b =>
                {
                    b.HasOne("TalkBuddy.Domain.Entities.ChatBox", "ChatBox")
                        .WithMany("ClientChatBoxes")
                        .HasForeignKey("ChatBoxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TalkBuddy.Domain.Entities.Client", "Client")
                        .WithMany("InChatboxes")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ChatBox");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("TalkBuddy.Domain.Entities.ClientMessage", b =>
                {
                    b.HasOne("TalkBuddy.Domain.Entities.Client", "Client")
                        .WithMany("ClientMessages")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TalkBuddy.Domain.Entities.Message", "Message")
                        .WithMany()
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Message");
                });

            modelBuilder.Entity("TalkBuddy.Domain.Entities.Friendship", b =>
                {
                    b.HasOne("TalkBuddy.Domain.Entities.Client", "Client1")
                        .WithMany("Friends")
                        .HasForeignKey("Client1Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TalkBuddy.Domain.Entities.Client", "Client2")
                        .WithMany()
                        .HasForeignKey("Client2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client1");

                    b.Navigation("Client2");
                });

            modelBuilder.Entity("TalkBuddy.Domain.Entities.Media", b =>
                {
                    b.HasOne("TalkBuddy.Domain.Entities.Message", "Message")
                        .WithMany("Medias")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");
                });

            modelBuilder.Entity("TalkBuddy.Domain.Entities.Message", b =>
                {
                    b.HasOne("TalkBuddy.Domain.Entities.ChatBox", "ChatBox")
                        .WithMany("Messages")
                        .HasForeignKey("ChatBoxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChatBox");
                });

            modelBuilder.Entity("TalkBuddy.Domain.Entities.Report", b =>
                {
                    b.HasOne("TalkBuddy.Domain.Entities.Client", "InformantClient")
                        .WithMany("InformantClients")
                        .HasForeignKey("InformantClientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TalkBuddy.Domain.Entities.Client", "ReportedClient")
                        .WithMany("ReportedClients")
                        .HasForeignKey("ReportedClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InformantClient");

                    b.Navigation("ReportedClient");
                });

            modelBuilder.Entity("TalkBuddy.Domain.Entities.ChatBox", b =>
                {
                    b.Navigation("ClientChatBoxes");

                    b.Navigation("Messages");
                });

            modelBuilder.Entity("TalkBuddy.Domain.Entities.Client", b =>
                {
                    b.Navigation("ClientMessages");

                    b.Navigation("CreatedChatBoxes");

                    b.Navigation("Friends");

                    b.Navigation("InChatboxes");

                    b.Navigation("InformantClients");

                    b.Navigation("ReportedClients");
                });

            modelBuilder.Entity("TalkBuddy.Domain.Entities.Message", b =>
                {
                    b.Navigation("Medias");
                });
#pragma warning restore 612, 618
        }
    }
}
