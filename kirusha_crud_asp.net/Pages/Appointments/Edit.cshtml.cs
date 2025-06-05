using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using kirusha_crud_asp.net.Data;
using kirusha_crud_asp.net.Model;

namespace kirusha_crud_asp.net.Pages.Appointments
{
    public class EditModel : PageModel
    {
        private readonly kirusha_crud_aspnetContext _context;

        public EditModel(kirusha_crud_aspnetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Appointment Appointment { get; set; }

        public SelectList Patients { get; set; }
        public SelectList Dentists { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment.FirstOrDefaultAsync(m => m.appointment_id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            Appointment = appointment;

            // Загружаем списки для селектов
            var patients = await _context.Patient.ToListAsync();
            var dentists = await _context.Dentist.ToListAsync();

            Patients = new SelectList(patients, "patient_id", "name_first", Appointment.patient_id);
            Dentists = new SelectList(dentists, "dentist_id", "name_first", Appointment.dentist_id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                // Логируем данные
                Console.WriteLine($"Editing appointment_id: {Appointment?.appointment_id}");
                Console.WriteLine($"treatment_id: {Appointment?.treatment_id}");
                Console.WriteLine($"patient_id: {Appointment?.patient_id}");
                Console.WriteLine($"dentist_id: {Appointment?.dentist_id}");
                Console.WriteLine($"datetime: {Appointment?.datetime}");
                Console.WriteLine($"status: {Appointment?.status}");

                if (Appointment != null)
                {
                    _context.Attach(Appointment).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine($"Concurrency error: {ex.Message}");
                if (!AppointmentExists(Appointment.appointment_id))
                {
                    return NotFound();
                }
                else
                {
                    ModelState.AddModelError("", "Запись была изменена другим пользователем. Попробуйте еще раз.");
                }
            }
            catch (Exception ex)
            {
                // Подробное логирование ошибки
                var fullError = ex.Message;
                if (ex.InnerException != null)
                {
                    fullError += " Inner: " + ex.InnerException.Message;
                    if (ex.InnerException.InnerException != null)
                    {
                        fullError += " Inner2: " + ex.InnerException.InnerException.Message;
                    }
                }

                Console.WriteLine($"Edit error: {fullError}");
                ModelState.AddModelError("", $"Ошибка: {fullError}");
            }

            // Если ошибка, перезагружаем списки
            var patients = await _context.Patient.ToListAsync();
            var dentists = await _context.Dentist.ToListAsync();

            Patients = new SelectList(patients, "patient_id", "name_first", Appointment?.patient_id);
            Dentists = new SelectList(dentists, "dentist_id", "name_first", Appointment?.dentist_id);

            return Page();
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointment.Any(e => e.appointment_id == id);
        }
    }
}