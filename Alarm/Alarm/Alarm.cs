using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alarm
{
    [Flags]
    public enum Weekdays
    {
        Mon = 0x1, Tue = 0x2, Wed = 0x4, Thu = 0x8, Fri = 0x10, Sat = 0x20, Sun = 0x40
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
        public void AlarmIsOFFMondayAtTen()
        {
            Weekdays alarmSchedule = Weekdays.Mon;
            AlarmSettings[] alarmSettings = new AlarmSettings[] { new AlarmSettings(alarmSchedule, 6) };
            Assert.AreEqual(false, CheckIfAlarmIsOn(alarmSettings, new AlarmSettings(Weekdays.Mon, 10)));
        }
        [TestMethod]
        public void AlarmIsONTuesdayAtSix()
        {
            Weekdays alarmSchedule = Weekdays.Tue;
            AlarmSettings[] alarmSettings = new AlarmSettings[] {new AlarmSettings(alarmSchedule, 6)};
            Assert.AreEqual(true, CheckIfAlarmIsOn(alarmSettings, new AlarmSettings(Weekdays.Tue, 6)));
        }
        [TestMethod]
        public void AlarmIsONSundayAtEight()
        {
            Weekdays alarmSchedule = Weekdays.Sat | Weekdays.Sun;
            AlarmSettings[] alarmSettings = new AlarmSettings[] {new AlarmSettings(alarmSchedule, 8)};
            Assert.AreEqual(true, CheckIfAlarmIsOn(alarmSettings, new AlarmSettings(Weekdays.Sun, 8)));
        }
        [TestMethod]
        public void AlarmIsOFFSaturdayAtFour()
        {
            Weekdays alarmSchedule = Weekdays.Sat | Weekdays.Sun;
            AlarmSettings[] alarmSettings = new AlarmSettings[] {new AlarmSettings(alarmSchedule, 8)};
            Assert.AreEqual(false, CheckIfAlarmIsOn(alarmSettings, new AlarmSettings(Weekdays.Sat, 4)));
        }
        bool CheckIfAlarmIsOn(AlarmSettings[] alarmSchedule, AlarmSettings alarmSettings)
        {
            for (int i = 0; i < alarmSchedule.Length; i++)
                if ((alarmSchedule[i].daySetting & alarmSettings.daySetting) !=0 && (alarmSchedule[i].hourSetting == alarmSettings.hourSetting))
                    return true;
            return false;
        }
    }
}
