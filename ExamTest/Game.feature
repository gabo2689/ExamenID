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

Scenario: When we put a tile, the tile can swap if needed
	Given  a tile with 3 in head  and 5 in tail
	When  we call swap
	Then  the tile will have 5 in head and 3 in tail