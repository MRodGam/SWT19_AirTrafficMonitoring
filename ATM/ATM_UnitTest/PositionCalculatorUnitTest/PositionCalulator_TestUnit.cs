﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using NSubstitute;
using ATM;
using TransponderReceiver; 


namespace ATM_UnitTest.PositionCalculatorUnitTest
{
    [TestFixture]
    public class PositionCalulator_TestUnit
    {
        private IPositionCalculator _uut;

        [SetUp]
        public void SetUp()
        {
            _uut = new PositionCalculator();
        }

        [Test]
        public void Test_PositionReturnsNord()
        {
            FormattedData test1 = new FormattedData("test1", 60, 34, 0, DateTime.Today, "Nord", 0); 
            string expected = "Nord";
            string actual = _uut.CalculatePosition(test1);
            
           Assert.AreEqual(expected,actual);
        }

        [Test]
        public void Test_PositionReturnsØst()
        {
            FormattedData test2 = new FormattedData("test2", 60, 50, 0, DateTime.Today, "Øst", 0); 
            string expected = "Øst";
            string actual = _uut.CalculatePosition(test2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_PositionReturnsSyd()
        {
            FormattedData test3 = new FormattedData("test3", 60, 71, 0, DateTime.Today, "Syd", 0);
            string expected = "Syd";
            string actual = _uut.CalculatePosition(test3);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_PositionReturnsVest()
        {
            FormattedData test4 = new FormattedData("test4", 60, 120, 0, DateTime.Today, "Vest", 0);
            string expected = "Vest";
            string actual = _uut.CalculatePosition(test4);

            Assert.AreEqual(expected, actual);
        }
    }
}
