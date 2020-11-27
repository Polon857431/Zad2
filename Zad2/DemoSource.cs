using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

namespace DemoSource
{
    public class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<EmailAddress> Emails { get; set; }
    }

    public class EmailAddress
    {
        public string Email { get; set; }
        public string EmailType { get; set; }
    }

    public class Account
    {
        public string Id { get; set; }
        public EmailAddress EmailAddress { get; set; }
    }

    public class Group
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public IEnumerable<Person> People { get; set; }
    }

    internal class ToDo
    {
        public IEnumerable<(DemoSource.Account, DemoSource.Person)>
        MatchPersonToAccount(
            IEnumerable<DemoSource.Group> groups,
            IEnumerable<DemoSource.Account> accounts,
            IEnumerable<string> emails)
        {
            return from g in groups 
                from p in g.People 
                from e in p.Emails 
                   select (accounts.Single(a=>a.EmailAddress.Email == e.Email), p );
        }
    }

}
