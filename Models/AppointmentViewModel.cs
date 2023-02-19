using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InfiniteHealthCare.Models
{
    public class AppointmentViewModel
    {



        //public int Id { get; set; }

        //[Required(ErrorMessage = "Plese  enter Patient Name")]
        //[Display(Name = "Patient Name")]

        //public string PatientName { get; set; }

        //[Required(ErrorMessage = "Plese enter Gender (Male-Female-Others)")]

        //public string Gender { get; set; }

        //[Required(ErrorMessage = "Plese enter the Age")]

        //public int Age { get; set; }

        //[Required(ErrorMessage = "Plese enter the Appointment Date")]
        //[Display(Name = "Appointment Date")]
        //public DateTime AppointmentDate { get; set; }

        //[Required(ErrorMessage = "Plese provide the Specialization Of Doctor")]
        //[Display(Name = "Specialization Of Doctor")]
        //public string SpecializationOfDoctor { get; set; }

        //[Required(ErrorMessage = "Plese provide the Time ")]
        //[Display(Name = "Time ")]
        //public DateTime Time { get; set; }


        //[Required(ErrorMessage = "Plese provide the Doctor Name")]
        //[Display(Name = "Doctor Name")]

        //public string DoctorName { get; set; }


        public int id { get; set; }

       

        public int Patientid { get; set; }


        public int Doctorid { get; set; }

        public string PatientName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string Problem { get; set; }

        public string specilization { get; set; }


    }
}
