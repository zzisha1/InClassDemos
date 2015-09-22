using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using eRestaurantSystem.DAL.Entities;
using eRestaurantSystem.DAL;
using System.ComponentModel; //used for ODS access

    
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
                return context.SpecialEvents.OrderBy(x => x.Description).ToList();



            }
        }
    }
}
