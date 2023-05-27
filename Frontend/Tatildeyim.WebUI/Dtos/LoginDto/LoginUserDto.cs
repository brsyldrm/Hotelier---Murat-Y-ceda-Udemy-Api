﻿using System.ComponentModel.DataAnnotations;

namespace Tatildeyim.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage ="Kullanıcı Adı Giriniz")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifreyi Giriniz")]
        public string Password { get; set; }
    }
}
