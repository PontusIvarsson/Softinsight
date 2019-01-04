﻿// <auto-generated />
using System;
using Blogging.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Softinsight.Services.Blog.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(BlogContext))]
    partial class BlogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Blogging.Domain.BlogAggregate.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("Blogging.Domain.BlogAggregate.Insight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BlogId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("Insight");
                });

            modelBuilder.Entity("Blogging.Domain.BlogAggregate.Insight", b =>
                {
                    b.HasOne("Blogging.Domain.BlogAggregate.Blog")
                        .WithMany("Insights")
                        .HasForeignKey("BlogId");

                    b.OwnsMany("Blogging.Domain.BlogAggregate.Hashtag", "Hashtags", b1 =>
                        {
                            b1.Property<int>("InsightId");

                            b1.Property<int>("Id");

                            b1.Property<string>("Value");

                            b1.HasKey("InsightId", "Id");

                            b1.ToTable("Hashtag");

                            b1.HasOne("Blogging.Domain.BlogAggregate.Insight")
                                .WithMany("Hashtags")
                                .HasForeignKey("InsightId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
