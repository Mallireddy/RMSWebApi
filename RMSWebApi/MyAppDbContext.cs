using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMSWebApi
{
    public class MyAppDbContext:DbContext
    {
        public DbSet<AppRole> Roles { get; set; }   
        public DbSet<UserInfo> Users { get; set; }  
        public DbSet<Order>Orders { get; set; } 
        public DbSet<Book> BooKs { get; set; }    
        public DbSet<PurchaseOrder> PurchaseOrders { get; set;}
        public DbSet<Genre> Genres { get; set; }
        public MyAppDbContext(DbContextOptions opts):base(opts)
        {

        } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasIndex(P => P.BookTitle).IsUnique();
        }
    }
    public class AppRole
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }   
        public List<UserInfo> UserInRole { get; set; }
        

    }
   public class UserInfo
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }   
        public int RoleId { get; set; } 
        [ForeignKey("RoleId")]
        public  AppRole UserRole { get; set; }
    }
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [ForeignKey("BookId")]
        public int BookId { get; set; }
        [Required]
        public int Quantity { get; set; }  
        [Required]
        public double Price { get; set; }
        [Required]
        public double TotalOrderPrice { get; set; }
        [Required]
        public string GenereId { get; set; } 
        public List<Genre> Genres { get; set; }
        public Book GetBook { get; set; }


    }
    public class Book
    {
        [Key]
        public int BookId { get; set; }  
        [Required]
        public string BookTitle { get; set; }
        public string AuthorName { get; set; }
        public string PublisherName { get; set; }
        public string Barcode { get; set; }
        [Required]
        public int Quatity { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string GenreId { get; set; } 
        public List<Genre> Genres { get; set; }
        public List<Order> Orders { get; set; }
        public List<PurchaseOrder> PurchaseOrders { get; set; }
    }
    public class PurchaseOrder
    {
        [Key]
        public int PurchaseOrderId { get; set; }
        [ForeignKey("BookId")]
        public int BookId { get; set; }
        [Required]
        public string BookTitle { get; set; }
        [Required]
        public int Quantity { get; set; }  
        [Required]
        public double Price { get; set; }
        [Required]
        public string GenreId { get; set; } 
        public List<Genre> Genres { get; set; }
        [Required]
        public double TotalOrderPrice { get; set; } 
        public Book GetBook { set; get; } 
         
    }
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        [Required]
        public string GenreTitle { get; set; }  
    }
}
