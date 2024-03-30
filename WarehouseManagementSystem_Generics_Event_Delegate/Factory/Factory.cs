using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem_Generics_Event_Delegate.Factory
{
    internal static class Factory<T, U> where U : class, T, new()
    {
        internal static T GetInstance()
        {
            T t;
            t = new U();
            return t;
        }
    }
}
