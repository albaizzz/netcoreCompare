using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Performancetest.netframework.Models.SQL
{
    [Table("Student")]
    public class StudentSQL
    {
        [Key]
        public int studentid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string IPAddress { get; set; }
    }
}