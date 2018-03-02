using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Portal.Controllers
{
    public class OperationController : Controller
    {
        private IOperationTransient _operationTransient { get; set; }
        private IOperationScoped _operationScoped { get; set; }
        private IOperationSingleton _operationSingleton { get;  set; }
        private IOperationSingleton _operationSingletonInstance { get;  set; }

        public OperationController(
            IOperationTransient operationTransient,
            IOperationScoped operationScoped,
            IOperationSingleton operationSingleton,
            IOperationSingleton operationSingletonInstance
            )
        {
            _operationTransient = operationTransient;
            _operationScoped = operationScoped;
            _operationSingleton = operationSingleton;
            _operationSingletonInstance = operationSingletonInstance;
        }

        public IActionResult Index()
        {
            ViewBag.Transient = _operationTransient.OperationId;
            ViewBag.Scoped = _operationScoped.OperationId;
            ViewBag.Singleton = _operationSingleton.OperationId;
            ViewBag.Instance = _operationSingletonInstance.OperationId;
            return View();
        }
    }
}