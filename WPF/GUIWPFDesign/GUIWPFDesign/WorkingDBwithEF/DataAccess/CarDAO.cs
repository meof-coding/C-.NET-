using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingDBwithEF.DataAccess
{
    class CarDAO
    {
        public List<Car> GetCars()
        {
            List<Car> cars;
            try
            {
                using(var context = new MyStockContext())
                {
                    cars = context.Cars.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cars;
        }

        public Car GetCarById(int id)
        {
            Car car = null;
            try
            {
                using (var context = new MyStockContext())
                {
                    car = context.Cars.SingleOrDefault(c => c.CarId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return car;
        }

        public void InsertCar(Car car)
        {
            try
            {
                Car c = GetCarById(car.CarId);
                if (c==null)
                {
                    using(var context = new MyStockContext())
                    {
                        context.Cars.Add(car);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The car is already exist.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void UpdateCar(Car car)
        {
            try
            {
                Car c = GetCarById(car.CarId);
                if (c != null)
                {
                    using(var context = new MyStockContext())
                    {
                        context.Entry<Car>(car).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The car does not already exist.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void RemoveCar(Car car)
        {
            try
            {
                Car c = GetCarById(car.CarId);
                if (c != null)
                {
                    using (var context = new MyStockContext())
                    {
                        context.Cars.Remove(car);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The car does not already exist.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
