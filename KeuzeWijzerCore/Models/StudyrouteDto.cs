using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeuzeWijzerCore.Models
{
    public class StudyrouteDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public bool HistoricalRoute { get; set; }
        public required List<StudyrouteSemesterDto> StudyrouteSemesters { get; set; } = new List<StudyrouteSemesterDto>();
    }
}
