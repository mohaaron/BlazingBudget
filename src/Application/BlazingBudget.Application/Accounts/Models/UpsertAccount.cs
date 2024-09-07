﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Application.Accounts.Models
{
    public class UpsertAccount
    {
        [Required()]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required()]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required()]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required()]
        [MaxLength(100)]
        public string Password { get; set; } = string.Empty;
    }
}
