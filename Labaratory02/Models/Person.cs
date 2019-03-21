using System;

namespace Labaratory02.Models
{
    [Serializable]
    public class Person
    {
        public readonly string FirstName, SecondName, Email;
        public readonly DateTime BornDateTime;

        public readonly bool IsAdult, IsBirthday;
        public readonly string ChineseSign , SunSign;

        private enum ChineseSigns
        {
            Monkey = 1,
            Rooster,
            Dog,
            Pig,
            Rat,
            Ram,
            Tiger,
            Rabbit,
            Dragon,
            Sneak,
            Horse,
            Ox
        }

        private enum SunSigns
        {
            Capricorn,
            Aquarius,
            Pisces,
            Aries,
            Taurus,
            Gemini,
            Cancer,
            Leo,
            Virgo,
            Libra,
            Scorpio,
            Sagittarius
        }

        public Person(){}

        public Person(string firstName , string secondName , string email , DateTime bornDateTime)
        {
            FirstName = firstName;
            SecondName = secondName;
            Email = email;
            BornDateTime = bornDateTime;

            IsAdult = CalculateAge(bornDateTime) > 18;
            ChineseSign = CalculateChineseSign(bornDateTime);
            SunSign = CalculateSunSign(bornDateTime);
            IsBirthday = CalculateBirthday(bornDateTime);

        }

        public Person(string firstName, string secondName, string email)
        {
            FirstName = firstName;
            SecondName = secondName;
            Email = email;

            IsAdult = false;
            ChineseSign = String.Empty;
            SunSign = String.Empty;
            IsBirthday = false;
        }

        public Person(string firstName, string secondName, DateTime bornDateTime)
        {
            FirstName = firstName;
            SecondName = secondName;
            BornDateTime = bornDateTime;

            IsAdult = CalculateAge(BornDateTime) > 18;
            ChineseSign = CalculateChineseSign(bornDateTime);
            SunSign = CalculateSunSign(bornDateTime);
            IsBirthday = CalculateBirthday(bornDateTime);
        }



        private int CalculateAge(DateTime dateOfBirth)
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;
            return age;
        }

        private string CalculateChineseSign(DateTime dateOfBirth)
        {
            return ((ChineseSigns)(dateOfBirth.Date.Year % 12)).ToString("G");
        }
        
        private string CalculateSunSign(DateTime dateOfBirth)
        {
            switch (dateOfBirth.Date.Month)
            {
                case 1:
                    return (dateOfBirth.Date.Day <= 20) ? SunSigns.Capricorn.ToString() : SunSigns.Aquarius.ToString();
                case 2:
                    return (dateOfBirth.Date.Day <= 19) ? SunSigns.Aquarius.ToString() : SunSigns.Pisces.ToString();
                case 3:
                    return (dateOfBirth.Date.Day <= 20) ? SunSigns.Pisces.ToString() : SunSigns.Aries.ToString();
                case 4:
                    return (dateOfBirth.Date.Day <= 20) ? SunSigns.Aries.ToString() : SunSigns.Taurus.ToString();
                case 5:
                    return (dateOfBirth.Date.Day <= 21) ? SunSigns.Taurus.ToString() : SunSigns.Gemini.ToString();
                case 6:
                    return (dateOfBirth.Date.Day <= 21) ? SunSigns.Gemini.ToString() : SunSigns.Cancer.ToString();
                case 7:
                    return (dateOfBirth.Date.Day <= 22) ? SunSigns.Cancer.ToString() : SunSigns.Leo.ToString();
                case 8:
                    return (dateOfBirth.Date.Day <= 23) ? SunSigns.Leo.ToString() : SunSigns.Virgo.ToString();
                case 9:
                    return (dateOfBirth.Date.Day <= 23) ? SunSigns.Virgo.ToString() : SunSigns.Libra.ToString();
                case 10:
                    return (dateOfBirth.Date.Day <= 23) ? SunSigns.Libra.ToString() : SunSigns.Scorpio.ToString();
                case 11:
                    return (dateOfBirth.Date.Day <= 22) ? SunSigns.Scorpio.ToString() : SunSigns.Sagittarius.ToString();
                case 12:
                    return (dateOfBirth.Date.Day <= 23) ? SunSigns.Sagittarius.ToString() : SunSigns.Capricorn.ToString();
                default:
                    return String.Empty;
            }

        }

        private bool CalculateBirthday(DateTime dateOfBirth)
        {
            return DateTime.Now.Day == dateOfBirth.Day && DateTime.Now.Month == dateOfBirth.Month;
        }


    }
}
