using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedSmart.Core.Domain.Application.DTOs
{
    public class RegisterDto
    {
        public string username { get; set; }
        public string password { get; set; }
        public string gmail { get; set; }
    }
}
