using System.Collections.Generic;

namespace RMSWebApi
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class UserInfoDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public AppRole UserRole { get; set; }
    }
    public class BookDTO
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string AuthorName { get; set; }
        public string PublisherName { get; set; }
        public string Barcode { get; set; }
        public int Quatity { get; set; }
        public double Price { get; set; }
        public string GenreId { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Order> Orders { get; set; }
        public List<PurchaseOrder> PurchaseOrders { get; set; }
    }
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalOrderPrice { get; set; }
        public string GenereId { get; set; }
        public List<Genre> Genres { get; set; }
       // public Book GetBook { get; set; }

    }
    public class PurchaseOrderDTO
    {
        public int PurchaseOrderId { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string GenreId { get; set; }
        public List<Genre> Genres { get; set; }
        public double TotalOrderPrice { get; set; }
        //public Book GetBook { set; get; }

    }
    public class GenreDTO
    {
        public int GenreId { get; set; }
        public string GenreTitle { get; set; }
    }
}
