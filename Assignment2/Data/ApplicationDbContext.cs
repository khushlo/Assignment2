using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterImplementation;
using RedditImplementation;

namespace Assignment2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TwitterImplementation.Tweet> Tweet { get; set; }
        public DbSet<RedditImplementation.RedditPost> RedditPost { get; set; }
    }
}
