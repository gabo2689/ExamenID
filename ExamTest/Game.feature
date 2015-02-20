Feature: Game

@mytag
Scenario: The game starts and the players take their tiles
	Given the players have an empty hand
	When the game begins and the players takes 7 tiles
	Then the two players must have 7 tiles each


Scenario: The game starts and one player has to start playing
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
