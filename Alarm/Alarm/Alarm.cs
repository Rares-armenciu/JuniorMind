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
        public void AlarmIsOffMondayAtTen()
        {
            AlarmSettings[] alarmSchedule = new AlarmSettings[] {new AlarmSettings(Weekdays.Mon, 6), new AlarmSettings(Weekdays.Tue, 6),
                new AlarmSettings(Weekdays.Wed, 6), new AlarmSettings(Weekdays.Thu, 6), new AlarmSettings(Weekdays.Fri, 6),
                new AlarmSettings(Weekdays.Sat, 8), new AlarmSettings(Weekdays.Sun, 8)};
            Assert.AreEqual(false, CheckIfAlarmIsOn(alarmSchedule, new AlarmSettings(Weekdays.Mon, 10)));
        }
        [TestMethod]
        public void AlarmIsOnTuesdayAtSix()
        {
            AlarmSettings[] alarmSchedule = new AlarmSettings[] {new AlarmSettings(Weekdays.Mon, 6), new AlarmSettings(Weekdays.Tue, 6),
                new AlarmSettings(Weekdays.Wed, 6), new AlarmSettings(Weekdays.Thu, 6), new AlarmSettings(Weekdays.Fri, 6),
                new AlarmSettings(Weekdays.Sat, 8), new AlarmSettings(Weekdays.Sun, 8)};
            Assert.AreEqual(true, CheckIfAlarmIsOn(alarmSchedule, new AlarmSettings(Weekdays.Tue, 6)));
        }
        [TestMethod]
        public void AlarmIsOnSundayAtEight()
        {
            AlarmSettings[] alarmSchedule = new AlarmSettings[] {new AlarmSettings(Weekdays.Mon, 6), new AlarmSettings(Weekdays.Tue, 6),
                new AlarmSettings(Weekdays.Wed, 6), new AlarmSettings(Weekdays.Thu, 6), new AlarmSettings(Weekdays.Fri, 6),
                new AlarmSettings(Weekdays.Sat, 8), new AlarmSettings(Weekdays.Sun, 8)};
            Assert.AreEqual(true, CheckIfAlarmIsOn(alarmSchedule, new AlarmSettings(Weekdays.Sun, 8)));
        }
        [TestMethod]
        public void AlarmIsOffSaturdayAtFour()
        {
            AlarmSettings[] alarmSchedule = new AlarmSettings[] {new AlarmSettings(Weekdays.Mon, 6), new AlarmSettings(Weekdays.Tue, 6),
                new AlarmSettings(Weekdays.Wed, 6), new AlarmSettings(Weekdays.Thu, 6), new AlarmSettings(Weekdays.Fri, 6),
                new AlarmSettings(Weekdays.Sat, 8), new AlarmSettings(Weekdays.Sun, 8)};
            Assert.AreEqual(false, CheckIfAlarmIsOn(alarmSchedule, new AlarmSettings(Weekdays.Sat, 4)));
        }
        bool CheckIfAlarmIsOn(AlarmSettings[] alarmSchedule, AlarmSettings alarmSettings)
        {
            for (int i = 0; i < alarmSchedule.Length; i++)
                if (alarmSchedule[i].daySetting == alarmSettings.daySetting && alarmSchedule[i].hourSetting == alarmSettings.hourSetting)
                    return true;
            return false;
        }
    }
}
