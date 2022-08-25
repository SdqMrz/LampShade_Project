using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using BolgManagement.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;

namespace BolgManagement.Infrastructure.EFCore
{
    public class BlogContext: DbContext
    {
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Article> Articles { get; set; }

        public BlogContext(DbContextOptions<BlogContext> context):base(context)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ArticleCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
