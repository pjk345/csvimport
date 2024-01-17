//using CoreWithCSVHelper.Models;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace csvimport.Controllers
{
    public class PaymentsController : Controller
    {
        [HttpGet]
        public IActionResult Index(List<Payments> payments = null)
        {
            payments = payments == null ? new List<Payments>() : payments;
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormFile file, [FromServices] IHostingEnvironment hostingEnvironment)
        {
            #region UploadCSV
            string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            #endregion

            var payments = this.GetPaymentsList(file.FileName);
            return Index(payments);
        }
        private List<Payments> GetPaymentsList(string fileName) 
        {
            List<Payments> payments = new List<Payments>();

            #region ReadCSV
            var path = $"{ Directory.GetCurrentDirectory()}{@"\wwwroot\files" }" +"\\" + fileName;
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
