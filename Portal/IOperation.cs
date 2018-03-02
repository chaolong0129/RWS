using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal
{
    public interface IOperation
    {
        Guid OperationId { get;}
    }

    public interface IOperationTransient : IOperation
    {}
    public interface IOperationScoped : IOperation
    { }
    public interface IOperationSingleton : IOperation
    { }
    public interface IOperationInstance : IOperation
    { }

}
