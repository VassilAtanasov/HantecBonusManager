# Hantec Bonus Manager
 This is a hiring project for Full-Stack Engineer position

 The Bonus Manager purpose is to calculate bonus points for a group of accounts based on data from the trading system.
 
  - The first version will do this using a simple algorithm and ad-hoc request for trading data.
  - The next version will implement a Strategy Design Pattern to allow multiple bonus point algorithms to be used.
  - The final version will use a local repository to store the trading data for all accounts to be processed in a batch manner for improved performance.
 
 For production use the project can be hosted in a service to run scheduled batches of work.

 The first commit implements the .Net projects with the provided interfaces and models.
 Then I will start using the TDD and write unit tests for the main class.
 -  ProcessBonusForAccounts test
 -  ProcessBonusForAccounts implementation
 -  invalid arguments test
 -  CalculateTotalBonus test
 -  CalculateTotalBonus implementation
 -  Refactor using Strategy Design Pattern
 -  Logging test and implementation
 -  Implement batch processing using a local database