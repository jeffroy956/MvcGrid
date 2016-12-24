using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGrid.Models
{
    public class YearsAgo
    {
        public static string ReplaceContentLabels(string content, int baseYear, int numToReplace)
        {
            for(int i = 0; i <= numToReplace; i++)
            {
                content = content.Replace("${" + i + "YearsAgoLabel}", (baseYear - i).ToString());
            }

            return content;
        }

        public static string ReplaceContentLabels(string content, int baseYear)
        {
            return ReplaceContentLabels(content, baseYear, 5);
        }

        public static string LabelFor(int yearsAgo)
        {
            return (DateTime.Now.Year - yearsAgo).ToString();
        }

    }
}