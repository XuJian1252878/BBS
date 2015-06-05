using BBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Domain.Concrete.DBContext
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("EFDbContext")
        {
            //The name of the connection string (which you'll add to the Web.config file later) is passed in to the constructor.
            //If you don't specify a connection string or the name of one explicitly, Entity Framework assumes that the connection string name is the same as the class name.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFDbContext, BBS.Domain.Migrations.Configuration>("EFDbContext"));
        }

        //实体类与数据库表的映射配置
        public DbSet<Admin> Admin { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Board> Board { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Reply> Reply { get; set; }
        public DbSet<Tag> Tag { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //The modelBuilder.Conventions.Remove statement in the OnModelCreating method prevents table names from being pluralized.
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //定义user和reply之间的一对多关系不涉及级联删除
            modelBuilder.Entity<Reply>()
                .HasRequired(reply => reply.User)
                .WithMany(user => user.Replies)
                .HasForeignKey(reply => reply.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Board>().
                HasOptional(board => board.ParentBoard).
                WithMany(board => board.Boards).
                HasForeignKey(board => board.ParentBoardID);
        }
    }
}
