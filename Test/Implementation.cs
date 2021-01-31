using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Test
{
    public class Implementation
    {
        public static IEnumerable<PersonWithEmail> Flatten(IEnumerable<Person> people)
        {
            var personWithEmailList = new List<PersonWithEmail>();

            foreach (var person in people)
                foreach (var email in person.Emails)
                {
                    var personWithEmail = new PersonWithEmail
                    {
                        SanitizedNameWithId = FormatNameWithIdAndSanitize(person),
                        FormattedEmail = FormatBasedOnEmailAndType(email)
                    };
                    personWithEmailList.Add(personWithEmail);
                }

            return personWithEmailList;
        }

        private static string FormatNameWithIdAndSanitize(Person person)
        {
            return Regex.Replace($"{person.Name}{person.Id}", @"^[a-zA-Z0-9]+$", "");
        }
        private static string FormatBasedOnEmailAndType(EmailAddress email)
        {
            var formattedEmail = $"{email.Email}-{email.EmailType}";
            // do formatting
            // for now return email-type
            return formattedEmail;
        }

        /* Tylko na podstawie tego co przedstawiono w problemie takie mapowanie niesie za sobą całą masę problemów
            - Wypłaszczenie danych w taki sposób może doprowadzić do anomalii w czasie wprowadzanie updateów
            - Wypłaszczenie często podnosi koszty programowania w dłuższym czasie
            - Rozwiązanie pomaga w poprawie wydajności systemu
            - Rozwiązanie może być wprowadzone tylko wtedy, gdy emaile się nie powtarzają
        */
    }
}
