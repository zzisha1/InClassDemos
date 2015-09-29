using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using eRestaurantSystem.DAL.Entities;
using eRestaurantSystem.DAL;
using System.ComponentModel;
using eRestaurantSystem.DAL.Entities.DTOs;
using eRestaurantSystem.DAL.Entities.POCOs; //used for ODS access

    
#endregion

namespace eRestaurantSystem.BLL
{
    [DataObject]
    public class AdminController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<SpecialEvent>SpecialEvent_List()
        {
            using (var context = new eRestaurantContext())
            {
                //retrieve the data from the specialEvent table
                //to do so we will use the DBset in eRestaurantContext 
                //call SoecialEvents (done by mapping)

                //method syntax
                //return context.SpecialEvents.OrderBy(x => x.Description).ToList();

                //query syntax 
                var results = from item in context.SpecialEvents
                              orderby item.Description
                              select item;
                return results.ToList();

            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]

        public List<Reservation> GetReservationsByEventCode(string eventcode)
        {
            using (var context = new eRestaurantContext())
            {
                
                    //query syntax 
                var results = from item in context.Reservations
                              where item.EventCode.Equals(eventcode)
                              orderby item.CustomerName, item.ReservationDate
                              select item;
                return results.ToList();





            }
        }

        [DataObjectMethod (DataObjectMethodType.Select,false)]
        public List<ReservationByDate> GetReservationsByDate(string ReservationDate)
        {
            using (var context = new eRestaurantContext())
            {
                //remember LINQ does not like using DateTime casting 
                int theYear = (DateTime.Parse(ReservationDate)).Year;
                int theMonth = (DateTime.Parse(ReservationDate)).Month;
                int theDay = (DateTime.Parse(ReservationDate)).Day;

                //Query syntax

                var result = from item in context.SpecialEvents
                             orderby item.Description
                             select new ReservationByDate() //DTO
                            {
                                Description = item.Description,
                                Reservation = from row in item.Reservations //virtual property ......collection of navigated rows of ICollection in SpecialEvent
                                               where row.ReservationDate.Year == theYear
                                               && row.ReservationDate.Month == theMonth
                                               && row.ReservationDate.Day == theDay

                                               select new ReservationDetail() //POCO
                                               { 
                                                    CustomerName = row.CustomerName,
                                                    ReservationDate = row.ReservationDate,
                                                    NumberInParty = row.NumberInParty,
                                                    ContactPhone = row.ContactPhone,
                                                    ReservationStatus = row.ReservationStatus
                                               }

                            };
                return result.ToList();
            }
        }
    }
}
