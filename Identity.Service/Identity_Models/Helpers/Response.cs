using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity_Models.Helpers
{
    public class Response
    {

        public bool isSucceed { get; set; }

        public Response(bool isSucceed)
        {
            this.isSucceed = isSucceed;
        }
    }
}
