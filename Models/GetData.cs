using System;
using System.ComponentModel.DataAnnotations;

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


}
