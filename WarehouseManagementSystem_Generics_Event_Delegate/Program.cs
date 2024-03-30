using System.Globalization;
using WarehouseManagementSystem_Generics_Event_Delegate.Enums;
using WarehouseManagementSystem_Generics_Event_Delegate.Factory;
using WarehouseManagementSystem_Generics_Event_Delegate.WarehouseClasses;
using WarehouseManagementSystemAPI;

namespace WarehouseManagementSystem_Generic_Event_Delegate;
public class Program
{
    public static void Main(string[] args)
    {
        List<WarehouseUnit> warehouseUnits = new List<WarehouseUnit>();

        //Creating list of imaginary warehouse units
        GetWarehouseUnits(warehouseUnits);

        WarehouseQueue<WarehouseUnit> warehouseQueue = new WarehouseQueue<WarehouseUnit>();
        warehouseQueue.eventQueueChanged += WarehouseQueue_eventQueueChanged;

        foreach(WarehouseUnit warehouseUnit in warehouseUnits)
        {
            //Raises event as queue content changes. WarehouseQueue_eventQueueChanged method gets invoked with relevant message in "eventData" object
            warehouseQueue.AddUnit(warehouseUnit);
            Thread.Sleep(3000);
        }

        foreach(WarehouseUnit warehouseUnit in warehouseUnits)
        {
            //Raises event as queue content changes. WarehouseQueue_eventQueueChanged method gets invoked with relevant message in "eventData" object
            WarehouseUnit placedUnit = warehouseQueue.GetNextUnit();
            Thread.Sleep(2000);
        }
    }

    private static void WarehouseQueue_eventQueueChanged(WarehouseQueue<WarehouseUnit> sender, EventData eventData)
    {
        Console.Clear();
    }

    //Creates various types of instances of warehouse units and adds them to main list
    internal static void GetWarehouseUnits(List<WarehouseUnit> warehouseUnits)
    {
        WarehouseUnit motor1 = GetWarehouseUnitInstance(Unit.Motor, 1, "Motor1", "Motor", 10, 200);
        WarehouseUnit motor2 = GetWarehouseUnitInstance(Unit.Motor, 1, "Motor2", "Motor", 20, 300);
        WarehouseUnit motor3 = GetWarehouseUnitInstance(Unit.Motor, 1, "Motor3", "Motor", 30, 400);
        WarehouseUnit hammer1 = GetWarehouseUnitInstance(Unit.Motor, 1, "Hammer1", "Hammer", 20, 200);
        WarehouseUnit hammer2 = GetWarehouseUnitInstance(Unit.Motor, 1, "Hammer2", "Hammer", 30, 300);
        WarehouseUnit hammer3 = GetWarehouseUnitInstance(Unit.Motor, 1, "Hammer3", "Hammer", 40, 400);
        WarehouseUnit weldingMachine1 = GetWarehouseUnitInstance(Unit.Motor, 1, "WeldingMachine1", "WeldingMachine", 10, 200);
        WarehouseUnit weldingMachine2 = GetWarehouseUnitInstance(Unit.Motor, 1, "WeldingMachine2", "WeldingMachine", 15, 250);
        WarehouseUnit weldingMachine3 = GetWarehouseUnitInstance(Unit.Motor, 1, "WeldingMachine3", "WeldingMachine", 20, 300);

        warehouseUnits.Add(motor1);
        warehouseUnits.Add(motor2);
        warehouseUnits.Add(motor3);
        warehouseUnits.Add(hammer1);
        warehouseUnits.Add(hammer2);
        warehouseUnits.Add(hammer3);
        warehouseUnits.Add(weldingMachine1);
        warehouseUnits.Add(weldingMachine2);
        warehouseUnits.Add(weldingMachine3);

    }

    //Creates one warehouse unit instance based on type of unit
    internal static WarehouseUnit GetWarehouseUnitInstance(Unit unit, int id, string name, string type, int quantity, double price)
    {
        WarehouseUnit warehouseUnit = null;
        switch (unit)
        {
            case Unit.Motor:
                warehouseUnit = Factory<WarehouseUnit, Motor>.GetInstance();
                break;
            case Unit.Hammer:
                warehouseUnit = Factory<WarehouseUnit, Hammer>.GetInstance();
                break;
            case Unit.WeldingMachine:
                warehouseUnit = Factory<WarehouseUnit, WeldingMachine>.GetInstance();
                break;
            default:
                break;
        }
        if(warehouseUnit != null)
        {
            warehouseUnit.Id = id;
            warehouseUnit.Name = name;
            warehouseUnit.Type = type;
            warehouseUnit.Quantity = quantity;
            warehouseUnit.Price = price;
        }
        return warehouseUnit;
    }
}