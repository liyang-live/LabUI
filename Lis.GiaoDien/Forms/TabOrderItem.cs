using System;

namespace Vietbait.Lablink.TestInformation.UI.Forms
{
    public class TabOrderItem
    {
        public string ControlName { get; set; }
        public string ControlTag { get; set; }
        public bool ControlTabStop { get; set; }
        public int ControlTabIndex { get; set; }

        public TabOrderItem(string tabOrderConfigString)
        {
            if(String.IsNullOrEmpty(tabOrderConfigString.Trim())) return;
            var arrconfig = tabOrderConfigString.Split(',');
            ControlName = arrconfig[0];
            ControlTag = arrconfig[1];
            ControlTabStop = Convert.ToBoolean(arrconfig[2]);
            ControlTabIndex = Convert.ToInt32(arrconfig[3]);
        }

        public TabOrderItem(){}

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3}", ControlName, ControlTag, ControlTabStop, ControlTabIndex);
        }
        public TabOrderItem Clone()
        {
            return new TabOrderItem(this.ToString());
        }
    }
}