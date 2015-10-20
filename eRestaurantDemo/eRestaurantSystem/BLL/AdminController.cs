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
        #region Query Samples
        
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
                                Reservations = from row in item.Reservations //virtual property ......collection of navigated rows of ICollection in SpecialEvent
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

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<eRestaurantSystem.DAL.Entities.DTOs.CategoryMenuItems> CategoryMenuItems_List()
        {
            using (var context = new eRestaurantContext())
            {
                
                //Query syntax

                var result = from category in context.MenuCategories
                             orderby category.Description
                             select new eRestaurantSystem.DAL.Entities.DTOs.CategoryMenuItems() //DTO
                             {
                                 Description = category.Description,
                                 MenuItems = from row in category.MenuItems //virtual property ......collection of navigated rows of ICollection in SpecialEvent
                                                select new MenuItem() //POCO
                                                {
                                                    Description = row.Description,
                                                    Price = row.CurrentPrice,
                                                    Calories = row.Calories,
                                                    Comment = row.Comment
                                                }

                             };
                return result.ToList();
            }
        }
        #endregion

        #region CRUD Insert, Update , Delete
        [DataObjectMethod(DataObjectMethodType.Insert, false)] //let the user slect to slelect method
        public void SpecialEvents_Add(SpecialEvent item)
        {
            //input into this method at the instance level
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //create a pointer variable for the instance type
                //set this pointer to null
                SpecialEvent added = null;
                //setup the add request for the dbcontext
                added = context.SpecialEvents.Add(item);

                //saving the changes will cause the .Add to execute

                //commits the Add to database
                //evaluates the annotation (validation) on your entity
                context.SaveChanges();



            }

            
        }

        [DataObjectMethod(DataObjectMethodType.Update,false)]
        public void SpecialEvents_Update(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                context.Entry<SpecialEvent>(context.SpecialEvents.Attach(item)).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void SpecialEvent_Delete(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //lookup the item instance to determine if the instance exists
                SpecialEvent existing = context.SpecialEvents.Find(item.EventCode);
                //setup the delete request command
                context.SpecialEvents.Remove(existing);
                //commit the action to happen.
                context.SaveChanges();

            }

        }
        
        
        //waiter CRUD

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Waiter> Waiter_List()
        {
            using (var context = new eRestaurantContext())
            {
                //retrieve the data from the specialEvent table
                //to do so we will use the DBset in eRestaurantContext 
                //call SoecialEvents (done by mapping)

                //method syntax
                //return context.SpecialEvents.OrderBy(x => x.Description).ToList();

                //query syntax 
                var results = from item in context.Waiters
                              orderby item.FirstName, item.LastName
                              select item;
                return results.ToList();

            }
        }

        public int Waiters_Add(Waiter item)
        {
            //input into this method at the instance level
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //create a pointer variable for the instance type
                //set this pointer to null
                Waiter added = null;
                //setup the add request for the dbcontext
                added = context.Waiters.Add(item);

                //saving the changes will cause the .Add to execute

                //commits the Add to database
                //evaluates the annotation (validation) on your entity
                context.SaveChanges();

                //added contains the data of the newly added waiter including the Pkey value
                return added.WaiterID;

            }


        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void Waiters_Update(Waiter item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                context.Entry<Waiter>(context.Waiters.Attach(item)).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void Waiters_Delete(Waiter item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //lookup the item instance to determine if the instance exists
                Waiter existing = context.Waiters.Find(item.WaiterID);
                //setup the delete request command
                context.Waiters.Remove(existing);
                //commit the action to happen.
                context.SaveChanges();

            }

        }

         [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public Waiter GetWaiterByID(int waiterId)
        {
            using (var context = new eRestaurantContext())
            {
                //retrieve the data from the specialEvent table
                //to do so we will use the DBset in eRestaurantContext 
                //call SoecialEvents (done by mapping)

                //method syntax
                //return context.SpecialEvents.OrderBy(x => x.Description).ToList();

                //query syntax 
                var results = from item in context.Waiters
                              where item.WaiterID == waiterId 
                              select item;
                return results.FirstOrDefault();

            }
        }

        

         [DataObjectMethod(DataObjectMethodType.Select, false)]
         public List<eRestaurantSystem.DAL.Entities.POCOs.CategoryMenuItems> GetReportCategoryMenuItems()
         {
             using (eRestaurantContext context = new eRestaurantContext())
             {
                 var results = from cat in context.Items
                               orderby cat.Category.Description, cat.Description
                               select new eRestaurantSystem.DAL.Entities.POCOs.CategoryMenuItems
                               {
                                   CategoryDescription = cat.Category.Description,
                                   ItemDescription = cat.Description,
                                   Price = cat.CurrentPrice,
                                   Calories = cat.Calories,
                                   Comment = cat.Comment
                               };

                 return results.ToList(); // this was .Dump() in Linqpad
             }
         }
        #endregion


    } //eof class
} //eof namespace
