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
    public class AppLoadTests {
        [TestMethod]
        public void AppLoadDiskRoundtrip() {
            // There is so much wrong here I don't know where to begin...
            // Refactor this byzantine load/store thing to use a platform service
            // Use more self-describing persistence strategy for messages, to avoid need to set
            //   "Name" before loading
            // Also, concerns are inappropriately mixed, should CREATE then SAVE object, not do
            //   this as a single bundled/atomic action

            Crittercism.AppID=TestHelpers.VALID_APPID;
            AppLoad newMessageReport = new AppLoad();

            try {    
                newMessageReport.Save();
                AppLoad loadedMessageReport=(AppLoad)MessageReport.LoadMessage(newMessageReport.Name);
            
                // TODO(DA) should do overlaoded object equality test here
                // We can't right now because types get mangled when round-tripping to/from JSON :/
                //Assert.IsTrue(newMessageReport.Equals(loadedMessageReport));

                Assert.AreEqual(JsonConvert.SerializeObject(newMessageReport),
                    JsonConvert.SerializeObject(loadedMessageReport));
            } finally {
                newMessageReport.Delete();
            }
        }

        [TestMethod]
        public void AppLoadFormat() {
            UnifiedAppLoad newMessageReport = new UnifiedAppLoad(TestHelpers.VALID_APPID);
            UnifiedAppLoadInner inner = newMessageReport.appLoads;

            Assert.AreEqual(newMessageReport.count, 1);
            Assert.AreEqual(newMessageReport.current, true);
            Assert.AreEqual(inner.osName,Crittercism.OSName);
            Assert.AreEqual(inner.carrier, "Fake GSM Network");     // On emulator
        }
    }
}
