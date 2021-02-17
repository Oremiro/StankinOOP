using System;
using Xunit;

namespace Lab1.Tests
{
    public class TestCalendar
    {
        [Fact]
        public void GetDayNameFromDateCurrentSuccess()
        {
            ICalendar calendar = new Calendar();
            var date = new DateTime(17, 2, 2021);
            var result = calendar.GetDayNameFromDate(date); //WED
            var correctResult = "WED";
            Assert.Equal(correctResult, result);
        }
        
        [Fact]
        public void GetDayNameFromDatePastSuccess()
        {
            ICalendar calendar = new Calendar();
            var date = new DateTime(15, 2, 2021);
            var result = calendar.GetDayNameFromDate(date); //MON
            var correctResult = "MON";
            Assert.Equal(correctResult, result);
        }
        
        [Fact]
        public void GetDayNameFromDateFutureSuccess()
        {
            ICalendar calendar = new Calendar();
            var date = new DateTime(19, 2, 2021);
            var result = calendar.GetDayNameFromDate(date); //FRI
            var correctResult = "FRI";
            Assert.Equal(correctResult, result);
        }
        
        [Fact]
        public void GetDayNameFromDateFail()
        {
            ICalendar calendar = new Calendar();
            var date = new DateTime(17, 2, 2021);
            var result = calendar.GetDayNameFromDate(date); //WED
            var correctResult = "FRI";
            Assert.False(correctResult == result);
        }
        
        [Fact]
        public void IsLeapYearSuccess()
        {
            ICalendar calendar = new Calendar();
            var date = new DateTime(17, 2, 2000);
            var leap = calendar.IsLeapYear(date);
            var correctResult = true;
            Assert.True(correctResult == leap);
        }
        
        [Fact]
        public void IsLeapYearFail()
        {
            ICalendar calendar = new Calendar();
            var date = new DateTime(17, 2, 2021);
            var leap = calendar.IsLeapYear(date);
            var correctResult = true;
            Assert.False(correctResult == leap);
        }
        
        [Fact]
        public void IsDayWeekendSuccessFalseStatement()
        {
            ICalendar calendar = new Calendar();
            var date = new DateTime(17, 2, 2021);
            var weekend = calendar.IsLeapYear(date);
            var correctResult = true;
            Assert.False(correctResult == weekend);
        }
        
        [Fact]
        public void IsDayWeekendSuccessTrueStatementHoliday()
        {
            ICalendar calendar = new Calendar();
            var date = new DateTime(31, 12, 2021);
            var weekend = calendar.IsDayWeekend(date);
            var correctResult = true;
            Assert.True(correctResult == weekend);
        }
        
        [Fact]
        public void IsDayWeekendSuccessTrueStatementWeekend()
        {
            ICalendar calendar = new Calendar();
            var date = new DateTime(27, 2, 2021);
            var weekend = calendar.IsDayWeekend(date);
            var correctResult = true;
            Assert.True(correctResult == weekend);
        }
        
        [Fact]
        public void GetDaysFromMonthRegYear()
        {
            ICalendar calendar = new Calendar();
            var date = new DateTime(27, 3, 2021);
            var days = calendar.GetDaysFromMonthDate(date);
            var correctResult = 31;
            Assert.True(correctResult == days);
        }
        
        [Fact]
        public void GetDaysFromMonthRegYearEven()
        {
            ICalendar calendar = new Calendar();
            var date = new DateTime(27, 4, 2021);
            var days = calendar.GetDaysFromMonthDate(date);
            var correctResult = 30;
            Assert.True(correctResult == days);
        }
        
        [Fact]
        public void GetDaysFromMonthLeapYear()
        {
            ICalendar calendar = new Calendar();
            var date = new DateTime(27, 2, 2000);
            var days = calendar.GetDaysFromMonthDate(date);
            var correctResult = 29;
            Assert.True(correctResult == days);
        }
    }
}