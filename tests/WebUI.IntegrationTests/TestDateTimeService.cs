using Covid19.Application.Common.Interfaces;
using System;

namespace Covid19.WebUI.IntegrationTests
{
    public class TestDateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
