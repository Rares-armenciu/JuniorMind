using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alarm
{
    public struct AlarmSettings
    {
        public int daySetting;
        public int hourSetting;
        public AlarmSettings(int daySetting, int hourSetting)
        {
            this.daySetting = daySetting;
            this.hourSetting = hourSetting;
        }
    }
    [TestClass]
    public class Alarm
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
