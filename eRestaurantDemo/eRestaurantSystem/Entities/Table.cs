using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
#endregion

namespace eRestaurantSystem.Entities
{
    public class Table
    {
        [Key]
        public int TableID { get; set; }


        [Required,Range(1,25)]
        public byte TableNumber { get; set; }
        public bool Smoking { get; set; }
        public int Capacity { get; set; }
        public bool Available { get; set; }


        //Navigation property
        //the reservation table is 'many to many' relationship to tables table
        //the SQL ReservationTable resolves this problem however ReseravtionTable holds only a compound primary key
        //We will not create a SQL ReservationTable entity in our project but handle it via navigation mapping therefore we will place a ICollection properties in this entity refering to the table Reservations

        public virtual ICollection<Reservation> Reservation { get; set; }
        public Table()
        {
            Available = true;
        }
    }
}
