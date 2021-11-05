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
using OpenBreweryASP.Models.Entities;
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
        [InlineData("Lagos")]
        public async Task GetBreweriesTestInvalidCity(string invalidCity)
        {
            //arrange 
            _mockRepo.Setup(repository => repository.ExistsByCityAsync(invalidCity)).ReturnsAsync(null);

            //act
            var resultOfInvalidCity = await _controller.AllBreweries(invalidCity);
            var ofInvalidCity = (NotFoundResult)resultOfInvalidCity;

            //assert
            Assert.Equal(404, ofInvalidCity.StatusCode);
            Assert.IsAssignableFrom<IActionResult>(resultOfInvalidCity);
            Assert.IsType<NotFoundResult>(resultOfInvalidCity);

            // Fluent assertion version
            resultOfInvalidCity.Should().BeOfType<NotFoundResult>();
        }
        
        [Theory]
        [InlineData("Bend")]
        public async Task GetBreweriesTestValidCity(string validCity)
        {
            

            //act
            var resultOfValidCity = await _controller.AllBreweries(validCity);
            var ofValidCity = (OkObjectResult)resultOfValidCity;

            //assert
            Assert.IsAssignableFrom<IActionResult>(resultOfValidCity);


      
       
        }
        
        
        [Theory]
        [InlineData("")]
        public async Task GetBreweriesTestEmpty(string empty)
        {
            //arrange 
            var breweryDtos = MockData.GetAllBreweries();
            _mockRepo.Setup(repository =>  repository.GetAllAsync()).Returns(Task.FromResult(breweryDtos));

            //act
            var resultOfInvalidCity = await _controller.AllBreweries(empty);
            var validCity = (OkObjectResult)resultOfInvalidCity;

            //assert
            Assert.Equal(200, validCity.StatusCode);
        }
        
        

    [Theory]
    [InlineData("Nevada")]
    public async Task GetBreweryByState(string validState)
    {
        //arrange 
        var validStateBrewery = MockData.GetAllBreweries().Where(b => b.State == validState).ToList();
        _mockRepo.Setup(repository => repository.GetAllAsync()).Returns(Task.FromResult(MockData.GetAllBreweries()));
        
        //act
        // var result = await _controller.GetBreweriesByState(validStateBrewery.First().State);
        
        // //assert
        // if (result is OkResult response) Assert.Equal(200, response.StatusCode);
        // Assert.IsAssignableFrom<IActionResult>(result);
        // Assert.NotNull(result);
        
        
  
        
        // // Fluent assertion version
        // result.Should().NotBe(null);
        //
        //
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
        Assert.IsAssignableFrom<IActionResult>(result);
        Assert.NotNull(result);
        
        // Fluent assertion version
        result.Should().NotBe(null);
        result.Should().BeAssignableTo<IActionResult>();




    }
    
    
    
    

    }
}
