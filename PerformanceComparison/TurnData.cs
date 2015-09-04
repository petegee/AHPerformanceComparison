using System;
using PerformanceComparison.schemas;

namespace PerformanceComparison
{
    class TurnData
    {
        public TurnData(NewDataSet.turnDataRow source)
        { 
            SustainedTurnRadius = source.sustainedTurnRadius;
            SustainedTurnRate = source.sustainedTurnRate;
            TurnSpeed = source.speed; 
            TimeToTurn = source.time;
            StallSpeed = source.stallSpeed;
            CornerVelocity = source.cornerVelocity;
            TurnRadiusAtCorner = source.turnRadiusAtCorner;
            TurnRateAtCorner = source.turnRateAtCorner;


            if (source.flapPosition == "none")
            {
                FlapPosition = TurnData.FlapPositionType.None;
            }
            else if (source.flapPosition == "full")
            {
                FlapPosition = TurnData.FlapPositionType.Full;
            }
            else
                throw new ApplicationException("Unknown Flap setting!");
        }    
   
        public enum FlapPositionType { None, Full };
        public float TurnSpeed { get; set; }
        public float TimeToTurn { get; set; }
        public float SustainedTurnRate { get; set; }
        public float SustainedTurnRadius { get; set; }
        public float StallSpeed { get; set; }
        public float CornerVelocity { get; set; }
        public float TurnRateAtCorner { get; set; }
        public float TurnRadiusAtCorner { get; set; }


        public FlapPositionType FlapPosition;
    }
}
