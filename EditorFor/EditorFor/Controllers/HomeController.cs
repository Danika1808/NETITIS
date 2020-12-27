using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EditorFor.Models;

namespace EditorFor.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            var testModel = new SomeEntity
            {
                IntProperty = 123,
                LongProperty = 1234567890,
                BoolProperty = true,
                StringProperty = "Hello",
                EnumProperty = Models.Enum.Option1,
                ClassProperty = new NestedClass
                {
                    NestedIntProperty = 9,
                    NestedStringProperty = "World"
                }
            };
            return View(testModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
