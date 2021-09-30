using FinalApi_ASPNETCORE.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FinalApi_ASPNETCORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmploeeView : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnv;
        private readonly EmployeeContext _context;

        public EmploeeView(EmployeeContext context, IHostingEnvironment hostingEnv)
        {
            _hostingEnv = hostingEnv;
            _context = context;
        }

        
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] EmployeeViewModel empVM)
        {

            if (empVM.Image != null)
            {
                var a = _hostingEnv.WebRootPath;
                var fileName = Path.GetFileName(empVM.Image.FileName);
                var filePath = Path.Combine(_hostingEnv.WebRootPath, "images\\Employees", fileName);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await empVM.Image.CopyToAsync(fileSteam);
                }

                Employee employee = new Employee();
                employee.Name = empVM.Name;
                employee.Occupation = empVM.Occupation;
                employee.ImagePath = filePath;  //save the filePath to database ImagePath field.
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
