using CrittercismSDK;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestApp.Tests.DataContracts {
    [TestClass]
    public class HandledExceptionTests {
        [TestMethod]
        public void HandledExceptionCommunicationTest() {
            TestHelpers.InitializeRemoveLoadFromQueue(TestHelpers.VALID_APPID);
            Crittercism._enableRaiseExceptionInCommunicationLayer = true;
            
            try {
                TestHelpers.ThrowDivideByZeroException();
            } catch (Exception ex) {
                Crittercism.LogHandledException(ex);
                AppLocator appLocator=new AppLocator(TestHelpers.VALID_APPID);
                QueueReader queueReader=new QueueReader(appLocator);
                queueReader.ReadQueue();
            }
        }
    }
}
