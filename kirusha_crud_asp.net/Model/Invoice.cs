using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace kirusha_crud_asp.net.Model
{
    public class Invoice
    {
        [Key] // Указывает, что это первичный ключ
        public int invoice_id { get; set; } // Уникальный идентификатор счета

        [Required] // Поле обязательно
        [ForeignKey("Appointment")] // Внешний ключ для таблицы Appointment
        public int appointment_id { get; set; } // ID записи на прием

        [Required] // Поле обязательно
        public DateOnly date { get; set; } // Дата счета

        [Required] // Поле обязательно
        [Range(0, double.MaxValue)] // Ограничение на диапазон суммы (неотрицательное значение)
        public decimal amount { get; set; } // Сумма счета

        [Required] // Поле обязательно
        public bool paid { get; set; } // Статус оплаты (true = оплачено, false = не оплачено)

        // Навигационное свойство для связи с Appointment
        public Appointment? Appointment { get; set; }
    }
}
