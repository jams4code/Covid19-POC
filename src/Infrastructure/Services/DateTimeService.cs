using Covid19.Application.Common.Interfaces;
using System;

namespace Covid19.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
