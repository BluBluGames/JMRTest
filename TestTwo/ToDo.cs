using System;
using System.Collections.Generic;
using System.Linq;

namespace TestTwo
{
    internal class ToDo
    {
        public IEnumerable<(Account, Person)> MatchPersonToAccount(IEnumerable<Group> groups, IEnumerable<Account> accounts, IEnumerable<string> emails)
        {
            var response = new List<(Account, Person)>();
            foreach (var @group in groups)
            {
                foreach (var @person in @group.People)
                {
                    foreach (var @email in @person.Emails)
                    {
                        var account = accounts.ToList().Find(x => x.EmailAddress.Email == @email.Email);
                        response.Add((account, @person));
                    }
                    
                }
            }
            return response;
        }
        public IEnumerable<(Account, Person)> MatchPersonToAccount_OneLiner(IEnumerable<Group> groups, IEnumerable<Account> accounts, IEnumerable<string> emails)
        {
            return (from @group in groups from person in @group.People from email in @person.Emails let account = accounts.ToList().Find(x => x.EmailAddress.Email == @email.Email) select (account, @person)).ToList();
        }
    }
}