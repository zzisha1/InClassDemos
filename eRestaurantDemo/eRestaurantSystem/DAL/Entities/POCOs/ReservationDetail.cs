using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

namespace eRestaurantSystem.DAL.Entities.POCOs
{
    public class ReservationDetail
    {
        //Note ; No validation in these POCO classes /The validation is done in the entity
        
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        public int NumberInParty { get; set; }
        public string ContactPhone { get; set; }
        public string ReservationStatus { get; set; }

    }
}
