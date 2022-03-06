﻿using System;
using System.Collections.Generic;
using GalaxyQuest.Converters;
using GalaxyQuest.Interfaces;
using NSubstitute;
using Xunit;

namespace GalaxyQuest.Test
{
    public class ConverterTests
    {
        private readonly InterGalacticCurrencyConverter _sut;
        private readonly INumberMapper _numberMapper;
        private readonly IMessageWriter _messageWriter;

        public ConverterTests()
        {
            _numberMapper = Substitute.For<INumberMapper>();
            _messageWriter = Substitute.For<IMessageWriter>();
            _sut = new InterGalacticCurrencyConverter(_numberMapper, _messageWriter);
        }

        [Fact]
        public void CalculateArabicValue_GivenValidInput_ReturnsCorrectValue()
        {
            //Arrange
            const string input = "pish tegj glob glob";
            var map = new Dictionary<string, string>
            {
                {"pish", "X"},
                {"tegj", "L"},
                {"glob", "I"},
            };
            _numberMapper.GetMap().Returns(map);

            //Act
            var dto = _sut.CalculateArabicValue(input);

            //Assert
            Assert.Equal(42, dto.Number);
            Assert.Equal(string.Empty, dto.Message);
        }

        [Fact]
        public void CalculateArabicValue_GivenInvalidInput_ReturnsErrorMessage()
        {
            //Arrange
            const string input = "pish posh";
            var map = new Dictionary<string, string>
            {
                {"pish", "X"},
                {"tegj", "L"},
                {"glob", "I"},
            };
            _numberMapper.GetMap().Returns(map);

            //Act
            var dto = _sut.CalculateArabicValue(input);

            //Assert
            Assert.Equal("I have no idea what you are talking about", dto.Message);
        }

        [Fact]
        public void GetCommodityValue_GivenValidInput_ReturnsCorrectValue()
        {
            //Arrange
            const string input = "pish pish iron";
            var map = new Dictionary<string, string>
            {
                {"pish", "X"},
                {"tegj", "L"},
                {"glob", "I"},
                {"prok", "V"}
            };
            _numberMapper.GetMap().Returns(map);
            _numberMapper.SetCommodityPrice("iron", 10, 20);
            _numberMapper.GetCommodityPrice("iron").Returns(10);

            //Act
            var dto = _sut.GetCommodityData(input);

            //Assert
            Assert.Equal(200, dto.Number);
        }

        [Fact]
        public void GetCommodityValue_GivenInvalidInput_ReturnsErrorMessage()
        {
            //Arrange
            const string input = "pish posh iron";
            var map = new Dictionary<string, string>
            {
                {"pish", "X"},
                {"tegj", "L"},
                {"glob", "I"},
                {"prok", "V"}
            };
            _numberMapper.GetMap().Returns(map);
            _numberMapper.SetCommodityPrice("iron", 10, 20);
            _numberMapper.GetCommodityPrice("iron").Returns(10);

            //Act
            var dto = _sut.GetCommodityData(input);

            //Assert
            Assert.Equal("I have no idea what you are talking about", dto.Message);
        }

        [Fact]
        public void CalculateCommodityPrice_GivenValidInput_ExecutesExpectedMethod()
        {
            //Arrange
            const string input = "glob glob silver";
            var map = new Dictionary<string, string>
            {
                {"pish", "X"},
                {"tegj", "L"},
                {"glob", "I"},
                {"prok", "V"}
            };
            _numberMapper.GetMap().Returns(map);
            var galacticRoman = new[] {input, "34 credits"};

            //Act
            _sut.CalculateCommodityPrice(galacticRoman);

            //Assert
            _numberMapper.Received().SetCommodityPrice(Arg.Any<string>(),Arg.Any<decimal>(),Arg.Any<decimal>());
        }

        [Fact]
        public void CalculateCommodityPrice_GivenInvalidInput_ExecutesExpectedMethod()
        {
            //Arrange
            const string input = "glob glob silver";
            var map = new Dictionary<string, string>
            {
                {"pish", "X"},
                {"tegj", "L"},
                {"glob", "I"},
                {"prok", "V"}
            };
            _numberMapper.GetMap().Returns(map);
            var galacticRoman = new[] {input, "34k credits"};
            
            //Act
            _sut.CalculateCommodityPrice(galacticRoman);

            //Assert
            _messageWriter.Received().WriteMessage(Arg.Any<string>());
        }
    }
}