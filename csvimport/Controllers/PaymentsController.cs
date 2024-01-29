using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using csvimport.Models;

namespace csvimport.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PaymentsController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index(List<Payments> payments)
        {
            return View(payments);
        }

        [HttpPost]
        public IActionResult Index(IFormFile file)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine,
                Delimiter = ";"
            };

            var paymentsRecord = ReadRaportFile(file, config);

            return View(paymentsRecord);
        }

        public List<Payments> ReadRaportFile(IFormFile file, CsvConfiguration config)
        {
            var result = new List<Payments>();

            using (var reader = new StreamReader(file.OpenReadStream()))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<ModelMap>();
                var records = csv.GetRecords<Payments>();
                result = records.ToList();
            }

            return result;
        }

        private List<Payments> GetPaymentsList(string fileName)
        {
            List<Payments> payments = new List<Payments>();

            var path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fileName;

           
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null,
                Delimiter = ";"
            };

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Read();
                csv.ReadHeader();

                while (csv.Read())
                {
                    var payment = csv.GetRecord<Payments>();
                    payments.Add(payment);
                }
            }

            return payments;
        }
    }
}
