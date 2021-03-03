
using Lab1;
using Lab3;
using Xunit;
using Calendar = Lab3.Calendar;
using ICalendar = Lab3.ICalendar;

namespace Lab5.Tests
{
    public class UnitTest1
    {
       private ICalendar Calendar { get; set; }
        public UnitTest1()
        {
            Calendar = new ExtendedGrigorianCalendar();   
        }
        [Fact]
        public void GetDayNameFromDateCurrentSuccess()
        {
           
            var date = new DateTime(17, 2, 2021);
            var result = Calendar.GetDayNameFromDate(date).ToString(); //WED
            var correctResult = "WED";
            Assert.Equal(correctResult, result);
        }
        
        [Fact]
        public void GetDayNameFromDatePastSuccess()
        {
            var date = new DateTime(15, 2, 2021);
            var result = Calendar.GetDayNameFromDate(date).ToString(); //MON
            var correctResult = "MON";
            Assert.Equal(correctResult, result);
        }
        
        [Fact]
        public void GetDayNameFromDateFutureSuccess()
        {
            var date = new DateTime(19, 2, 2021);
            var result = Calendar.GetDayNameFromDate(date).ToString(); //FRI
            var correctResult = "FRI";
            Assert.Equal(correctResult, result);
        }
        
        [Fact]
        public void GetDayNameFromDateFail()
        {
            var date = new DateTime(17, 2, 2021);
            var result = Calendar.GetDayNameFromDate(date).ToString(); //WED
            var correctResult = "FRI";
            Assert.False(correctResult == result);
        }
        
        [Fact]
        public void IsLeapYearSuccess()
        {
            var date = new DateTime(17, 2, 2000);
            var leap = Calendar.IsLeapYear(date);
            var correctResult = true;
            Assert.True(correctResult == leap);
        }
        
        [Fact]
        public void IsLeapYearFail()
        {
            var date = new DateTime(17, 2, 2021);
            var leap = Calendar.IsLeapYear(date);
            var correctResult = true;
            Assert.False(correctResult == leap);
        }
        
        [Fact]
        public void IsDayWeekendSuccessFalseStatement()
        {
            var date = new DateTime(17, 2, 2021);
            var weekend = Calendar.IsLeapYear(date);
            var correctResult = true;
            Assert.False(correctResult == weekend);
        }
        
        [Fact]
        public void IsDayWeekendSuccessTrueStatementHoliday()
        {
            var date = new DateTime(31, 12, 2021);
            var weekend = Calendar.IsDayWeekend(date);
            var correctResult = true;
            Assert.True(correctResult == weekend);
        }
        
        [Fact]
        public void IsDayWeekendSuccessTrueStatementWeekend()
        {
            var date = new DateTime(27, 2, 2021);
            var weekend = Calendar.IsDayWeekend(date);
            var correctResult = true;
            Assert.True(correctResult == weekend);
        }
        
        [Fact]
        public void GetDaysFromMonthRegYear()
        {
            var date = new DateTime(27, 3, 2021);
            var days = Calendar.GetDaysFromMonthDate(date);
            var correctResult = 31;
            Assert.True(correctResult == days);
        }
        
        [Fact]
        public void GetDaysFromMonthRegYearEven()
        {
            var date = new DateTime(27, 4, 2021);
            var days = Calendar.GetDaysFromMonthDate(date);
            var correctResult = 30;
            Assert.True(correctResult == days);
        }
        
        [Fact]
        public void GetDaysFromMonthLeapYear()
        {
            var date = new DateTime(27, 2, 2000);
            var days = Calendar.GetDaysFromMonthDate(date);
            var correctResult = 29;
            Assert.True(correctResult == days);
        }
    }
}