# IT265 Design Treatment Checkpoint

---
## Video
https://www.youtube.com/watch?v=v8VP4AHV6M0

---
## Change Log
- Due to time constraints and implementation challenges, I was unable to incorporate the Lucky Number feature into the final version of the demo. Although the idea was to add a randomly assigned number to each player that, when rolled, would grant a special bonus, I ran into issues integrating this mechanic into the existing dice system and player logic. Given the limited development window, I chose to prioritize core gameplay features and stability over adding this optional mechanic.

- Due to time contraints and implementation challenges, I was unable to incorporate the War tile feature properly into the final version of the demo. The idea was that players are able to interact with other players and compete for each other's resources. I worked on the war phase whenever a player lands on the war tile but there were issues in player logic where the selected resources weren't being transferred properly to the winner. Given the limited development window, I chose to bench this feature to prioritize the stability of the game and avoid creating more issues.

- Lowered the amount of tiles within the game compared to the physical prototype. When there's a player count up to 4 the game takes a long time to complete since every player needs to roll and select decisions on cards they receive. Even with only two players I felt the game was taking too long which would cause player engagement to decrease so lowering the amount of tiles was ideal and be able to shorten game time. 

- Dice change from 2d6 to 1d6 to better help with the lowered tile amount. If 2d6 was kept then the players were able to easily speed through the game board without being able to collect enough resources from the proper tiles. 1d6 provide the right pacing and players are landing on certain tiles more frequent and be able to collect more of a certain category.

---

## Title
- Live like a King

---

## Concept Statement
- Rule your kingdom through strategic decisions, unpredictable events, and a race for legacy where every roll, choice, and title shapes your royal fate.

---

## Genre and Style

### Genre
- The game is a turn-based strategy board game with resource management and narrative choice sub-genres, combining tactical movement with branching story-driven events.

### Style
- The game features a medieval tone.
- The gameplay is strategic yet casual which balances the weight of choices with luck and the unpredictability of dice rolls and cards.

---

## Target Audience

### Demographics
**Demographics:**
- Age: 10+
- Gender: Appeal to all genders with the concept of strategy

**Interests:**
- Medieval/Fantasy lore
- Strategic board game lover
- Role-playing and decision-based games
- Prefers a mix of strategy and chance
- Enjoy Replayability
- Play in small groups(2-4)

**Justification**
- Appeals to players who enjoy managing resources (Wealth, Crown Points, Wisdom Points) and making tactical decisions.
- Mechanics like Crisis tiles, alliances, and challenge allows player interaction.
- The blend of medieval history and light fantasy appeals with fans of fantasy-like games and historical strategy games.

### Accessibility
-The game offers a straight-forward core mechanic in rolling a dice and making simple choices while having a layer of strategy through resource management, brancing decisions, and long-term planning. Casual players can enjoy the game as well as players with experience in resource managing and strategic planning.

### Inclusivity Strategies
-The game promote inclusivity by using color friendly UI elements for those with Color blindness.

---

## Core Gameplay Mechanics

### Primary Mechanics
Player Resources:
- Wealth/Gold = This is will be considered the currency the player will get and will go to the kingdom's treasury and resources. It can be gained through collecting taxes from your subjects, successful management of resources, or collecting war reperations from other players. You can spend this to have the potential to build structures that could increase the amount of taxes you get or landing on crisis tiles.
- Crown points = This will represent the king's influence or dominance. You can potentially gain crown points by landing on a crown tile or regular tile and clicking on a card that offers crown points. Spending this can be done when landing on crisis tiles or challenging other players.
- Wisdom points = This will reflect the king's education. These are gained by landing on  regular tiles and clicking on a card that offers wisdom points. Spending this can be done when landing on crisis tiles or wisdom tiles.

