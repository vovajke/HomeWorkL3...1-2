using System;

namespace HomeWorkL3_1_2_
{
    class Program
    {
        public enum BankAccountType
        {
            Deposit,
            Credit
        }

        public class BankAccount
        {
            private static ulong lastAccountNumber = 1_000_000_001;
            private ulong _accountNumber;
            private decimal _accountBalance;
            private BankAccountType _accountType;

            private BankAccount()
            {
                GenerateAccountNumber();
            }

            //Если при создании экземпляра класса указан только баланс, то тип класса по-умолчанию будет Deposit.
            public BankAccount(decimal accountBalance) : this(accountBalance, (BankAccountType)0)
            {
                _accountBalance = accountBalance;
            }

            //Если при создании экземпляра класса указан только тип, то баланс по-умолчанию будет равен 0. 
            public BankAccount(BankAccountType accountType) : this(0m, accountType)
            {
                _accountType = accountType;
            }

            public BankAccount(decimal accountBalance, BankAccountType accountType) : this()
            {
                _accountBalance = accountBalance;
                _accountType = accountType;
            }

            public ulong AccountNumber
            {
                get
                {
                    return _accountNumber;
                }
                set
                {
                    if (value.GetType().ToString() == "System.UInt64")
                    {
                        _accountNumber = value;
                    }
                }
            }

            public decimal AccountBalance
            {
                get
                {
                    return _accountBalance;
                }
                set
                {
                    if (value.GetType().ToString() == "System.Decimal")
                    {
                        _accountBalance = value;
                    }
                }
            }

            public BankAccountType AccountType
            {
                get
                {
                    return _accountType;
                }
                set
                {
                    if (value.GetType().ToString() == "Lesson_3.BankAccountType")
                    {
                        _accountType = value;
                    }
                }
            }

            private void GenerateAccountNumber()
            {
                _accountNumber = lastAccountNumber;
                lastAccountNumber = _accountNumber + 1;
            }

            public void PrintAccountInfo()
            {
                Console.WriteLine($"Номер счета: {AccountNumber}. Баланс: {AccountBalance}. Тип счета: {AccountType}.");
            }

            public void DepositMoney(decimal inletMoney)
            {
                AccountBalance += inletMoney;
                Console.WriteLine($"Операция пополнения счета на сумму {inletMoney} руб. выполнена успешно.");
                Console.WriteLine($"Текущий баланс равен {AccountBalance} руб.");
            }

            public void WithdrawMoney(decimal outletMoney)
            {
                if ((AccountBalance - outletMoney) >= 0)
                {
                    AccountBalance -= outletMoney;
                    Console.WriteLine($"Операция снятия со счета средств {outletMoney} руб. выполнена успешно.");
                    Console.WriteLine($"Текущий баланс равен {AccountBalance} руб.");
                }
                else
                {
                    Console.WriteLine($"Недостаточно средств. Текущий баланс составляет {AccountBalance} руб.");
                }
            }

            public void TransferMoney(BankAccount sourceAccount, decimal value)
            {
                if ((sourceAccount.AccountBalance - value) >= 0)
                {
                    sourceAccount.AccountBalance -= value;
                    AccountBalance += value;
                    /*
                    Верхние 2 строчки можно заменить на:
                    sourceAccount.WithdrawMoney(value);
                    DepositMoney(value);
                    */
                    Console.WriteLine($"Операция перевода средств со счета {sourceAccount.AccountNumber} на счет {AccountNumber} в размере {value} руб. выполнена успешно.");
                    Console.WriteLine($"Текущий баланс счета {sourceAccount.AccountNumber} равен {sourceAccount.AccountBalance} руб.");
                    Console.WriteLine($"Текущий баланс счета {AccountNumber} равен {AccountBalance} руб.");
                }
                else
                {
                    Console.WriteLine($"На счете {sourceAccount.AccountNumber} недостаточно средств для перевода {value} руб., остаток составляет {sourceAccount.AccountBalance} руб.");
                }
            }
        }

       
            static void Main(string[] args)
            {
                BankAccount account1 = new BankAccount(32167m, BankAccountType.Deposit);
                BankAccount account2 = new BankAccount(0m, BankAccountType.Credit);

                account1.PrintAccountInfo();
                account2.PrintAccountInfo();

                account2.TransferMoney(account1, 2167m);

                Console.WriteLine();
                account1.PrintAccountInfo();
                account2.PrintAccountInfo();

                Console.WriteLine();
                account1.TransferMoney(account2, 2168m);

                Console.WriteLine();
                account1.PrintAccountInfo();
                account2.PrintAccountInfo();

                Console.WriteLine();
                account1.TransferMoney(account2, 2167m);

                Console.WriteLine();
                account1.PrintAccountInfo();
                account2.PrintAccountInfo();

                Console.WriteLine();
                account2.TransferMoney(account1, 32167m);

                Console.WriteLine();
                account1.PrintAccountInfo();
                account2.PrintAccountInfo();

                Console.WriteLine();
                account1.TransferMoney(account2, 17144m);

                Console.WriteLine();
                account1.PrintAccountInfo();
                account2.PrintAccountInfo();

                Console.ReadKey();
            }
        
    }
}
