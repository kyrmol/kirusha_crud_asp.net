using System.ComponentModel.DataAnnotations;

namespace kirusha_crud_asp.net.Model
{
    public class Treatment
    {
        [Key] 
        public int treatment_id { get; set; } // Уникальный идентификатор лечения

      


        [Required] 
        [StringLength(100)] 
        public string type { get; set; } = string.Empty; // Тип лечения

        [Required] 
        [StringLength(500)] 
        public string notes { get; set; } = string.Empty; 

        [Required] 
        [Range(0, double.MaxValue)] 
        public decimal cost { get; set; } 
    }
}
