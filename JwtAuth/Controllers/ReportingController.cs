using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace JwtAuth.Controllers
{
    public class ReportingController : Controller
    {
        public IActionResult Report()
        {
            //List<Employee> employees =new List<Employee>();
            //for (int i = 1; i <= 15; i++)
            //{
            //    Employee employee = new Employee
            //    {
            //        Id = i,
            //        Name = $"Korim {i.ToString()}",
            //        Email = $"{i.ToString()}_email@gmail.com",
            //        Address = $"{i.ToString()}, Dhaka, bangladesh",
            //        Mobile = $"0182066723{i.ToString()}",
            //        DateOfBirth = DateTime.Today.AddDays(i),
            //        JoiningDate = DateTime.Today.AddDays(i),
            //    };
            //    employees.Add(employee);
            //}
            return View();
        }
        public IActionResult ReportPdf()
        {
            try
            {
                //List<Employee> employees = new List<Employee>();
                //for (int i = 1; i <= 15; i++)
                //{
                //    Employee employee = new Employee
                //    {
                //        Id = i,
                //        Name = $"Korim{i.ToString()}",
                //        Email = $"{i.ToString()}email@gmail.com",
                //        Address = $"{i.ToString()}, Dhaka, bangladesh",
                //        Mobile = $"0182066723{i.ToString()}",
                //        DateOfBirth = DateTime.Today.AddDays(i),
                //        JoiningDate = DateTime.Today.AddDays(i),
                //    };
                //    employees.Add(employee);
                //}
                var report = new ViewAsPdf("Report")
                {
                    FileName = "Invoice.pdf"
                };
                return report;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
