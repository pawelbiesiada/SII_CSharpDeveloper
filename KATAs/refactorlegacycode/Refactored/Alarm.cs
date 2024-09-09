using System;
using System.Collections.Generic;
using System.Text;

namespace KataCSharpStarting.Refactored
{
    public class PressureChecker : IChecker
    {
        private const double LowPresureThreshold = 17;
        private const double HighPresureThreshold = 21;
        private readonly IPressureSensor sensor;

        public PressureChecker(IPressureSensor sensor)
        {
            this.sensor = sensor;
        }

        public bool IsCorrect()
        {
            double psiPressureValue = sensor.PopNextPressurePsiValue();

            return psiPressureValue < LowPresureThreshold || psiPressureValue > HighPresureThreshold;
        }

        public string GetMessage()
        {
            return !IsCorrect() ? "BEEP BOOP the alarm bells are ringing! Control the pressure" :
                "Everything is fine";
        }
    }

    public class Alarm
    {
        private readonly IChecker _checker;
        bool isAlarmOn = false;
        private Action<string> _notify;


        //new Alarm(new PressureChecker(new SimpleSensor()), Console.WriteLine)

        public Alarm(IChecker checker, Action<string> notify)
        {
            _checker = checker;
            _notify = notify;
        }


        public void Validate()
        {
            isAlarmOn = !_checker.IsCorrect();
        }

        public void GetDetails()
        {
            //   Console.WriteLine(_checker.GetMessage());
            _notify(_checker.GetMessage());
        }
    }


    public class AlarmEventArgs : EventArgs
    {
        public string AlarmMessage { get; set; }
    }

    public class AlarmWithEvent
    {
        private readonly IChecker _checker;
        bool isAlarmOn = false;
        
        public event EventHandler<AlarmEventArgs> OnAlarm;

        //new AlarmWithEvent(new PressureChecker(new SimpleSensor()))

        public AlarmWithEvent(IChecker checker)
        {
            _checker = checker;
        }


        public void Validate()
        {
            isAlarmOn = !_checker.IsCorrect();


            if (isAlarmOn && OnAlarm != null)
            {
                OnAlarm.Invoke(this, new AlarmEventArgs() { AlarmMessage = _checker.GetMessage() });
            }
        }

        public void GetDetails()
        {
            if(OnAlarm != null)
            {
                OnAlarm.Invoke(this, new AlarmEventArgs() { AlarmMessage = _checker.GetMessage()});
            }
        }
    }

    class AlarmTest
    {
        public void Execute()
        {
            var alarm = new AlarmWithEvent(new PressureChecker(new SimpleSensor()));
            alarm.OnAlarm += Alarm_OnAlarm; // write to console
            alarm.OnAlarm += (s, e) => {  }; // sends email

            alarm.Validate();
        }

        private void Alarm_OnAlarm(object sender, AlarmEventArgs e)
        {
            Console.WriteLine(e.AlarmMessage);
        }
    }
}
