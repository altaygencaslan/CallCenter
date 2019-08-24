using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CallCenter.Business.Tests
{
    [TestClass]
    public class WhenCallCenterDbContextIsCreated
    {
        [TestMethod]
        public void CallCenterDbContext_InstanceCreate_IsSuccess()
        {
            CallCenterDbContext callCenterDbContext = new Business.CallCenterDbContext();
            Assert.IsNotNull(callCenterDbContext, "success!");
        }
        
    }
}
