using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.APPCORE.domain
{
    public class Staff : Passenger
    {
        
        public DateTime EmploymentDate { get; set; }
      
        public string Function { get; set; }
        [DataType(DataType.Currency)]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive value")]
        public double Salary { get; set; }
        public override void PassengerType()
        {
            //base kaynha super
            base.PassengerType();
            Console.WriteLine("I am a staff member");
        }
    }
}
