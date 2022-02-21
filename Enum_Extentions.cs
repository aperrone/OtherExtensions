using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace System
{
    public static class Enum_Extentions
    {
        public static string GetDescription(this Enum value)
        {
            MemberInfo[] memInfo = value.GetType().GetMember(value.ToString());

            DescriptionAttribute attribute = CustomAttributeExtensions.GetCustomAttribute<DescriptionAttribute>(memInfo[0]);
            if (attribute != null)
                return attribute.Description;

            return Enum.GetName(value.GetType(), value);
        }
    }
}
