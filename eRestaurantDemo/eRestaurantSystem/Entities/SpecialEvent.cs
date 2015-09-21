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
    public class SpecialEvent
    {
        [Key]

        //all validation goes before 

        [Required(ErrorMessage = "An event code is required(only one character)")]
        [StringLength(1,ErrorMessage="Event code can only use a single character code")]
        
        public string EventCode { get; set; }
        
        /// 
        
        [Required(ErrorMessage="Desccription is required (5-30 characters)")]
        [StringLength(30, MinimumLength=5, ErrorMessage="Description must be 5-30 characters in length")]

        public string Description { get; set; }

        //all classes can have their own constructor
        //constructors can contain initialization values
        
        public SpecialEvent()
        {
            Active = true;

        }
        public bool Active { get; set; }

        //navigation virtual property (s)

        public virtual ICollection<Reservation> Reservation { get; set; }

    }
}
