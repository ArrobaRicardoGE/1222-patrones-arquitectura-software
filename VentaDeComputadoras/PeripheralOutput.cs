using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSale
{
    class PeripheralOutput : Component
    {
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
            return base.Describe() + string.Format("\nType: Output\nValidPorts: {0}", FormatValidPorts());
        }
    }
}
