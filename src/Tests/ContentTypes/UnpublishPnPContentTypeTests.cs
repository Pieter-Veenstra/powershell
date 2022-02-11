using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace PnP.PowerShell.Tests.ContentTypes
{
    [TestClass]
    public class UnpublishPnPContentTypeTests : PnPTest
    {
        #region Test Setup/CleanUp
        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
             // This runs on class level once before all tests run
            //using (var ctx = TestCommon.CreateClientContext())
            //{
            //}
        }
        #endregion
        #region Scaffolded Cmdlet Tests
        [TestMethod]
        public void UnpublishPnPContentTypeTest()
        {
            using (var scope = new PSTestScope(true))
            {
                var results = scope.ExecuteCommand("Unpublish-PnPContentType",
                    new CommandParameter("ContentType", "0x0101"));

                Assert.IsNotNull(results);
            }
        }
        #endregion
    }
}
            