using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibrarySystem.Data.UnitOfWork;

namespace LibrarySystem.Web.Infrastructure.ActionFilters
{
    public class SaveChangesFilter : IActionFilter
    {
        private readonly IEfUnitOfWork unitOfWork;

        public SaveChangesFilter(IEfUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            this.unitOfWork.SaveChanges();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Just to satisfy the interface. Cannot decouple from it.
        }
    }
}