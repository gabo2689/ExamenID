Feature: Game

@mytag
Scenario: The game starts and the players take their tiles
	Given the players have an empty hand
	When the game begins and the players takes 7 tiles
	Then the two players must have 7 tiles each


Scenario: The game starts and one player has to start playing
	Given the player one has the next set of tiles
	| Tile Head | Tile Tail |
	| 0		    | 0			|
	| 0         | 3		    |
	| 0			| 4			|
	| 1		    | 1         |
	| 1			| 4			|
	| 6		    | 6 		|
	When the player two has the highest double
	| Tile Head | Tile Tail |
	| 0		    | 0			|
	| 0         | 3		    |
	| 0			| 4			|
	| 1		    | 1         |
	| 1			| 4			|
	| 3		    | 5			|
	Then the player 1 has to start the game 
