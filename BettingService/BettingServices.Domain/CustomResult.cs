using System.Collections.Generic;

namespace BettingServices.Domain
{
    public class CustomResult
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public IList<CustomResult> ChildResults { get; set; }
    }
}