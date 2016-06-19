using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace MyLOL.Helper
{
    class SerializeHelper
    {
        /// <summary>
        /// 序列化集合对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tArray"></param>
        /// <returns></returns>
        public static string JsonSerializerByArrayData<T>(List<T> tArray)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<T>));
            using (MemoryStream ms = new MemoryStream())
            {
                ser.WriteObject(ms, tArray);
                string jsonString = Encoding.UTF8.GetString(ms.ToArray());
                return jsonString;
            }
        }

        /// <summary>
        /// 反序列化集合对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static List<T> JsonDeserializeByArrayData<T>(string jsonString)
        {

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<T>));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            List<T> arrayObj = (List<T>)ser.ReadObject(ms);
            return arrayObj;


        }

        /// <summary>  
        /// 序列化单个对象  
        /// </summary>  
        public static string JsonSerializerBySingleData<T>(T t)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                ser.WriteObject(ms, t);
                string jsonString = Encoding.UTF8.GetString(ms.ToArray());
                return jsonString;
            }

        }

        /// <summary>   
        /// 反序列化单个对象  
        /// </summary>   
        public static T JsonDeserializeBySingleData<T>(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(ms);
            return obj;
        }

    }
}
