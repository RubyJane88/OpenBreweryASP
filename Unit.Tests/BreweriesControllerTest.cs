using System;
using System.Collections;
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
            _mockRepo.Setup(repository => repository.GetBreweryByCityAsync(invalidCity))
                .Returns(Task.FromResult<IEnumerable<BreweryDto>>(null));

            //act
            var resultOfInvalidCity = await _controller.GetAllBreweries(invalidCity);
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
            
            //arrange
            var mockBreweryDto = MockData.GetAllBreweries().Where(c => c.City == validCity);
            
            _mockRepo.Setup(repository => repository.GetBreweryByCityAsync(validCity))
                .Returns(Task.FromResult(mockBreweryDto));
            
            //act
            var resultOfValidCity = await _controller.GetAllBreweries(validCity);
            var response = (OkObjectResult)resultOfValidCity;
            var breweriesByCities = response.Value as IEnumerable<BreweryDto>;
            
            // assert
            Assert.Equal(200, response.StatusCode);
            Assert.IsAssignableFrom<IActionResult>(resultOfValidCity);
            Assert.IsType<OkObjectResult>(resultOfValidCity);
            
            
            //Fluent Assertion version
            breweriesByCities.Should().HaveCount(1);
            
        }
        
        //GET ALL BREWERIES
        [Theory]
        [InlineData("")]
        public async Task GetBreweriesTestEmpty(string empty)
        {
            //arrange 
            var breweryDtos = MockData.GetAllBreweries();
            _mockRepo.Setup(repository =>  repository.GetAllBreweriesAsync()).Returns(Task.FromResult(breweryDtos));

            //act
            var resultOfInvalidCity = await _controller.GetAllBreweries(empty);
            var validCity = (OkObjectResult)resultOfInvalidCity;

            //assert
            Assert.Equal(200, validCity.StatusCode);
            Assert.IsAssignableFrom<IActionResult>(resultOfInvalidCity);
            Assert.IsType<OkObjectResult>(resultOfInvalidCity);
            
        }
        
        

    [Theory]
    [InlineData("Nevada")]
    public async Task GetBreweriesByState(string validState)
    {
        //arrange 
        var mockBreweryDtos = MockData.GetAllBreweries().Where(b => b.State == validState);
        _mockRepo.Setup(repository => repository.GetBreweriesByStateAsync(validState))
            .Returns(Task.FromResult(mockBreweryDtos));

        //act
        var result = await _controller.GetBreweriesByState(validState);
        var response = (OkObjectResult)result;
        var breweriesByState = response.Value as IEnumerable<BreweryDto>;
     

        //assert
        Assert.Equal(200, response.StatusCode);
        Assert.IsAssignableFrom<IActionResult>(result);
        Assert.IsType<OkObjectResult>(result);
        
        //Fluent Assertion version
        breweriesByState.Should().HaveCount(1);
        breweriesByState.Should().Subject.First().State.Should().Be(validState);
       
    }

    [Theory]
    [InlineData("contract")]
    public async Task GetBreweryByType(string validType)
    {
        //arrange 
        var validTypeBrewery = MockData.GetAllBreweries().Where(b => b.BreweryType == validType);
        _mockRepo.Setup(repository => repository.GetBreweriesByTypeAsync(validType))
            .Returns(Task.FromResult(validTypeBrewery));
        
        //act
        var result = await _controller.GetBreweriesByType(validType);
        var response = (OkObjectResult)result;
        var breweriesByType = response.Value as IEnumerable<BreweryDto>;

        //assert
        Assert.Equal(200, response.StatusCode);
   
        
        // Fluent assertion version
        breweriesByType.Should().HaveCount(1);
        breweriesByType.Should().Subject.First().BreweryType.Should().Be(validType);

    }

    [Fact]
    public async Task PostBreweryTest()
    {
        //arrange
        var mockBreweryDto = MockData.GetOneBreweryDto();
        var mockBrewery = MockData.GetOneBrewery();
        
        _mockRepo.Setup(repository => repository.CreateBreweryAsync(mockBrewery)).Returns(Task.FromResult(mockBreweryDto));
        
        
        //act
        var result = await _controller.PostBrewery(mockBrewery);
        var response = (OkObjectResult)result;
        var brewery = response.Value as BreweryDto;
        
        //assert
        Assert.Equal(200, response.StatusCode);
        Assert.IsAssignableFrom<IActionResult>(result);
        Assert.IsType<OkObjectResult>(result);
        
        // Fluent assertion version
        brewery.Should().BeEquivalentTo(mockBreweryDto);
        brewery.Should().NotBeNull();
        brewery?.Id.Should().Be(mockBreweryDto.Id);
    }


    [Fact]
    public async Task PutBreweryTest()
    {
        //arrange
        var mockBrewery = MockData.GetOneBrewery();
        var mockBreweryDto = MockData.GetOneBreweryDto();
        _mockRepo.Setup(repository => repository.UpdateBreweryAsync(mockBrewery)).Returns(Task.FromResult(mockBreweryDto));
        
        //act
        var result = await _controller.PutBrewery(mockBrewery.Id, mockBrewery);
        var response = (NoContentResult)result;
        
        //assert
        Assert.Equal(204, response.StatusCode);
        Assert.IsAssignableFrom<IActionResult>(result);
        
        // Fluent assertion version
        response.Should().NotBeNull();
        result.Should().BeOfType<NoContentResult>();
        
    }
    

    }
}
