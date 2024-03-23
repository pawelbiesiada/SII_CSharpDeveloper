using System;
using System.Collections.Generic;
using System.Text;

namespace KataCSharpStarting.Refactored
{
    public class SimpleSensor : IPressureSensor
    {
        private const double OFFSET = 16;

        public double PopNextPressurePsiValue()
        {
            double pressureTelemetryValue;
            pressureTelemetryValue = SamplePressure();
            return OFFSET + pressureTelemetryValue;
        }

        private double SamplePressure()
        {
            Random basicRandomNumbersGenerator = new Random();
            double pressureTelemetryValue = 6 * basicRandomNumbersGenerator.NextDouble() * basicRandomNumbersGenerator.NextDouble();
            return pressureTelemetryValue;
        }

    }
}
