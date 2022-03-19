Feature: UpdateContactDetails
	As a customer 
	I want to be able to use the online contact form 
	So that I can provide communicate with Jupiter Toys


	Scenario: 1. Validate errors for blank data mandatory fields
	Given a user is in the contact page
		And has not entered any data in the mandatory field
		And has submitted the contact form
		And received validation errors
	When User populates the manadatory fields
	Then the validation errors are not displayed

	Scenario: 2. Validate successful submission message
	Given a user is in the contact page
		And has populated mandatory fields
	When the user submits the contact form
	Then a successful submission message is displayed

	Scenario: 3. Validate errors for invalid data in mandatory fields
	Given a user is in the contact page
	When the user populates mandatory fields with invalid data
	Then validation errors are populated

