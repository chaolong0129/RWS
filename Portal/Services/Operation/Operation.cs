using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal
{
    public class Operation : IOperationTransient, IOperationScoped, IOperationSingleton, IOperationInstance
    {
        private Guid? _empty;
        public Operation(){}

        public Operation(Guid empty)
        {
            _empty = empty;
        }

        Guid IOperation.OperationId
        {
            get
            {
                if (!_empty.HasValue)
                    _empty = Guid.NewGuid();

                return _empty.Value;
            }
        }
    }
}
