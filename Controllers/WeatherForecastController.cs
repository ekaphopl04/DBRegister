using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using DBRegister.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.Hosting;

namespace DBRegister.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DBRegisterController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<DBRegisterController> _logger;
        private readonly ReportContext _db ;
        private IWebHostEnvironment _hostingEnvironment;


        public DBRegisterController(ILogger<DBRegisterController> logger, ReportContext db,IWebHostEnvironment environment )
        {
            _logger = logger;
            _db = db ;
            _hostingEnvironment = environment;
        }
        [HttpPost]
        public ActionResult PostForDatabase(GetData Value){
            var UserCheck = _db.ReportTable.Where(x => x.Id == Value.Id).Select(x => x.Id).FirstOrDefault();
            var pwBase64 = System.Text.Encoding.UTF8.GetBytes(Value.Password);
            var pwBase = System.Convert.ToBase64String(pwBase64);
            if(UserCheck != Value.Id && Value.Name != null && Value.Surname != null){
                _db.ReportTable.Add(new Report{
                    Id = Value.Id,
                Email = Value.Email,
                Password = pwBase,
                Name = Value.Name,
                Surname = Value.Surname,
                Birthday = Value.Birthday,

                });
                _db.SaveChanges();
                return Ok();

            } else{
                return BadRequest();
            }


        }

        [HttpGet]
        public List<GetData> GetData()
        {
            var data = _db.ReportTable.Select(x => new GetData {
                
                Id = x.Id,
                Email = x.Email,
                Password = x.Password,
                Name = x.Name,
                Surname = x.Surname,
                Birthday = x.Birthday,
                //Date = DateTime.Now.AddDays(index),
            }).ToList();
            return data ;
        }
           [HttpGet]
        public List<GetData1> GetData1()
        {
            var data = _db.ReportTable.Select(x => new GetData1 {
                
                Email = x.Email,
                Name = x.Name,
                Surname = x.Surname,
                Birthday = x.Birthday,
               
                //Date = DateTime.Now.AddDays(index),
            }).ToList();
            return data ;
        }
        [HttpPut]

        public ActionResult EditUserForDatabase(EditUserForDatabase Value)
        {  
            var ChangeTarget = _db.ReportTable.FirstOrDefault(x => x.Id == Value.Id);
            if(ChangeTarget != null)
            {
                ChangeTarget.Name = Value.Name;
                ChangeTarget.Surname = Value.Surname;
                _db.ReportTable.Update(ChangeTarget);
                _db.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        
        }
        //อัพโหลดไฟล์
         [HttpPost]
         
    public async Task<IActionResult> Upload(IList<IFormFile> files) {
        
        string _hostingEnvironment = "/Users/bc-work/mywork/DBRegister";
        string uploads = Path.Combine(_hostingEnvironment, "uploads");
        Console.WriteLine(uploads);
        foreach (IFormFile file in files) {
            if (file.Length > 0) {
                uploads = "/Users/bc-work/mywork/DBRegister";
                string filePath = Path.Combine(uploads, file.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create)) {
                    await file.CopyToAsync(fileStream);
                }
            }
        }
        return Ok();
    }


        [HttpDelete]

        public ActionResult DeleteUserForDatabase(int Id)
        {
            var DeleteTarget = _db.ReportTable.FirstOrDefault(data => data.Id == Id);
            if(DeleteTarget != null)
            {
                _db.ReportTable.Remove(DeleteTarget);
                _db.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        
    }
}

