using System.ComponentModel.DataAnnotations;


namespace kirusha_crud_asp.net.Model
{
    public class Patient
    {
        [Key] 
        public int patient_id { get; set; } 

        [Required]
        [StringLength(50)]
        public string name_first { get; set; } = string.Empty; 


       
        [StringLength(50)]
        public string? name_middle { get; set; } 

        [Required]
        [StringLength(50)]
        public string name_last { get; set; } = string.Empty; 

        [Required]
        public DateOnly date_of_birth { get; set; } 


        [Required]
        [StringLength(100)]
        public string? street { get; set; } 


        [Required]
        [StringLength(10)]
        public string? house_number { get; set; } 


        [Required]
        [StringLength(10)]
        public string? postcode { get; set; } 


        [Required]
        [Phone]
        public string? phone { get; set; } 


        [Required]
        [EmailAddress]
        public string? email { get; set; } 

        public string? allergies { get; set; } 

        public string? notes { get; set; } 
    }
}
