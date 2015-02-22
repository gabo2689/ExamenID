Feature: Player
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytagxs
Scenario: When the player one get one tile from stock
	Given the list from stock exist from board
	| Tile Head | Tile Tail | isDouble |
	| 4         | 4         |   true   |
	| 3         | 2         |   false  |
	| 2         | 1         |   false  |
	And the player get 1 tile from stock
	Then remove 1 tile from stock
	And  add 1 tile to player list
	| Tile Head | Tile Tail | isDouble |
	| 3         | 0         |   false  |
	| 5         | 2         |   false  |
	| 4         | 1         |   false  |

