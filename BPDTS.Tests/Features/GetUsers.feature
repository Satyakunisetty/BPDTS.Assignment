Feature: Get All Users details

This feature is to call the /Users Endpoint which fetches all user details 
and validate the Enpoint is giving proper status code and results as expected.

Scenario: Get all user details from /Users endpoint
Given The api base url is present
When I call the endpoint
Then I should get the OK status and get all user details