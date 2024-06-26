﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeFinder.Infrastructure.Data.Models;

namespace RecipeFinder.Infrastructure.Data.SeedDatabase
{
    internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            var data = new SeedData();
            builder
               .HasOne(e => e.Recipe)
               .WithMany(e => e.Comments)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new Comment[] { data.BrowniesComment });
        }
    }
}
