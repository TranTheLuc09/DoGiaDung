using System.ComponentModel.DataAnnotations;

namespace DataModel
{
    public class Accounts
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string level { get; set; }
        public int money { get; set; }
        public string fullname { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string token { get;set; }
    }

    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }

    public class UpdateModel
    {
        [Required]
        public string fullname { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string address { get; set; }
    }

    public class UpdateModelByAdmin
    {
        [Required]
        public string fullname { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string level { get; set; }
        [Required]
        public string username { get; set; }
    }

    public class AppSettings
    {
        public string Secret { get; set; }

    }
}