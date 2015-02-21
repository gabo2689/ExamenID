Feature: Game
	
@mytag
Scenario: The game starts and the players take their tiles
	Given the players have an empty hand
	When the game begins and the players takes 7 tiles
	Then the two players must have 7 tiles each

Scenario: The game starts and Player2 has to start playing because has Higher Double
	Given a brand new game is about to start	
	When the player one has the next set of tiles
	| Tile Head | Tile Tail |
	| 0		    | 0			|
	| 0         | 3		    |
	| 0			| 4			|
	| 1		    | 1         |
	| 1			| 4			|
	| 6		    | 5 		|
	And the player two has the next set of tiles the highest double
	| Tile Head | Tile Tail |
	| 0		    | 0			|
	| 0         | 3		    |
	| 0			| 4			|
	| 1		    | 1         |
	| 1			| 4			|
	| 6		    | 6			|
	Then the player "2" has to start the game 

	Scenario: The game starts and Player1 has to start playing because has Higher Double
	Given a brand new game is about to start	
	When the player one has the next set of tiles
	| Tile Head | Tile Tail |
	| 0		    | 0			|
	| 0         | 3		    |
	| 3			| 3			|
	| 1		    | 1         |
	| 1			| 4			|
	| 6		    | 5 		|
	And the player two has the next set of tiles the highest double
	| Tile Head | Tile Tail |
	| 0		    | 1			|
	| 0         | 3		    |
	| 0			| 4			|
	| 1		    | 1         |
	| 1			| 4			|
	| 6		    | 5			|
	Then the player "1" has to start the game 

Scenario: The game starts and Player1 has to start playing because he has the most heavy Tile(Non doubleHigher)
	Given a brand new game is about to start	
	When the player one has the next set of tiles
	| Tile Head | Tile Tail |
	| 0		    | 0			|
	| 0         | 3		    |
	| 3			| 2			|
	| 1		    | 5         |
	| 1			| 4			|
	| 6		    | 5 		|
	And the player two has the next set of tiles
	| Tile Head | Tile Tail |
	| 0		    | 1			|
	| 0         | 3		    |
	| 0			| 4			|
	| 1		    | 3         |
	| 1			| 4			|
	| 1		    | 5			|
	Then the player "1" has to start the game

	Scenario: The game starts and Player2 has to start playing because he has the most heavy Tile(Non doubleHigher)
	Given a brand new game is about to start	
	When the player one has the next set of tiles
	| Tile Head | Tile Tail |
	| 0		    | 0			|
	| 0         | 3		    |
	| 3			| 2			|
	| 1		    | 0         |
	| 1			| 4			|
	| 3		    | 1 		|
	And the player two has the next set of tiles
	| Tile Head | Tile Tail |
	| 0		    | 1			|
	| 0         | 3		    |
	| 0			| 4			|
	| 1		    | 6         |
	| 1			| 4			|
	| 1		    | 5			|
	| 3		    | 5			|
	Then the player "2" has to start the game

Scenario: When we put a tile, the tile can swap if needed
	Given  a tile with 3 in head  and 5 in tail
	When  we call swap
	Then  the tile will have 5 in head and 3 in tail


Scenario: The player1 move one tile to the board and then is the turn of the player2
	Given a game started 
	And  a started board
	When the player one has the next set of tiles
	| Tile Head | Tile Tail |
	| 0		    | 1			|
	| 0         | 6		    |
	| 0			| 5			|
	| 1		    | 3         |
	| 5			| 6			|
	| 0		    | 2 		|
	| 1		    | 2 		|
	And the player two has the next set of tiles
	| Tile Head | Tile Tail |
	| 0		    | 4			|
	| 1         | 4		    |
	| 1			| 5			|
	| 1		    | 6         |
	| 2			| 5			|
	| 2		    | 4			|
	| 2		    | 3			|
	And the player one move a tile to the board 
	Then is the turn of the player 2 

	Scenario: When Player one doesnt have compatible tile and he has less tiles than the Player two and the stock isEmpty he win
	Given a game started 
	When the player one has the next set of tiles
	| Tile Head | Tile Tail |
	| 0         | 2	        |
	| 1		    | 5 		|
	And the player two has the next set of tiles
	| Tile Head | Tile Tail |
	| 2         | 2			|
	| 0         | 5		    |
	| 0		    | 0			|
	And the board has just the tile 6 in head and 6 in tail in the middle
	And  the stock is empty
	And the player doesnt has a tile to move
	Then the player 1 must win 