Boardgame tiles:
- Regular Tiles = When landing on this tile, the player will be prompted with two decision cards that are randomized. The cards will offer the player a chance to earn either a 1 crown point or 1 wisdom point. There's a potential to earn both or more than 1 point but at the cost of spending some gold/wealth. These cards will be more uncommon to obtain.
- Crisis Tiles = When landing on this tile, the player will be prompted with a crisis that can make the player either spend a large sum of money, crown points, or wisdom points. There will be extreme cases where you'd have to spend one of the points and along with money.
- Crown Tiles = When landing on this tile, the player will be prompted with card decisions which will offer 1 or more crown points.
- Wisdom Tiles = When landing on this tile, the player will be prompted with card decisions which will offer 1 or more wisdom points. There's a potential to obtain a policy card which can be used to increase the amount of taxes you receive when landing on a tax tile or give a player a lucky number in the number range 1-6. 
- Wealth Tiles = When landing on this tile, the player will be given an obtion to obtain a structure they can build by spening the gold/wealth they have. The structures help increase the amount of taxes you receive when landing on a tax tile.
- Tax Tiles = When landing on this tile or passing, the player will receive a set amount of gold/wealth. May increase after getting a policy card or building a structure.

"Dice roll:
- To move through the different tiles, the player will click a button which will have a number range 1-6. A random number will be selected within that range and that number is the amount of spaces the player can go.

Lucky Number:
- When a player gains a lucky number, other opposing players who roll that number they will need to pay the player who has that number as a lucky number a peace tax. Player's can only have one lucky number at a time. 

Challenging:
- To avoid paying a peace tax the player can spend a crown point. It can only work if player 2(challenger) currently has more crown points than player 1(challenged).
- If the challenge was successful, the player avoids the peace tax for that turn.

Church Loans:
- When a player runs out of gold, they are able to request a loan from the Church/Pope. At the end of the game the amount of loans you've took will subtract from your total score.

### Goals and Challenges
**Goals**
- The main goal for the game is to make it to the end of the board with a legacy that reflects who you are as a ruler. This is measured by the resources of Wealth(Gold), Crown Points(Influence), and Wisdom Points(Knowledge).
- Endure crisis and manage your resources
- Use resources to increase the amount of money you receive.
- Have enough points so it can be collected and added together at the end of the game to determine the winner.

**Challenges**
- Crisis tiles will deplete your resources(Wealth, Crown, or Wisdom points).
- Prioritizing which resources is needed on your journey through the game board.
- Randomized decision cards makes it difficult to plan ahead
- Lucky Number mechanic forces players to either pay money to opponents or spend their Crown Points to challenge them.
- Must decide when to contest a peace tax versus saving your Crown Points for other challenges.

### Progression
- As you move forward in the game you are competing with the other players to have the most resources in order to win.

### Game Rules
- Rules are relatively simple. Each player gets to roll in order from whoever is player 1 to player 4.
- Each tile type triggers a unique event when landed on and prompts decision cards with two choices affecting player resources
- Resource types include Gold, Crown, Wisdom, and Wealth (cards). Choices may grant or cost these.
- If a player lacks resources for a card option, they may accept a 600 gold loan from the Church, with a –600 point penalty per loan applied at the end.
- Players cannot take another turn after reaching the end.
- Players with a wealth card can only equip one at a time since they provide more passive income via tax bonuses.
- The game ends when all players reach the last tile on the board. Scores are calculated from all resources, with bonus points from titles like “Wise Ruler” or “Cunning Monarch” awarded to category leaders. Ties for a category result in no title.
- Player with the highest total score wins.

---

## Story and Setting

### Setting
-The game is set in a diverse world that blends elements from various historical eras, such as the Medieval period, the Renaissance, and ancient history. Players will face scenarios inspired by real events ranging from the opportunity to construct monumental wonders like grand cathedrals to confronting crises such as plagues or natural disasters, each presenting unique costs and challenges. The goal is to create an experience that involves historical references into strategic decision-making, allowing players to shape their kingdom's fate through their choices.

### Plot
- In this game, players assume the role of a young ruler ascending to power after the death of their predecessor. Each player starts with a kingdom and a vision to build a legacy better than others. The life will be difficult as the young ruler needs to navigate the different paths in order to reach their goal. There will be obstacles and difficult choices preventing the growth of your kingdom. The impact of each choice decides what kind of ruler you are at the end of your life. Will that legacy be of a conqueror, a wise ruler, or a monarch who focused on prosperity.

### Characters
- Each player plays as a monarch who will have to go through life as a king or queen. The player piece will most likely be a crown and they will use that piece to navigate through their life.

