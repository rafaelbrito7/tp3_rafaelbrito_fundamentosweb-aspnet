using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tp3_rafaelbrito_fundamentosweb_aspnet.Models
{
    public class Person
    {
        public Person(int id, string firstName, string lastName, DateTime birthday)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            FullName = $"{FirstName} {LastName}";
        }

        public int Id { get; set; }
        [Required]
        [Display(Name = "Nome")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Aniversário")]
        public DateTime Birthday { get; set; }
        public string FullName { get; set; }
    }
}
