Feature: AddAndRemoveFromCart
	Adding and removing product from the cart

@addandremovefromcart
Scenario: Adding and removing product from the cart
	Given I am on the purchase page of the product named Hobbit
	And I click the Add To Cart button
	And In the window that opens, I click the go to cart button
	When I click the delete button on the opened page
	Then the product named Hobbit should be removed from the cart