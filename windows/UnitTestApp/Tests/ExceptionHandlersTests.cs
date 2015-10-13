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
    public class ExceptionHandlersTests {
        [TestMethod]
        public void LogHandledExceptionTest() {
            Crittercism._autoRunQueueReader = false;
            TestHelpers.InitializeRemoveLoadFromQueue(TestHelpers.VALID_APPID);

            Crittercism.LeaveBreadcrumb("HandledExceptionBreadcrumb");
            Crittercism.SetValue("favoriteFood", "Texas Sheet Cake");
            TestHelpers.CleanUp(); // drop all previous messages

            try {
                TestHelpers.ThrowDivideByZeroException();
            } catch (Exception ex) {
                Crittercism.LogHandledException(ex);
            }

            HandledException he = Crittercism.MessageQueue.Dequeue() as HandledException;
            he.Delete();
            Assert.IsNotNull(he, "Expected a HandledException message");

            String asJson = JsonConvert.SerializeObject(he);
            TestHelpers.CheckCommonJsonFragments(asJson);
            string[] jsonStrings = new string[] {
                "\"breadcrumbs\":",
                "\"current_session\":[{\"message\":\"HandledExceptionBreadcrumb\"",
                "\"metadata\":{",
                "\"favoriteFood\":\"Texas Sheet Cake\"}",
            };
            foreach (String jsonFragment in jsonStrings) {
                Assert.IsTrue(asJson.Contains(jsonFragment));
            }
        }

        [TestMethod]
        public void HandledUnthrownExceptionTest()
        {
            try {
                Exception exception = new Exception("description");
                exception.Data.Add("MethodName", "methodName");
                Crittercism.LogHandledException(exception);
            } catch (Exception) {
                // logHandledException should not throw its own exception
                // when passed an unthrown user created Exception object
                // with null stacktrace.
                Assert.Fail();
            }
        }
    }
}
