using System;
using System.Collections.Generic;
using System.Reflection;
using com.knetikcloud.Client;
using com.knetikcloud.Attributes;

namespace com.knetikcloud.Factory
{
    /// <summary>
    /// A factory to instantiate polymorphic types by a JSON type value.
    /// </summary>
    public static class KnetikFactory
    {
        /// <summary>
        /// Per base type unique serialization type name and matching C# class to instantiate
        /// for example: Property will have an entry for "file" & FileProperty for example.
        /// </summary>
        private class PerBaseTypeInfo
        {
            public readonly Dictionary<string, Type> CreationInfo = new Dictionary<string, Type>();
        }

        private static readonly Dictionary<Type, PerBaseTypeInfo> sRegisteredTypes = new Dictionary<Type, PerBaseTypeInfo>();

        /// <summary>
        /// Create an instance of a sub-class for the base type and unique serialization name.
        /// </summary>
        /// <remarks>
        /// NOTE: This can throw an exception if the class in question does not have a matching attribute!
        /// </remarks>
        public static object CreateInstance(Type baseType, string uniqueTypeName)
        {
            // Get the base class hierarchy type
            PerBaseTypeInfo typeInfo;
            if (!sRegisteredTypes.TryGetValue(baseType, out typeInfo))
            {
                // Did you register any base types?  E.g. 'Property' for the Property hierarchy of classes
                throw new KnetikException(string.Format("Missing 'KnetikFactoryAttribute' for parent class {0} with type {1}!", baseType, uniqueTypeName));
            }

            // Get the appropriate type to construct
            Type creationType;
            if (!typeInfo.CreationInfo.TryGetValue(uniqueTypeName, out creationType))
            {
                // Did you register your specific type.  E.g. 'file' for 'FileProperty'?
                throw new KnetikException(string.Format("Missing 'KnetikFactoryAttribute' for parent class {0} with type {1}!", baseType, uniqueTypeName));
            }

            // Create a new instance of the class from the type
            object newInstance = Activator.CreateInstance(creationType);
            return newInstance;
        }

        /// <summary>
        /// Initialize the factory, which in turn scans for types registered with the 'KnetikFactory' attribute.
        /// </summary>
        public static void Initialize()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            for (int assemblyIndex = 0; assemblyIndex < assemblies.Length; ++assemblyIndex)
            {
                Type[] assemblyTypes = assemblies[assemblyIndex].GetTypes();

                for (int typeIndex = 0; typeIndex < assemblyTypes.Length; ++typeIndex)
                {
                    object[] attributes = assemblyTypes[typeIndex].GetCustomAttributes(typeof(KnetikFactoryAttribute), false);
                    for (int i = 0; i < attributes.Length; ++i)
                    {
                        KnetikFactoryAttribute attribute = (KnetikFactoryAttribute)attributes[i];
                        RegisterType(attribute.Key, assemblyTypes[typeIndex]);
                    }
                }
            }
        }

        /// <summary>
        /// Register the type for factory instantiation.
        /// </summary>
        private static void RegisterType(string key, Type creationType)
        {
            Type parentType = GetRootType(creationType);

            PerBaseTypeInfo typeInfo;
            if (!sRegisteredTypes.TryGetValue(parentType, out typeInfo))
            {
                typeInfo = new PerBaseTypeInfo();
                sRegisteredTypes[parentType] = typeInfo;
            }

            typeInfo.CreationInfo[key] = creationType;
        }

        /// <summary>
        /// Determine the root class in the hierarchy instead of the immediate parent.
        /// For example, we want 'Property' for 'AudioFileGroup' instead of 'FileGroupProperty'
        /// </summary>
        private static Type GetRootType(Type currentType)
        {
            if (currentType == null)
            {
                throw new KnetikException("You cannot pass null as a Type argument!");
            }

            // ReSharper disable once PossibleNullReferenceException 
            // NOTE: all objects inherit from System.Object
            while (currentType.BaseType != typeof(object))
            {
                currentType = currentType.BaseType;
            }

            return currentType;
        }
    }
}
