using System;
using com.shephertz.app42.paas.sdk.csharp;
using IApp42CallBack = com.shephertz.app42.paas.sdk.csharp.App42CallBack;

namespace LooneyInvaders.Services.App42
{
    public class App42CallbackHandler : IApp42CallBack
    {
        public Action OnErrorCallback { get; set; }
        public Action<App42Exception> OnExceptionCallback { get; set; }
        public object Response { get; set; }
        public bool IsSuccess { get; private set; }

        public void OnException(Exception ex)
        {
            Console.WriteLine($"{nameof(App42CallbackHandler)} {nameof(OnException)}'s Exception is: " + ex);
            try
            {
                OnExceptionCallback?.Invoke(ex as App42Exception);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{nameof(App42CallbackHandler)} {nameof(OnException)}'s Internal exception is: " + e);
            }
            finally
            {
                Response = ex;
            }
        }

        public void OnSuccess(object response)
        {
            IsSuccess = true;
            Response = response;
        }
    }
}
