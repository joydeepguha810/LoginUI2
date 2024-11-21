Feature: User login functionality on ExpandTesting

  Scenario: Valid user login with correct credentials
    Given the user is on the login page
    When the user enters valid credentials
    And the user clicks the Login button
    Then the user should be redirected to the homepage