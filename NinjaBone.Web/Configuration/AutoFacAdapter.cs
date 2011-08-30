using Autofac;
using ServiceStack.Configuration;

namespace NinjaBone.Web.Configuration
{
    public class AutoFacAdapter : IContainerAdapter
    {
        private readonly IContainer container;

        public AutoFacAdapter(IContainer container)
        {
            this.container = container;
        }

        #region IContainerAdapter Members

        public T TryResolve<T>()
        {
            T result;
            container.TryResolve(out result);
            return result;
        }

        public T Resolve<T>()
        {
            var resolve = container.Resolve<T>();
            return resolve;
        }

        #endregion
    }
}