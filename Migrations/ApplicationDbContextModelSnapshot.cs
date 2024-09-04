using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using EfficientTaskManager.Models;

namespace EfficientTaskManager.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EfficientTaskManager.Models.User", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<string>("Email")
                    .HasColumnType("TEXT");

                b.Property<string>("UserName")
                    .HasColumnType("TEXT");

                b.HasKey("Id");

                b.ToTable("Users");
            });

            modelBuilder.Entity("EfficientTaskManager.Models.Task", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<string>("Description")
                    .HasColumnType("TEXT");

                b.Property<DateTime>("DueDate")
                    .HasColumnType("TEXT");

                b.Property<string>("Title")
                    .HasColumnType("TEXT");

                b.Property<int>("UserId")
                    .HasColumnType("INTEGER");

                b.HasKey("Id");

                b.HasIndex("UserId");

                b.ToTable("Tasks");
            });

            modelBuilder.Entity("EfficientTaskManager.Models.Note", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<string>("Content")
                    .HasColumnType("TEXT");

                b.Property<int>("TaskId")
                    .HasColumnType("INTEGER");

                b.HasKey("Id");

                b.HasIndex("TaskId");

                b.ToTable("Notes");
            });

            modelBuilder.Entity("EfficientTaskManager.Models.File", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<string>("FilePath")
                    .HasColumnType("TEXT");

                b.Property<int>("TaskId")
                    .HasColumnType("INTEGER");

                b.HasKey("Id");

                b.HasIndex("TaskId");

                b.ToTable("Files");
            });

            modelBuilder.Entity("EfficientTaskManager.Models.Task", b =>
            {
                b.HasOne("EfficientTaskManager.Models.User", "User")
                    .WithMany("Tasks")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("EfficientTaskManager.Models.Note", b =>
            {
                b.HasOne("EfficientTaskManager.Models.Task", "Task")
                    .WithMany("Notes")
                    .HasForeignKey("TaskId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("EfficientTaskManager.Models.File", b =>
            {
                b.HasOne("EfficientTaskManager.Models.Task", "Task")
                    .WithMany("Files")
                    .HasForeignKey("TaskId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });
        }
    }
}
