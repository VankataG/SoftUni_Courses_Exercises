using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRacing
{
     class Car
     {
         public void Drive(double distance)
         {
             if (FuelAmount >= distance * FuelConsumptionPerKilometer)
             {
                 FuelAmount -= distance * FuelConsumptionPerKilometer;
                 TravelledDistance += distance;
             }
             else
             {
                Console.WriteLine("Insufficient fuel for the drive");
             }
         }
         public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
         {
             Model = model;
             FuelAmount = fuelAmount;
             FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
             TravelledDistance = 0;
         }
         public string Model { get; set; }
         public double FuelAmount { get; set; }
         public double FuelConsumptionPerKilometer { get; set; }
         public double TravelledDistance { get; set; }


     }
}
