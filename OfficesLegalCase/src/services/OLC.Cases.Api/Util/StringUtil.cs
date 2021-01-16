using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OLC.Cases.Api.Util
{
    public static class StringUtil
    {
        public static bool IsValidCaseNumber(this string caseNumber)
        {
            var rx = new Regex(@"([1-9]{9}).([1-9]{4}).([1-9]{1}).([1-9]{2}).([1-9]{4})", RegexOptions.Compiled);

            if (rx.IsMatch(caseNumber))
                return true;

            return false;
        }
    }
}
