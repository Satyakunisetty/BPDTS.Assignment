Feature: Get User details based on Id

This feature is to call the /user Endpoint by passing the Id
and fetch the user details belong to it.

Background:
	Given I get the api base url	

Scenario Outline: Get user details by valid Id
	When I call the user endpoint with <user_Id>
	Then I should get the <StatusCode>
	And validate API response values like <First_Name>, <Last_Name>, <Email>, <Ip_Address>, <Latitude>, <Longitude>, <City> based on <user_Id>

	Examples:
		| user_Id | First_Name | Last_Name  | Email                      | Ip_Address     | Latitude   | Longitude    | City      | StatusCode |
		| 1       | Maurise    | Shieldon   | mshieldon0@squidoo.com     | 192.57.232.111 | 34.003135  | -117.7228641 | Kax       | OK         |
		| 200     | Becka      | Shaudfurth | bshaudfurth5j@bluehost.com | 18.55.237.174  | 43.1581207 | -77.6063541  | Rochester | OK         |

Scenario Outline: Users Endpoint should return error message when invalid Id is passed
	When I call the user endpoint with <user_Id>
	Then I should get the <StatusCode>
	And validate <ErrorMessage> in API response

	Examples:
		| user_Id    | StatusCode | ErrorMessage                |
		| 1234567891 | NOT FOUND   | Id 1234567891 doesn't exist |
		| 1234567890 | NOT FOUND   | Id 1234567890 doesn't exist |