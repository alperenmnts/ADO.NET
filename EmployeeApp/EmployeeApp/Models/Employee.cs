using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "İsim giriniz!")]
        public string EmpName { get; set; }
        [Required(ErrorMessage = "Soyisim giriniz!")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "TC kimlik numarasını giriniz!")]
        public byte Kimlik { get; set; }
        [Required(ErrorMessage = "Departman adını giriniz!")]
        public string Departman { get; set; }
        public DateTime Date { get; set; }
    }
}