using System;
using Microsoft.Extensions.Logging;
using Moq;
using RichardSzalay.MockHttp;
using YelpApiServer.Core.Models;
using YelpApiServer.Services.IServices;
using YelpApiServer.Services.Services;

namespace YelpServerTests
{
	public class RestaurantSearchTest
	{
        
        [Fact]
        public async Task Test_BaseService()
        {

            var messageHandler = new MockHttpMessageHandler();
            messageHandler.Expect(Constants.ApiServiceURL + "business/search")
                .WithHeaders(@"Authorization: Bearer " + Constants.ApiKey)
                .WithQueryString("location=washington&term=cream")
                .Respond("application/json", "response");

        }
    }
}

