using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGrid.Helpers
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string message) : base(message)
        {

        }

    }
}