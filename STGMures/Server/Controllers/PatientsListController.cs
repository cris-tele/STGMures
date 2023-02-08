using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StgMures.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsListController : ControllerBase
    {
        private readonly StgMuresContext _context;

        public PatientsListController(StgMuresContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var ret = await _context.Patients.ToListAsync();
            return Ok(ret);
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return Ok(await _context.Patients.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, Patient patient)
        {
            var dbPatient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
            if (dbPatient == null)
            {
                return NotFound("""Pacientul cu Id-ul {id} nu exista.""");
            }

            dbPatient.FirstName = patient.FirstName;
            dbPatient.LastName = patient.LastName;
            dbPatient.ParentsName = patient.ParentsName;
            dbPatient.BirthDate = patient.BirthDate;
            dbPatient.BloodGroup = patient.BloodGroup;
            //dbPatient.ChildOrAdult = patient.ChildOrAdult;
            dbPatient.Cnp = patient.Cnp;
            dbPatient.Cnascode = patient.Cnascode;
            dbPatient.Note = patient.Note;
            dbPatient.Sex = patient.Sex;

            await _context.SaveChangesAsync();

            return Ok(dbPatient);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ForceDeletePatient(int id ) 
        {
            var dbPatient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
            if (dbPatient == null)
            {
                return NotFound("""Pacientul cu Id-ul {id} nu exista.""");
            }

            _context.Patients.Remove(dbPatient);
            await _context.SaveChangesAsync();

            return Ok(await _context.Patients.ToListAsync());
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> DeletePatient(int id , Patient patient) //soft delete
        {
            var dbPatient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
            if (dbPatient == null)
            {
                return NotFound("""Pacientul cu Id-ul {id} nu exista.""");
            }

            dbPatient.FirstName = patient.FirstName;
            dbPatient.LastName = patient.LastName;
            dbPatient.ParentsName = patient.ParentsName;
            dbPatient.BirthDate = patient.BirthDate;
            dbPatient.BloodGroup = patient.BloodGroup;
            //dbPatient.ChildOrAdult = patient.ChildOrAdult;
            dbPatient.Cnp = patient.Cnp;
            dbPatient.Cnascode = patient.Cnascode;
            dbPatient.Note = patient.Note;
            dbPatient.Sex = patient.Sex;
            // dbPatient.IsDeleted = true; // that's all

            await _context.SaveChangesAsync();

            return Ok(dbPatient);
        }

    }
}
