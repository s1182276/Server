﻿using System.ComponentModel.DataAnnotations;

namespace KeuzeWijzerApi.DAL.DataEntities
{
    public class SchoolYear
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Module> Modules { get; set; }
    }
}