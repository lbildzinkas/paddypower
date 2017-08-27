# paddypower interview challenge

Background
Domain Model
Punter – represents the customer
Bookmaker – represents the company offering betting opportunities for money
Event – represents a sporting event that a punter can place a bet on. i.e. The Champions League Final
Market – represents a facet of the game that a punter can place a bet on. i.e. The outcome of the event in regular time, or the total number of goals scored by a team in regular time
Selection – represents a possible outcome for a market. A punter will place a bet on a selection. A selection will have odds representing the likelihood of the selection being a winner. A selections’ odds will change over time. i.e. For the event outcome market, there are 3 selections; Team A can win, Team B can win or it could end in a draw. A punter can place a bet on one of these 3 selections
Bet – represents a bet placed by a punter on a selection. It captures a selection and the odds given to the punter at the time the bet was placed. i.e. A punter places a €10 bet at 8/1 on Team A being the winner of  The Champions League Final
Stake – the amount of money wagered by the company. i.e. the punter placed a bet of €5
Price – the odds the punter received by the punter from the bookmaker for a bet. i.e. the punter placed a bet of €5 at a price of 10/1
An event will have multiple markets. A market will have multiple selections.
Betting explained
Long before a real world event kicks off, we create an Event-Market-Selection hierarchy that represents this event. Once created, punters can place bets on these Selections. A punter will give the bookmaker the stake when the bet is placed. When the event is finished, each Selection is settled as a winner or loser. When a Selection is settled as a winner or loser, all bets associated with that Selection are settled as a winner or loser. A punter with a winning bet will receive his original Stake plus the Stake times the Price.
Example A. A punter will placed a bet for €10 at a price of 2/1 for Team A to win The Champions League Final. The punter gives the bookmaker €10 at the time the bet is placed. Later, Team A wins the Champions League Final. The punter receives his €10 plus his winnings of €20 (€10 * 2/1) 
Example B. A punter will placed a bet for €10 at a price of 2/1 for Team B to win The Champions League Final. The punter gives the bookmaker €10 at the time the bet is placed. Later, Team A wins the Champions League Final. The punter loses his stake and receives nothing.


Problem to solve
Background Detail
There are 2 markets for the Paddy Power Cup Final soccer match
Outright result in normal time (3 selections)
Clonskeagh to win @ 11/4
Tallaght to win @  13/5
Draw @ 4/6
Correct Score     (13 selections)
Clonskeagh 1-0 @ 4/9
Clonskeagh 2-0 @ 11/2
Clonskeagh 2-1 @ 22/1
Clonskeagh 3-0 @ 55/1
Clonskeagh 3-1  @ 255/1
Draw 0-0 @ 9/2
Draw 1-1 @ 175/1
Draw 2-2  @ 225/1
Tallaght 1-0 @ 12/1
Tallaght 2-0 @ 9/2
Tallaght 2-1  @17/1
Tallaght 3-0 @ 16/5
Tallaght 3-1 @14/1

There are 2 markets for L Harte v C Ryan tennis match
Match Betting market (2 selections)
L Harte to win @ 9/4
C Ryan to win @ 3/10
To win Set 2 1st game (2 selections)
L Harte to win @ 4/7
C Ryan to win @ 5/4

The Following bets are made (All bets are from different customers and assume odds do not change over time)
Customer bets €4 that Clonskeagh win (outright winner)
Customer bets €5 that C Ryan win Set 2 1st game (Set 2 1st game winner) 
Customer bets €5 that C Ryan win (outright winner)
Customer bets €2 that Clonskeagh win 3-1 
Customer bets €1 that Tallaght win 1-0 
Customer bets €5 that L Harte win Set 2 1st game (Set 2 1st game winner)
Customer bets €2 that Clonskeagh win 3-1 
Customer bets €1 that Tallaght win 2-1 
Customer bets €4 that Clonskeagh draw with Tallaght 
Customer bets €2 that Clonskeagh win (outright winner)
Customer bets €10 that Clonskeagh win 2-0 
Customer bets €6 that C Ryan win (outright winner)
Customer bets €1 that Tallaght win (outright winner)
Customer bets €0.5 that L Harte win (outright winner)
Customer bets €2 that Clonskeagh win 2-0 
Customer bets €1 that Tallaght win (outright winner)
Customer bets €1 that L Harte win Set 2 1st game (Set 2 1st game winner)
Customer bets €11 that Tallaght win 1-0 

The results of the events are as follows
Clonskeagh 2-1 Tallaght
C Ryan beats L Harte outright
L Harte wins Set 2 1st game 

Problem
Create a C# solution that models the following scenario:
Create a football event called ‘Paddy Power Cup Final’ that kicks off on 1st June 2020 at 14:00 Hrs. A teams playing called ‘Clonskeagh’ and ‘Tallaght’
Create a tennis event called ‘PP group D match 6’ that starts on 17th March 2018 at 15:15 Hrs. A teams playing called ‘L Harte’ and ‘C Ryan’
Calculate the profit or loss to the bookmaker after all winnings are paid out.
In other words, you should create a program that faithfully models the problem at hand. Using that model, you’ll need to resolve the problem by analysing which selections win/lose and then calculating the company’s profit/loss. Your program should use the standard output to display its result, i.e.: per-selection result and global profit/loss.

