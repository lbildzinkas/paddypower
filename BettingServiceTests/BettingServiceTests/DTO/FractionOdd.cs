namespace BettingService.Tests.DTO
{
    public class FractionOdd
    {
        private readonly int _odd1;
        private readonly int _odd2;

        public FractionOdd(int odd1, int odd2)
        {
            _odd1 = odd1;
            _odd2 = odd2;
        }

        public decimal ConvertToDecimal()
        {
            return ((decimal)_odd1/(decimal)_odd2) + 1;
        }

        public override string ToString()
        {
            return $"{_odd1}/{_odd2}";
        }
    }
}