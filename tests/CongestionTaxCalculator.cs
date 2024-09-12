using Congestion.Calculator.Contracts;
using Congestion.Calculator.Helpers;
using Congestion.Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using System.Runtime.ConstrainedExecution;

namespace Congestion.Calculator.Tests
{
    [TestClass]
    public class CongestionTaxCalculatorTests
    {
        private CongestionTaxCalculator _calculator;

        [TestInitialize]
        public void SetUp()
        {
            _calculator = new CongestionTaxCalculator();
        }

        [TestMethod]
        public void GetTax_EmptyDatesList_ThrowsException()
        {
            // Arrange
            var vehicle = new Car();
            var dates = new List<DateTime>();

            Assert.ThrowsException<ArgumentException>(() =>
            {
                var result = _calculator.GetTax(vehicle, dates);
            });
        }

        [TestMethod]
        public void GetTax_SingleDate_ReturnsTollFee()
        {
            // Arrange
            var vehicle = new Car();
            var dates = new List<DateTime> { new DateTime(2022, 1, 3, 12, 0, 0) };

            // Act
            var result = _calculator.GetTax(vehicle, dates);

            // Assert
            Assert.AreEqual(TollFeeCalculator.GetTollFee(dates[0]), result);
        }

        [TestMethod]
        public void GetTax_MultipleDates_ReturnsTotalTollFee()
        {
            // Arrange
            var vehicle = new Car();
            var dates = new List<DateTime>
            {
                new DateTime(2022, 1, 3, 12, 0, 0),
                new DateTime(2022, 1, 3, 14, 0, 0),
                new DateTime(2022, 1, 3, 16, 0, 0)
            };

            // Act
            var result = _calculator.GetTax(vehicle, dates);

            // Assert
            Assert.AreEqual(
                TollFeeCalculator.GetTollFee(dates[0]) +
                TollFeeCalculator.GetTollFee(dates[1]) +
                TollFeeCalculator.GetTollFee(dates[2]),
                result
            );
        }

        [TestMethod]
        public void GetTax_TheSingleChargeRule()
        {
            // Arrange
            var vehicle = new Car();
            var date1 = new DateTime(2022, 1, 3, 6, 15, 0);
            var date2 = new DateTime(2022, 1, 3, 6, 20, 0);
            var date3 = new DateTime(2022, 1, 3, 6, 35, 0);

            var dates = new List<DateTime>
            {
               date1,
               date2,
               date3
            };

            // Act
            var result = _calculator.GetTax(vehicle, dates);

            // Assert
            Assert.AreEqual(
                TollFeeCalculator.GetTollFee(date3),
                result
            );
        }

        [TestMethod]
        public void GetTax_TollFreeDate_ReturnsZero()
        {
            // Arrange
            var vehicle = new Car();
            var dates = new List<DateTime> { new DateTime(2022, 1, 1, 12, 0, 0) }; // assume this date is toll-free

            // Act
            var result = _calculator.GetTax(vehicle, dates);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetTax_TollFreeVehicle_ReturnsZero()
        {
            // Arrange
            var vehicle = new Motorcycles();
            var dates = new List<DateTime> { new DateTime(2022, 1, 1, 12, 0, 0) };

            // Act
            var result = _calculator.GetTax(vehicle, dates);

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}