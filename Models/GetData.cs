using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace DBRegister.Models
{
    public class GetData
    {
        public int Id { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string Name { set; get; }
        public string Surname { set; get; }
        [DataType(DataType.Date)]
      
         public DateTime Birthday {set ; get ;}
    }
    public class GetData1
    {
 
        public string Email { set; get; }
        public string Name { set; get; }
        public string Surname { set; get; }
        [DataType(DataType.Date)]
         public DateTime Birthday {set ; get ;}
    }
    //แก้ไขชื่อแล้วบันทึกข้อมูล
      public class EditUserForDatabase
    {
 
        public int Id { set; get; }
        public string Name { set; get; }
        public string Surname { set; get; }
      
        
    }
    //รับค่าอัพโหลดไฟล์
    public class Upload{

    
        public IFormFile file { get; set; }
        public string Json { get; set; } = string.Empty;
  
    }

}
