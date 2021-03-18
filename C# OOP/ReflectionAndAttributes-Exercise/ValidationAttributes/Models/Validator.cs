using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] allProperties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | 
                                                              BindingFlags.Static | BindingFlags.NonPublic);
            foreach (PropertyInfo property in allProperties)
            {
                List<MyValidationAttribute> myAttributes = property.GetCustomAttributes<MyValidationAttribute>().ToList();

                foreach (var attribute in myAttributes)
                {
                    object value = property.GetValue(obj);

                    if (!attribute.IsValid(value))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
