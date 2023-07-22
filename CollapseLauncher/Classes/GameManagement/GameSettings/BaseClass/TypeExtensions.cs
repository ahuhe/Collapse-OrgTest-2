﻿using System;
using System.Reflection;

namespace CollapseLauncher
{
    public static class TypeExtensions
    {
        public static bool IsInstancePropertyEqual<T>(T self, T to) where T : class
        {
            // Check if the value is null
            if (self == null && to == null) return true;
            // Check if the reference is equal
            if (ReferenceEquals(self, to)) return true;

            // Get the type of the instance
            Type type = typeof(T);
            // Enumerate the PropertyInfo out of instance
            foreach (PropertyInfo pi in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                // Get the property name and value from both self and to
                object selfValue = type.GetProperty(pi.Name).GetValue(self, null);
                object toValue = type.GetProperty(pi.Name).GetValue(to, null);

                // If the value on both self and to is different, then return false (not equal)
                if (selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue)))
                {
                    return false;
                }
            }

            // If all passes, then return true (equal)
            return true;
        }
    }
}
