﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurantSystem.DAL.Entities.POCOs
{
    public class WaiterBilling
    {
        public string BillDate { get; set; }
        public string Name { get; set; }
        public int BillID { get; set; }
        public decimal BillTotal { get; set; }
        public int PartySize { get; set; }
        public string Contact { get; set; }
    }
}
