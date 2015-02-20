Feature: Player
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytagxs
Scenario: When the player one get one tile from stock
	Given the list from stock exist from board
	|header | tail |
	| 4      | 4    |
	| 3      | 2    |
	| 2      | 1    |
	And the player get 1 tile from stock
	Then remove 1 tile from stock
	And  add 1 tile to player list
	| header | tail |
	| 3      | 0    |
	| 5      | 2    |
	| 4      | 1    |

