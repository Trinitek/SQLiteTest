using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite_Test_2.Tables;

namespace SQLite_Test_2
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLiteDatabase db = new SQLiteDatabase("test.db");

            /*People a = new People()
            {
                FirstName = "Jane",
                LastName = "Doe",
                Address = new Addresses()
                {
                    Address1 = "84 Pine Crescent",
                    City = "Newnan",
                    State = "GA",
                    Zip = "30265",
                }
            };

            db.Context.People.Add(a);
            db.Context.SaveChanges();*/

            var queryPeople = from person in db.Context.People
                              where person.LastName == "Doe"
                              select person;

            foreach(People person in queryPeople)
            {
                db.Context.Entry(person).Reference(p => p.Address).Load();
                Console.WriteLine(person.LastName + ", " + person.FirstName + " - " + person.Address.Address1);
            }

            Console.ReadKey();
        }
    }
}
