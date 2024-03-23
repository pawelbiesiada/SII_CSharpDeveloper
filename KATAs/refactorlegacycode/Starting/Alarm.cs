using System;
using System.Collections.Generic;
using System.Text;

namespace KataCSharpStarting.Starting
{
    public class Alarm
    {
        private const double LowPresureThreashold = 17;
        private const double HighPresureThreshold = 21;

        private readonly SimpleSensor sensor = new SimpleSensor();
        bool isAlarmOn = false;

        public void CheckPressure()
        {
            double psiPressureValue = sensor.PopNextPressurePsiValue();

            if(psiPressureValue < LowPresureThreashold || psiPressureValue > HighPresureThreshold)
            {
                isAlarmOn = true;
            }
        }

        public void ShowDetails()
        {
            if (isAlarmOn)
            {
                Console.WriteLine("BEEP BOOP the alarm bells are ringing! Control the pressure");
            } else
            {
                Console.WriteLine("Everything is fine");
            }
        }
    }
}
