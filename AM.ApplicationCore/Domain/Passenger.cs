using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.APPCORE.domain
{


    public class Passenger
    {
        [DataType(DataType.DateTime)]
        [Display(Name = "Date of Birth")]

        public virtual ICollection<Ticket> tickets { get; set; }
        public DateTime BirthDate { get; set; }
        [Key]
        [StringLength(7, ErrorMessage = "Must be 7")]
        public string PassportNumber { get; set; }
        [EmailAddress(ErrorMessage = "Email must be valid")]
        public string EmailAddress { get; set; }
        [RegularExpression(@"^\d{8}$", ErrorMessage = "Phone number must contain exactly 8 digits")]
        public string TellNumber { get; set; }
        public int Id { get; set; }
        
        public string LastName { get; set; }
        [MinLength(3, ErrorMessage = "First name must contain at least 3 characters")]
        [MaxLength(25, ErrorMessage = "First name cannot exceed 25 characters")]
        public string FirstName { get; set; }
        public Passenger()
        {
            flights = new List<Flight>();
        }


        public ICollection<Flight> flights { get; set; }

        public override string ToString()
        {
            return " First name:" + FirstName
                + " , Last name :" + LastName;
        }
        //Polymorphisme par Signature
        //1.a 
        public bool CheckProfile(string nom, string prenom)
        {
            return LastName == nom && FirstName == prenom;
        }
        //1.b
        public bool CheckProfile(string nom, string prenom, string mail)
        {
            return LastName == nom && FirstName == prenom && EmailAddress.Equals(mail);
        }
        //1.c
        public bool Login(string nom, string prenom, string mail = null)
        {
            if (mail == null)
                return LastName == nom && FirstName == prenom;

            return LastName == nom && FirstName == prenom && EmailAddress.Equals(mail);
        }
        //
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }


    }
}
