using AM.APPCORE.domain;
using AM.APPCORE.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain

{

    public class Plane
    {
        public Plane() { }
        public Plane(int capacity, int planeId, DateTime manufactureDate, PlaneType planeType)
        {

            this.capacity = capacity;
            PlaneId = planeId;
            ManufactureDate = manufactureDate;
            PlaneType = planeType;
             flights = new List<Flight>(); // IMPORTANT: Initialiser la collection
        }

        //version light : prop +tab
        [Range(0, int.MaxValue, ErrorMessage = "Capacity must be a positive number")]

        public int capacity { get; set; }
        public int PlaneId { get; set; }
        [DataType(DataType.Date)]
        public DateTime ManufactureDate { get; set; }
        
        public PlaneType PlaneType { get; set; }
        public virtual ICollection<Flight> flights { get; set; }

        public override string ToString()
        {
            return " Plan type: " + PlaneType
                + " ,capacity : " + capacity
                + " ,ManufactureDate:  " + ManufactureDate
                ;
        }








        //secure propg +tab
        // public int MyProperty { get; private set; }
        //version full : propfull+tab

        /*  private int myVar;

          public int Full1
          {
              get { return myVar; }
              set { myVar = value; }
          } */



    }
}
