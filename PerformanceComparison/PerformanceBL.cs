using System;
using System.Collections;

using PerformanceComparison.schemas;

namespace PerformanceComparison
{
    class PerformanceBL
    {
        const string WepOn = "on";
        const string WepOff = "off";
        private NewDataSet _aircraft;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="aircraftName"></param>
        public PerformanceBL (string aircraftName)
        {
            _aircraft = Registry.Instance.GetAircraftData(aircraftName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="heights"></param>
        /// <param name="rates"></param>
        /// <param name="wep"></param>
        public void GetClimbData(ArrayList heights, ArrayList rates, bool wep)
        {
            foreach (NewDataSet.climbRow climb in _aircraft.climb)
            {
                float altFactor = 1.0f;
                float rateFactor = 1.0f;
                long altOffset = 0;
                long rateOffset = 0;

                try
                {
                    altOffset = climb.altOffset;
                    rateOffset = climb.rateOffset;
                    altFactor = climb.altFactor;
                    rateFactor = climb.rateFactor;
                }
                catch (System.Data.StrongTypingException)
                {
                    // far from ideal as it is marked as optional in the XSD , however, 
                    // these strongly typed datasets throw an exception if it isnt 
                    // present *sigh*
                }


                if (((climb.wep == WepOn) && wep) || ((climb.wep == WepOff) && !wep))
                {
                    foreach (NewDataSet.cmeasureRow cmeas in climb.GetcmeasureRows())
                    {
                        heights.Add((long)((float)cmeas.altitude * altFactor)+altOffset);
                        rates.Add((long)((float)cmeas.rate * rateFactor)+rateOffset);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="heights"></param>
        /// <param name="rates"></param>
        /// <param name="wep"></param>
        public void GetSpeedData(ArrayList heights, ArrayList rates, bool wep)
        {
            foreach (NewDataSet.speedRow speed in _aircraft.speed)
            {
                float altFactor = 1.0f;
                float tasFactor = 1.0f;
                long altOffset = 0;
                long tasOffset = 0;

                try
                {
                    altOffset = speed.altOffset;
                    tasOffset = speed.tasOffset;
                    altFactor = speed.altFactor;
                    tasFactor = speed.tasFactor;
                }
                catch (System.Data.StrongTypingException)
                {
                    // far from ideal as it is marked as optional in the XSD , however, 
                    // these strongly typed datasets throw an exception if it isnt 
                    // present *sigh*
                }


                if (((speed.wep == WepOn) && wep) || ((speed.wep == WepOff) && !wep))
                {
                    foreach (NewDataSet.smeasureRow smeas in speed.GetsmeasureRows())
                    {
                        heights.Add((long)((float)smeas.altitude * altFactor)+altOffset);
                        rates.Add((long)((float)smeas.tas * tasFactor)+tasOffset);
                    }
                }
            }
        }


        public void GetAllTurnData(out TurnData noFlapsData, out TurnData fullFlapsData)
        {
            noFlapsData = null;
            fullFlapsData = null;

            foreach (NewDataSet.turnDataRow turnRow in _aircraft.turnData)
            {
                try
                {
                    TurnData data = new TurnData(turnRow);

                    if (data.FlapPosition == TurnData.FlapPositionType.None)
                    {
                        noFlapsData = data;
                    }
                    else if (data.FlapPosition == TurnData.FlapPositionType.Full)
                    {
                        fullFlapsData = data;
                    }
                    else
                        throw new ApplicationException("Unknown Flap setting!");
                }
                catch (System.Data.StrongTypingException)
                {
                    // far from ideal as it is marked as optional in the XSD , however, 
                    // these strongly typed datasets throw an exception if it isnt 
                    // present *sigh*
                }
            }
        }
    }
}
