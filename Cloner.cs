using System;
using System.Linq;
using System.Reflection;

namespace ObjectCloner
{
    static class Cloner
    {
        public static T DeepClone<T>(T cloneableObject) where T : new()
        {
            var newObject = new T();

            Type cloneableType = typeof(T);
            MemberInfo[] members = cloneableType.GetProperties();

            foreach (PropertyInfo property in members)
            {
                if (property.PropertyType.IsValueType || property.PropertyType.IsEnum || property.PropertyType.Equals(typeof(string)))
                {
                    property.SetValue(newObject, property.GetValue(cloneableObject, null));
                }

                else
                {
                    Type subType = property.GetType();
                    var classTypeProperty = property.GetValue(cloneableObject, null);

                    property.SetValue(newObject, DeepClone(classTypeProperty));
                }
            }

            //foreach (FieldInfo field in members)
            //{
            //    field.SetValue(clonedObject, field.GetValue(cloneableObject));
            //}

            return newObject;
        }
    }
}
