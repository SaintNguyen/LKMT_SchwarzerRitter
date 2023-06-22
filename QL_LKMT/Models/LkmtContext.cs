using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QL_LKMT.Models;

public partial class LkmtContext : DbContext
{
    public LkmtContext()
    {
    }

    public LkmtContext(DbContextOptions<LkmtContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Khachhang> Khachhangs { get; set; }

    public virtual DbSet<Loaisanpham> Loaisanphams { get; set; }

    public virtual DbSet<Nhomsanpham> Nhomsanphams { get; set; }

    public virtual DbSet<Phuongthucthanhtoan> Phuongthucthanhtoans { get; set; }

    public virtual DbSet<Sanpham> Sanphams { get; set; }

    public virtual DbSet<Thuonghieu> Thuonghieus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SATOMIKOUTAROU\\DBCODEFIRST; Database=LKMT;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.IdAdmin).HasName("PK__admin__89472E95BDE957AC");

            entity.ToTable("admin", tb =>
                {
                    tb.HasTrigger("DELETE_ADMIN_TRIGGER");
                    tb.HasTrigger("IN_UP_ADMIN_TRIGGER");
                });

            entity.HasIndex(e => e.IdAdmin, "UQ__admin__89472E9461AC94C1").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__admin__AB6E6164810761D8").IsUnique();

