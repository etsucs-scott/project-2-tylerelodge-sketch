## Multiplayer Support
2–4 players  
## Card System
Standard 52-card deck  
Fully randomized shuffle  
## Gameplay Mechanics
Automatic round resolution  
Recursive tie ("war") handling  
## Game Feedback
Displays:  
Cards played each round  
Round winner or tie  
Remaining cards per player  
## Safety
Max round limit (10,000) prevents infinite games  
## Getting Started
Build  
dotnet build  
Run  
dotnet run --project WarGame.Console  
## Choose Number of Players
### Option 1: Command Argument
dotnet run --project WarGame.Console -- 3  
### Option 2: Manual Input
Enter number of players (2-4):  
## Gameplay Rules
### Next Round
To continue playing the game you must press enter to go to the next round  
### Basic Flow
Deck is shuffled and dealt evenly  
Each player draws their top card  
Highest card wins the round  
### Tie Scenario (War)
Tied players draw additional cards  
Process repeats until a winner is determined  
### Game End
One player owns all cards  
OR  
Round limit is reached  
Console-only interface  
No advanced rule variations  
Games may run for a long time  
