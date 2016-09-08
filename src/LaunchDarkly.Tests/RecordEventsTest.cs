﻿using Moq;
using LaunchDarkly.Client;
using System.Net.Http;
using Xunit;

namespace LaunchDarkly.Tests
{
    public class RecordEventsTest
    {
        [Fact]
        public async void CanRaiseACustomEvent()
        {
            var config = Configuration.Default();
            var eventStore = new Mock<IStoreEvents>();
            var mockHttp = new Mock<HttpClient>();
            config.WithHttpClient(mockHttp.Object);
            var client = new LdClient(config, eventStore.Object);
            var user = User.WithKey("user@test.com");

            client.Track("AnyEventName", user, "AnyJson");

            eventStore.Verify(s => s.Add(It.IsAny<CustomEvent>()));
            client.Dispose();
        }
    }
}
