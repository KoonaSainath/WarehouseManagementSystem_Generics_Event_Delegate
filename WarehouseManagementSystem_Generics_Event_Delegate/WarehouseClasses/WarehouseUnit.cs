using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystemAPI.Interfaces;

namespace WarehouseManagementSystem_Generics_Event_Delegate.WarehouseClasses
{
    /*
     * Making the WarehouseUnit class abstract to restrict object creation as we only allow objects of specific unit which inherits WarehouseUnit class
     */
    internal abstract class WarehouseUnit : IWarehouseUnitBasicDetails, IWarehouseUnitAdvancedDetails
    {
        public int Id { get ; set; }
        public string Name { get ; set; }
        public string Type { get ; set; }
        public int Quantity { get ; set; }
        public double Price { get ; set; }
    }
}
