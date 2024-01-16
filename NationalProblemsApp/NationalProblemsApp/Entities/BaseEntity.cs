using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NationalProblemsApp.Entities
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPk { get; set; } = 0;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = Convert.ToDateTime("1900-01-01");
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedOn { get; set; } = Convert.ToDateTime("1900-01-01");
    }
}