﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeuzeWijzerApi.DAL.DataEntities
{
    public class Module
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int EC { get; set; }
        public int Level { get; set; }
        public bool Active { get; set; }
        public int SchoolYearId { get; set; }
        public string? Description { get; set; }
        public bool PRequired { get; set; }
        public int MinimalEC { get; set; }
        public int Semester { get; set; }
    }
}
