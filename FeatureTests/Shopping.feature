Feature: Shopping
	As a customer 
	I want to be able to use the online shop
	So that I can buy the correct toys

	Scenario: Verify correct items are added to shopping cart
	Given a user is in the shop page
		And has selected to buy two Funny Cows
		And has selected to buy a Fluffy Bunny
	When the user selects the cart menu
	Then the selected items are in the cart
