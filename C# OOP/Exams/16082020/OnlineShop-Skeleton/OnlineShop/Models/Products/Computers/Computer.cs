using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => this.components.ToList().AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.ToList().AsReadOnly();

        public override double OverallPerformance
        {
            get
            {
                if (this.Components.Count == 0)
                {
                    return this.overallPerformance;
                }
                else
                {
                    return this.overallPerformance + 
                        this.Components.Select(c => c.OverallPerformance).Average();
                }
            }

        }

        public override decimal Price
            => this.price + this.ComponentsPrice() + this.PeripheralsPrice();
             

        public void AddComponent(IComponent component)
        {
            if (this.Components.Select(c => c.GetType()).Contains(component.GetType()))
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.Peripherals.Select(p => p.GetType()).Contains(peripheral.GetType()))
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            IComponent selectedComponent = this.Components.FirstOrDefault(c => c.GetType().Name == componentType);

            if (this.Components.Count == 0 ||
                selectedComponent == null)
            {
                throw new ArgumentException($"Component {componentType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            this.components.Remove(selectedComponent);

            return selectedComponent;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral peripheral = this.Peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);

            if (this.Peripherals.Count == 0 || peripheral == null)
            {
                throw new ArgumentException($"Peripheral {peripheralType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            this.peripherals.Remove(peripheral);

            return peripheral;
        }

        private decimal ComponentsPrice()
            => this.Components.Sum(c => c.Price);

        private decimal PeripheralsPrice()
            => this.Peripherals.Sum(p => p.Price);

        private double PeripheralsAveragePerformance()
        {
            if (this.Peripherals.Count == 0)
            {
                return 0;
            }

            return this.Peripherals.Select(p => p.OverallPerformance).Average();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({this.Components.Count}):");

            foreach (IComponent component in this.Components)
            {
                sb.AppendLine($"  {component.ToString()}");
            }

            sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({PeripheralsAveragePerformance():f2}):");

            foreach (IPeripheral peripheral in this.Peripherals)
            {
                sb.AppendLine($"  {peripheral.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
