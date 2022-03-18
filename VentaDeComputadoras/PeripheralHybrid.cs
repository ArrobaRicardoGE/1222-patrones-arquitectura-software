using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSale
{
    // Concrete product used by PeripheralComponentCreator. Its derived classes are selected
    // depending on the argument passed to the factory method. 
    class PeripheralHybrid : Component
    {
        protected string Connector { get; set; }
        protected int[] ValidPorts { get; set; }

        private string FormatValidPorts()
        {
            string ans = "[";
            foreach (int x in ValidPorts)
                ans += string.Format("{0}, ", x);
            return ans.Substring(0, ans.Length - 2) + "]";
        }

        public override string Describe()
        {
            return base.Describe() + string.Format("\nType: Hybrid\nConnector: {0}\nValidPorts: {1}", Connector, FormatValidPorts());
        }
    }
}
