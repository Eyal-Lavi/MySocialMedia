using Microsoft.EntityFrameworkCore;
using MySocialMedia.Common.DBTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialMedia.Logic.Services
{
    public class MySocialMediaDBContext : DbContext
    {
        public MySocialMediaDBContext(DbContextOptions<MySocialMediaDBContext> options) : base(options)
        {
        }

        public DbSet<User> users { get; set; }
        public DbSet<User_messages> user_messages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(x => x.ID);//מעדכן אותו שידע שזה ה key 

            modelBuilder.Entity<User_messages>()
               .HasKey(x => x.ID);//מעדכן אותו שידע שזה ה key 

            // הגדרת קשר אחד-לרבים בין טבלת Users לטבלת User_messages דרך שדה SENDER_USER_ID
            modelBuilder.Entity<User>()
               .HasMany(x => x.send_user_messages)//מעדכן אותו שידע שיש לכל משתמש הרבה הודעות 
               .WithOne(x => x.send_user)// עבור כל הודעה יש משתמש אחד ששלח אותה
               .HasForeignKey(x => x.SENDER_USER_ID);

            // הגדרת קשר אחד-לרבים בין טבלת Users לטבלת User_messages דרך שדה RECEIVER_USER_ID
            modelBuilder.Entity<User>()
                .HasMany(x => x.receive_user_messages)//מעדכן אותו שידע שיש לכל משתמש הרבה הודעות 
                .WithOne(x => x.receive_user)
                .HasForeignKey(x => x.RECEIVER_USER_ID);


        }
    }
}
