using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CarAppCore.Entities;
using CarAppCore.Interface;
using CarAppCore.Profiles;
using CarAppCore.ServiceCore.BrandService;
using Moq;
using Xunit;

namespace Tests
{
    public class BrandServiceTest
    {
        [Fact]
        public void GetByIdTestCorrect()
        {
            //Arrange
            //repository
            var MockBrandRepository = new Mock<IBrantRepository>();
            MockBrandRepository.Setup(a => a.GetAsync(1).Result)
                               .Returns(new Brand { ID = 1, Name = "Name" });

            //mapper
            var mockMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BrandProfile());
            });
            var MockMapper = mockMapperConfig.CreateMapper();

            //creating service
            BrandService brandService = new BrandService(MockBrandRepository.Object, MockMapper);

            //Act
            var ActualResult = brandService.GetAsync(1).Result;

            //Assert
            var ExpectedResult = new Brand { ID = 1, Name = "Name" };
            Assert.True(ActualResult.ID == ExpectedResult.ID && ActualResult.Name == ExpectedResult.Name);
        }
        [Fact]
        public void GetByIdTestExceptionKeyNotFound()
        {
            //Arrange
            //repository
            Brand brand = null;
            var MockBrandRepository = new Mock<IBrantRepository>();
            MockBrandRepository.Setup(a => a.GetAsync(1).Result)
                               .Returns(brand);

            //mapper
            var mockMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BrandProfile());
            });
            var MockMapper = mockMapperConfig.CreateMapper();

            //creating service
            BrandService brandService = new BrandService(MockBrandRepository.Object, MockMapper);

            //Act+Assert
            Assert.ThrowsAsync<KeyNotFoundException>(()=> brandService.GetAsync(1));
        }
    }
}
