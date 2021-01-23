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
            MemberInfo[] members = cloneableType.GetMembers();

            foreach (MemberInfo member in members)
            {
                switch (member.MemberType)
                {
                    case MemberTypes.Property:
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
                        break;

                    case MemberTypes.Field:
                        foreach (FieldInfo field in members)
                        {
                            if (field.FieldType.IsValueType || field.FieldType.IsEnum || field.FieldType.Equals(typeof(string)))
                            {
                                field.SetValue(newObject, field.GetValue(cloneableObject));
                            }
                        }
                        break;
                }
            }

            return newObject;
        }


        public static T Clone<T>(T cloneableObject) where T : new()
        {
            var newObject = new T();

            Type cloneableType = typeof(T);
            MemberInfo[] properties = cloneableType.GetProperties();
            MemberInfo[] fields = cloneableType.GetFields();

            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType.IsValueType || property.PropertyType.IsEnum || property.PropertyType.Equals(typeof(string)))
                {
                    property.SetValue(newObject, property.GetValue(cloneableObject, null));
                }

                else
                {
                    Type subType = property.GetType();

                    var classTypeProperty = property.GetValue(cloneableObject, null);

                    property.SetValue(newObject, Clone(classTypeProperty));
                }
            }

            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsValueType || field.FieldType.IsEnum || field.FieldType.Equals(typeof(string)))
                {
                    field.SetValue(newObject, field.GetValue(cloneableObject));
                }

                else
                {
                    Type subType = field.GetType();

                    var classTypeProperty = field.GetValue(cloneableObject);

                    field.SetValue(newObject, DeepClone(classTypeProperty));
                }
            }


            return newObject;
        }
    }
}