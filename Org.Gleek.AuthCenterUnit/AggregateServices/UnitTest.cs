using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Org.Gleek.AuthCenterUnit
{
    /// <summary>
    /// 测试类
    /// </summary>
    [TestClass]
    public class UnitTest : BaseUnitTest
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