---

## Unique Selling Points (USP)
- It stands out because of the strategic depth blended with some medieval roleplay and a resource-based decision system.
- Choice driven progression = Players must make decisions throughout the game from the cards that can impact them.
- Every tile offers meaningful interaction
- Wealth cards in the game adds strategic limitation
- A title system that grants players bonus points at the end of the game. Dynamic titles not only adds points but flavor to the outcome
- Easy to follow mechanics with deep layers of risk assessment and strategically managing your resources

---

## Inspiration

### Sources
- Game of Life
- CIV 6
- Mount and Blade Bannerlord
- Yes your grace

### Why It Matters
The game blends inspirations from CIV 6, Game of Life, Mount & Blade: Bannerlord, and Yes, Your Grace to create a strategic yet accessible kingdom building experience. From CIV 6, it inherits resource management and decision making with long-term consequences. Game of Life inspired the tile-based progression and life path choices. Mount & Blade: Bannerlord influences the medieval theme and the idea of personal growth through titles and reputation. Finally, Yes, Your Grace shapes the moral weight of decisions like taking church loans and the narrative of ruling a kingdom under pressure.

---

## Player Experience Goals
- The game is suppose to cause a mix of curiosity and tension. PLayers feel curious when drawing cards, unsure of what reward or penalty it gives them. Tension rises when deciding between risky opportunities and safe plays especially when reasources are low and rival players are close to winning.

---

## Technical Requirements

### Platform
PC

### Tools
- Uses Unity
- Uses C# scripting
- AI used to help analyze any errors that appeared during development

---

## Art and Sound Direction

### Visual Style
- The visual style is a blend of medieval inspired aesthetics with clean, colorful UI elements. Each tile type is visually distinct to convey purpose at a glance, while the interface uses sharp and readable fonts.

### Sound Design
- There's no sound design within the game.

---

## Monetization Strategy
- The game would be a free game or a one-time purchase of $1.

---

## Treatment Details

### Gameplay Example
**Starting the Game**
- The player selects the number of players (2–4) from the initial UI. Each player is assigned a unique color, a Player Token appears on the start tile, and their individual resource panels activate.

**Rolling the Dice**
- On their turn, Player 1 presses the spacebar to roll the dice. The game animates a die roll and shows a result from 1 to 6, then the Player Token moves that number of tiles across the board.

**Decision Points & Forks**
- If the player reaches a fork in the road, a Decision Panel appears offering a "Left" or "Right" choice. Based on the choice, the player continues their movement path.

**Landing on a Tile**
- Once movement ends, the tile type determines what happens:

- Crisis Tile: Draws a Crisis card (e.g., “Plague outbreak”) with two choices—both may cost or reward resources.

- Wealth Tile: Offers a Wealth Card purchase, granting long-term tax bonuses if accepted.

- Tax Tile: Awards gold (plus any wealth card bonuses).

- Other Tiles: Trigger wisdom, crown, or regular cards with meaningful decisions.

**Making a Card Decision**
- The player reads the card's choices and picks one. If they lack the resources to choose, a panel offers a church loan (+600 gold, -600 score penalty). Choices impact gold, wisdom, or crown resources, and may shape endgame scoring.

**Turn Ends**
- Once the card decision is made, the next player's turn begins.

**Reaching the End Tile**
- When a player reaches the Finish tile, they can no longer take turns. Once all players finish, the game tallies resources, applies bonuses/penalties, and displays the EndGameStats panel with titles ("Wise Ruler") and a final winner.

---

### Challenges and Considerations

#### Potential Risks
**Balancing Card Effects**
- Some cards may offer choices that are either too punishing or overly rewarding, which can create unbalanced progression or runaway leads.

**Church Loan System**
- While it's a useful fallback, players might exploit it if the penalty isn't harsh enough or avoid it entirely if the penalty is too steep.

**Difficulty Curve**
- The randomness of dice rolls combined with tile distribution may create inconsistent pacing and some players may hit Crisis tiles too often, while others coast without challenge.

#### Feasibility
<!-- 
Describe any technological, financial, or development constraints. 
How will you mitigate these risks? 
-->

