using System;

namespace OpenWeatherN
{
    public class AppConstants
    {
        //Private Constructor.  
        private AppConstants()
        {
        }
        public  string ApiKey = "643e999658849b4622d202e847220f80";
        private static AppConstants instance = null;
        public static AppConstants Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AppConstants();
                }
                return instance;
            }
        }

        
    }
}
