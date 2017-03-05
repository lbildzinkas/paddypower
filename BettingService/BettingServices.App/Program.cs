using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettingServices.Domain;
using BettingServices.Services;
using BettingServices.Domain.DomainServices;

namespace BettingServices.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventService = new EventService(new ProfitCalculatorService());

            var eventName = "Paddy Power Cup Final";
            Console.WriteLine($"CreatingEvent {eventName}");
            var bettingEvent = EventBuilder.CreateEvent(eventName, Sport.Football);

            var marketName = "Outright result in normal time";

            var market1 = EventBuilder.CreateMarket(marketName);
            bettingEvent.WithMarket(market1);

            var team1Win = EventBuilder.CreateSelection(11, 4, true, 1, 0);
            market1.WithSelection(team1Win);
            var team2Win = EventBuilder.CreateSelection(13, 5, true, 0, 1);
            market1.WithSelection(team2Win);
            var draw = EventBuilder.CreateSelection(4, 6, true, 0, 0);
            market1.WithSelection(draw);

            var marketName2 = "Correct Score";

            var market2 = EventBuilder.CreateMarket(marketName2);
            bettingEvent.WithMarket(market2);

            var team1W1X0 = EventBuilder.CreateSelection(4, 9, false, 1, 0);
            market2.WithSelection(team1W1X0);
            var team1W2X0 = EventBuilder.CreateSelection(11, 2, false, 2, 0);
            market2.WithSelection(team1W2X0);
            var team1W2X1 = EventBuilder.CreateSelection(22, 1, false, 2, 1);
            market2.WithSelection(team1W2X1);
            var team1W3X0 = EventBuilder.CreateSelection(55, 1, false, 3, 0);
            market2.WithSelection(team1W3X0);
            var team1W3X1 = EventBuilder.CreateSelection(255, 1, false, 3, 1);
            market2.WithSelection(team1W3X1);
            var draw0X0 = EventBuilder.CreateSelection(9, 2, false, 0, 0);
            market2.WithSelection(draw0X0);
            var draw1X1 = EventBuilder.CreateSelection(175, 1, false, 1, 1);
            market2.WithSelection(draw1X1);
            var draw2x2 = EventBuilder.CreateSelection(225, 1, false, 2, 2);
            market2.WithSelection(draw2x2);
            var team2W1X0 = EventBuilder.CreateSelection(12, 1, false, 0, 1);
            market2.WithSelection(team2W1X0);
            var team2W2x0 = EventBuilder.CreateSelection(9, 2, false, 0, 2);
            market2.WithSelection(team2W2x0);
            var team2W2X1 = EventBuilder.CreateSelection(17, 1, false, 1, 2);
            market2.WithSelection(team2W2X1);
            var team2W3X0 = EventBuilder.CreateSelection(16, 5, false, 0, 3);
            market2.WithSelection(team2W3X0);
            var team2W3X1 = EventBuilder.CreateSelection(14, 1, false, 1, 3);
            market2.WithSelection(team2W3X1);


            var eventName1 = "L Harte v C Ryan tennis match";
            Console.WriteLine($"CreatingEvent {eventName}");

            var tennisBettingEvent = EventBuilder.CreateEvent(eventName1, Sport.Tennis);

            var tennisMarketName = "Match Betting market";
            var tennisMarket1 = EventBuilder.CreateMarket(tennisMarketName);
            tennisBettingEvent.WithMarket(tennisMarket1);

            var play1Win = EventBuilder.CreateSelection(9, 4, true, 1, 0);
            tennisMarket1.WithSelection(play1Win);
            var play2Win = EventBuilder.CreateSelection(3, 10, true, 0, 1);
            tennisMarket1.WithSelection(play2Win);

            tennisMarketName = "To win Set 2 1 st game";
            var tennisMarket2 = EventBuilder.CreateMarket(tennisMarketName);
            tennisBettingEvent.WithMarket(tennisMarket2);

            var play1WinGame1 = EventBuilder.CreateSelection(4, 7, false, 1, 0).
                WithTennisWinningConditions(1, true, true, 2);
            tennisMarket2.WithSelection(play1WinGame1);
            var play2WinGame1 = EventBuilder.CreateSelection(5, 4, false, 0, 1).
                WithTennisWinningConditions(1, true, false, 2);
            tennisMarket2.WithSelection(play2WinGame1);


            Console.WriteLine($"Registering Bets");

            bettingEvent.WithBet(EventBuilder.CreateBet(4m, team1Win));
            tennisBettingEvent.WithBet(EventBuilder.CreateBet(5m, play2WinGame1));
            tennisBettingEvent.WithBet(EventBuilder.CreateBet(5m, play2Win));
            bettingEvent.WithBet(EventBuilder.CreateBet(2m, team1W3X1));
            bettingEvent.WithBet(EventBuilder.CreateBet(1m, team2W1X0));
            tennisBettingEvent.WithBet(EventBuilder.CreateBet(5m, play1WinGame1));
            bettingEvent.WithBet(EventBuilder.CreateBet(2m, team1W3X1));
            bettingEvent.WithBet(EventBuilder.CreateBet(1m, team2W2X1));
            bettingEvent.WithBet(EventBuilder.CreateBet(4m, draw));
            bettingEvent.WithBet(EventBuilder.CreateBet(2m, team1Win));
            bettingEvent.WithBet(EventBuilder.CreateBet(10m, team1W2X0));
            tennisBettingEvent.WithBet(EventBuilder.CreateBet(6m, play2Win));
            bettingEvent.WithBet(EventBuilder.CreateBet(1m, team2Win));
            tennisBettingEvent.WithBet(EventBuilder.CreateBet(0.5m, play1Win));
            bettingEvent.WithBet(EventBuilder.CreateBet(2m, team1W2X0));
            bettingEvent.WithBet(EventBuilder.CreateBet(1m, team2Win));
            tennisBettingEvent.WithBet(EventBuilder.CreateBet(1m, play1WinGame1));
            bettingEvent.WithBet(EventBuilder.CreateBet(11m, team1W1X0));

            Console.WriteLine($"Results:");

            Console.WriteLine($"Clonskeagh 2 - 1 Tallaght");
            Console.WriteLine($"C Ryan beats L Harte outright");
            Console.WriteLine($"L Harte wins Set 2 1 st game");

            bettingEvent.WithScoreResults(2, 1);
            tennisBettingEvent.WithScoreResults(0, 3);
            tennisBettingEvent.WithGame(2, 1, true);

            var total1 = 0m;
            var total2 = 0m;

            total1 = eventService.CalculateEventProfitAsync(bettingEvent).Result;

            total2 = eventService.CalculateEventProfitAsync(tennisBettingEvent).Result;


            Console.WriteLine($"Calculating profit:");
            Console.WriteLine(total1);
            Console.WriteLine(total2);

            Console.WriteLine($"Balance: {total1 + total2}");
            Console.ReadKey();
        }
    }
}
