Feature: SearchProduct
	User search 'kitap' and clicking product name 'Hobbit'

@searchproduct
Scenario: SearchProduct
	Given I am on the Amazon website
	And Accept cookies
	And Type kitap on the search box
	And Search it
	And Search results are shown
	When I click on the product named Hobbit
	Then The purchase page of the product named Hobbit should be opened