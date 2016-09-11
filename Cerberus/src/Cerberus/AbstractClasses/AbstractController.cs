using Cerberus.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.AbstractClasses
{
    public class AbstractController : Controller
    {
        protected MainContext context;

        public AbstractController(MainContext Context)
        {
            context = Context;
        }
    }
}
