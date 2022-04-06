using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RegularExpressions
{
    class Program
    {
        static void DomainValidation()
        {
            var domain = "https://www.google.com";

            Regex regex = new Regex(@"^https?://(www.)?([\w]+)((\.[a-zA-Z]{2,3})+)$");
            Console.WriteLine(regex.IsMatch(domain));
        }

        static void PhoneValidation()
        {
            var phone = "+52 (666) 123 4567";
            Regex regex = new Regex(@"^\+[\d]{2}\s\([\d]{3}\)\s[\d]{3}\s[\d]{4}$");
            Console.WriteLine(regex.IsMatch(phone));
        }

        /*
         * 8 caracteres mínimo
         * Al menos una mayuscula
         * al menos una minuscula
         * Al menos un numero
         * Al menos un caracter especial (*#!$?)
         */
        static void PasswordValidation()
        {
            var pass = "SuperP4$$w0rd";
            Regex regex = new Regex(@"^(?=\S+[A-Z])(?=\S+[a-z])(?=\S+\d)(?=\S+[*#!$?])(?=.{8,}$)");
            Console.WriteLine(regex.IsMatch(pass));
        }

        static void Main(string[] args)
        {
            PasswordValidation();
        }
    }
}
