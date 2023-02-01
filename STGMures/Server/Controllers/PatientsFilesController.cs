using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StgMures.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsFilesController : ControllerBase
    {
        private readonly StgMuresContext _context;

        public PatientsFilesController(StgMuresContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatientFiles()
        {
            var ret = await _context.PatientFiles.ToListAsync();
            return Ok(ret);
        }

        [HttpPost]
        public async Task<IActionResult> AddPatientFiles(PatientFile patientFile)
        {
            _context.PatientFiles.Add(patientFile);
            await _context.SaveChangesAsync();
            return Ok(await _context.PatientFiles.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatientFiles(int id, PatientFile patientFile)
        {
            var dbPatient = await _context.PatientFiles.FirstOrDefaultAsync(p => p.Id == id);
            if (dbPatient == null)
            {
                return NotFound("""Pacientul cu Id-ul {id} nu exista.""");
            }

            dbPatient.PatientId= patientFile.PatientId;
            dbPatient.FileNumber= patientFile.FileNumber;
            dbPatient.FileDate= patientFile.FileDate;
            dbPatient.HospitalAdmissionDate= patientFile.HospitalAdmissionDate;
            dbPatient.AtiTakeOverDate= patientFile.AtiTakeOverDate;
            dbPatient.AtiRetakeOverDate = patientFile.AtiRetakeOverDate;
            dbPatient.Weight= patientFile.Weight;
            dbPatient.Height = patientFile.Height;
            dbPatient.Bmi= patientFile.Bmi;
            dbPatient.Bsa = patientFile.Bsa;
            dbPatient.AnotherHospitalAdmission = patientFile.AnotherHospitalAdmission;
            dbPatient.WardTransferDate = patientFile.WardTransferDate;
            dbPatient.DischargeDate = patientFile.DischargeDate;
            dbPatient.WardDays = patientFile.WardDays;
            dbPatient.Atidays= patientFile.Atidays;
            dbPatient.WardRetransferDate = patientFile.WardRetransferDate;

            await _context.SaveChangesAsync();

            return Ok(dbPatient);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ForceDeletePatient(int id)
        {
            var dbPatient = await _context.PatientFiles.FirstOrDefaultAsync(p => p.Id == id);
            if (dbPatient == null)
            {
                return NotFound("""Pacientul cu Id-ul {id} nu exista.""");
            }

            _context.PatientFiles.Remove(dbPatient);
            await _context.SaveChangesAsync();

            return Ok(await _context.PatientFiles.ToListAsync());
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> DeletePatient(int id, PatientFile patientFile) //soft delete
        {
            var dbPatient = await _context.PatientFiles.FirstOrDefaultAsync(p => p.Id == id);
            if (dbPatient == null)
            {
                return NotFound("""Pacientul cu Id-ul {id} nu exista.""");
            }

            dbPatient.PatientId = patientFile.PatientId;
            dbPatient.FileNumber = patientFile.FileNumber;
            dbPatient.FileDate = patientFile.FileDate;
            dbPatient.HospitalAdmissionDate = patientFile.HospitalAdmissionDate;
            dbPatient.AtiTakeOverDate = patientFile.AtiTakeOverDate;
            dbPatient.AtiRetakeOverDate = patientFile.AtiRetakeOverDate;
            dbPatient.Weight = patientFile.Weight;
            dbPatient.Height = patientFile.Height;
            dbPatient.Bmi = patientFile.Bmi;
            dbPatient.Bsa = patientFile.Bsa;
            dbPatient.AnotherHospitalAdmission = patientFile.AnotherHospitalAdmission;
            dbPatient.WardTransferDate = patientFile.WardTransferDate;
            dbPatient.DischargeDate = patientFile.DischargeDate;
            dbPatient.WardDays = patientFile.WardDays;
            dbPatient.Atidays = patientFile.Atidays;
            dbPatient.WardRetransferDate = patientFile.WardRetransferDate;
            // dbPatient.IsDeleted = true; // that's all

            await _context.SaveChangesAsync();

            return Ok(dbPatient);
        }
    }
}
