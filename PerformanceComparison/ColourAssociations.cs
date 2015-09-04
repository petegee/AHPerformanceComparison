using System;
using System.Drawing;

namespace PerformanceComparison
{
    /// <summary>
    /// Represents the associations between aircraft and the colours used to represent them 
    /// on the screen.
    /// </summary>
    internal class ColourAssociations
    {
        public int NumberOfColours
        { 
            get { return associations.Length; } 
        }

        private ColourAssociation[] associations;

        #region Public Methods

        /// <summary>
        /// Constructor. Assign the colour association array.
        /// </summary>
        public ColourAssociations()
        {

            associations = new ColourAssociation[]
            {
                new ColourAssociation(Color.Blue),
                new ColourAssociation(Color.Red),
                new ColourAssociation(Color.Chartreuse),
                new ColourAssociation(Color.Orange),
                new ColourAssociation(Color.Turquoise),
                new ColourAssociation(Color.Violet),
                new ColourAssociation(Color.Brown),
                new ColourAssociation(Color.Gray),
                new ColourAssociation(Color.CornflowerBlue),
                new ColourAssociation(Color.Crimson),
                new ColourAssociation(Color.Cyan),
                new ColourAssociation(Color.DarkBlue),
                new ColourAssociation(Color.DarkCyan),
                new ColourAssociation(Color.DarkGoldenrod),
                new ColourAssociation(Color.DarkGray),
                new ColourAssociation(Color.Green),
                new ColourAssociation(Color.DarkKhaki),
                new ColourAssociation(Color.DarkMagenta),
                new ColourAssociation(Color.DarkOliveGreen),
                new ColourAssociation(Color.DarkOrange),
                new ColourAssociation(Color.DarkOrchid),
                new ColourAssociation(Color.DarkRed),
                new ColourAssociation(Color.DarkSalmon),
                new ColourAssociation(Color.DarkSlateBlue),
                new ColourAssociation(Color.DarkSlateGray),
                new ColourAssociation(Color.DarkTurquoise),
                new ColourAssociation(Color.DarkViolet),
                new ColourAssociation(Color.Gold),
                new ColourAssociation(Color.DeepSkyBlue),
                new ColourAssociation(Color.DimGray),
                new ColourAssociation(Color.DodgerBlue),
                new ColourAssociation(Color.Firebrick),
                new ColourAssociation(Color.ForestGreen),
                new ColourAssociation(Color.Fuchsia),
                new ColourAssociation(Color.Aqua),
                new ColourAssociation(Color.Aquamarine)
        };
            //associations = new ColourAssociation[NumberOfColours];

            //associations[0] = new ColourAssociation(Color.Blue);
            //associations[1] = new ColourAssociation(Color.Red);
            //associations[2] = new ColourAssociation(Color.Chartreuse);
            //associations[3] = new ColourAssociation(Color.Orange);
            //associations[4] = new ColourAssociation(Color.Turquoise);
            //associations[5] = new ColourAssociation(Color.Violet);
            //associations[6] = new ColourAssociation(Color.Brown);
            //associations[7] = new ColourAssociation(Color.Gray);
            //associations[8] = new ColourAssociation(Color.CornflowerBlue);
            //associations[9] = new ColourAssociation(Color.Crimson);
            //associations[10] = new ColourAssociation(Color.Cyan);
            //associations[11] = new ColourAssociation(Color.DarkBlue);
            //associations[12] = new ColourAssociation(Color.DarkCyan);
            //associations[13] = new ColourAssociation(Color.DarkGoldenrod);
            //associations[14] = new ColourAssociation(Color.DarkGray);
            //associations[15] = new ColourAssociation(Color.Green);
            //associations[16] = new ColourAssociation(Color.DarkKhaki);
            //associations[17] = new ColourAssociation(Color.DarkMagenta);
            //associations[18] = new ColourAssociation(Color.DarkOliveGreen);
            //associations[19] = new ColourAssociation(Color.DarkOrange);
            //associations[21] = new ColourAssociation(Color.DarkOrchid);
            //associations[22] = new ColourAssociation(Color.DarkRed);
            //associations[23] = new ColourAssociation(Color.DarkSalmon);
            //associations[24] = new ColourAssociation(Color.DarkSlateBlue);
            //associations[25] = new ColourAssociation(Color.DarkSlateGray);
            //associations[26] = new ColourAssociation(Color.DarkTurquoise);
            //associations[27] = new ColourAssociation(Color.DarkViolet);
            //associations[28] = new ColourAssociation(Color.Gold);
            //associations[29] = new ColourAssociation(Color.DeepSkyBlue);
            //associations[30] = new ColourAssociation(Color.DimGray);
            //associations[31] = new ColourAssociation(Color.DodgerBlue);
            //associations[32] = new ColourAssociation(Color.Firebrick);
            //associations[33] = new ColourAssociation(Color.ForestGreen);
            //associations[34] = new ColourAssociation(Color.Fuchsia);
            //associations[35] = new ColourAssociation(Color.Aqua);
            //associations[36] = new ColourAssociation(Color.Aquamarine);
        }


