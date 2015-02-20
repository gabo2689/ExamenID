Feature: Stack
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Stack is Empty
	Given the following tiles
	| Tile Head | Tile Tail |
	
	
	Then the result should be 0 on the screen

Scenario: Shuffle Tiles
	Given  the following Random Stack exist
	| Tile Head | Tile Tail |
	| 0		    | 0			|
	| 0         | 3		    |
	| 0			| 4			|
	| 1		    | 1         |
	| 1			| 4			|
	| 3		    | 5			|
	When Randoms tiles are generated
	
	Then the following tiles appear 
	| Tile Head | Tile Tail |
	| 0		    | 3			|
	| 0         | 0		    |
	| 1			| 1			|
	| 0		    | 4         |
	| 3			| 5			|
	| 1		    | 4			|

