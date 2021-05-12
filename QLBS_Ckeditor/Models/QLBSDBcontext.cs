using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Quanlybansach.Models
{
    public partial class QLBSDBcontext : DbContext
    {
        public QLBSDBcontext()
            : base("name=QLBSDBcontext")
        {
        }

        public virtual DbSet<Chitietdonhang> Chitietdonhangs { get; set; }
        public virtual DbSet<Chude> Chudes { get; set; }
        public virtual DbSet<Donhang> Donhangs { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<Nhaxuatban> Nhaxuatbans { get; set; }
        public virtual DbSet<Sach> Sachs { get; set; }
        public virtual DbSet<Tacgia> Tacgias { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chitietdonhang>()
                .Property(e => e.soluong)
                .IsUnicode(false);

            modelBuilder.Entity<Chitietdonhang>()
                .Property(e => e.madh)
                .IsUnicode(false);

            modelBuilder.Entity<Chitietdonhang>()
                 .Property(e => e.masach)
                 .IsUnicode(false);


            modelBuilder.Entity<Chitietdonhang>()
                  .Property(e => e.dongia)
                  .IsUnicode(false);

            modelBuilder.Entity<Chude>()
                 .Property(e => e.machude)
                 .IsUnicode(false);

            modelBuilder.Entity<Chude>()
                .Property(e => e.tenchude)
                .HasMaxLength(100);

            modelBuilder.Entity<Donhang>()
                 .Property(e => e.madh)
                 .IsUnicode(false);

            modelBuilder.Entity<Donhang>()
                .Property(e => e.tinhtrangdonhang)
                .IsUnicode(false);

            modelBuilder.Entity<Donhang>()
                .Property(e => e.ngaydat)
                .IsUnicode(false);

            modelBuilder.Entity<Donhang>()
                .Property(e => e.ngaygiao)
                .IsUnicode(false);

            modelBuilder.Entity<Donhang>()
                 .Property(e => e.makh)
                 .IsUnicode(false);

            modelBuilder.Entity<Khachhang>()
                 .Property(e => e.makh)
                 .IsUnicode(false);

            modelBuilder.Entity<Khachhang>()
                 .Property(e => e.tenkh)
                   .HasMaxLength(100);

            modelBuilder.Entity<Khachhang>()
                .Property(e => e.taikhoan)
                .IsUnicode(false);

            modelBuilder.Entity<Khachhang>()
                .Property(e => e.matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<Khachhang>()
                 .Property(e => e.email)
                 .IsUnicode(false);

            modelBuilder.Entity<Khachhang>()
                .Property(e => e.diachi)
                  .HasMaxLength(100);

            modelBuilder.Entity<Khachhang>()
                .Property(e => e.dienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<Nhaxuatban>()
                          .Property(e => e.manxb)
                          .IsUnicode(false);

            modelBuilder.Entity<Nhaxuatban>()
                 .Property(e => e.tennxb)
                  .HasMaxLength(100);

            modelBuilder.Entity<Nhaxuatban>()
                .Property(e => e.diachi)
                .HasMaxLength(100);

            modelBuilder.Entity<Nhaxuatban>()
                .Property(e => e.dienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.masach)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.tensach)
                 .HasMaxLength(1000);

            modelBuilder.Entity<Sach>()
                .Property(e => e.mota)
                  .HasMaxLength(10000);

            modelBuilder.Entity<Sach>()
                .Property(e => e.soluongton)
                .IsUnicode(false);



            modelBuilder.Entity<Tacgia>()
                .Property(e => e.matacgia)
                .IsUnicode(false);

            modelBuilder.Entity<Tacgia>()
                .Property(e => e.tentacgia)
                  .HasMaxLength(500);

            modelBuilder.Entity<Tacgia>()
                .Property(e => e.diachi)
                 .HasMaxLength(100);

            modelBuilder.Entity<Tacgia>()
                .Property(e => e.dienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
               .Property(e => e.RoleID)
               .IsUnicode(false);



        }

       
    }
}
