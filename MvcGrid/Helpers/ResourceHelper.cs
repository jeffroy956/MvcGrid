using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MvcGrid.Helpers
{
    public static class ResourceHelper
    {

        public static string GetIgniteTemplate(string templateName)
        {
            return GetStringResource($"MvcGrid.Templates.{templateName}.html").Replace("\r\n", "");
        }

        private static string GetStringResource(string fullyQualifiedResourceName)
        {
            string result;
            using (Stream stream = typeof(ResourceHelper).Assembly.GetManifestResourceStream(fullyQualifiedResourceName))
            {
                if (stream == null)
                {
                    throw new ResourceNotFoundException($"Could not find HTML template with resource name {fullyQualifiedResourceName}");
                }
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }

            return result;
        }
    }
}