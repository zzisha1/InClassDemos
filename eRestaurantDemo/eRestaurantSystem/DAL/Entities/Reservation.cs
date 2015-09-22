using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
#endregion

namespace eRestaurantSystem.DAL.Entities
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }
        [Required]
        [StringLength(40)]
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        

        [Range(1,16,ErrorMessage="Party size is limited to 1 - 16")]
        public int NumberInParty { get; set; }

        [StringLength(15)]

        public int ContactPhone { get; set; }
        
        [Required, StringLength(1, MinimumLength=1)]
        public string ReservationStatus { get; set; }

        [StringLength(1)]
        public string EventCode { get; set; }

        //Navigation Ptoperties
        public virtual SpecialEvent Event { get; set; }

        //the reservation table is 'many to many' relationship to tables table
        //the SQL ReservationTable resolves this problem however ReseravtionTable holds only a compound primary key
        //We will not create a SQL ReservationTable entity in our project but handle it via navigation mapping therefore we will place a ICollection properties in this entity refering to the table Tables

        public virtual ICollection<Table> Tables { get; set; }
    }
}
