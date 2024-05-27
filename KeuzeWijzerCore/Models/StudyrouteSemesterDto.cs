using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeuzeWijzerCore.Models
{
    public class StudyrouteSemesterDto
    {
        public int Id { get; set; }
        public int Semester { get; set; }
        public int StudyrouteId { get; set; }
        public StudyrouteDto? Studyroute { get; set; }
        public int ModuleId { get; set; }
        public SchoolModuleDto? Module { get; set; }
        public int SchoolYearId { get; set; }
        public SchoolYearDto? SchoolYear { get; set; }
    }
}
