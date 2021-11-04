using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OpenBreweryASP.Contracts;
using OpenBreweryASP.Controllers;
using OpenBreweryASP.Data;
using OpenBreweryASP.Models.Dtos;
using Xunit;

namespace Unit.Tests
{
    public class BreweriesControllerTest
    {
        private readonly Mock<IBreweryRepository> _mockRepo;
        private readonly BreweriesController _controller;


        public BreweriesControllerTest()
        {
            _mockRepo = new Mock<IBreweryRepository>();
            _controller = new BreweriesController(_mockRepo.Object);
        }

        [Theory]
        [InlineData("Lagos", "Alameda")]
        public async Task GetBreweriesTest(string invalidCity, string validCity)
        {
            //arrange 
            var mockBreweryDtos = MockData.GetAllBreweries();
            _mockRepo.Setup(repository => repository.GetAllAsync()).Returns(Task.FromResult(mockBreweryDtos));

            //act
            var result = await _controller.GetBreweries(invalidCity);
            var response = (NotFoundResult)result;

            //assert
            Assert.Equal(404, response.StatusCode);

            // Fluent assertion version
            result.Should().BeOfType<NotFoundResult>();
            
        }

    [Theory]
    [InlineData("Nevada")]
    public async Task GetBreweryByState(string validState)
    {
        //arrange 
        var validStateBrewery = MockData.GetAllBreweries().Where(b => b.State == validState).ToList();
        _mockRepo.Setup(repository => repository.GetAllAsync()).Returns(Task.FromResult(MockData.GetAllBreweries()));
        
        //act
        var result = await _controller.GetBreweryByState(validStateBrewery.First().State);
        
        //assert
        if (result is OkResult response) Assert.Equal(200, response.StatusCode);
        
        // Fluent assertion version
        result.Should().NotBe(null);
        result.Should().BeOfType<OkResult>();
        
    }

    [Theory]
    [InlineData("contract")]
    public async Task GetBreweryByType(string validType)
    {
        //arrange 
        var validTypeBrewery = MockData.GetAllBreweries().Where(b => b.BreweryType == validType).ToList();
        _mockRepo.Setup(repository => repository.GetAllAsync()).Returns(Task.FromResult(MockData.GetAllBreweries()));
        
        //act
        var result = await _controller.GetBreweryByType(validTypeBrewery.First().BreweryType);
        
        //assert
        if (result is OkResult response) Assert.Equal(200, response.StatusCode);
        
        
    }
    

    }
}
