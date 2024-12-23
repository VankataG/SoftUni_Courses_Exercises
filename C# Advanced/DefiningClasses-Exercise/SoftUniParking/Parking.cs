using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    public class Parking
    {
        public string AddCar(Car addCar)
        {
            foreach (var car in Cars)
            {
                if (car.RegistrationNumber == addCar.RegistrationNumber)
                {
                    return "Car with that registration number, already exists!";
                }
            }

            if (Cars.Count >= Capacity)
            {
                return "Parking is full!";
            }

            Cars.Add(addCar);

            return $"Successfully added new car {addCar.Make} {addCar.RegistrationNumber}";

        }

        public string RemoveCar(string registrationNumber)
        {
            bool removed = false;
            foreach (Car car in Cars)
            {
                if (car.RegistrationNumber == registrationNumber)
                {
                    removed = true;
                    break;
                }
            }

            if (!removed)
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Cars.Remove(Cars.First(x => x.RegistrationNumber == registrationNumber));
                return $"Successfully removed {registrationNumber}";
            }

        }

        public Car GetCar(string registrationNumber)
        {
            return Cars.Find(x => x.RegistrationNumber == registrationNumber);

        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registrationNumber in registrationNumbers)
            {
                RemoveCar(registrationNumber);
                //Car car = Cars.Find(x => x.RegistrationNumber == registrationNumber);

                //if (car != null)
                //{
                //    Cars.Remove(car);
                //}
            }
        }

        private List<Car> cars;

        public List<Car> Cars
        {
            get { return cars; }
            set { cars = value; }
        }

        private int capacity;

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public int Count
        {
            get { return Cars.Count; }
        }

        public Parking(int capacity)
        {
            Cars = new List<Car>();
            Capacity = capacity;
        }
    }
}
