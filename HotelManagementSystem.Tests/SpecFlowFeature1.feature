Feature: Add hotel
	In order to simulate hotel management system
	As api consumer
	I want to be able to add hotel,get hotel details and book hotel

@AddHotel
Scenario Outline: User adds hotel in database by providing valid inputs
	Given User provided valid Id '<id>'  and '<name>'for hotel 
	And Use has added required details for hotel
	When User calls AddHotel api
	Then Hotel with name '<name>' should be present in the response
Examples: 
| id | name   |
| 1  | hotel1 |
| 2  | hotel2 |
| 3  | hotel3 |

Scenario Outline: User adds hotel in database by providing valid inputs and gets data
	Given User provided valid Id '<id>'  and '<name>'for hotel 
	And Use has added required details for hotel
	And User calls AddHotel api
	When User enters id '<id>' for getting the result hotel and calls GetHotelById
	Then User gets the hotel By ID '<id>'

Examples: 
| id | name   |
| 4  | hotel4 |
| 5  | hotel5 |


Scenario: User adds hotel in database by providing valid multiple inputs and gets data
	Given User provided valid Id '6'  and 'hotel6'for hotel 
	And Use has added required details for hotel
	And User calls AddHotel api
	Given User provided valid Id '7'  and '<hotel7>'for hotel 
	And Use has added required details for hotel
	And User calls AddHotel api
	Given User provided valid Id '8'  and '<hotel8>'for hotel 
	And Use has added required details for hotel
	And User calls AddHotel api
	When User gets all hotels by GetAllHotels method
	Then Verify if all hotels are present  

