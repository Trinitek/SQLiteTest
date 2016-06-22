using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLite_Test_2.Tables
{
    class People
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public Addresses Address { get; set; }
    }
}
