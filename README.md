
# Knerdy Knitter
#### This app generates knitting patterns based on cellular automata rules.
## Description
_The main purpose of this app is to generate a 2-color scarf knitting pattern from a mathematical model. Users are able to change the rule, colors, and the dimensions and see the scarf change immediately. Users are able to save their creations and revisit them later by signing in with a username and password. The mathematical model used was developed by Steven Wolfram in the '80s. It describes one-dimensional cellular automata. The rules governing the creation of these cellular automata are very simple. A cell can be in one of two states: "on" or "off" (represented by two different colors). Whether the cell will be "on" or "off" depends on its current state and the state of the cell to the right of it and the state of the cell to the left of it. A new row of cells is created like this. So, for the scarf, the color of each stitch depends on the color of each of the three stitches in the previous row that are most adjacent to the stitch. This mathematical model is demonstrates that simple rules can produce complex and random patterns. To read more about cellular automata, check out the [Wikipedia article](https://en.wikipedia.org/wiki/Cellular_automaton) or Steven Wolfram's book [A New Kind of Science](http://www.wolframscience.com/nks/), which is free online!_

#### Create Form: 
![alt-text](https://github.com/LinaShadrach/KnerdyKnitter/blob/master/create-pattern-img.png)

#### A scarf generated using rule 30. This rule is classified as "chaotic":
![alt-text](https://github.com/LinaShadrach/KnerdyKnitter/blob/master/scarf-img.png)

## Installation

* `git clone <https://github.com/LinaShadrach/KnerdyKnitter.NET>`

## Set-Up Requirements
_To get the project up and running as is, the following are required:_
* [.NET Core 1.0](https://www.microsoft.com/net/core#windowsvs2015)
* [SSMS](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)
_This project was created using VS 2015, but you can also run the app from the CLI:_
* `> dotnet restore` : to load nuget packages
* `> dotnet build` : to build project
* `> dotnet run`: to run the app. Use `CTRL C` to quit.

## Known Bugs

_None known._

## Support and contact details
_Please contact author through GitHub at username: LinaShadrach_

## Technologies and Resources used
_C#, CSS, D3, Git, GitHub, HTML, Javascript, JQuery, Materialize, .NETCore 1.0 (Entity, Identity, MVC), SSMS, SVG, Visual Studio 2015_

#### Author
_Lina Shadrach_

### License
_MIT_
 Copyright(c) 2016 ***Lina Shadrach***
