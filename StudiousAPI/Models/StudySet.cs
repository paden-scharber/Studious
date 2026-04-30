using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudiousAPI.Models
{
    [Table("FLASH_CARDS") ]
    [Keyless]
    public class StudySet
    {
        public string USERNAME { get; set; }
        public string STUDYSET_NAME { get; set; }
        public string TERM { get; set; }
        public string DEFINITION { get; set; }
    }
}
