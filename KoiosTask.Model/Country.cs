﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KoiosTask.Model
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
