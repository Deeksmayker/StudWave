using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Model
{
    class DateTimeInfo
    {
        public static DateTimeInfo Instance = new DateTimeInfo();

        #region EnumAndProperties

        public enum Months
        {
            Январь = 1,
            Февраль = 2,
            Март = 3,
            Апрель = 4,
            Май = 5,
            Июнь = 6,
            Июль = 7,
            Август = 8,
            Сентябрь = 9,
            Октябрь = 10,
            Ноябрь = 11,
            Декабрь = 12
        }

        private int year = 2020;

        public int Year
        {
            get => year;
        }

        private int month = 9;

        public int Month
        {
            get => month;
            set
            {
                if (value > 12)
                {
                    value -= 12;
                    year++;
                }

                if (value == 9)
                    Course++;

                month = value;
            }
        }

        private int week = 1;

        public int Week
        {
            get => week;
            set
            {
                if (value > 4)
                {
                    value -= 4;
                    Month++;
                }

                week = value;
            }
        }

        private int hour = 8;

        public int Hour
        {
            get => hour;
            set
            {
                if (value > 24)
                {
                    value -= 24;
                    Week++;
                }

                hour = value;
            }
        }

        private int minute = 0;

        public int Minute
        {
            get => minute;
            set
            {
                if (value > 60)
                {
                    value -= 60;
                    Hour++;
                }

                minute = value;
            }
        }

        private int course = 1;

        public int Course
        {
            get => course;
            set => course = value < course ? throw new Exception("Курс стал меньше, как") : value;
        }

        #endregion

        public string GetDateAndCourse()
        {
            return String.Format("{0} {1} год {2} курс", (Months)month, year, course);
        }
    }
}
