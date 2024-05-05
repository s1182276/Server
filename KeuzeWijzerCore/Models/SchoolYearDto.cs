using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KeuzeWijzerCore.Models
{
    public class SchoolYearDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SchoolModuleDto>? SchoolModules { get; set; }
    }
}
