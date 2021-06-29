using System;

namespace DBRegister.Models

{
    public static class DbInitializer
    {
        public static void Initialize(ReportContext db){
            // Console.Write(Create DataBase") ;
            db.Database.EnsureCreated();

        }
    }

}