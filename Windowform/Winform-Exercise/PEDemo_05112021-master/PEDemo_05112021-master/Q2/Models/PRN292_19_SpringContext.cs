using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace Q2.Models
{
    public partial class PRN292_19_SpringContext : DbContext
    {
        public PRN292_19_SpringContext()
        {
        }

        public PRN292_19_SpringContext(DbContextOptions<PRN292_19_SpringContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Corporation> Corporations { get; set; }
        public virtual DbSet<CourseRegistration> CourseRegistrations { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<TestResult> TestResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("MyTestDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Corporation>(entity =>
            {
                entity.HasKey(e => e.CorpNo)
                    .HasName("corporation_ident");

                entity.ToTable("corporation");

                entity.HasIndex(e => e.RegionNo, "corporation_region_link");

                entity.Property(e => e.CorpNo).HasColumnName("corp_no");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.CorpCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("corp_code")
                    .HasDefaultValueSql("('  ')")
                    .IsFixedLength(true);

                entity.Property(e => e.CorpName)
                    .IsRequired()
                    .HasMaxLength(31)
                    .IsUnicode(false)
                    .HasColumnName("corp_name");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("country")
                    .IsFixedLength(true);

                entity.Property(e => e.ExprDt)
                    .HasColumnType("datetime")
                    .HasColumnName("expr_dt");

                entity.Property(e => e.MailCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("mail_code")
                    .IsFixedLength(true);

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("phone_no")
                    .IsFixedLength(true);

                entity.Property(e => e.RegionNo).HasColumnName("region_no");

                entity.Property(e => e.StateProv)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("state_prov")
                    .IsFixedLength(true);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("street");

                entity.HasOne(d => d.RegionNoNavigation)
                    .WithMany(p => p.Corporations)
                    .HasForeignKey(d => d.RegionNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("corporation_region_link");
            });

            modelBuilder.Entity<CourseRegistration>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CourseRegistration");

                entity.Property(e => e.Note).HasColumnType("text");

                entity.Property(e => e.StudentId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("StudentID");

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Time)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => e.MemberNo)
                    .HasName("member_ident");

                entity.ToTable("member");

                entity.HasIndex(e => e.CorpNo, "member_corporation_link");

                entity.HasIndex(e => e.RegionNo, "member_region_link");

                entity.Property(e => e.MemberNo).HasColumnName("member_no");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.CorpNo).HasColumnName("corp_no");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("country")
                    .IsFixedLength(true);

                entity.Property(e => e.CurrBalance)
                    .HasColumnType("money")
                    .HasColumnName("curr_balance")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ExprDt)
                    .HasColumnType("datetime")
                    .HasColumnName("expr_dt")
                    .HasDefaultValueSql("(dateadd(year,(1),getdate()))");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("firstname");

                entity.Property(e => e.IssueDt)
                    .HasColumnType("datetime")
                    .HasColumnName("issue_dt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("lastname");

                entity.Property(e => e.MailCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("mail_code")
                    .IsFixedLength(true);

                entity.Property(e => e.MemberCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("member_code")
                    .HasDefaultValueSql("('  ')")
                    .IsFixedLength(true);

                entity.Property(e => e.Middleinitial)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("middleinitial")
                    .IsFixedLength(true);

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("phone_no")
                    .IsFixedLength(true);

                entity.Property(e => e.Photograph)
                    .HasColumnType("image")
                    .HasColumnName("photograph");

                entity.Property(e => e.PrevBalance)
                    .HasColumnType("money")
                    .HasColumnName("prev_balance")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RegionNo).HasColumnName("region_no");

                entity.Property(e => e.StateProv)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("state_prov")
                    .IsFixedLength(true);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("street");

                entity.HasOne(d => d.CorpNoNavigation)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.CorpNo)
                    .HasConstraintName("member_corporation_link");

                entity.HasOne(d => d.RegionNoNavigation)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.RegionNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("member_region_link");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.RegionNo)
                    .HasName("region_ident");

                entity.ToTable("region");

                entity.Property(e => e.RegionNo).HasColumnName("region_no");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("country")
                    .IsFixedLength(true);

                entity.Property(e => e.MailCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("mail_code")
                    .IsFixedLength(true);

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("phone_no")
                    .IsFixedLength(true);

                entity.Property(e => e.RegionCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("region_code")
                    .HasDefaultValueSql("('  ')")
                    .IsFixedLength(true);

                entity.Property(e => e.RegionName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("region_name");

                entity.Property(e => e.StateProv)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("state_prov")
                    .IsFixedLength(true);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("street");
            });

            modelBuilder.Entity<TestResult>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TestResult");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.StudentId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("StudentID");

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TestType)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
