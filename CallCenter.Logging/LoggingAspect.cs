using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace CallCenter.Logging
{
    public class LoggingAspect : IInterceptionBehavior
    {
        public bool WillExecute
        {
            get
            {
                return true;
            }
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            //İsteğe bağlı loglama işlemleri:

            Console.WriteLine("{0} metodu {1} tarihinde çalıştırıldı.", input.MethodBase.Name, DateTime.Now);
            var result = getNext()(input, getNext);

            if (result.Exception != null)
                Console.WriteLine("{0} metodu {1} tarihinde hata verdi. Hata Mesajı: {3}", input.MethodBase, DateTime.Now, result.Exception.Message);
            else
                Console.WriteLine("{0} metodu {1} tarihinde dönüş yaptı. Dönüş cevabı: ", input.MethodBase, DateTime.Now, result.ReturnValue);

            return result;
        }
    }
}
