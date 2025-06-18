using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kirusha_crud_asp.net.Model
{
    public class Appointment
    {
        [Key] 
        public int appointment_id { get; set; } 

        [Required] 
        [ForeignKey("Treatment")] 
        public int treatment_id { get; set; } 
        public Treatment Treatment { get; set; }

        [Required] 
        [ForeignKey("Patient")] 
        public int patient_id { get; set; } 
        public Patient Patient { get; set; }


        [Required] 
        [ForeignKey("Dentist")] 
        public int? dentist_id { get; set; } 
        public Dentist? Dentist { get; set; } 

        [Required] 
        public DateTime datetime { get; set; }

        [Required] 
        [StringLength(50)] 
        public string status { get; set; } = string.Empty; 
    }
}