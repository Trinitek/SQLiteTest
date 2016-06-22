using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Reflection;

namespace SQLite_Test_2
{
    class SQLiteDatabase
    {
        public SQLiteConnection Connection { get; }
        public Context Context { get; }

        public SQLiteDatabase(string uri)
        {
            this.Connection = new SQLiteConnection("Data Source=" + uri);
            this.Connection.Open();

            CreateTables();

            this.Context = new Context(this.Connection);
        }

        private void CreateTables()
        {
            string[] filenames =
            {
                "CreateAddresses.sql",
                "CreatePeople.sql"
            };

            Assembly assembly = Assembly.GetExecutingAssembly();

            foreach (string filename in filenames)
            {
                using (Stream stream = assembly.GetManifestResourceStream("SQLite_Test_2.Tables.SQL." + filename))
                using (StreamReader reader = new StreamReader(stream))
                using (SQLiteCommand command = new SQLiteCommand(reader.ReadToEnd(), this.Connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
