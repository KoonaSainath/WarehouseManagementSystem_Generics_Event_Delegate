﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystemAPI.Interfaces
{
    public interface IWarehouseUnitBasicDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

    }
}
