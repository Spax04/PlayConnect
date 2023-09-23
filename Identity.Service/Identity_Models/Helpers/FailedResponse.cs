using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity_Models.Helpers
{
    public class FailedResponse : Response
    {
        public string ErrorMassage { get; set; }
        public FailedResponse(string massage) : base(false)
        {
            ErrorMassage = massage;
        }
    }
}
