using kirusha_crud_asp.net.Data;
using kirusha_crud_asp.net.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace kirusha_crud_asp.net.Pages.Appointments
{
    public class CreateModel : PageModel
    {
        private readonly kirusha_crud_aspnetContext _context;

        public CreateModel(kirusha_crud_aspnetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Appointment Appointment { get; set; }

        public SelectList Patients { get; set; }
        public SelectList Dentists { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var patients = await _context.Patient.ToListAsync();
            var dentists = await _context.Dentist.ToListAsync();

            Patients = new SelectList(patients, "patient_id", "name_first");
            Dentists = new SelectList(dentists, "dentist_id", "name_first");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                // Логируем полученные данные
                Console.WriteLine($"treatment_id: {Appointment?.treatment_id}");
                Console.WriteLine($"patient_id: {Appointment?.patient_id}");
                Console.WriteLine($"dentist_id: {Appointment?.dentist_id}");
                Console.WriteLine($"datetime: {Appointment?.datetime}");
                Console.WriteLine($"status: {Appointment?.status}");

                // Простая проверка - есть ли данные
                if (Appointment != null)
                {
                    _context.Appointment.Add(Appointment);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
            }
            catch (Exception ex)
            {
                // Показываем полную ошибку включая inner exception
                var fullError = ex.Message;
                if (ex.InnerException != null)
                {
                    fullError += " Inner: " + ex.InnerException.Message;
                    if (ex.InnerException.InnerException != null)
                    {
                        fullError += " Inner2: " + ex.InnerException.InnerException.Message;
                    }
                }

                Console.WriteLine($"Полная ошибка: {fullError}");
                ModelState.AddModelError("", $"Ошибка: {fullError}");
            }

            // Если что-то не так, перезагружаем списки и возвращаем страницу
            var patients = await _context.Patient.ToListAsync();
            var dentists = await _context.Dentist.ToListAsync();

            Patients = new SelectList(patients, "patient_id", "name_first");
            Dentists = new SelectList(dentists, "dentist_id", "name_first");

            return Page();
        }
    }
}