﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SodomaInn.Core.Utils
{
    public class ObjectMapper
    {
        public static D Map<S, D>(S source) where D : new()
        {
            //Activator.CreateInstance(typeof(D));
            D dest = new D();
            PropertyInfo[] sourceProps = typeof(S).GetProperties();
            PropertyInfo[] destProps = typeof(D).GetProperties();
            foreach (PropertyInfo prop in sourceProps)
            {
                if (prop == null)
                {
                    continue;
                }
                PropertyInfo destProp = destProps.FirstOrDefault(p => p.Name == prop.Name);
                if (destProp == null)
                {
                    continue;
                }
                if (Convert.GetTypeCode(destProp.GetValue(dest)) == TypeCode.Object)
                {
                    var x = Convert.GetTypeCode(destProp);
                    var type1 = prop.PropertyType;
                    var type2 = destProp.PropertyType;
                    Object result = typeof(ObjectMapper).GetMethod("Map").MakeGenericMethod(new[] { type1 , type2}).Invoke(null, new object[] { prop.GetValue(source) });
                    destProp.SetValue(dest, result);
                    continue;
                }
                destProp.SetValue(dest, prop.GetValue(source));

            }
            return dest;
        }
    }
}
