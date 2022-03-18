using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSale
{
    class PersonalComputer
    {
        private List<Component> Parts;
        public Creator Inputs, Outputs, Components; 

        public PersonalComputer()
        {
            Inputs = new PeripheralInputCreator();
            Outputs = new PeripheralOutputCreator();
            Components = new ComponentCreator();
            Parts = new List<Component>(); 
        }

        public void AddInput(string type)
        {
            Parts.Add(Inputs.CreateComponent(type)); 
        }
        public void AddOutput(string type)
        {
            Parts.Add(Outputs.CreateComponent(type));
        }
        public void AddComponent(string type)
        {
            Parts.Add(Components.CreateComponent(type));
        }

        public float GetFinalPrice()
        {
            float total = 0f; 
            foreach(Component x in Parts)
                total += x.Price;
            return total; 
        }

        public bool ValidateComponentCount()
        {
            int inputCount = 0, outputCount = 0;
            bool centralUnit = false;
            foreach(Component x in Parts)
            {
                if (x is PeripheralInput) inputCount++;
                if (x is PeripheralOutput) outputCount++; 
                if(x is PeripheralHybrid)
                {
                    inputCount++;
                    outputCount++; 
                }
                if (x is CentralUnit) centralUnit = true; 
            }
            return (centralUnit && inputCount > 0 && outputCount > 0); 
        }
        public string DescribeComponents()
        {
            string ans = "";
            foreach (Component x in Parts)
                ans += x.Describe() + "\n********************\n"; 
            return ans; 
        }
    }
}
