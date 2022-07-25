using Refit;
using System;

namespace OrdersApi.Proxy
{
    public class RefitProxy
    {
        #region singletion
        private static readonly Lazy<RefitProxy> _instance = new Lazy<RefitProxy>(() => new RefitProxy());
        private RefitProxy()
        {

        }
        public static RefitProxy Instance = _instance.Value;
        #endregion

        public bool CustomerValidation(Guid id)
        {
            ICustomerApi client   = RestService.For<ICustomerApi>("http://localhost:7001/");            
            var response =  client.Validation(id);
            return response.Result;
        }
    }
}
