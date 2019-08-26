﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CallCenter.Presentation.Models.Login
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Kullanıcı Adınızı giriniz.")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifrenizi giriniz.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}