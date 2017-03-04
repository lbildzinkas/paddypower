using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BettingService.Tests.Domain;

namespace BettingService.Tests.Services
{
    public class ProfitCalculatorService : IProfitCalculatorService
    {
        private const long Multiplier = 10000;
        public async Task<decimal> CalculateAsync(Event bettingEvent, HashSet<Guid> winnerSelections)
        {
            return await Task.Run(() => { 
                long totalLoss = 0;
                long totalWin = 0;
                var winnerBets = bettingEvent.Bets.Where(b => winnerSelections.Contains(b.SelectionBet.Id));
                var loserBets = bettingEvent.Bets.Where(b => !winnerSelections.Contains(b.SelectionBet.Id));

                var taskLoss = Task.Run(() =>
                {
                    Parallel.ForEach(winnerBets, bet =>
                    {
                        var decimalOdds = bet.SelectionBet.Odd.ConvertToDecimal();
                        var betBalance = decimalOdds * bet.BetAmmount;
                        var amount = (long) (-betBalance * Multiplier);
                        Interlocked.Add(ref totalLoss, amount);
                    });
                });

                var taskWin = Task.Run(() =>
                {
                    Parallel.ForEach(loserBets, bet =>
                    {
                        var amount = (long)(bet.BetAmmount * Multiplier);
                        Interlocked.Add(ref totalWin, amount);
                    });
                });

                Task.WaitAll(taskLoss, taskWin);

                return (((decimal)totalLoss) / Multiplier) + (((decimal)totalWin) / Multiplier);
            });
        }
    }
}