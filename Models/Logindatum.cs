﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PracticeLoginFormAspCore.Models
{
    public partial class Logindatum
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public int Age { get; set; }
        public string Email { get; set; } = null!;
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
