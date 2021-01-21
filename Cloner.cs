using System;
using System.Linq;
using System.Reflection;

namespace ObjectCloner
{
    static class Cloner
    {
        public static T DeepClone<T>(T cloneableObject) where T : new()
        {
            var clonedObject = new T();

            Type cloneableType = typeof(T);
            MemberInfo[] members = cloneableType.GetProperties();
            
            // fields

            foreach (PropertyInfo property in members)
            {
                if (property.PropertyType.IsClass)
                {
                    //create object
                    //fill fields & properties using recursion
                }

                property.SetValue(clonedObject, property.GetValue(cloneableObject, null));
            }

            foreach (FieldInfo field in members)
            {
                field.SetValue(clonedObject, field.GetValue(cloneableObject));
            }

            return clonedObject;
        }
    }
}
