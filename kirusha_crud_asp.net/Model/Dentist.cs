using System.ComponentModel.DataAnnotations;


namespace kirusha_crud_asp.net.Model
{
    public class Dentist
    {
        [Key] // Указывает, что это первичный ключ
        public int dentist_id { get; set; } // Идентификатор стоматолога

        [Required]
        [StringLength(100)]
        public string specialty { get; set; } = string.Empty; // Специальность (обязательно)

        [Required]
        [StringLength(50)]
        public string name_first { get; set; } = string.Empty; // Имя (обязательно)

        [StringLength(50)]
        public string? name_middle { get; set; } // Отчество (необязательно)

        [Required]
        [StringLength(50)]
        public string name_last { get; set; } = string.Empty; // Фамилия (обязательно)

        [Required]
        [StringLength(100)]
        public string street { get; set; } = string.Empty; // Улица (обязательно)

        [Required]
        [StringLength(10)]
        public string house_number { get; set; } = string.Empty; // Номер дома (обязательно)

        [Required]
        [StringLength(10)]
        public string postcode { get; set; } = string.Empty; // Почтовый индекс (обязательно)

        [Required]
        [Phone]
        public string phone { get; set; } = string.Empty; // Телефон (обязательно)

        [Required]
        [EmailAddress]
        public string email { get; set; } = string.Empty; // Электронная почта (обязательно)
    }
}
