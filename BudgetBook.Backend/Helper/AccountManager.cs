using BudgetBook.Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBook.Backend.Helper;
public class AccountManager
{
    private List<Account> _Accounts = new List<Account>();

    public (bool Succeeded, string Message) AddExistingAccount(Account account)
    {
        if (_Accounts.Any(x => x.Equals(account)))
            return (false, "Can't add an account more than once.");
        _Accounts.Add(account);
        return (true, string.Empty);
    }

    public (bool Succeeded, string Message) CreateNewAccount(string name, double initialDeposit = 0, bool restrictDesposits = false, bool restrictWithdrawls = false)
    {
        var account = new Account()
        {
            Name = name,
            RestrictDeposits = restrictDesposits,
            RestrictWithdrawls = restrictWithdrawls
        };
        if (_Accounts.Any(x => x.Equals(account)))
            return (false, "Can't create an already existing account.");
        _Accounts.Add(account);
        return (true, string.Empty);
    }

    public (bool Succeeded, string Message) DeleteAccount(Guid id)
    {
        var account = _Accounts.Find(x => x.Id == id);
        if (account is null)
            return (false, $"No account found with id '{id}'");

        if (account.Balance != 0)
            return (false, $"Can't delete an account with balance.");

        _Accounts.Remove(account);
        return (true, string.Empty);
    }

    public (bool Succeeded, string Message) ExecuteTransaction(Transaction transaction)
    {
        Account? outgoing = null;
        Account? target = null;
        foreach(var account in _Accounts)
        {
            if (account.Id == transaction.TargetId)
                target = account;
            else if (account.Id == transaction.OutgoingId)
                outgoing = account;
        }
        if (outgoing is null)
            return (false, "The outgoing account can't be found.");
        if (target is null && transaction.TargetId != new Guid())
            return (false, "The target account can't be found.");

        if (outgoing.Balance < transaction.Amount)
            return (false, $"Not enough balance in outgoing account '{outgoing.Name}'.");

        outgoing.Balance -= transaction.Amount;
        if(transaction.TargetId != new Guid())
            target.Balance += transaction.Amount;

        return (true, string.Empty);
    }

    public (bool Succeeded, string Message) ExportAccounts(string filePath) { throw new NotImplementedException(); }
    public (bool Succeeded, string Message) ImportAccounts(string filePath) { throw new NotImplementedException(); }
}
