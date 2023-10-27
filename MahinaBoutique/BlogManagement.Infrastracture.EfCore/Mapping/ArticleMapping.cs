using BlogManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Infrastracture.EfCore.Mapping
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(300).IsRequired();
            builder.Property(x => x.CanonicalAddress).HasMaxLength(1000);
            builder.Property(x => x.Picture).HasMaxLength(500);
            builder.Property(x => x.PictureAlt).HasMaxLength(200);
            builder.Property(x => x.PictureTitle).HasMaxLength(200);
            builder.Property(x => x.Keywords).HasMaxLength(100).IsRequired();
            builder.Property(x => x.MetaDescription).HasMaxLength(200).IsRequired();
            builder.Property(x => x.ShortDescription).HasMaxLength(1000).IsRequired();

            builder.HasOne(x => x.Category).WithMany(x => x.Articles).HasForeignKey(x => x.CategoryId);
        }
    }
}