---

## Visualizing the Game Concept

### Concept Sketches or Storyboards
- Provide at least **two sketches**  
- Ensure sketches accurately represent the game’s concept and theme  
- Maintain coherence with the game’s style and theme  

**Board Layout**
- A winding path of interconnected tiles, each representing different tile types: Regular, Crown, Wisdom, Crisis, Wealth, Tax, and Finish.

**HUD**
- Each player receives a resource panel which displays their crown, wisdom, and gold resources.
- Endgame stats panels is a vertical summary of each player's Final resource totals, their title they earned, along with their total scores.
- There's a 2d Dice role display centered in the middle of the board.
- A text indicating a player's turn so it's easy to keep track of
- A small panel which breaksdown the scoring values of each resource and provides information on the penalties.

---

## Pitch Preparation

### Pitch Summary
-This game invites players to step into the shoes of a ruler and navigate the trials of  a king's life. It's inspired by games such as Game of Life but also adds some strategic elements from Civilization. This game lets players shape their legacy by managing their Wealth, Influence, and Wisdom. Every decision like building monumental structures to facing crisis offers a blend of resource management and choice driven gameplay. As you journey through this world of different dilemmeas, you'll need to decide what kind of ruler/king you want to be. A wise scholar, a rutheless conqueror, or a prosperous merchant. With its historical flavor, inclusive design, and a balance of strategy and chance, it stands out in the current market. The game’s accessibility features, such as high-contrast visuals and no player elimination can keep everyone engaged until the end. This makes it great for both casual game nights and dedicated strategists. 

### Target Audience Appeal
- Appeals to players who enjoy managing resources (Wealth, Crown Points, Wisdom Points) and making tactical decisions.
- Mechanics like Crisis tiles, alliances, and challenge allows player interaction.
- The blend of medieval history and light fantasy appeals with fans of fantasy-like games and historical strategy games.

### Market Differentiation
- This game uniquely blends the strategic governance of CIV 6, the curious chance of Game of Life, and the narrative depth of Yes, Your Grace, offering a board-style kingdom simulator where each player’s choices shape their legacy. Unlike typical turn-based games, it combines resource management, moral dilemmas, and title-based scoring to reward both strategy and adaptability which makes it stand out for players who enjoy both entertaining competition and meaningful consequences.

---

## External Feedback
<!-- Duplicate Feedback group as necessary if beyond 3 -->

### Feedback 1
- **Reviewer**:  
  Ryan(Cousin)
- **Summary**:  
  Enjoys the concept and mechanics of the game where there is different opportunities to earn something different. Not everything is set in stone and you have the potential to earn more. The title bonuses and the different titles provides something special to every playthrough and adds competition in wanting to achieve a certain title such as "Emperor of Legacy". Complaint on how the game UI didn't seem very "medieval-like".
- **Refinement**:  
  The HUD and UI should match with the theme of the game. It looked generic and didn't give a medieval feel.

### Feedback 2
- **Reviewer**:  
  Rick(Friend)
- **Summary**:  
  The game felt a little slow at times given the dice rolls would sometimes make them move 1-3 spaces. It's not a huge complaint. They wanted some more endgame scenarios for player to increase the level of challenge when they reach the end of the game.
- **Refinement**:  
  Adding scenarious for when some players reach the end of the board could add more depth in player interaction. Creating dilemmas or choice cards to relfect that their reign is reaching an end and if they would like to gain more resources but it requires more to spend.

### Feedback 3
- **Reviewer**:  
  Darren(Dad)
- **Summary**:  
  The game seemed easy to follow but it was difficult to keep track of the players and the information seen on screen. Font's seemed a little too small but is still readable.
- **Refinement**:  
  Increasing the font size and adjusting the UI to fit the newly size incresased font could help with players that have a hard time reading the text on cards. On the resource panels for each player it would be good to highlight the panel of whoever's turn it is. So if its player 1's turn then player 1 resource panel will highlight. So that they can see their resources and be able to make their decision quickly.


---

## Appendix
<!-- 
Include any additional sketches, mood boards, or early design mockups if available.  
If digital assets are unavailable, describe any rough concepts you have in mind. 
-->

---
