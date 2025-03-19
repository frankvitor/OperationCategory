using System;
using OperationCategory.Models;
using OperationCategory.Services;
using Xunit;
using FluentAssertions;

namespace OperationCategory.Tests.Services
{
    public class TradeServiceTests
    {
        private readonly TradeService _service;

        public TradeServiceTests()
        {
            _service = new TradeService();
        }

        [Fact]
        public void Should_Return_HIGHRISK_When_TradeExceeds1Million_And_ClientSectorIsPrivate()
        {
            var trade = new Trade(2000000, "Private", new DateTime(2025, 12, 29));
            DateTime referenceDate = new DateTime(2020, 12, 11);

            var category = _service.CategorizeTrade(trade, referenceDate);

            category.Should().Be("HIGHRISK");
        }

        [Fact]
        public void Should_Return_MEDIUMRISK_When_TradeExceeds1Million_And_ClientSectorIsPublic()
        {
            var trade = new Trade(4000000, "Public", new DateTime(2025, 12, 29));
            DateTime referenceDate = new DateTime(2020, 12, 11);

            var category = _service.CategorizeTrade(trade, referenceDate);

            category.Should().Be("MEDIUMRISK");
        }

        [Fact]
        public void Should_Return_EXPIRED_When_PaymentDateIsInThePast()
        {
            var trade = new Trade(400000, "Public", new DateTime(2020, 07, 01));
            DateTime referenceDate = new DateTime(2020, 12, 11);

            var category = _service.CategorizeTrade(trade, referenceDate);

            category.Should().Be("EXPIRED");
        }
    }
}
