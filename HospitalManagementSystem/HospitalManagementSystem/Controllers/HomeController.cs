using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace HospitalManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ViewResult Doctors(Doctor d , int page=1)
        {
            
            var DoctorsDb = _context.Doctors.AsQueryable();
            
            if (d.Name != null)
            DoctorsDb = DoctorsDb.Where(i => i.Name.Contains(d.Name));
            if(d.SpecializationId>0)
            DoctorsDb = DoctorsDb.Where(i => i.SpecializationId == d.SpecializationId);
            DoctorsDb = DoctorsDb.Include(i => i.Specialization);
            ViewBag.TotalPages = Math.Ceiling(DoctorsDb.Count() / 6.0);
            ViewBag.CurrentPage = page;
            DoctorsDb = DoctorsDb.Skip((page - 1) * 6).Take(6);
            return View(new DoctorsVM() { Doctors = DoctorsDb.AsEnumerable() ,Specializations = _context.Specializations.AsEnumerable() });
        }

        public ViewResult MakeApp(Appointment appointment, bool IsSubmit)
        {
            if(IsSubmit)
            {
                if (appointment.PatientName != null && !appointment.Date.Equals(new DateOnly(1,1,1)) && !appointment.Time.Equals(new TimeOnly(0,0)))
                {
                    var CheckApp = _context.Appointments.Where(a => a.DoctorId == appointment.DoctorId && a.Time.Equals(appointment.Time) && a.Date.Equals(appointment.Date));
                    if(CheckApp.IsNullOrEmpty())
                    {
                        _context.Appointments.Add(appointment);
                        _context.SaveChanges();
                        return View(new MakeAppVM { DoctorId = appointment.DoctorId, IsValid = true, IsSubmit = true });
                    }
                    else
                    {
                        return View(new MakeAppVM { DoctorId = appointment.DoctorId, IsValid = false, IsSubmit = true, ErrMessage = "Sorry this slot is reserved"});

                    }
                }
                else
                {
                    return View(new MakeAppVM { DoctorId = appointment.DoctorId, IsValid = false , IsSubmit=true , ErrMessage="Error in inputs"});
                }
            }
            
            
            return View(new MakeAppVM { DoctorId = appointment.DoctorId , IsValid = true,IsSubmit=false});
        }

        public ViewResult ShowApp()
        {
            var Appointments = _context.Appointments.AsQueryable();
            Appointments = Appointments.Include(p => p.Doctor).Include(p => p.Doctor.Specialization);
            List<AppVM> apps = new List<AppVM>();
            foreach (var item in Appointments)
            {
                AppVM appvm = new AppVM
                {
                    AppId = item.Id,
                    PatientName = item.PatientName,
                    DoctorName = item.Doctor.Name,
                    SpecializationName = item.Doctor.Specialization.Name,
                    Date = item.Date,
                    Time = item.Time
                };

                apps.Add(appvm);

            }

            return View(apps);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
