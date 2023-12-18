# Hantec Bonus Manager
 This is a hiring project for Full-Stack Engineer position

 The Bonus Manager purpose is to calculate bonus points for a group of accounts based on data from the trading system.
 
  - The first version will do this using a simple algorithm and ad-hoc request for trading data.
  - The next version will implement a Strategy Design Pattern to allow multiple bonus point algorithms to be used.
  - The final version will use a local repository to store the trading data for all accounts to be processed in a batch manner for improved performance.
 
 For production use the project can be hosted in a service to run scheduled batches of work.

 The first commit implements the .Net projects with the provided interfaces and models.
 Then I will start using the TDD and write unit tests for the main class.
 -  [x] ProcessBonusForAccounts test
 -  [x] ProcessBonusForAccounts implementation
 -  [x] invalid arguments test
 -  [x] CalculateTotalBonus test
 -  [x] CalculateTotalBonus implementation
 -  [x] Refactor using Strategy Design Pattern
 -  [x] Logging test and implementation
 -  [x] Implement batch processing using a local database

The main entry point of the API is the BonusManager class 
 -  ProcessBonusForAccounts()  
https://github.com/VassilAtanasov/HantecBonusManager/blob/092f12a92d24688cbaeb30b321a0a29e97f7ce88/HantecBonusManager/BonusManager.cs#L18C11-L18C11
 -  StoreHistoricalDealsInRepository()
https://github.com/VassilAtanasov/HantecBonusManager/blob/092f12a92d24688cbaeb30b321a0a29e97f7ce88/HantecBonusManager/BonusManager.cs#L46C27-L46C59