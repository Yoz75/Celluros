## This library provides for you a simple solution for cellular automata creating! (Dart original: https://github.com/peaashmeter/ceditor)

## API:
GoL in Celluros example (without execution and render, this is user deals):<br>
```cs
Cell dead = new(0);
Cell alive = new(1);

var randomRule = new Rule(1);
randomRule.Conditions.Add(new AlwaysCondition(0.5f, alive));

var golRule = new Rule(100);
var beAlive = new NearCondition(1, dead, alive, alive, 3);
var die = new NearCondition(1, alive, dead, dead, 0, 1, 2, 3, 4, 7, 8);

golRule.Conditions.Add(beAlive);
golRule.Conditions.Add(die);

AutomatonExecuter automaton = new();
automaton.Rules.Add(randomRule);
automaton.Rules.Add(golRule);
```
Every automaton executes by a AutomatonExecuter. Every action in automaton provided by Rule class for example, in GoL we used randomRule (randomly place alive cells) and golRule (game of life logics).<br>
Every rule consists of Conditions. Conditions are change the type of cell at some point. For example beAlive in GoL is a newar condition. It changes dead  cell to alive with chancw 1, if near this cell 3 alive cells.
