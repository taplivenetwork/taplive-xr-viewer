using UnityEngine;
using System;
using System.Collections.Generic;

namespace TapLive.Utils
{
    /// <summary>
    /// JSON serialization utilities
    /// Handles complex objects and arrays
    /// </summary>
    public static class JsonUtils
    {
        /// <summary>
        /// Serialize object to JSON string
        /// </summary>
        public static string ToJson<T>(T obj, bool prettyPrint = false)
        {
            return JsonUtility.ToJson(obj, prettyPrint);
        }

        /// <summary>
        /// Deserialize JSON string to object
        /// </summary>
        public static T FromJson<T>(string json)
        {
            return JsonUtility.FromJson<T>(json);
        }

        /// <summary>
        /// Serialize array to JSON (wrapper required for Unity)
        /// </summary>
        public static string ArrayToJson<T>(T[] array, bool prettyPrint = false)
        {
            Wrapper<T> wrapper = new Wrapper<T> { items = array };
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        /// <summary>
        /// Deserialize JSON to array
        /// </summary>
        public static T[] ArrayFromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.items;
        }

        /// <summary>
        /// Serialize list to JSON
        /// </summary>
        public static string ListToJson<T>(List<T> list, bool prettyPrint = false)
        {
            return ArrayToJson(list.ToArray(), prettyPrint);
        }

        /// <summary>
        /// Deserialize JSON to list
        /// </summary>
        public static List<T> ListFromJson<T>(string json)
        {
            T[] array = ArrayFromJson<T>(json);
            return new List<T>(array);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] items;
        }
    }
}
