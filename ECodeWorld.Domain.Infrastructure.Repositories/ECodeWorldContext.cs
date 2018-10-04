using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class ECodeWorldContext : DbContext
    {
        private readonly string connectionString;
        private readonly TimeSpan cacheTimespan;
        public ECodeWorldContext()
        {
        }

        public ECodeWorldContext(string connectionString, TimeSpan cacheTimespan)
        {
            this.connectionString = connectionString;
            this.cacheTimespan = cacheTimespan;
        }
        public ECodeWorldContext(DbContextOptions<ECodeWorldContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccessLevels> AccessLevels { get; set; }
        public virtual DbSet<AccountPlanLevels> AccountPlanLevels { get; set; }
        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Certifications> Certifications { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<CitiesMl> CitiesMl { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<CommentsMl> CommentsMl { get; set; }
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<ComplexityLevels> ComplexityLevels { get; set; }
        public virtual DbSet<ComplexityLevelsMl> ComplexityLevelsMl { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<CountriesMl> CountriesMl { get; set; }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<LikesCounters> LikesCounters { get; set; }
        public virtual DbSet<Logins> Logins { get; set; }
        public virtual DbSet<Memberships> Memberships { get; set; }
        public virtual DbSet<PostCategories> PostCategories { get; set; }
        public virtual DbSet<PostCategoriesMl> PostCategoriesMl { get; set; }
        public virtual DbSet<PostReviews> PostReviews { get; set; }
        public virtual DbSet<PostReviewsMl> PostReviewsMl { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<PostsImages> PostsImages { get; set; }
        public virtual DbSet<PostsMl> PostsMl { get; set; }
        public virtual DbSet<PostStatus> PostStatus { get; set; }
        public virtual DbSet<PostStatusMl> PostStatusMl { get; set; }
        public virtual DbSet<PostTypes> PostTypes { get; set; }
        public virtual DbSet<PostTypesMl> PostTypesMl { get; set; }
        public virtual DbSet<Qualifications> Qualifications { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<StatesMl> StatesMl { get; set; }
        public virtual DbSet<TempPosts> TempPosts { get; set; }
        public virtual DbSet<TempPostsMl> TempPostsMl { get; set; }
        public virtual DbSet<Universities> Universities { get; set; }
        public virtual DbSet<UserCertifications> UserCertifications { get; set; }
        public virtual DbSet<UserProfiles> UserProfiles { get; set; }
        public virtual DbSet<UserQualifications> UserQualifications { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersAddress> UsersAddress { get; set; }
        public virtual DbSet<ZipCodes> ZipCodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessLevels>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccessLevel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<AccountPlanLevels>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountPlanLevel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountPlanLevelsId).HasColumnName("AccountPlanLevelsID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountPlanLevels)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccountPlanLevelsId)
                    .HasConstraintName("FK_AccountsPlanLevels");
            });

            modelBuilder.Entity<Certifications>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Isocode)
                    .HasColumnName("ISOCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatesId).HasColumnName("StatesID");

                entity.HasOne(d => d.States)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.StatesId)
                    .HasConstraintName("FK_CitiesStates");
            });

            modelBuilder.Entity<CitiesMl>(entity =>
            {
                entity.ToTable("Cities_ML");

                entity.HasIndex(e => new { e.CitiesId, e.LanguageId })
                    .HasName("UC_UniqueCitiesLanguage")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CitiesId).HasColumnName("CitiesID");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Isocode)
                    .HasColumnName("ISOCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cities)
                    .WithMany(p => p.CitiesMl)
                    .HasForeignKey(d => d.CitiesId)
                    .HasConstraintName("FK_Cities_MLCities");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.CitiesMl)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_Cities_MLLanguages");
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AuthorEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AuthorIp)
                    .HasColumnName("AuthorIP")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AuthorsId).HasColumnName("AuthorsID");

                entity.Property(e => e.Content)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PostsId).HasColumnName("PostsID");

                entity.HasOne(d => d.Authors)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.AuthorsId)
                    .HasConstraintName("FK_CommentsAuthors");

                entity.HasOne(d => d.Posts)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostsId)
                    .HasConstraintName("FK_CommentsPosts");
            });

            modelBuilder.Entity<CommentsMl>(entity =>
            {
                entity.ToTable("Comments_ML");

                entity.HasIndex(e => new { e.CommentsId, e.LanguageId })
                    .HasName("UC_CommentsLanguage")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CommentsId).HasColumnName("CommentsID");

                entity.Property(e => e.Content)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.HasOne(d => d.Comments)
                    .WithMany(p => p.CommentsMl)
                    .HasForeignKey(d => d.CommentsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comments_MLComments");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.CommentsMl)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_Comments_MLLanguages");
            });

            modelBuilder.Entity<Companies>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccessLevelsId).HasColumnName("AccessLevelsID");

                entity.Property(e => e.AccountsId).HasColumnName("AccountsID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccessLevels)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.AccessLevelsId)
                    .HasConstraintName("FK_CompaniesAccessLevels");

                entity.HasOne(d => d.Accounts)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.AccountsId)
                    .HasConstraintName("FK_CompaniesAccounts");
            });

            modelBuilder.Entity<ComplexityLevels>(entity =>
            {
                entity.HasIndex(e => e.Complexity)
                    .HasName("UC_ComplexityLevels")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Complexity)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ComplexityLevelsMl>(entity =>
            {
                entity.ToTable("ComplexityLevels_ML");

                entity.HasIndex(e => e.Complexity)
                    .HasName("UC_ComplexityLevels_ML")
                    .IsUnique();

                entity.HasIndex(e => new { e.ComplexityLevelsId, e.LanguageId })
                    .HasName("UC_UniqueComplexityLevelsLanguage")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Complexity)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ComplexityLevelsId).HasColumnName("ComplexityLevelsID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.HasOne(d => d.ComplexityLevels)
                    .WithMany(p => p.ComplexityLevelsMl)
                    .HasForeignKey(d => d.ComplexityLevelsId)
                    .HasConstraintName("FK_ComplexityLevels_MLComplexityLevels");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.ComplexityLevelsMl)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_ComplexityLevels_MLLanguages");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Isocode)
                    .HasColumnName("ISOCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CountriesMl>(entity =>
            {
                entity.ToTable("Countries_ML");

                entity.HasIndex(e => new { e.CountriesId, e.LanguageId })
                    .HasName("UC_UniqueCountriesLanguage")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountriesId).HasColumnName("CountriesID");

                entity.Property(e => e.Isocode)
                    .HasColumnName("ISOCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Countries)
                    .WithMany(p => p.CountriesMl)
                    .HasForeignKey(d => d.CountriesId)
                    .HasConstraintName("FK_Countries_MLCountries");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.CountriesMl)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_Countries_MLLanguages");
            });

            modelBuilder.Entity<Languages>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameLocal).HasMaxLength(128);
            });

            modelBuilder.Entity<LikesCounters>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LikeIp)
                    .HasColumnName("LikeIP")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PostsId).HasColumnName("PostsID");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Posts)
                    .WithMany(p => p.LikesCounters)
                    .HasForeignKey(d => d.PostsId)
                    .HasConstraintName("FK_LikesCountersPosts");
            });

            modelBuilder.Entity<Logins>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSalt)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UsersId).HasColumnName("UsersID");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK_LoginsUsers");
            });

            modelBuilder.Entity<Memberships>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompaniesId).HasColumnName("CompaniesID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RolesId).HasColumnName("RolesID");

                entity.Property(e => e.UsersId).HasColumnName("UsersID");

                entity.HasOne(d => d.Companies)
                    .WithMany(p => p.Memberships)
                    .HasForeignKey(d => d.CompaniesId)
                    .HasConstraintName("FK_MembershipsCompanies");

                entity.HasOne(d => d.Roles)
                    .WithMany(p => p.Memberships)
                    .HasForeignKey(d => d.RolesId)
                    .HasConstraintName("FK_MembershipsRoles");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Memberships)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK_MembershipsUsers");
            });

            modelBuilder.Entity<PostCategories>(entity =>
            {
                entity.HasIndex(e => e.Category)
                    .HasName("UC_PostCategories")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PostCategoriesMl>(entity =>
            {
                entity.ToTable("PostCategories_ML");

                entity.HasIndex(e => e.Category)
                    .HasName("UC_PostCategories_ML")
                    .IsUnique();

                entity.HasIndex(e => new { e.PostCategoriesId, e.LanguageId })
                    .HasName("UC_UniquePostCategoryLanguage")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.PostCategoriesId).HasColumnName("PostCategoriesID");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.PostCategoriesMl)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_PostCategories_MLLanguages");

                entity.HasOne(d => d.PostCategories)
                    .WithMany(p => p.PostCategoriesMl)
                    .HasForeignKey(d => d.PostCategoriesId)
                    .HasConstraintName("FK_TempPosts_MLPostCategories");
            });

            modelBuilder.Entity<PostReviews>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssignedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Comments)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.CompletionDate).HasColumnType("date");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DoneDate).HasColumnType("date");

                entity.Property(e => e.Messages)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.TempPostsId).HasColumnName("TempPostsID");

                entity.Property(e => e.UsersId).HasColumnName("UsersID");

                entity.HasOne(d => d.TempPosts)
                    .WithMany(p => p.PostReviews)
                    .HasForeignKey(d => d.TempPostsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostReviewTempPosts");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.PostReviews)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostReviewUsers");
            });

            modelBuilder.Entity<PostReviewsMl>(entity =>
            {
                entity.ToTable("PostReviews_ML");

                entity.HasIndex(e => new { e.PostReviewsId, e.LanguageId })
                    .HasName("UC_PostReviews_MLLanguage")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comments)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.Messages)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PostReviewsId).HasColumnName("PostReviewsID");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.PostReviewsMl)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_PostReviews_MLLanguages");

                entity.HasOne(d => d.PostReviews)
                    .WithMany(p => p.PostReviewsMl)
                    .HasForeignKey(d => d.PostReviewsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostReviews_MLPostReviews");
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.ComplexityLevelsId).HasColumnName("ComplexityLevelsID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Keywords)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PostStatusId).HasColumnName("PostStatusID");

                entity.Property(e => e.PostTypesId).HasColumnName("PostTypesID");

                entity.Property(e => e.ScheduleDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_PostsUsers");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_PostsPostCategories");

                entity.HasOne(d => d.ComplexityLevels)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.ComplexityLevelsId)
                    .HasConstraintName("FK_PostsComplexityLevels");

                entity.HasOne(d => d.PostStatus)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.PostStatusId)
                    .HasConstraintName("FK_PostsPostStatus");

                entity.HasOne(d => d.PostTypes)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.PostTypesId)
                    .HasConstraintName("FK_PostsPostTypes");
            });

            modelBuilder.Entity<PostsImages>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostsImages)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostsImagesPosts");
            });

            modelBuilder.Entity<PostsMl>(entity =>
            {
                entity.ToTable("Posts_ML");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Keywords)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.PostsId).HasColumnName("PostsID");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.PostsMl)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_Posts_MLLanguages");

                entity.HasOne(d => d.Posts)
                    .WithMany(p => p.PostsMl)
                    .HasForeignKey(d => d.PostsId)
                    .HasConstraintName("FK_Posts_MLPosts");
            });

            modelBuilder.Entity<PostStatus>(entity =>
            {
                entity.HasIndex(e => e.Pstatus)
                    .HasName("UC_PostStatus")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Pstatus)
                    .IsRequired()
                    .HasColumnName("PStatus")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PostStatusMl>(entity =>
            {
                entity.ToTable("PostStatus_ML");

                entity.HasIndex(e => e.Pstatus)
                    .HasName("UC_PostStatus_ML")
                    .IsUnique();

                entity.HasIndex(e => new { e.PostStatusId, e.LanguageId })
                    .HasName("UC_UniquePostStatusLanguage")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.PostStatusId).HasColumnName("PostStatusID");

                entity.Property(e => e.Pstatus)
                    .IsRequired()
                    .HasColumnName("PStatus")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.PostStatusMl)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_PostStatus_MLLanguages");

                entity.HasOne(d => d.PostStatus)
                    .WithMany(p => p.PostStatusMl)
                    .HasForeignKey(d => d.PostStatusId)
                    .HasConstraintName("FK_TempPosts_MLPostStatus");
            });

            modelBuilder.Entity<PostTypes>(entity =>
            {
                entity.HasIndex(e => e.Ptype)
                    .HasName("UC_PostTypes")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ptype)
                    .IsRequired()
                    .HasColumnName("PType")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PostTypesMl>(entity =>
            {
                entity.ToTable("PostTypes_ML");

                entity.HasIndex(e => e.Ptype)
                    .HasName("UC_PostTypes_ML")
                    .IsUnique();

                entity.HasIndex(e => new { e.PostTypesId, e.LanguageId })
                    .HasName("UC_UniquePostTypesLanguage")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.PostTypesId).HasColumnName("PostTypesID");

                entity.Property(e => e.Ptype)
                    .IsRequired()
                    .HasColumnName("PType")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.PostTypesMl)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_PostTypes_MLLanguages");

                entity.HasOne(d => d.PostTypes)
                    .WithMany(p => p.PostTypesMl)
                    .HasForeignKey(d => d.PostTypesId)
                    .HasConstraintName("FK_PostTypes_MLPostStatus");
            });

            modelBuilder.Entity<Qualifications>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<States>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountriesId).HasColumnName("CountriesID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Isocode)
                    .HasColumnName("ISOCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Countries)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.CountriesId)
                    .HasConstraintName("FK_StatesCountries");
            });

            modelBuilder.Entity<StatesMl>(entity =>
            {
                entity.ToTable("States_ML");

                entity.HasIndex(e => new { e.StatesId, e.LanguageId })
                    .HasName("UC_UniqueStatesLanguage")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Isocode)
                    .HasColumnName("ISOCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatesId).HasColumnName("StatesID");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.StatesMl)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_States_MLLanguages");

                entity.HasOne(d => d.States)
                    .WithMany(p => p.StatesMl)
                    .HasForeignKey(d => d.StatesId)
                    .HasConstraintName("FK_States_MLStates");
            });

            modelBuilder.Entity<TempPosts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.ComplexityLevelsId).HasColumnName("ComplexityLevelsID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Keywords)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PostStatusId).HasColumnName("PostStatusID");

                entity.Property(e => e.PostTypesId).HasColumnName("PostTypesID");

                entity.Property(e => e.ScheduleDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.TempPosts)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_TempPostsUsers");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TempPosts)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_TempPostsPostCategories");

                entity.HasOne(d => d.ComplexityLevels)
                    .WithMany(p => p.TempPosts)
                    .HasForeignKey(d => d.ComplexityLevelsId)
                    .HasConstraintName("FK_TempPostsComplexityLevels");

                entity.HasOne(d => d.PostStatus)
                    .WithMany(p => p.TempPosts)
                    .HasForeignKey(d => d.PostStatusId)
                    .HasConstraintName("FK_TempPostsPostStatus");

                entity.HasOne(d => d.PostTypes)
                    .WithMany(p => p.TempPosts)
                    .HasForeignKey(d => d.PostTypesId)
                    .HasConstraintName("FK_TempPostsPostTypes");
            });

            modelBuilder.Entity<TempPostsMl>(entity =>
            {
                entity.ToTable("TempPosts_ML");

                entity.HasIndex(e => new { e.TempPostsId, e.LanguageId })
                    .HasName("UC_UniqueTempPosts_MLLanguage")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Keywords)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.TempPostsId).HasColumnName("TempPostsID");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.TempPostsMl)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_TempPosts_MLLanguages");

                entity.HasOne(d => d.TempPosts)
                    .WithMany(p => p.TempPostsMl)
                    .HasForeignKey(d => d.TempPostsId)
                    .HasConstraintName("FK_TempPosts_MLTempPosts");
            });

            modelBuilder.Entity<Universities>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserCertifications>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CertificationsId).HasColumnName("CertificationsID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.QualificationDate).HasColumnType("date");

                entity.Property(e => e.UsersId).HasColumnName("UsersID");

                entity.Property(e => e.ValidFrom).HasColumnType("date");

                entity.Property(e => e.ValidTo).HasColumnType("date");

                entity.HasOne(d => d.Certifications)
                    .WithMany(p => p.UserCertifications)
                    .HasForeignKey(d => d.CertificationsId)
                    .HasConstraintName("FK_Certifications");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.UserCertifications)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK_UsersCertifications");
            });

            modelBuilder.Entity<UserProfiles>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AboutMe)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Avtar)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Banner)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Icon)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Keywords)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Logo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsersId).HasColumnName("UsersID");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.UserProfiles)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK_UserUsersProfiles");
            });

            modelBuilder.Entity<UserQualifications>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.QualificationDate).HasColumnType("date");

                entity.Property(e => e.QualificationsId).HasColumnName("QualificationsID");

                entity.Property(e => e.UniversitiesId).HasColumnName("UniversitiesID");

                entity.Property(e => e.UsersId).HasColumnName("UsersID");

                entity.HasOne(d => d.Qualifications)
                    .WithMany(p => p.UserQualifications)
                    .HasForeignKey(d => d.QualificationsId)
                    .HasConstraintName("FK_Qualifications");

                entity.HasOne(d => d.Universities)
                    .WithMany(p => p.UserQualifications)
                    .HasForeignKey(d => d.UniversitiesId)
                    .HasConstraintName("FK_Universities");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.UserQualifications)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK_Users");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsersAddress>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Address3)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.Property(e => e.UsersId).HasColumnName("UsersID");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.UsersAddress)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK_UsersAddress");
            });

            modelBuilder.Entity<ZipCodes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CitiesId).HasColumnName("CitiesID");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Isocode)
                    .HasColumnName("ISOCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cities)
                    .WithMany(p => p.ZipCodes)
                    .HasForeignKey(d => d.CitiesId)
                    .HasConstraintName("FK_ZipCodesCities");
            });
        }
    }
}
