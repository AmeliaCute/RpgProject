using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using System.IO;
using RpgProject.Game.Data;
using UnityEngine;

namespace RpgProject.Framework.Resource
{
    public class Bindable<T>
    {
        private T value;
        public T Value => value;

        public Bindable(T initialValue)
        {
            value = initialValue;
        }

        public void Set(T newValue)
        {
            value = newValue;
        }

       
    }

    public class BindableTool
    {
         /// <summary>
        /// This function sets a new value for a given Bindable object.
        /// </summary>
        /// <param name="bindable">A generic Bindable object that can hold a value of type T and can be
        /// bound to other objects.</param>
        /// <param name="T">T is a generic type parameter that can be replaced with any valid type at
        /// runtime. It is used to specify the type of the value that the Bindable object can hold.</param>
        #pragma warning disable CS0693
        public static void SetBindable<T>(Bindable<T> bindable, T newValue)
        {
            bindable.Set(newValue);
        }
        
        /// <summary>
        /// This function binds the value of one Bindable object to another Bindable object.
        /// </summary>
        /// <param name="bindable">A generic Bindable object that contains a value to be bound to another
        /// Bindable object.</param>
        /// <param name="to">The `to` parameter is a `Bindable<T>` object that the `bindable` parameter will
        /// be bound to.</param>
        public static void BindWith<T>(Bindable<T> bindable, Bindable<T> to)
        {
            SetBindable(to, bindable.Value);
        }

        public static void BindWith<T>(RpgSettings setting, Bindable<T> to)
        {
            to.Set(GetBindableValueFromConfig<RpgSettingsData, T>(Path.Combine(Application.persistentDataPath, "rpgsettings.json"), setting.ToString()));
        }

        public static T GetBindableValueFromConfig<Z, T>(string path, string name)
        {
            Z data = Files.Json<Z>(path);

            PropertyInfo property = typeof(Z).GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (property != null)
            {
                var jsonPropertyAttribute = property.GetCustomAttributes(typeof(JsonPropertyAttribute), true).FirstOrDefault() as JsonPropertyAttribute;

                if (jsonPropertyAttribute != null)
                {
                    string jsonPropertyName = jsonPropertyAttribute.PropertyName;

                    var value = property.GetValue(data);

                    if (value != null && value.GetType() != typeof(T))
                    {
                        try
                        {
                            value = Convert.ChangeType(value, typeof(T));
                        }
                        catch
                        {
                            UnityEngine.Debug.LogError("Failed to convert property value to type: " + typeof(T).FullName);
                        }
                    }

                    if (value is T)
                        return (T)value;
                }
            }

            UnityEngine.Debug.LogError("Failed to load resource: " + path);

            return default(T);
        }
    }
}