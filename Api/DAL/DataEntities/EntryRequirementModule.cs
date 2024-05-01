﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeuzeWijzerApi.DAL.DataEntities
{
    public class EntryRequirementModule
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public int ModuleId { get; set; }
        public Module? Module { get; set; }

        public int MustModuleId { get; set; }
        public Module? MustModule { get; set; }

        public bool MustPassed { get; set; }

    }
}