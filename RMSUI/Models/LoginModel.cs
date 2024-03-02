namespace RMSUI.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class TokenResponse
    {
        public string Token { get; set; }
        public string CheckUser { get; set; }
    }
    public class RegisterUser
    {
        public string UserName { get; set; }
      
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
