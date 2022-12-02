﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinWin.Domain.Model.Account
{
    public class AccountModel
    {
 
        public string? UserName { get; set; }
        public string? DisplayName { get; set; }
        public string? PassWord { get; set; }
    }
}
