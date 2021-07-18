using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.BLL.Interfaces;

namespace Library.Web.Controllers
{
    public abstract class CrudController<TViewModel> : Controller 
        where TViewModel : class
    {
        //[HttpGet]
        //protected virtual Task<IActionResult> Add()
        //{
        //    return View();
        //}
        //[HttpPost]
        //protected virtual Task<IActionResult> Add(TViewModel item)
        //{
        //    throw new NotImplementedException();
        //}
        //protected virtual Task<IActionResult> Delete()
        //{
           
        //}
        //protected virtual Task<IActionResult> Edit()
        //{
        //    throw new NotImplementedException();
        //}
        //protected virtual Task<IActionResult> Update()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
