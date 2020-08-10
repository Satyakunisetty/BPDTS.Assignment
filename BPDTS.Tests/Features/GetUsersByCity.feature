Feature: Get all User details based on City

This feature is to call the /city Endpoint by passing the City name 
and fetch all user details belong to that city.

Scenario Outline: Get users through city endpoint when requested with city name
	Given I have the api base url
	When I call the city endpoint using <CityName>
	Then I should get the OK status result from endpoint
	And validate API response values like <Id>, <First_Name>,<Last_Name>, <Email>, <Ip_Address>, <Latitude> , <Longitude> and <Count>

	Examples:
		| Id | First_Name | Last_Name | Email                  | Ip_Address     | Latitude   | Longitude    | CityName    | Count |
		| 1  | Maurise    | Shieldon  | mshieldon0@squidoo.com | 192.57.232.111 | 34.003135  | -117.7228641 | Kax         | 1     |
		| 12 | Hugibert   | Dore      | hdoreb@unesco.org      | 44.17.237.159  | 25.4765601 | -108.0887656 | Los Angeles | 1     |
		|    |            |           |                        |                |            |              | Loseles     | 0     |