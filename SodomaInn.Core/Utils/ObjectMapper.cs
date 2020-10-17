using System;
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
                destProp.SetValue(dest, prop.GetValue(source));

            }
            return dest;
        }
    }
}
