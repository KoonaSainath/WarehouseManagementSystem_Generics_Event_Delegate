﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystemAPI.Interfaces
{
    public interface IWarehouseUnitAdvancedDetails
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
