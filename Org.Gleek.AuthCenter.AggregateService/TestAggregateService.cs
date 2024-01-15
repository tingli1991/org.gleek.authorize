using Com.GleekFramework.AutofacSdk;

namespace Org.Gleek.AuthCenter.AggregateService
{
    /// <summary>
    /// 
    /// </summary>
    public class TestAggregateService : IBaseAutofac
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> TestAsync()
        {
            return await Task.FromResult(true);
        }
    }
}