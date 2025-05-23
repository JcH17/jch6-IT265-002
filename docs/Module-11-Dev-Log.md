
## Name: Justin Herbert
### Module: 11

### Date: [5/9/2025]

#### Goals for this Module

[x]Create Player Movement
Create a Player token GameObject.
Write a PlayerMovement script:
Player clicks a "Roll Dice" button.
Dice roll gives a number (1–6).
Player moves across the board based on tile spaces.

 [x]Dice Roll System
-Create a DiceManager script:
-Randomly pick a number between 1 and 6
-Animate dice roll (optional).
-Output result to a UI Text or Dice Image.

[x]Create a TileInteractionManager script that manages what happens when a player lands
-Regular Tile → Draw Regular Decision Card
-Wisdom Tile → Draw Wisdom Card
-Crown Tile → Draw Crown Card
-Crisis Tile → Draw Crisis Card
-Wealth Tile → Open building option
-Tax Tile → Gain Gold

[x]Create a CardManager script:
-Have different decks (Crisis Cards, Wisdom Cards, Crown Cards, etc.).
-Randomly draw a card from the correct deck when triggered.
-Display card UI (Card Title, Card Description, Choices).
-Handle player choices (gain or spend resources).


[x]Track Resources:
-Gold (Wealth)
-Crown Points
-Wisdom Points
-Create a PlayerStats script to update and display resources on the UI.


#### Progress
- **What I accomplished**:
    Implemented smooth player token movement based on dice rolls. Players roll a die (1–6) and move along the board’s tile path accordingly.
Developed a fully functional dice system that generates a random value (1–6), with a visual animation and output display via UI.
Created a modular TileInteractionManager that detects tile types and triggers appropriate actions, such as drawing decision cards or gaining gold.
Built a flexible CardManager that supports multiple card decks (Crisis, Wisdom, Crown, etc.), shows card UI, and lets players make decisions that affect resources.
Designed a PlayerStats system to manage and display key resources: Gold, Crown Points, and Wisdom Points and they are all updated in real-time on the UI.
- **Challenges faced**:
  - I ran into issues of card effects. Initially, resource gains (for example, "Gain 100 gold") were incorrectly processed using spend gold function and resulted in logic failures and prevented players from gaining resources especially when starting with 0.
  - The game mistakenly checked whether players could “afford” positive resource gains, causing even free rewards to be blocked due to low resource amounts.
  - I made early logic that didn’t distinguish between positive (gain) and negative (cost) values, leading to confusion and improper updates of gold, crown, and wisdom stats.
- **Solutions**:
  - Created a function that checks for whether each value is a gain or cost and then call the right method so that the resources change correctly
  - Added a UI indication to show a clear message when a player lacks the required resource
  - Rewrote a function in my script a few times and finally made sure that a player no longer gets blocked from acquiring free resources from some cards whenever they have low or 0 resources
  - Had some inconsistencies with one of my functions that handles card effects and had to delete some lines.
#### Learnings
- Found out about Queue<T> for c# which stores elements in a first in and first out order. This helped with my player movement when going from their current tile to their next tile.
- Learned to assign button clicks via script instead of the inspector. In a game I worked on before I used the second way to assign functionality to buttons to use a public method created via script. Instead I tried using the other way around and used addlistener and removelistener methods to manage the events for UI buttons.


#### Free Thinking
-N/A

#### Next Steps
- Work on player management. Start of the game will ask how many players will be playing and will generate playertokens along with their own stats panel based on the answer(only 1-4 player)
- Turn system
- Policy card effects
- Develop end game wrap up. Tally all resources from players and show who the winner is along with their title.
