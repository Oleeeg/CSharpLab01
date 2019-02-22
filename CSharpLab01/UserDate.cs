using System;

namespace CSharpLab01
{
    internal class UserDate
    {
        private DateTime _dateOfBirth;
        private string _years;
        private string _westernSign;
        private string _chineseSign;

        private static String[] chineseHor = { "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", };
        private static String[] westernHor = { "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius", "Capricorn", "Aquarius", "Pieces" };


        internal UserDate()
        {
            _dateOfBirth = DateTime.Today;
        }

        internal DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                int yearsOld = DateTime.Today.Year - _dateOfBirth.Year;
                if (DateTime.Today.Year != _dateOfBirth.Year)
                {
                    if (_dateOfBirth.DayOfYear > DateTime.Today.DayOfYear) yearsOld--;
                }

                bool valid = Validation();
                if (valid)
                {
                    _years = yearsOld.ToString();
                    _chineseSign = chineseHor[_dateOfBirth.Year % 12];
                    _westernSign = WestSign();
                }
                else
                {
                    Wipe();
                }
            }
        }

        public bool Validation()
        {
            bool valid = DateTime.Today.Year - _dateOfBirth.Year >= 0 && DateTime.Today.Year - _dateOfBirth.Year <= 135;
            if (DateTime.Today.Year == _dateOfBirth.Year)
            {
                if (DateTime.Today.DayOfYear < _dateOfBirth.DayOfYear) valid = false;
            }
            return valid;
        }

        public string Years
        {
            get { return _years; }
            set
            {
                _years = value;
            }
        }

        public string WesternSign
        {
            get { return _westernSign; }
            set
            {
                _westernSign = value;
            }
        }

        public string ChineseSign
        {
            get { return _chineseSign; }
            set
            {
                _chineseSign = value;
            }
        }

        private string WestSign()
        {
            string sign = "";
            if (((_dateOfBirth.Month == 1) && (_dateOfBirth.Day >= 21 && (_dateOfBirth.Day <= 31)) || ((_dateOfBirth.Month == 2) && (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 20)))) sign = westernHor[10];
            if (((_dateOfBirth.Month == 2) && (_dateOfBirth.Day >= 21 && (_dateOfBirth.Day <= 28)) || ((_dateOfBirth.Month == 3) && (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 20)))) sign = westernHor[11];
            if (((_dateOfBirth.Month == 3) && (_dateOfBirth.Day >= 21 && (_dateOfBirth.Day <= 31)) || ((_dateOfBirth.Month == 4) && (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 20)))) sign = westernHor[0];
            if (((_dateOfBirth.Month == 4) && (_dateOfBirth.Day >= 21 && (_dateOfBirth.Day <= 30)) || ((_dateOfBirth.Month == 5) && (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 20)))) sign = westernHor[1];
            if (((_dateOfBirth.Month == 5) && (_dateOfBirth.Day >= 21 && (_dateOfBirth.Day <= 31)) || ((_dateOfBirth.Month == 6) && (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 21)))) sign = westernHor[2];
            if (((_dateOfBirth.Month == 6) && (_dateOfBirth.Day >= 22 && (_dateOfBirth.Day <= 30)) || ((_dateOfBirth.Month == 7) && (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 22)))) sign = westernHor[3];
            if (((_dateOfBirth.Month == 7) && (_dateOfBirth.Day >= 23 && (_dateOfBirth.Day <= 31)) || ((_dateOfBirth.Month == 8) && (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 23)))) sign = westernHor[4];
            if (((_dateOfBirth.Month == 8) && (_dateOfBirth.Day >= 24 && (_dateOfBirth.Day <= 31)) || ((_dateOfBirth.Month == 9) && (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 23)))) sign = westernHor[5];
            if (((_dateOfBirth.Month == 9) && (_dateOfBirth.Day >= 24 && (_dateOfBirth.Day <= 30)) || ((_dateOfBirth.Month == 10) && (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 23)))) sign = westernHor[6];
            if (((_dateOfBirth.Month == 10) && (_dateOfBirth.Day >= 24 && (_dateOfBirth.Day <= 31)) || ((_dateOfBirth.Month == 11) && (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 22)))) sign = westernHor[7];
            if (((_dateOfBirth.Month == 11) && (_dateOfBirth.Day >= 23 && (_dateOfBirth.Day <= 30)) || ((_dateOfBirth.Month == 12) && (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 21)))) sign = westernHor[8];
            if (((_dateOfBirth.Month == 12) && (_dateOfBirth.Day >= 22 && (_dateOfBirth.Day <= 31)) || ((_dateOfBirth.Month == 1) && (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 20)))) sign = westernHor[9];
            return sign;

        }

        private void Wipe()
        {
            _years = "";
            _westernSign = "";
            _chineseSign = "";
        }
    }
}
