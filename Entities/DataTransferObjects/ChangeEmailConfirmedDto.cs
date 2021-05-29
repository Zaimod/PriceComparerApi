using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class ChangeEmailConfirmedDto
    {
        public string code { get; set; }
        public string userName { get; set; }
    }
}
