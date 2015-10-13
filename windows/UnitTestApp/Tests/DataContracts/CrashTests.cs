using CrittercismSDK;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestApp.Tests.DataContracts {
    [TestClass]
    public class CrashTests {
        /// <summary>
        /// Returns a Crash object with a well-formed stack trace, like a real stack trace would. 
        /// </summary>
        /// We end up using a roundabout procedure beacuse I want the function to have Crash
        /// return type, so all code paths must return that type, even if one path is unreachable
        /// by dint of always throwing a (caught) exception.
        /// <returns></returns>
        private Crash GetCrashMessage() {
            var crEx = new ExceptionObject("Unreachable", "Unreachable", "Unreachable");
            
            try {
                int i = 1;
                int j = 0;
                var k = i / j;

                // This is unreachable; above always throws divide-by-zero
                return new Crash(TestHelpers.VALID_APPID,
                    new Dictionary<string,string>(),Breadcrumbs.SessionStart(),crEx);
            } catch(Exception ex) {
                crEx = new ExceptionObject(ex.GetType().FullName, ex.Message, ex.StackTrace);
                return new Crash(TestHelpers.VALID_APPID,
                    new Dictionary<string,string>(),Breadcrumbs.SessionStart(),crEx);
            }
        }
        
        [TestMethod]
        public void CrashLoadAfterSaveTest() {
            var crash = GetCrashMessage();
            string expectedJson = JsonConvert.SerializeObject(crash);

            try {
                crash.Save();
                Crash messageReportLoaded=(Crash)MessageReport.LoadMessage(crash.Name);
                var actualJson = JsonConvert.SerializeObject(messageReportLoaded);

                Assert.AreEqual(expectedJson, actualJson);
            } finally {
                crash.Delete();
            }
        }

        [TestMethod]
        public void CrashHasExpectedDataItemsTest() {
            TestHelpers.InitializeRemoveLoadFromQueue(TestHelpers.VALID_APPID);
            var crash = GetCrashMessage();

            Assert.AreEqual(crash.app_id, TestHelpers.VALID_APPID);
            Assert.AreEqual(crash.crash.name, "System.DivideByZeroException");
            Assert.AreEqual(crash.crash.reason, "Attempted to divide by zero.");
            Assert.AreEqual(crash.crash.stack_trace.Count, 1);
            Assert.AreEqual(crash.crash.stack_trace[0], "   at UnitTestApp.Tests.DataContracts.CrashTests.GetCrashMessage()");
            Assert.IsNotNull(crash.platform.device_id);
            Assert.AreEqual(crash.platform.device_model, "XDeviceEmulator");
            Assert.AreEqual(crash.platform.os_name,Crittercism.OSName);
        }
    }
}
