using System.Reflection;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            // classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger))); bu var olan bütün metodları otomatik loglamak içindir ama bu altyapı şuan yok

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
