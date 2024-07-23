using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Genre { get; set; }
        public string Country { get; set; }
    }
}