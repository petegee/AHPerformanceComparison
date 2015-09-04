using System.Collections.Generic;

using PerformanceComparison.schemas;

namespace PerformanceComparison
{
    sealed class Registry // SINGLETON
    {
        private static readonly object obj = new object();
        private static Registry _instance;
        private ColourAssociations aircraftColours = new ColourAssociations();
        private Dictionary<string, NewDataSet> aircraftData;

        private Registry() 
        {
            aircraftData = new Dictionary<string, NewDataSet>();
        }
                
        public static Registry Instance
        {
            get
            {
                lock (obj)
                {
                    if (_instance == null)
                    {
                        _instance = new Registry();
                    }
                    return _instance;
                }
            }
        }


        public ColourAssociations AircraftColours 
        {
            get { return aircraftColours; }
        }

        public NewDataSet GetAircraftData(string aircraftName)
        {
            // if its cached, return the cached copy.
            if (aircraftData.ContainsKey(aircraftName))
            {
                return aircraftData[aircraftName];
            }
            else
            {
                //Ooops not loaded yet, so load it.
                NewDataSet aircraft = new NewDataSet();
                aircraft.ReadXml(@"airData\" + aircraftName + ".xml");
                
                // Now add it so next time its cached.
                aircraftData.Add(aircraftName, aircraft);

                return aircraft;
            }
        }
    }
}
