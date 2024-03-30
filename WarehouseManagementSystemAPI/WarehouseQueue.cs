using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystemAPI
{
    //This delegate is used as event type. Basically we are creating a custom event using delegate concept.
    public delegate void QueueChangedDelegate<T, U>(T sender, U eventData);
    /*
     * The class WarehouseQueue is used by console application to add/get units from the actual queue "warehouseQueue".
     * T is the type parameter, which acts as a placeholder for whatever type of data we want our queue to hold for a particular instance created.
     */
    public class WarehouseQueue<T>
    {
        private Queue<T> warehouseQueue = null;

        //Event declaration using delegate we declared outside this class.
        public event QueueChangedDelegate<WarehouseQueue<T>, EventData> eventQueueChanged;
        public WarehouseQueue()
        {
            this.warehouseQueue = new Queue<T>();
        }

        /*
         * Public property to directly provide length of queue
         */
        public int NumberOfUnits
        {
            get
            {
                return this.warehouseQueue.Count;
            }
        }

        /*
         * Public property to return new Enumerator object of warehouseQueue to calling code.
         */
        public IEnumerator<T> WarehouseQueueEnumerator
        {
            get
            {
                return this.warehouseQueue.GetEnumerator();
            }
        }

        /*
         * Adding the warehouse unit to the actual queue.
         * Observe that, with this method call, the content of "warehouseQueue" is getting changed, hence we've to fire an event.
         */
        public void AddUnit(T unit)
        {
            this.warehouseQueue.Enqueue(unit);

            //Fire the event to print current warehouse unit message (entered the warehouse) and overall table of units as queue content has changed
            FireOnQueueChanged(unit);
        }

        /*
         * Deletes the first unit of the queue and returns the instance of same unit.
         * Observe that, with this method call, the content of "warehouseQueue" is getting changed, hence we've to fire an event.
         */
        public T GetNextUnit()
        {
            T nextUnit = this.warehouseQueue.Dequeue();

            //Fire the event to print current warehouse unit message (placed in warehouse) and overall table of units as queue content has changed.
            FireOnQueueChanged(nextUnit);
            return nextUnit;
        }

        /*
         * Common method to fire the event 
         */
        public void FireOnQueueChanged(T unit)
        {
            //The eventQueueChanged gets an object if it is subscribed anywhere
            if(this.eventQueueChanged != null)
            {
                EventData eventData = new EventData();
                eventData.Message = string.Empty;
                this.eventQueueChanged(this, eventData);
            }
        }
    }

    /*
     * Inheriting the C# provided EventArgs class to be used as communication object between sender and receiver of events
     */
    public class EventData : EventArgs
    {
        public string Message { get; set; }
    }
}
