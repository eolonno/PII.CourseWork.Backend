using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection collection); //collection will be loaded.
        //example collections => IHttpAccessor(Request tracker), caching => ICacheManager
    }
}