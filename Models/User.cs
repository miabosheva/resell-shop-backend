﻿using System.ComponentModel.DataAnnotations;

namespace backend_resell_app.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
