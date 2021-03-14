using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAA.Plugin.Supports
{
    public class ProfileTransformation
    {
        public string Angle(string profile)
        {
            switch(profile)
            {
                case "L100X100X10":
                    return "L100X10_8509_93";
                case "L80X80X10":
                    return "L100X8_8509_93";
                case "L120X120X12":
                    return "L125X12_8509_93";
                case "L150X150X15":
                    return "L160X10_8509_93";

                default:
                    throw new Exception("Неверный профиль");
            }
        }
    }
}
