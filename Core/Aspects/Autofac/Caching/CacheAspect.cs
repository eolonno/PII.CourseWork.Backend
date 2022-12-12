using System.Linq;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private readonly ICacheManager _cacheManager;
        private readonly int _duration; //memory'de kalma süresi

        public CacheAspect(int duration = 60) //constructor
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation) //invocation => method
        {
            //Method.ReflectedType.FullName => namespace of the part of the method
            //We use the method's namespace, the interface and the name of the method when giving Cache Keys. With the key given in this way, the method to be cached can be found immediately.
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments =
                invocation.Arguments
                    .ToList(); //arguments = parameters of the method. We give this as a list with the parameters as elements.
            var key =
                $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})"; // when generating the key, add the parameters if there are any. otherwise leave the parameters as null.
            if (_cacheManager.IsAdd(key)) //cache mevcut mu?
            {
                invocation.ReturnValue =
                    _cacheManager
                        .Get(key); //cache, then just get the cache given by the key value from memory and send it as the return value of the method.
                return;
            }

            invocation.Proceed(); //cache memoryde mevcut değil. o zaman methodu çalıştır.
            _cacheManager.Add(key, invocation.ReturnValue, _duration); //methodu çalıştırdıktan sonra cacheye de ekle.
        }
    }
}