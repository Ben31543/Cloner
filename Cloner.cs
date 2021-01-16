using System;
using System.Reflection;

namespace ObjectCloner
{
    static class Cloner
    {
        public static void GetDeepClone<T>(T cloneFrom, T cloneTo)
        {
            Type cloneableType = typeof(T);
            MemberInfo[] members = cloneableType.GetProperties();

            foreach (PropertyInfo propertyInfo in members)
            {
                PropertyInfo property = cloneableType.GetProperty(propertyInfo.Name);
                property.SetValue(cloneTo, property.GetValue(cloneFrom, null));
            }
        }
    }
}
