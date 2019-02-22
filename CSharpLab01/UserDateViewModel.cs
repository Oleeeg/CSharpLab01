using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace CSharpLab01
{
    internal class UserDateViewModel : INotifyPropertyChanged
    {
        private readonly UserDate userDate = new UserDate();

        public DateTime BirthDate
        {
            get
            {
                return userDate.DateOfBirth;
            }
            set
            {
                userDate.DateOfBirth = value;
                bool valid = userDate.Validation();
                if (!valid)
                {
                    MessageBox.Show("You have entered incorrect date!", "Something went wrong...", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    bool birthday = DateTime.Today.Month == userDate.DateOfBirth.Month && DateTime.Today.DayOfYear == userDate.DateOfBirth.DayOfYear;
                    if (birthday)
                    {
                        MessageBox.Show("Hey, you! HAPPY BIRTHDAY!!!");
                    }
                }
                OnPropertyChanged();
                OnPropertyChanged(nameof(Years));
                OnPropertyChanged(nameof(ChineseSign));
                OnPropertyChanged(nameof(WesternSign));
            }
        }

        public string Years
        {
            get
            {
                return "Your age is : " + userDate.Years + " years old";
            }
        }

        public string WesternSign
        {
            get
            {
                return "Your sign in western horoscope is" + '\n' + userDate.WesternSign;
            }
        }

        public string ChineseSign
        {
            get
            {
                return "Your sign in chinese horoscope is" + '\n' + userDate.ChineseSign;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}