using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alarm
{
    public enum Weekdays
    {
        Mon, Tue, Wed, Thu, Fri, Sat, Sun
    }
    public struct AlarmSettings
    {
        public Weekdays daySetting;
        public int hourSetting;
        public AlarmSettings(Weekdays daySetting, int hourSetting)
        {
            this.daySetting = daySetting;
            this.hourSetting = hourSetting;
        }
    }

    [TestClass]
    public class Alarm
    {
        [TestMethod]
        public void AlarmIsOffMondayAtHourTen()
        {
            AlarmSettings[] alarmSchedule = new AlarmSettings[] {new AlarmSettings(Weekdays.Mon, 6), new AlarmSettings(Weekdays.Tue, 6),
                new AlarmSettings(Weekdays.Wed, 6), new AlarmSettings(Weekdays.Thu, 6), new AlarmSettings(Weekdays.Fri, 6),
                new AlarmSettings(Weekdays.Sat, 8), new AlarmSettings(Weekdays.Sun, 8)};
            Assert.AreEqual(false, CheckIfAlarmIsOn(alarmSchedule, new AlarmSettings(Weekdays.Mon, 10)));
        }

        bool CheckIfAlarmIsOn(AlarmSettings[] alarmSchedule, AlarmSettings alarmSettings)
        {
            return true;
        }
    }
}
