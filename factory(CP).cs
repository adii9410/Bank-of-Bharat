﻿using System;
class PD
{
    public static List<string?> name = new List<string?>();
    public static List<string?> address = new List<string?>();
    public static List<string?> email = new List<string?>();
    public static List<string?> gender = new List<string?>();
    public static List<string?> marriage = new List<string?>();
    public static List<string?> username = new List<string?>();
    public static List<string?> password = new List<string?>();
    public static List<int> age = new List<int>();
    public static List<int> Mpin = new List<int>();
    public static List<Int64> phone = new List<Int64>();
    public static List<Int64> accnum = new List<Int64>();
    public static List<Int64> money = new List<Int64>();
    public static Int64 ACCID, balance;
    public static int tran, check = 2;
    public PD()
    {
        name.AddRange(new List<string>() { "Alen", "Abel", "Manan", "Allwyn", "Mark" });
        address.AddRange(new List<string>() { "Chrsit", "christ", "USA", "canada", "india" });
        email.AddRange(new List<string>() { "alen@", "Abel@", "Manan@", "Allwyn@", "Mark@" });
        gender.AddRange(new List<string>() { "M", "M", "M", "M", "M" });
        marriage.AddRange(new List<string>() { "Y", "N", "Y", "N", "Y" });
        username.AddRange(new List<string>() { "Alen", "Abel", "Manan", "Allwyn", "Mark" });
        password.AddRange(new List<string>() { "1234", "2345", "3456", "4567", "5678" });
        age.AddRange(new List<int>() { 20, 21, 20, 19, 24 });
        Mpin.AddRange(new List<int>() { 0987, 9876, 8765, 7654, 6543 });
        phone.AddRange(new List<Int64>() { 12345, 23456, 34567, 45678, 56789 });
        accnum.AddRange(new List<Int64>() { 2060316, 2060468, 2060256, 2060318, 2060344 });
        money.AddRange(new List<Int64>() { 1000, 10000, 2000, 20000, 9999 });
    }
}
interface iLogin
{
    void Admin();
}
class admin_login : iLogin
{
    public void Admin()
    {
        PD.check = 2;
        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine("\n\t Admin Login\n");
            Console.Write("\t User Name: ");
            var username = Console.ReadLine();
            Console.Write("\t Password : ");
            var password = Console.ReadLine();
            if (username == "admin" && password == "admin")
            {
                Console.WriteLine("Admin Login Sucessful");
                PD.check = 1;
                break;
            }
            else
            {
                Console.WriteLine("Try Again");
                PD.check = 0;
                Console.ReadKey();
                continue;
            }
        }
    }
}
class Ulogin : iLogin
{
    public void Admin()
    {
        PD.check = 2;
        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine("\n\t Client Login\n");
            Console.Write("\t User Name: ");
            var username = Console.ReadLine();
            Console.Write("\t Password : ");
            var password = Console.ReadLine();
            if (username == "admin" && password == "admin")
            {
                Console.WriteLine("Admin Client Login Sucessful");
                PD.check = 1;
                break;
            }
            else
            {
                Console.WriteLine("Try Again");
                PD.check = 0;
                Console.ReadKey();
                continue;
            }
        }
    }
}
class Client
{
    private iLogin _service;
    public Client(iLogin service)
    {
        this._service = service;
    }
    public void AdminMethod()
    {
        this._service.Admin();
    }
}
class User_login : Security_OTP
{
    public void User()
    {
        PD.check = 2;
        Console.Write("\n\t Account Number: ");
        PD.ACCID = Convert.ToInt64(Console.ReadLine());
        if (PD.accnum.Contains(PD.ACCID))
        {
            for (int i = 0; i < PD.accnum.Count; i++)
            {
                if (PD.ACCID == PD.accnum[i])
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Clear();
                        Console.WriteLine("\n\t Account Number: " + PD.accnum[i]);
                        Console.Write("\t User Name     : ");
                        var loginID = Console.ReadLine();
                        Console.Write("\t Password      : ");
                        var loginPass = Console.ReadLine();
                        if (loginID == PD.username[i] && loginPass == PD.password[i])
                        {
                            OTP();
                            Console.WriteLine("\n\t User Login Sucessful");
                            PD.check = 1;
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\n\t User Login Failed: Try Again");
                            PD.check = 0;
                            Console.ReadKey();
                        }
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Try Again");
        }
    }
}

public abstract class Trans : Security_MPIN
{
    public abstract void Execute();
}

public class Withdrawal : Trans
{
    public override void Execute()
    {
        PD.check = 2;
        for (int i = 0; i < PD.accnum.Count; i++)
        {
            if (PD.ACCID == PD.accnum[i])
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine("\n\t Account Balance: " + PD.money[i]);
                    Console.Write("\n\t Enter the Amount to Withdraw: ");
                    var WITHDEP = Convert.ToInt32(Console.ReadLine());
                    MPIN();
                    if (PD.check == 1)
                    {
                        PD.money[i] = PD.money[i] - WITHDEP;
                        PD.balance = PD.money[i];
                        PD.tran = i;
                        Console.WriteLine("\n\t Account Balance: " + PD.money[i]);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong Mpin: Try Again");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}

public class Deposit : Trans
{
    public override void Execute()
    {
        PD.check = 2;
        for (int i = 0; i < PD.accnum.Count; i++)
        {
            if (PD.ACCID == PD.accnum[i])
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine("\n\t Account Balance: " + PD.money[i]);
                    Console.Write("\n\t Enter the Amount to Deposit: ");
                    var WITHDEP = Convert.ToInt32(Console.ReadLine());
                    MPIN();
                    if (PD.check == 1)
                    {
                        PD.money[i] = PD.money[i] + WITHDEP;
                        PD.balance = PD.money[i];
                        Console.WriteLine("\n\t Account Balance: " + PD.money[i]);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong Mpin: Try Again");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}

public static class TransactionFactory
{
    public static Trans CreateTransaction(string transactionType)
    {
        switch (transactionType)
        {
            case "withdrawal":
                return new Withdrawal();
            case "deposit":
                return new Deposit();
            default:
                throw new ArgumentException("Invalid transaction type specified.");
        }
    }
}


class Account
{
    public void User_detail()
    {
        for (int i = 0; i < PD.accnum.Count; i++)
        {
            if (PD.ACCID == PD.accnum[i])
            {
                Console.WriteLine("\n\t Details\n");
                Console.WriteLine("\n\t Account Number  : " + PD.accnum[i]);
                Console.WriteLine("\n\t Account Balance : " + PD.money[i]);
                Console.WriteLine("\n\t Name            : " + PD.name[i]);
                Console.WriteLine("\n\t Age             : " + PD.age[i]);
                Console.WriteLine("\n\t Address         : " + PD.address[i]);
                Console.WriteLine("\n\t Phone Number    : " + PD.phone[i]);
                Console.WriteLine("\n\t Email           : " + PD.email[i]);
                Console.WriteLine("\n\t Gender          : " + PD.gender[i]);
                Console.WriteLine("\n\t Martial Status  : " + PD.marriage[i]);
            }
        }
    }
}
interface iAdminDetail
{
    void Admin_detail();
}
class Admin_account : iAdminDetail
{
    public void Admin_detail()
    {
        Console.Write("\tAccount Number: ");
        var acc = Convert.ToInt64(Console.ReadLine());
        try
        {
            if (PD.accnum.Contains(acc))
            {
                for (int i = 0; i < PD.accnum.Count; i++)
                {
                    if (PD.accnum[i] == acc)
                    {
                        Console.Clear();
                        Console.WriteLine("\n\t\t Details\n");
                        Console.WriteLine("\t Name          : " + PD.name[i]);
                        Console.WriteLine("\t Age           : " + PD.age[i]);
                        Console.WriteLine("\t Address       : " + PD.address[i]);
                        Console.WriteLine("\t Phone Number  : " + PD.phone[i]);
                        Console.WriteLine("\t Email         : " + PD.email[i]);
                        Console.WriteLine("\t Gender        : " + PD.gender[i]);
                        Console.WriteLine("\t Martial Status: " + PD.marriage[i]);
                    }
                }
            }
            else
                throw new Exception();
        }
        catch (Exception e)
        {
            Console.WriteLine("\n\t Wrong User Account Number");
        }
    }
}
interface iAdminDetailmore
{
    void Admin_table_detail();
}
class Admin_Table : iAdminDetailmore
{
    public void Admin_table_detail()
    {
        Console.WriteLine("AccountID\t Name\t\t Age\t Address\t\t Phone Number\t Email\t\t Gender\t Married");
        for (int i = 0; i < PD.accnum.Count; i++)
        {
            Console.WriteLine(PD.accnum[i] + " \t " + PD.name[i] + "\t\t " + PD.age[i]
            + " \t  " + PD.address[i] + " \t\t  " + PD.phone[i] + " \t " + PD.email[i]
            + " \t\t " + PD.gender[i] + "  \t " + PD.marriage[i]);
        }
    }
}
public class Register : Security_OTP
{
    public virtual void REG_UP()
    {
        Random rand = new Random();
        PD.ACCID = rand.Next(10000, 100000);
        PD.accnum.Add(PD.ACCID);
        Console.WriteLine("\n\t\tEnter your Details");
        Console.Write("\t Name          : ");
        PD.name.Add(Console.ReadLine());
        Console.Write("\t Age           : ");
        PD.age.Add(Convert.ToInt32(Console.ReadLine()));
        Console.Write("\t Address       : ");
        PD.address.Add(Console.ReadLine());
        Console.Write("\t Email         : ");
        PD.email.Add(Console.ReadLine());
        Console.Write("\t Phone Number  : ");
        PD.phone.Add(Convert.ToInt64(Console.ReadLine()));
        Console.Write("\t Gender        : ");
        PD.gender.Add(Console.ReadLine());
        Console.Write("\t Married(Y/N)  :");
        PD.marriage.Add(Console.ReadLine());
        Console.Write("\t User Name     : ");
        PD.username.Add(Console.ReadLine());
        Console.Write("\t Password      : ");
        PD.password.Add(Console.ReadLine());
        Console.Write("\t MPIN          : ");
        PD.Mpin.Add(Convert.ToInt32(Console.ReadLine()));
        PD.money.Add(0);
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("\n\t Enter OTP sent ");
        OTP();
    }
}
public sealed class User_update : Register
{
    public override void REG_UP()
    {
        for (int i = 0; i < PD.accnum.Count; i++)
        {
            if (PD.ACCID == PD.accnum[i])
            {
                PD.name.RemoveAt(i);
                PD.age.RemoveAt(i);
                PD.address.RemoveAt(i);
                PD.email.RemoveAt(i);
                PD.phone.RemoveAt(i);
                PD.gender.RemoveAt(i);
                PD.marriage.RemoveAt(i);
                PD.username.RemoveAt(i);
                PD.password.RemoveAt(i);
                PD.Mpin.RemoveAt(i);
                Console.WriteLine("\n\t\tEnter your New Details");
                Console.Write("\t Name          : ");
                PD.name.Insert(i, Console.ReadLine());
                Console.Write("\t Age           : ");
                PD.age.Insert(i, Convert.ToInt32(Console.ReadLine()));
                Console.Write("\t Address       : ");
                PD.address.Insert(i, Console.ReadLine());
                Console.Write("\t Email         : ");
                PD.email.Insert(i, Console.ReadLine());
                Console.Write("\t Phone Number  : ");
                PD.phone.Insert(i, Convert.ToInt64(Console.ReadLine()));
                Console.Write("\t Gender        : ");
                PD.gender.Insert(i, Console.ReadLine());
                Console.Write("\t Married(Y/N)  :");
                PD.marriage.Insert(i, Console.ReadLine());
                Console.Write("\t User Name     : ");
                PD.username.Insert(i, Console.ReadLine());
                Console.Write("\t Password      : ");
                PD.password.Insert(i, Console.ReadLine());
                Console.Write("\t MPIN          : ");
                PD.Mpin.Insert(i, Convert.ToInt32(Console.ReadLine()));
            }
        }
    }
}
interface iAdminDelete
{
    void Admin_delete();
}
class Delete : iAdminDelete
{
    public void Admin_delete()
    {
        Console.Write(" Enter your Account Number: ");
        var acc = Convert.ToInt64(Console.ReadLine());
        if (PD.accnum.Contains(acc))
        {
            for (int i = 0; i < PD.accnum.Count; i++)
            {
                if (acc == PD.accnum[i])
                {
                    PD.accnum.RemoveAt(i);
                    PD.name.RemoveAt(i);
                    PD.money.RemoveAt(i);
                    PD.age.RemoveAt(i);
                    PD.address.RemoveAt(i);
                    PD.email.RemoveAt(i);
                    PD.phone.RemoveAt(i);
                    PD.gender.RemoveAt(i);
                    PD.marriage.RemoveAt(i);
                    PD.username.RemoveAt(i);
                    PD.password.RemoveAt(i);
                    PD.Mpin.RemoveAt(i);
                    Console.WriteLine("\n\t Account " + acc + " Deleted");
                }
            }
        }
        else
            Console.WriteLine("\n\t Wrong User Account Number");
    }
}
public class Security_OTP
{
    public void OTP()
    {
        for (int i = 0; i < 5; i++)
        {
            Random rand = new Random();
            int otp = rand.Next(1000, 9999);
            Console.WriteLine("OTP     : " + otp);
            Console.Write("Type the OTP: ");
            if (otp == Convert.ToInt32(Console.ReadLine()))
            {
                Console.WriteLine("Success");
                break;
            }
            else
            {
                Console.WriteLine("Try Again");
                continue;
            }
        }
    }
}
public class Security_MPIN
{
    public void MPIN()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Enter the MPIN: ");
            var pin = Convert.ToInt32(Console.ReadLine());
            if (PD.Mpin.Contains(pin))
            {
                Console.WriteLine("Success");
                PD.check = 1;
                break;
            }
            else
            {
                Console.WriteLine("Try Again");
                Console.ReadKey();
                PD.check = 0;
                continue;
            }
        }
    }
}
public sealed class cust_support
{
    public void contact()
    {
        Console.WriteLine("\n\t Welcome to Customer Support");
        Console.WriteLine("\t ❤ Chat with us ❤ ");
    }
}
class Program
{
    static void Main(string[] args)
    {
        int admin_choice, user_choice, trans_choice, login_choice, choice;
        string transactionType;
        PD pD = new PD();
        iLogin Admin_login = new admin_login();
        iLogin ulogin = new Ulogin();
        User_login user_Login = new User_login();
        Account account = new Account();
        iAdminDetail admin_Account = new Admin_account();
        iAdminDetailmore admin_Table = new Admin_Table();
        Register register = new Register();
        User_update user_Update = new User_update();
        Delete delete = new Delete();
        cust_support cust_Support = new cust_support();
        Client c1 = new Client(ulogin);
        goto MainMenu;
    AdminControl:
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\n\t\tMenu\n");
                Console.WriteLine("\t 1.User Detail\n");
                Console.WriteLine("\t 2.Table Detail\n");
                Console.WriteLine("\t 3.Delete\n");
                Console.WriteLine("\t 4.Back to Main Menu\n");
                Console.Write("\n\t Enter your Choice: ");
                admin_choice = Convert.ToInt32(Console.ReadLine());
                switch (admin_choice)
                {
                    case 1:
                        admin_Account.Admin_detail();
                        Console.ReadKey();
                        break;
                    case 2:
                        admin_Table.Admin_table_detail();
                        Console.ReadKey();
                        break;
                    case 3:
                        delete.Admin_delete();
                        Console.ReadKey();
                        break;
                    case 4:
                        goto MainMenu;
                }
            } while (admin_choice < 4);
        }
    UserControl:
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\n\t\tMenu\n");
                Console.WriteLine("\t 1.User Detail\n");
                Console.WriteLine("\t 2.Update Detail\n");
                Console.WriteLine("\t 3.Transaction\n");
                Console.WriteLine("\t 4.Customer Support\n");
                Console.WriteLine("\t 5.Back to Main Menu\n");
                Console.Write("\n\t Enter your Choice: ");
                user_choice = Convert.ToInt32(Console.ReadLine());
                switch (user_choice)
                {
                    case 1:
                        account.User_detail();
                        Console.ReadKey();
                        break;
                    case 2:
                        user_Update.REG_UP();
                        account.User_detail();
                        Console.ReadKey();
                        break;
                    case 3:
                        goto TransactionControl;
                    case 4:
                        cust_Support.contact();
                        Console.ReadKey();
                        break;
                    case 5:
                        goto MainMenu;d
                }
            } while (user_choice < 5);
        }
    TransactionControl:
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\n\t\tMenu\n");
                Console.WriteLine("\t 1.Deposit\n");
                Console.WriteLine("\t 2.Withdraw\n");
                Console.WriteLine("\t 3.Back to Menu\n");
                Console.Write("\n\t Enter your Choice: ");
                trans_choice = Convert.ToInt32(Console.ReadLine());
                switch (trans_choice)
                {
                    case 1:
                        transactionType = "deposit";
                        Trans transaction = TransactionFactory.CreateTransaction(transactionType);
                        transaction.Execute();
                        Console.ReadKey();
                        break;
                    case 2:
                        transactionType = "withdrawal";
                        Trans tran = TransactionFactory.CreateTransaction(transactionType);
                        tran.Execute();
                        Console.ReadKey();
                        break;
                    case 3:
                        goto UserControl;
                }
            } while (trans_choice < 3);
        }
    LOGIN:
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\n\t\tMenu\n");
                Console.WriteLine("\t 1.Admin\n");
                Console.WriteLine("\t 2.User\n");
                Console.WriteLine("\t 3.Admin Client\n");
                Console.WriteLine("\t 4. Back to menu");
                Console.Write("\n\t Enter your Choice: ");
                login_choice = Convert.ToInt32(Console.ReadLine());
                switch (login_choice)
                {
                    case 1:
                        Admin_login.Admin();
                        if (PD.check == 1)
                            goto AdminControl;
                        else
                        {
                            Console.WriteLine("Admin Login Failed");
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        user_Login.User();
                        if (PD.check == 1)
                            goto UserControl;
                        else
                        {
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        c1.AdminMethod();
                        Console.ReadKey();
                        break;
                    case 4:
                        goto MainMenu;
                }
            } while (login_choice < 3);
        }
    MainMenu:
        {
            Console.Clear();
            do
            {
                Console.Clear();
                Console.WriteLine("\t Welcone to Manan Bank");
                Console.WriteLine("\n\t\t Menu");
                Console.WriteLine("\n\t 1.Login");
                Console.WriteLine("\n\t 2.Create Account");
                Console.WriteLine("\n\t 3.Contact");
                Console.WriteLine("\n\t 4.Exit");
                Console.Write("\n\t Enter your Choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        goto LOGIN;
                    case 2:
                        Console.Clear();
                        register.REG_UP();
                        account.User_detail();
                        Console.ReadKey();
                        break;
                    case 3:
                        cust_Support.contact();
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("\n\t ❤ Thank for choosing Manan Bank ❤");
                        Console.ReadKey();
                        break;
                }
            } while (choice < 4);
        }
    }
}