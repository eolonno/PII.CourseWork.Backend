using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection collection); //collection yüklenecek.
        //örnek collectionlar => IHttpAccessor(İstek takipçisi), caching => ICacheManager
    }
}