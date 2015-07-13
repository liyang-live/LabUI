using System;

namespace VietBaIT.HISLink.UI.ControlUtility.BaseClass
{
    class ComboBoxItem
    {
        private readonly object bindingValue;
        private readonly object displayText;

        public object BindingValue
        {
            get { return bindingValue; }
        }

        public object DisplayText
        {
            get { return displayText; }
        }

        public ComboBoxItem(object cValue, object cText)
        {
            this.bindingValue = cValue;
            this.displayText = cText;
        }

        public override string ToString()
        {
            return Convert.ToString(displayText);
        }
    }
}
