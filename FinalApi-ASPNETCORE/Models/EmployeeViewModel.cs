using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalApi_ASPNETCORE.Models
{
    public class EmployeeViewModel
    {
        public string Name { get; set; }

        public string Occupation { get; set; }
        public IFormFile Image { get; set; }
    }
}
