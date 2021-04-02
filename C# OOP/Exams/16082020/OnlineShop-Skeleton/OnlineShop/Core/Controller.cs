using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private ICollection<IComputer> computers;
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, 
            int id, string componentType, 
            string manufacturer,
            string model, 
            decimal price, 
            double overallPerformance, 
            int generation)
        {
            IComputer selectedComputer = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (selectedComputer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            if (this.components.Select(c => c.Id).Contains(id))
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            IComponent component = null;

            if (componentType == nameof(CentralProcessingUnit))
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(Motherboard))
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(PowerSupply))
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(RandomAccessMemory))
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(SolidStateDrive))
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(VideoCard))
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException("Component type is invalid.");
            }

            selectedComputer.AddComponent(component);
            this.components.Add(component);

            return $"Component {componentType} with id {component.Id} added successfully in computer with id {selectedComputer.Id}.";
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.Select(c => c.Id).Contains(id))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            IComputer computer = null;

            if (computerType == nameof(Laptop))
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == nameof(DesktopComputer))
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException("Computer type is invalid.");
            }

            this.computers.Add(computer);

            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, 
            int id, 
            string peripheralType, 
            string manufacturer, 
            string model, 
            decimal price, 
            double overallPerformance, 
            string connectionType)
        {
            IComputer selectedComputer = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (selectedComputer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            if (this.peripherals.Select(p => p.Id).Contains(id))
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }

            IPeripheral peripheral = null;

            if (peripheralType == nameof(Headset))
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == nameof(Keyboard))
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == nameof(Monitor))
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == nameof(Mouse))
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }

            selectedComputer.AddPeripheral(peripheral);
            this.peripherals.Add(peripheral);

            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {selectedComputer.Id}.";
        }

        public string BuyBest(decimal budget)
        {
            IComputer selectedComputer = this.computers
                .OrderByDescending(c => c.OverallPerformance)
                .Where(c => c.Price <= budget)
                .FirstOrDefault();

            if (selectedComputer == null)
            {
                throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
            }

            this.computers.Remove(selectedComputer);

            return selectedComputer.ToString();
        }

        public string BuyComputer(int id)
        {
            IComputer selectedComputer = this.computers.FirstOrDefault(c => c.Id == id);

            if (selectedComputer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            this.computers.Remove(selectedComputer);

            return selectedComputer.ToString();
        }

        public string GetComputerData(int id)
        {
            IComputer selectedComputer = this.computers.FirstOrDefault(c => c.Id == id);

            if (selectedComputer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            return selectedComputer.ToString();
        }

        //TODO: Check if component is not null
        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer selectedComputer = this.computers.FirstOrDefault(c => c.Id == computerId);
            IComponent selectedComponent = this.components.FirstOrDefault(c => c.GetType().Name == componentType);

            if (selectedComputer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            string result = string.Empty;

            if (selectedComponent!=null)
            {
                this.components.Remove(selectedComponent);
                selectedComputer.RemoveComponent(selectedComponent.GetType().Name);
                result = $"Successfully removed {componentType} with id {selectedComponent.Id}.";
            }
            else
            {
                result = $"Component {componentType} does not exist in {selectedComputer.GetType().Name} with Id {selectedComputer.Id}.";
            }

            return result;
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer selectedComputer = this.computers.FirstOrDefault(c => c.Id == computerId);
            IPeripheral selectedPeripheral = this.peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);

            if (selectedComputer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            string result = string.Empty;

            if (selectedPeripheral != null)
            {
                this.peripherals.Remove(selectedPeripheral);
                selectedComputer.RemovePeripheral(selectedPeripheral.GetType().Name);
                result = $"Successfully removed {peripheralType} with id {selectedPeripheral.Id}.";
            }
            else
            {
                result = $"Peripheral {peripheralType} does not exist in {selectedComputer.GetType().Name} with Id {selectedComputer.Id}.";
            }

            return result;
        }

    }
}
