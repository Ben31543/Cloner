using System;
using System.Globalization;
using System.Reflection;

namespace ObjectCloner
{
    static class Cloner
    {
        public static T DeepClone<T>(T cloneableObject) where T : new()
        {
            var newObject = Activator.CreateInstance(cloneableObject.GetType());
            Type cloneableType = cloneableObject.GetType();

            var targetMembers = cloneableType.GetProperties();

            foreach (PropertyInfo property in targetMembers)
            {
                if (property.PropertyType.IsValueType || property.PropertyType.IsEnum || property.PropertyType.Equals(typeof(string)))
                {
                    property.SetValue(newObject, property.GetValue(cloneableObject, null));
                }

                else
                {
                    var propertyToClone = property.GetValue(cloneableObject, BindingFlags.CreateInstance, null, null, CultureInfo.CurrentCulture);
                    var propValue = DeepClone(propertyToClone);
                    property.SetValue(newObject, propValue);
                }
            }
            return (T)newObject;
        }
    }
}