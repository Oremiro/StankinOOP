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
    }
}