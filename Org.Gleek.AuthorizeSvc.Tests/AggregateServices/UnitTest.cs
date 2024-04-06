using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Org.Gleek.AuthorizeSvc.Tests
{
    /// <summary>
    /// 测试类
    /// </summary>
    [TestClass]
    public class UnitTest : BaseTest
    {
        /// <summary>
        /// 测试方法
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestAsync()
        {
            //var testAggregateService = AutofacProvider.GetService<TestAggregateService>();
            //var isSuccess = await testAggregateService.TestAsync();
            //Assert.IsTrue(isSuccess);
            Assert.IsTrue(true);
            await Task.CompletedTask;
        }
    }
}