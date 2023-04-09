using State;

Console.Title = "State";

BankAccount bankAccount = new BankAccount();

bankAccount.Deposit(100);
bankAccount.Withdraw(500);
bankAccount.Withdraw(100);

bankAccount.Deposit(2000);
bankAccount.Deposit(100);

bankAccount.Withdraw(3000);

bankAccount.Deposit(3000);
bankAccount.Deposit(100);

Console.ReadLine();