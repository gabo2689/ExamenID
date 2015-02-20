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



