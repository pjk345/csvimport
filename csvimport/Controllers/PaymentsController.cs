//using CoreWithCSVHelper.Models;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
//using CoreExcelSaveAndRead.Models;
using System.Collections.Generic;
using System.Globalization;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


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
        public IActionResult Index(List<Payments> payments = null)
        {
            payments = payments == null ? new List<Payments>() : payments;
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormFile file )
        {
            #region UploadCSV
            string fileName = $"{_hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            #endregion

            var payments = this.GetPaymentsList(file.FileName);
            return View(payments);
        }
        private List<Payments> GetPaymentsList(string fileName) 
        {
            List<Payments> payments = new List<Payments>();



            #region ReadCSV
            var path = $"{ Directory.GetCurrentDirectory()}{@"\wwwroot\files" }" +"\\" + fileName;
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null,
                Delimiter = ";"
            };
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader,CultureInfo.InvariantCulture))
            {

                csv.Read();
                csv.ReadHeader();
                

                while (csv.Read()) 
                {
                    var payment = csv.GetRecord<Payments>();
                    payments.Add(payment);
                }
            }
            #endregion


                return payments;
        }
    }
}
