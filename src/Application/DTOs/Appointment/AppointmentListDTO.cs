using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ClinAgenda.src.Application.DTOs.Appointment
{
    public class AppointmentListDTO
    {
        public int Id { get; set; }
        public required string patientName { get; set; }
        public required string doctorName { get; set; }
        public required int SpecialtyId { get; set; }        
    }
}