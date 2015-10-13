using CrittercismSDK;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestApp.Tests {
    [TestClass]
    public class MiscTests {
        [TestInitialize]
        public void Init() {
            TestHelpers.InitializeRemoveLoadFromQueue(TestHelpers.VALID_APPID);
        }

        [TestMethod]
        public void TruncatedBreadcrumbTest() {
            // start breadcrumb with sentinel to ensure we don't left-truncate
            string breadcrumb = "raaaaaaaaa";
            for (int x = 0; x < 13; x++) {
                breadcrumb += "aaaaaaaaaa";
            }
            // end breadcrumb with "illegal" chars and check for their presence
            breadcrumb += "zzzzzzzzzz";
            Crittercism.LeaveBreadcrumb(breadcrumb);

            try {
                TestHelpers.ThrowDivideByZeroException();
            } catch (Exception ex) {
                Crittercism.LogHandledException(ex);
            }

            HandledException he = Crittercism.MessageQueue.Dequeue() as HandledException;
            he.Delete();
            Assert.IsNotNull(he, "Expected a HandledException message");
            String asJson = JsonConvert.SerializeObject(he);
            Assert.IsTrue(asJson.Contains("\"breadcrumbs\":"));
            Assert.IsTrue(asJson.Contains("\"raaaaaa"));
            Assert.IsFalse(asJson.Contains("aaaaz"));
            Assert.IsFalse(asJson.Contains("zzz"));
        }

        [TestMethod]
        public void OptOutTest() {
            TestHelpers.InitializeRemoveLoadFromQueue(TestHelpers.VALID_APPID);
            Crittercism._enableRaiseExceptionInCommunicationLayer = true;
            
            Assert.IsTrue(Crittercism.MessageQueue == null || Crittercism.MessageQueue.Count == 0);
            Crittercism.SetOptOutStatus(true);
            Assert.IsTrue(Crittercism.GetOptOutStatus());
            int i = 0;
            int j = 5;
            try {
                int k = j / i;
            } catch (Exception ex) {
                Crittercism.LogHandledException(ex);
            }
            Assert.IsTrue(Crittercism.MessageQueue.Count == 0);
            // Now turn it back on
            Crittercism.SetOptOutStatus(false);
            Assert.IsFalse(Crittercism.GetOptOutStatus());
            try {
                int k = j / i;
            } catch (Exception ex) {
                Crittercism.LogHandledException(ex);
            }
            Assert.IsTrue(Crittercism.MessageQueue.Count == 1);

        }
    }
}
