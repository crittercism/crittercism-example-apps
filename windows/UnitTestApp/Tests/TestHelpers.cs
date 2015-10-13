using CrittercismSDK;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestApp.Tests {
    class TestHelpers {
        public const string VALID_APPID = "50807ba33a47481dd5000002";

        public static void CheckCommonJsonFragments(String loadedJsonMessage) {
            Platform p = new Platform();
            string[] jsonStrings = new string[] {
                "\"app_id\":\"50807ba33a47481dd5000002\"",
                "\"app_state\":{\"app_version\":\"" + System.Windows.Application.Current.GetType().Assembly.GetName().Version.ToString() + "\"",
                "\"battery_level\":",
                "\"platform\":{\"client\":",
                "\"device_id\":\"" + p.device_id + "\"",
                "\"device_model\":",
                "\"os_name\":",
                "\"os_version\":",
                "\"locale\":",
            };
            foreach (string jsonFragment in jsonStrings) {
                Assert.IsTrue(loadedJsonMessage.Contains(jsonFragment));
            }
            // Make sure DateTimes are stringified in the canonical way and not in this goofy default way
            Assert.IsFalse(loadedJsonMessage.Contains("Date("));
        }

        public static void CleanUp() {
            // This method is for clean all the possible variables that may be will used by another unit test
            Crittercism._autoRunQueueReader = true;
            Crittercism._enableCommunicationLayer = true;
            Crittercism._enableRaiseExceptionInCommunicationLayer = false;
            Crittercism.OptOut = false;
            while (Crittercism.MessageQueue != null && Crittercism.MessageQueue.Count > 0) {
                MessageReport message = Crittercism.MessageQueue.Dequeue();
                message.Delete();
            }
            // Some unit tests might pollute the message folder.  clean those up
            try {
                IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
                foreach (string file in storage.GetFileNames("")) {
                    storage.DeleteFile(file);
                }
            } catch (Exception ex) {
                Console.WriteLine("cleanUp exception: " + ex);
            }
        }

        public static void InitializeLeaveLoadOnQueue(string appId) {
            StartApp(appId, true);
        }
        
        public static void InitializeRemoveLoadFromQueue(string appId) {
            StartApp(appId, false);
        }

        private static void StartApp(string appId, bool leaveAppLoadOnQueue) {
            Crittercism._autoRunQueueReader = false;
            Crittercism.Init(appId);
            if (!leaveAppLoadOnQueue) {
                MessageReport message = Crittercism.MessageQueue.Dequeue();
                message.Delete();
            }
        }

        public static void ThrowDivideByZeroException() {
            int i = 0;
            int j = 5;
            int k = j / i;
        }
    }
}
