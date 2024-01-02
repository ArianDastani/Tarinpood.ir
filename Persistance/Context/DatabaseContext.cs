using System;
using System.Collections.Generic;
using Application.InterFace;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Context;

public partial class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext, IDatabaseContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asste> Asstes { get; set; }

    public virtual DbSet<Attribute> Attributes { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<MainSlider> MainSliders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }

    public virtual DbSet<ProductPicture> ProductPictures { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TarinpoodDb;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Persian_100_BIN");

        modelBuilder.Entity<Asste>(entity =>
        {
            entity.HasKey(e => e.AssetId).HasName("PK__asstes__D28B561D670A1C37");

            entity.ToTable("asstes");

            entity.Property(e => e.AssetId).HasColumnName("asset_id");
            entity.Property(e => e.AssetFilePath).HasColumnName("asset_file_path");
            entity.Property(e => e.AssetType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("asset_type");
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("insert_date");
            entity.Property(e => e.IsRemove)
                .HasDefaultValueSql("((0))")
                .HasColumnName("is_remove");
            entity.Property(e => e.RemoveDate)
                .HasColumnType("datetime")
                .HasColumnName("remove_date");
            entity.Property(e => e.UId).HasColumnName("u_id");

            entity.HasOne(d => d.UIdNavigation).WithMany(p => p.Asstes)
                .HasForeignKey(d => d.UId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_users_assets");
        });

        modelBuilder.Entity<Attribute>(entity =>
        {
            entity.HasKey(e => e.AttributeId).HasName("PK__attribut__9090C9BBD864C4EE");

            entity.ToTable("attributes");

            entity.Property(e => e.AttributeId).HasColumnName("attribute_id");
            entity.Property(e => e.AttributeName)
                .HasMaxLength(50)
                .HasColumnName("attribute_name");
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("insert_date");
            entity.Property(e => e.IsRemove)
                .HasDefaultValueSql("((0))")
                .HasColumnName("is_remove");
            entity.Property(e => e.RemoveDate)
                .HasColumnType("datetime")
                .HasColumnName("remove_date");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__categori__D54EE9B429925954");

            entity.ToTable("categories");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .HasColumnName("category_name");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("fk_categories_categories");
        });

        modelBuilder.Entity<MainSlider>(entity =>
        {
            entity.HasKey(e => e.SliderId).HasName("PK__main_sli__5B89E39551BC2FDA");

            entity.ToTable("main_slider");

            entity.Property(e => e.SliderId).HasColumnName("slider_id");
            entity.Property(e => e.SliderH2Content)
                .HasMaxLength(60)
                .HasColumnName("slider_h2_content");
            entity.Property(e => e.SliderH5Content)
                .HasMaxLength(100)
                .HasColumnName("slider_h5_content");
            entity.Property(e => e.SliderOrder).HasColumnName("slider_order");
            entity.Property(e => e.SliderPicture).HasColumnName("slider_picture");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__products__47027DF55FA6B133");

            entity.ToTable("products");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("insert_date");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("((0))")
                .HasColumnName("is_active");
            entity.Property(e => e.IsRemove)
                .HasDefaultValueSql("((0))")
                .HasColumnName("is_remove");
            entity.Property(e => e.ProductDescription).HasColumnName("product_description");
            entity.Property(e => e.ProductMainPicture).HasColumnName("product_main_picture");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .HasColumnName("product_name");
            entity.Property(e => e.RemoveDate)
                .HasColumnType("datetime")
                .HasColumnName("remove_date");
            entity.Property(e => e.UId).HasColumnName("u_id");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_categories_products");

            entity.HasOne(d => d.UIdNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.UId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_users_poducts");
        });

        modelBuilder.Entity<ProductAttribute>(entity =>
        {
            entity.HasKey(e => e.ProductAttributeId).HasName("PK__product___A99AD081A5ED7584");

            entity.ToTable("product_attributes");

            entity.Property(e => e.ProductAttributeId).HasColumnName("product_attribute_id");
            entity.Property(e => e.AttributeId).HasColumnName("attribute_id");
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("insert_date");
            entity.Property(e => e.ProductAttributeContent)
                .HasMaxLength(100)
                .HasColumnName("product_attribute_content");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Attribute).WithMany(p => p.ProductAttributes)
                .HasForeignKey(d => d.AttributeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_product_attributes_attributes");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductAttributes)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_product_attributes_products");
        });

        modelBuilder.Entity<ProductPicture>(entity =>
        {
            entity.HasKey(e => e.ProductPictureId).HasName("PK__product___A982818C4C243636");

            entity.ToTable("product_pictures");

            entity.Property(e => e.ProductPictureId).HasColumnName("product_picture_id");
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("insert_date");
            entity.Property(e => e.IsRemove)
                .HasDefaultValueSql("((0))")
                .HasColumnName("is_remove");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductPictureFilePath).HasColumnName("product_picture_file_path");
            entity.Property(e => e.RemoveDate)
                .HasColumnType("datetime")
                .HasColumnName("remove_date");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductPictures)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_product_picture_products");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__roles__760965CC6B8069C7");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UId).HasName("PK__users__B51D3DEA1E982959");

            entity.ToTable("users");

            entity.Property(e => e.UId).HasColumnName("u_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("insert_date");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("((1))")
                .HasColumnName("is_active");
            entity.Property(e => e.IsRemove)
                .HasDefaultValueSql("((0))")
                .HasColumnName("is_remove");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.RemoveDate)
                .HasColumnType("datetime")
                .HasColumnName("remove_date");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("u_name");
            entity.Property(e => e.UPassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("u_password");
            entity.Property(e => e.UPhone)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("u_phone");
            entity.Property(e => e.UProfilePicture).HasColumnName("u_profile_picture");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_roles_users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