        /// <summary>
        /// Get the colour used to represent a specific aircraft. 
        /// Get the colour associated with this aircraft, if it has one; 
        /// OR, get the next free colour from the array if this aircraft 
        /// is not already associated with a colour.
        /// </summary>
        /// <param name="aircraftName">the name of the aircraft</param>
        /// <returns>the colour to use in representing that aircraft in the app.</returns>
        public Color GetAircraftColour(string aircraftName)
        {
            int index = FindAircraftIndex(aircraftName);
            if (index != -1)
                return associations[index].AircraftColour;

            // not found yet? Find the first free slot and return its colour.
            int freeSlot = GetFirstFreeColourIndex();
            associations[freeSlot].AircraftName = aircraftName;
            return associations[freeSlot].AircraftColour;
        }


        /// <summary>
        /// Remove an aircraft to colour association from the colour association array.
        /// </summary>
        /// <param name="aircraftName"></param>
        public void RemoveAircraftAssociation(string aircraftName)
        {
            int index = FindAircraftIndex(aircraftName);
            if (index != -1)
            {
                associations[index].AircraftName = null;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Find the nominated aircraft in the colour association array if it exists.
        /// </summary>
        /// <param name="aircraftName">the aircraft to find.</param>
        /// <returns>the index of its colour association in the array, or -1 if not found.</returns>
        private int FindAircraftIndex(string aircraftName)
        {
            for (int i = 0; i < associations.Length; i++)
            {
                if (associations[i] != null && string.Equals(associations[i].AircraftName, aircraftName))
                {
                    return i;
                }
            }
            return -1;
        }


        /// <summary>
        /// Finds the first slot in the colour association array which is not
        /// associated with an aircraft.
        /// </summary>
        /// <returns>the first free slot in the array.</returns>
        private int GetFirstFreeColourIndex()
        {
            for (int i = 0; i < associations.Length; i++)
            {
                if (associations[i] != null && !associations[i].IsInUse())
                    return i;
            }

            throw new ApplicationException("No more free colours!");
        }

        #endregion

        #region Nested Classes

        /// <summary>
        /// Represents an association between an aircraft and a colour.
        /// </summary>
        public class ColourAssociation
        {
            private Color aircraftColour;

            #region Public Properties

            public Color AircraftColour 
            {
                get { return aircraftColour; }
            }

            public string AircraftName 
            { 
                get; 
                set;
            }

            #endregion 

            #region Public Methods

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="colour"></param>
            public ColourAssociation(Color colour)
            {
                aircraftColour = colour;
            }

            /// <summary>
            /// Is this colour currently associated with an aircraft?
            /// </summary>
            /// <returns>true if its associated, false otherwise.</returns>
            public bool IsInUse()
            {
                if (string.IsNullOrEmpty(AircraftName))
                    return false;
                else
                    return true;
            }

            #endregion
        }

        #endregion
    }
}
