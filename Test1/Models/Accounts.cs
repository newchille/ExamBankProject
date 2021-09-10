using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Test1.Models
{
    public class Accounts
    {
        [Key]
        public Int64 id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string iban { get; set; }
        public decimal balance { get; set; }
    }
}