            entity.Property(e => e.IdAdmin).HasColumnName("id_admin");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Matkhau)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("matkhau");
            entity.Property(e => e.Sodienthoai)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("sodienthoai");
            entity.Property(e => e.Ten)
                .HasMaxLength(128)
                .HasColumnName("ten");
        });

        modelBuilder.Entity<Khachhang>(entity =>
        {
            entity.HasKey(e => e.IdKhachhang).HasName("PK__khachhan__63966DBD8F581ACE");

            entity.ToTable("khachhang", tb =>
                {
                    tb.HasTrigger("DELETE_KHACHHANG_TRIGGER");
                    tb.HasTrigger("INSERT_KHACHHANG_TRIGGER");
                    tb.HasTrigger("UPDATE_KHACHHANG_TRIGGER");
                });

            entity.HasIndex(e => e.Sodienthoai, "UC_Sodienthoai").IsUnique();

            entity.HasIndex(e => e.IdKhachhang, "UQ__khachhan__63966DBC4B7058A6").IsUnique();

            entity.Property(e => e.IdKhachhang).HasColumnName("id_khachhang");
            entity.Property(e => e.Diachi)
                .HasMaxLength(128)
                .HasColumnName("diachi");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Matkhau)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("matkhau");
            entity.Property(e => e.Ngaycapnhat)
                .HasColumnType("datetime")
                .HasColumnName("ngaycapnhat");
            entity.Property(e => e.Ngaytao)
                .HasColumnType("datetime")
                .HasColumnName("ngaytao");
            entity.Property(e => e.Sodienthoai)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("sodienthoai");
            entity.Property(e => e.Ten)
                .HasMaxLength(128)
                .HasColumnName("ten");
        });

        modelBuilder.Entity<Loaisanpham>(entity =>
        {
            entity.HasKey(e => e.IdLoai).HasName("PK__loaisanp__9A03AA727490FE8B");

            entity.ToTable("loaisanpham");

            entity.HasIndex(e => e.IdLoai, "UQ__loaisanp__9A03AA73395465A2").IsUnique();

            entity.Property(e => e.IdLoai)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_loai");
            entity.Property(e => e.IdNhom)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_nhom");
            entity.Property(e => e.Ngaycapnhat)
                .HasColumnType("datetime")
                .HasColumnName("ngaycapnhat");
            entity.Property(e => e.Ngaytao)
                .HasColumnType("datetime")
                .HasColumnName("ngaytao");
            entity.Property(e => e.Tenloai)
                .HasMaxLength(32)
                .HasColumnName("tenloai");

            entity.HasOne(d => d.IdNhomNavigation).WithMany(p => p.Loaisanphams)
                .HasForeignKey(d => d.IdNhom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_loaisanpham_nhomsanpham");
        });

        modelBuilder.Entity<Nhomsanpham>(entity =>
        {
            entity.HasKey(e => e.IdNhom).HasName("PK__nhomsanp__284B2F9CE7F68AE4");

            entity.ToTable("nhomsanpham");

            entity.HasIndex(e => e.IdNhom, "UQ__nhomsanp__284B2F9D14FE12D8").IsUnique();

            entity.Property(e => e.IdNhom)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_nhom");
            entity.Property(e => e.Ngaycapnhat)
                .HasColumnType("datetime")
                .HasColumnName("ngaycapnhat");
            entity.Property(e => e.Ngaytao)
                .HasColumnType("datetime")
                .HasColumnName("ngaytao");
            entity.Property(e => e.Tennhom)
                .HasMaxLength(32)
                .HasColumnName("tennhom");
        });

        modelBuilder.Entity<Phuongthucthanhtoan>(entity =>
        {
            entity.HasKey(e => e.IdThanhtoan).HasName("PK__phuongth__257DA41A32308759");

            entity.ToTable("phuongthucthanhtoan");

            entity.HasIndex(e => e.IdThanhtoan, "UQ__phuongth__257DA41B9978D845").IsUnique();

            entity.Property(e => e.IdThanhtoan).HasColumnName("id_thanhtoan");
            entity.Property(e => e.IdKhachhang).HasColumnName("id_khachhang");
            entity.Property(e => e.IdSanpham)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("id_sanpham");
            entity.Property(e => e.Tenthanhtoan)
                .HasMaxLength(48)
                .HasColumnName("tenthanhtoan");

            entity.HasOne(d => d.IdKhachhangNavigation).WithMany(p => p.Phuongthucthanhtoans)
                .HasForeignKey(d => d.IdKhachhang)
                .HasConstraintName("FK_id_khachhang");

            entity.HasOne(d => d.IdSanphamNavigation).WithMany(p => p.Phuongthucthanhtoans)
                .HasForeignKey(d => d.IdSanpham)
                .HasConstraintName("FK_id_sanpham");
        });

        modelBuilder.Entity<Sanpham>(entity =>
        {
            entity.HasKey(e => e.IdSanpham).HasName("PK__sanpham__5D76C1A23C7818FA");

            entity.ToTable("sanpham", tb =>
                {
                    tb.HasTrigger("DELETE_SANPHAM_TRIGGER");
                    tb.HasTrigger("INSERT_SANPHAM_TRIGGER");
                    tb.HasTrigger("UPDATE_SANPHAM_TRIGGER");
                });

            entity.HasIndex(e => e.IdSanpham, "UQ__sanpham__5D76C1A3BD689E25").IsUnique();

            entity.Property(e => e.IdSanpham)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("id_sanpham");
            entity.Property(e => e.Baohanh).HasColumnName("baohanh");
            entity.Property(e => e.Gia)
                .HasColumnType("decimal(15, 4)")
                .HasColumnName("gia");
            entity.Property(e => e.Hinh)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("hinh");
            entity.Property(e => e.IdLoai)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_loai");
            entity.Property(e => e.IdThanhtoan).HasColumnName("id_thanhtoan");
            entity.Property(e => e.IdThuonghieu).HasColumnName("id_thuonghieu");
            entity.Property(e => e.Khuyenmai).HasColumnName("khuyenmai");
            entity.Property(e => e.Mota)
                .HasColumnType("text")
                .HasColumnName("mota");
            entity.Property(e => e.Ngaycapnhat)
                .HasColumnType("datetime")
                .HasColumnName("ngaycapnhat");
            entity.Property(e => e.Ngaytao)
                .HasColumnType("datetime")
                .HasColumnName("ngaytao");
            entity.Property(e => e.Tensanpham)
                .HasMaxLength(52)
                .HasColumnName("tensanpham");

            entity.HasOne(d => d.IdLoaiNavigation).WithMany(p => p.Sanphams)
                .HasForeignKey(d => d.IdLoai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_sanpham_loaisanpham");

            entity.HasOne(d => d.IdThuonghieuNavigation).WithMany(p => p.Sanphams)
                .HasForeignKey(d => d.IdThuonghieu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_sanpham_thuonghieu");
        });

        modelBuilder.Entity<Thuonghieu>(entity =>
        {
            entity.HasKey(e => e.IdThuonghieu).HasName("PK__thuonghi__8FCB194CFC391272");

            entity.ToTable("thuonghieu");

            entity.HasIndex(e => e.IdThuonghieu, "UQ__thuonghi__8FCB194D1258ABEE").IsUnique();

            entity.Property(e => e.IdThuonghieu).HasColumnName("id_thuonghieu");
            entity.Property(e => e.IdNhom)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_nhom");
            entity.Property(e => e.Ngaycapnhat)
                .HasColumnType("datetime")
                .HasColumnName("ngaycapnhat");
            entity.Property(e => e.Ngaytao)
                .HasColumnType("datetime")
                .HasColumnName("ngaytao");
            entity.Property(e => e.Tenthuonghieu)
                .HasMaxLength(40)
                .HasColumnName("tenthuonghieu");

            entity.HasOne(d => d.IdNhomNavigation).WithMany(p => p.Thuonghieus)
                .HasForeignKey(d => d.IdNhom)
                .HasConstraintName("FK_thuonghieu_nhomsanpham");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
