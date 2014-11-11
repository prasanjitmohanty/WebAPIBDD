Feature: Products API
      In order to perform CRUD operations on the products
      As a client of the Web Api
      I want to be able to Create, Update, Delete, and List products

	  @ProductCrud

 Scenario: Retrieving all Products
    Given existing products
    When all products are retrieved
    Then a '200 OK' status is returned
    Then all products are returned
	
  Scenario: Retrieving a product by id
    Given an existing product id '1'
    When it is retrieved
    Then a '200 OK' status is returned
    Then it is returned
    Then it should have an id
    Then it should have a title
    Then it should have a catagory
    Then it should have a price

  Scenario: Create a new product saves posted values.
      Given the following product inputs
          | Field       | Value      |
          | Name        | Tomato Soup|
          | Category    | Groceries  |
		  | Price       | 2.75       |
		            
      When the client posts the inputs to the website
      Then a '201 Created' status should be returned
      When the client gets the product by header location
      Then the saved product matches the inputs

Scenario: Updating a product
    Given the following product inputs
          | Field       | Value      |
          | Name        | Tomato Soup|
          | Category    | Groceries  |
		  | Price       |3.75        |
    When a PUT request is made
    Then a '200 OK' is returned
    Then the product should be updated

 Scenario: Deleting a product
    Given an existing product id '1'
    When a DELETE request is made
    Then a '200 OK' status is returned
    Then the product should be removed	  
