using System;
using System.Collections.Generic;

namespace BettingService.Tests.Domain
{
    public class WinningCondition
    {
        //todo: implementing different strategies for winning conditions
        public bool IsOutright { get; set; }
        public bool TeamAWin { get; set; }
        public bool TeamBWin { get; set; }
        public bool Draw { get; set; }
        public int TeamAScore { get; set; }
        public int TeamBScore { get; set; }
        public Dictionary<string, CustomCondition> CustomCondition { get; set; }
    }

    public class CustomCondition
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public IList<CustomCondition> ChildConditions { get; set; }
    }
}