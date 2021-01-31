using System;
using System.Reflection;

namespace ObjectCloner
{
    static class Cloner
    {
        public static T DeepClone<T>(T cloneableObject) where T : new()
        {
            var newObject = new T();
            Type cloneableType = typeof(T);

            var targetMembers = cloneableType.GetProperties();

            foreach (PropertyInfo property in targetMembers)
            {
                if (property.PropertyType.IsValueType || property.PropertyType.IsEnum ||
                    property.PropertyType.Equals(typeof(string)))
                {
                    property.SetValue(newObject, property.GetValue(cloneableObject, null));
                }

                else
                {
                    var instance = Activator.CreateInstance(property.PropertyType);

                    property.SetValue(instance, property.GetValue(cloneableObject));

                    property.SetValue(newObject, DeepClone(instance));

                    //property.SetValue(property.GetValue(cloneableObject), property.GetValue(DeepClone(instance)));
                }
            }
            return newObject;
        }
    }
}