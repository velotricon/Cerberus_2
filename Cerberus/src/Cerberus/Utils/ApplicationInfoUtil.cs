using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Utils
{
    public class ApplicationInfoUtil
    {
        private static string application_path;
        private static bool application_path_is_set = false;
        private static object application_path_lock = new object();

        public static string ApplicationPath
        {
            get { return application_path; }
            set
            {
                lock(application_path_lock)
                {
                    if(application_path_is_set) throw new Exception("ApplicationPath may be set only once");
                    else
                    {
                        application_path = value;
                        application_path_is_set = true;
                    }
                }
            }
        }
    }
}
