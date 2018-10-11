using System;
using System.Collections.Generic;
using System.IO;
using Moq;
using WebShop.Core;
using WebShop.Core.Entity;
using Xunit;

namespace CoreTest
{
    public class ChairServiceTest
    {

        [Fact]
        public void CreateValidChairTest(){
            //Setup

            Dictionary<int, Chair> chairs = new Dictionary<int, Chair>();
            int Id = 1;

            Mock<IChairRepository> mockChairRepo = new Mock<IChairRepository>();

            mockChairRepo.Setup(x => x.AddChair(It.IsAny<Chair>())).Returns<Chair>(arg => InsertIntoDictionaryAndAddId(Id, chairs, arg));

            IChairService chairService = new ChairService(mockChairRepo.Object);

            Chair validChair = new Chair() {Name = "someName", Price = 1};

            //Test
            Chair chair = chairService.AddChair(validChair);


            Assert.Single(chairs); // cheks if there as been added ONE chair to the "Repositorie"

            Assert.NotNull(chair);

            Assert.Equal(Id, chair.Id); // cheks if the returned chair has the given id

            Assert.Equal(chairs[Id], chair);

        }

        private Chair InsertIntoDictionaryAndAddId(int id, Dictionary<int, Chair> chairs, Chair chair)
        {
            chair.Id = id;
            chairs.Add(id, chair);
            return chair;
        }

        [Fact]
        public void GetChairById(){
            //Setup
            Mock<IChairRepository> mockChairRepo = new Mock<IChairRepository>();
            var testChair = new Chair() { Id = 1 , Name = "Im the testChair", Price = 1};
            mockChairRepo.Setup(x => x.GetChair(It.IsAny<int>())).Returns<int>(arg => testChair);

            IChairService chairService = new ChairService(mockChairRepo.Object);

            // Test
            Chair gottanChair = chairService.GetChairById(1);

            Assert.NotNull(gottanChair);

            Assert.Equal(testChair, gottanChair);

        }

        [Fact]
        public void GetChairByIdWhereIdDoesNotExistExpectExeption()
        {
            //Setup
            Mock<IChairRepository> mockChairRepo = new Mock<IChairRepository>();

            mockChairRepo.Setup(x => x.GetChair(It.IsAny<int>())).Returns<int>(arg => null);

            IChairService chairService = new ChairService(mockChairRepo.Object);

            // Test
            Chair gottanChair = null;

            Assert.Throws<ArgumentException>(() => gottanChair = chairService.GetChairById(1));

            Assert.Null(gottanChair);
        }

        [Fact]
        public void AddChairWithoutNameExpectExeption(){
            //Setup
            Mock<IChairRepository> mockChairRepo = new Mock<IChairRepository>();
            IChairService chairService = new ChairService(mockChairRepo.Object);

            //Test
            var chair = new Chair() { Price = 1 };

            Assert.Throws<InvalidDataException>(() => chairService.AddChair(chair));
            mockChairRepo.Verify(m => m.AddChair(chair), Times.Never());
        }

        [Fact]
        public void AddChairWithoutPriceExpectExeption()
        {
            //Setup
            Mock<IChairRepository> mockChairRepo = new Mock<IChairRepository>();
            IChairService chairService = new ChairService(mockChairRepo.Object);

            //Test
            var chair = new Chair() { Name = "aName" };

            Assert.Throws<InvalidDataException>(() => chairService.AddChair(chair));
            mockChairRepo.Verify(m => m.AddChair(chair), Times.Never());
        }

        [Fact]
        public void AddChairWithNegativePriceExpectExeption()
        {
            //Setup
            Mock<IChairRepository> mockChairRepo = new Mock<IChairRepository>();
            IChairService chairService = new ChairService(mockChairRepo.Object);

            //Test
            var chair = new Chair() { Name = "aName", Price = -1 };

            Assert.Throws<InvalidDataException>(() => chairService.AddChair(chair));
            mockChairRepo.Verify(m => m.AddChair(chair), Times.Never());
        }

        [Fact]
        public void GetChairsPaged()
        {
            //Setup
            Mock<IChairRepository> mockChairRepo = new Mock<IChairRepository>();

            List<Chair> chairsFull = new List<Chair>();

            for (int i = 1; i < 30; i++)
            {
                chairsFull.Add(new Chair(){Id = i});
            }

            mockChairRepo.Setup(x => x.GetChairs()).Returns(() => chairsFull);

            IChairService chairService = new ChairService(mockChairRepo.Object);

            //Test
            var page = 1;
            var itemsOnPage = 10;
            var chairsPaged = chairService.GetChairsPaged(page, itemsOnPage);

            Assert.Equal(itemsOnPage, chairsPaged.Count);
            Assert.Equal(1, chairsPaged[0].Id);
            Assert.Equal(10, chairsPaged[9].Id);
        }

        [Fact]
        public void GetChairsPagedWithZeroPagesAndItemsExpectExeption()
        {
            //Setup
            Mock<IChairRepository> mockChairRepo = new Mock<IChairRepository>();
            IChairService chairService = new ChairService(mockChairRepo.Object);

            //Test
            Assert.Throws<InvalidDataException>(() => chairService.GetChairsPaged(1,0));
            Assert.Throws<InvalidDataException>(() => chairService.GetChairsPaged(0,1));
        }

        [Fact]
        public void UpdateChair()
        {
             
        }

        [Fact]
        private void UpdateChairWithNonExistingIdExpectExeption()
        {
            
        }

        [Fact]
        public void DeleteChair()
        {
            Mock<IChairRepository> mockChairRepo = new Mock<IChairRepository>();
            mockChairRepo.Setup(x => x.GetChair(It.IsAny<int>())).Returns(() => new Chair());
            IChairService chairService = new ChairService(mockChairRepo.Object);

            chairService.DeleteChair(1);

            mockChairRepo.Verify(m => m.DeleteChair(1), Times.Once());
        }

        [Fact]
        private void DeleteChairWithNonExistingIdExpectExeption()
        {

        }
    }
}
