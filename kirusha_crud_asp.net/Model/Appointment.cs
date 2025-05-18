using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kirusha_crud_asp.net.Model
{
    public class Appointment
    {
        [Key] // Указывает, что это первичный ключ
        public int appointment_id { get; set; } // Уникальный идентификатор записи

        [Required] // Поле обязательно
        [ForeignKey("Treatment")] // Внешний ключ для таблицы Treatment
        public int treatment_id { get; set; } // ID лечения

        [Required] // Поле обязательно
        [ForeignKey("Patient")] // Внешний ключ для таблицы Patient
        public int patient_id { get; set; } // ID пациента

        [Required] // Поле обязательно
        [ForeignKey("Dentist")] // Внешний ключ для таблицы Dentist
        public int dentist_id { get; set; } // ID стоматолога

        [Required] // Поле обязательно
        public DateTime datetime { get; set; } // Дата и время записи

        [Required] // Поле обязательно
        [StringLength(50)] // Ограничение длины строки
        public string status { get; set; } = string.Empty; // Статус записи (например, "Scheduled", "Completed", "Canceled")
    }
}