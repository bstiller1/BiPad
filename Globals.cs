using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalVariables
{
    public static class Globals
    {
        // parameterless constructor required for static class
        static Globals() { GlobalName = ""; } // default value

        // public get, and private set for strict access control
        public static string GlobalName { get; private set; }

        // GlobalInt can be changed only via this method
        public static void SetGlobalInt(string currFilename)
        {
            GlobalName = currFilename;
        }

        internal static void SetGlobalName(string p)
        {
            throw new NotImplementedException();
        }
    }
}
