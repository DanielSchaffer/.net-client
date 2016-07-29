using LaunchDarkly.Client;
using System;
using Xunit;

namespace LaunchDarkly.Tests
{
    class EventTest
    {
        [Fact]
        public void CanConvertDateTimeToUnixMillis()
        {
            var dateTime = new DateTime(2000, 1, 1, 0, 0, 10, DateTimeKind.Utc);
            var dateTimeMillis = 946684810000;
            var actualEpochMillis = Event.GetUnixTimestampMillis(dateTime);
            Assert.Equal(dateTimeMillis, actualEpochMillis);
        }
    }
}
