using System;

namespace com.knetikcloud.Attributes
{
    /// <inheritdoc />
    /// <summary>
    /// Register this type for polymorphic instantiation with the KnetikFactory.
    /// 'key' should match the string value passed back via the 'Type' field in the model class.
    /// For example, you would specify 'file' for the FileProperty class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class KnetikFactoryAttribute : Attribute
    {
        public string Key;

        public KnetikFactoryAttribute(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("KnetikFactoryAttribute cannot be empty or null!", "key");
            }

            Key = key;
        }
    }
}
