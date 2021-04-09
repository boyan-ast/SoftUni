using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;

        private decimal totalIncome = 0;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;

            if (type == nameof(Tea))
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == nameof(Water))
            {
                drink = new Water(name, portion, brand);
            }

            this.drinks.Add(drink);

            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;

            if (type == nameof(Bread))
            {
                food = new Bread(name, price);
            }
            else if (type == nameof(Cake))
            {
                food = new Cake(name, price);
            }

            this.bakedFoods.Add(food);

            //What if type is not correct?

            return $"Added {name} ({type}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;

            if (type == nameof(InsideTable))
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == nameof(OutsideTable))
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            this.tables.Add(table);

            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            List<ITable> freeTables = this.tables.Where(t => !t.IsReserved).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (ITable table in freeTables)
            {
                sb.Append(table.GetFreeTableInfo());
                sb.Append(Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            //What about the other orders?

            return $"Total income: {this.totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            decimal bill = table.GetBill();

            this.totalIncome += bill;

            table.Clear();

            return $"Table: {tableNumber}" + Environment.NewLine + $"Bill: {bill:f2}";

            //What if null?
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IDrink drink = this.drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            string result = string.Empty;

            if (table == null)
            {
                result = $"Could not find table {tableNumber}";
            }
            else if (drink == null)
            {
                result = $"There is no {drinkName} {drinkBrand} available";
            }
            else
            {
                table.OrderDrink(drink);
                result = $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
            }

            return result;
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IBakedFood food = this.bakedFoods.FirstOrDefault(f => f.Name == foodName);

            string result = string.Empty;

            if (table == null)
            {
                result = $"Could not find table {tableNumber}";
            }
            else if (food == null)
            {
                result = $"No {foodName} in the menu";
            }
            else
            {
                table.OrderFood(food);
                result = $"Table {tableNumber} ordered {foodName}";
            }

            return result;
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = this.tables.FirstOrDefault(t => !t.IsReserved && t.Capacity >= numberOfPeople);

            string result = string.Empty;

            if (table == null)
            {
                result = $"No available table for {numberOfPeople} people";
            }
            else
            {
                table.Reserve(numberOfPeople);

                result = $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
            }

            return result;
        }
    }
}
