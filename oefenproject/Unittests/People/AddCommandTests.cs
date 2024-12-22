using AP.MyGameStore.Application.CQRS.People;
using AP.MyGameStore.Application.Interfaces;
using AP.MyGameStore.Domain;
using FluentValidation.TestHelper;
using Moq;

namespace Unittests.People
{
    [TestClass]
    public class AddCommandTests
    {
        private Mock<IUnitofWork> uowMock;
        private Mock<IStoresRepository> storeRepoMock;

        [TestInitialize]
        public void Setup()
        {
            //The Validator also uses a repo for testing the EmployerId
            //So we should also Mock the uow & repo because otherwise an exception will 
            //be thrown when the repo is called in the validator
            uowMock = new Mock<IUnitofWork>();
            storeRepoMock = new Mock<IStoresRepository>();
            uowMock.Setup(p => p.StoresRepository)
                .Returns(storeRepoMock.Object);
        }

        [TestMethod]
        public async Task TestFirstNameEmpty()
        {
            //Arrange
            var person = new PersonDetailDTO() { FirstName = null };
            var unit = new AddCommand() { Person = person };
            //Act
            var result = await new AddCommandValidator(uowMock.Object)
                .TestValidateAsync(unit);
            //Assert
            result.ShouldHaveValidationErrorFor(p => p.Person.FirstName)
                .WithErrorCode("NotNullValidator");

        }

        [TestMethod]
        public async Task TestFirstNameTooLong()
        {
            //Arrange
            var person = new PersonDetailDTO() { FirstName = "AZERTYUIOPQSDFGH" };
            var unit = new AddCommand() { Person = person };
            //Act
            var result = await new AddCommandValidator(uowMock.Object)
                .TestValidateAsync(unit);
            
            //Assert
            result.ShouldHaveValidationErrorFor(p => p.Person.FirstName)
                .WithErrorCode("MaximumLengthValidator");
        }

        [TestMethod]
        public async Task TestEmployerDoesNotExist()
        {
            //Arrange
            var person = new PersonDetailDTO() { FirstName = "Jan", EmployerId = 5 };
            var unit = new AddCommand() { Person = person };
            //Arranging the repo mock that it will return null for any store being requested
            storeRepoMock.Setup(r => r.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult<Store>(null));
            
            //Act
            var result = await new AddCommandValidator(uowMock.Object)
                .TestValidateAsync(unit);
            //Assert
            result.ShouldHaveValidationErrorFor(p => p.Person.EmployerId)
                .WithErrorCode("AsyncPredicateValidator");

        }

        [TestMethod]
        public async Task TestSuccessFulAddValidation()
        {
            //Arrange
            var person = new PersonDetailDTO() { FirstName = "Jozef", EmployerId = 5};
            var unit = new AddCommand() { Person = person };
            //Arranging the repo mock that it will return a store object
            //when a store with ID = 5 is being requested
            storeRepoMock.Setup(r => r.GetById(5))
                .Returns(Task.FromResult<Store>(new Store()));
            
            //Act
            var result = await new AddCommandValidator(uowMock.Object)
                .TestValidateAsync(unit);
            
            //Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
