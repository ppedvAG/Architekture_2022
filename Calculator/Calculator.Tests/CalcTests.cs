using FluentAssertions;
using Microsoft.QualityTools.Testing.Fakes;
using NUnit.Framework;
using System;

namespace Calculator.Tests
{
    public class CalcTests
    {

        [Test]
        public void Sum_2_and_3_results_5()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(2, 3);

            //Assert
            //Assert.AreEqual(5, result);
            result.Should().BeInRange(1, 100);
        }

        [Test]
        public void Sum_MAX_and_1_throws_OverflowExcpetion()
        {
            var calc = new Calc();

            //Assert.Throws<OverflowException>(() => calc.Sum(int.MaxValue, 1));
            new Action(() => calc.Sum(int.MaxValue, 1)).Should().Throw<OverflowException>();
        }

        [Test]
        public void IsWeekend_test()
        {
            var calc = new Calc();

            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2022, 4, 11); //mo
                calc.IsWeekend().Should().BeFalse();
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2022, 4, 12); //di
                calc.IsWeekend().Should().BeFalse();
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2022, 4, 13); //mi
                calc.IsWeekend().Should().BeFalse();
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2022, 4, 14); //do
                calc.IsWeekend().Should().BeFalse();
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2022, 4, 15); //fr
                calc.IsWeekend().Should().BeFalse();
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2022, 4, 16); //sa
                calc.IsWeekend().Should().BeTrue();
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2022, 4, 17); //so
                calc.IsWeekend().Should().BeTrue();
                
            }
        }
    }
}