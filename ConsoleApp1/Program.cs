// See https://aka.ms/new-console-template for more information

using ConsoleApp1;
using System;

static IEnumerable<string> Suits()
{
    yield return "clubs";
    yield return "diamonds";
    yield return "hearts";
    yield return "spades";
}

static IEnumerable<string> Ranks()
{
    yield return "two";
    yield return "three";
    yield return "four";
    yield return "five";
    yield return "six";
    yield return "seven";
    yield return "eight";
    yield return "nine";
    yield return "ten";
    yield return "jack";
    yield return "queen";
    yield return "king";
    yield return "ace";
}


var startingDeck = from s in Suits()
                   from r in Ranks()
                   select new { Suit = s, Rank = r };
 
foreach (var card in startingDeck)
{
    Console.WriteLine(card);
}

//Redis
//StackE_Redis.Read();

var top = startingDeck.Take(26);
var bottom = startingDeck.Skip(26);



// The Three Parts of a LINQ Query:
// 1. Data source.
int[] numbers = [0, 1, 2, 3, 4, 5, 6,88,76,90];

// 2. Query creation.
// numQuery is an IEnumerable<int>
var numQuery =
    from num in numbers
    where (num % 2) == 0
    select num;

// 3. Query execution.
foreach (int num in numQuery)
{
    Console.Write("{0,1} ", num);
}

Console.WriteLine(Environment.NewLine);
IEnumerable<int> highScoresQuery =
    from score in numbers
    where score > 80
    orderby score descending
    select score;

foreach (int num in highScoresQuery)
{
    Console.WriteLine("{0,1} ", num);
}



Console.WriteLine(Environment.NewLine);
IEnumerable<string> highScoresQuery2 =
    from score in numbers
    where score > 80
    orderby score descending
    select $"The score is {score}";

foreach (string  num in highScoresQuery2)
{
    Console.WriteLine("{0,1} ", num);
}

uint a = uint.MaxValue;

unchecked
{
    Console.WriteLine(a + 3);  // output: 2
}

try
{
    checked
    {
        Console.WriteLine(a);
    }
}
catch (OverflowException e)
{
    Console.WriteLine(e.Message);  // output: Arithmetic operation resulted in an overflow.
}


