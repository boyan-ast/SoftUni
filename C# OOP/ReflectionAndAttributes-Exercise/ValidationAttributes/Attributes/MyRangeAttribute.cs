using System;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            int objAsInteger = Convert.ToInt32(obj);

            bool isValid = (objAsInteger >= this.minValue) && (objAsInteger <= this.maxValue);

            return isValid;
        }
    }
}
