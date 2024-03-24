using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystemAPI
{
    /*
     * The class WarehouseQueue is used by console application to add/get units from the actual queue "warehouseQueue".
     * T is the type parameter, which acts as a placeholder for whatever type of data we want our queue to hold for a particular instance created.
     */
    public class WarehouseQueue<T>
    {
        private Queue<T> warehouseQueue = null;

        public WarehouseQueue()
        {
            this.warehouseQueue = new Queue<T>();
        }

        /*
         * Adding the warehouse unit to the actual queue.
         * Observe that, with this method call, the content of "warehouseQueue" is getting changed, hence we've to fire an event.
         */
        public void AddUnit(T unit)
        {
            this.warehouseQueue.Enqueue(unit);
        }

        /*
         * Deletes the first unit of the queue and returns the instance of same unit.
         * Observe that, with this method call, the content of "warehouseQueue" is getting changed, hence we've to fire an event.
         */
        public T GetNextUnit()
        {
            T nextUnit = this.warehouseQueue.Dequeue();
            return nextUnit;
        }
    }
}
