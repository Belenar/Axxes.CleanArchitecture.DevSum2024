using BeerSender.Application.Packages;
using BeerSender.Domain;
using FluentAssertions;
using NSubstitute;

namespace BeerSender.Application.Tests
{
    public class BoxCreateTest  
    {
        [Fact]
        public void WhenValidInput_ReturnsBox()
        {
            var capacity = 10;
            var command = new CreateBox(capacity);

            var repository = Substitute.For<IPackageRepository>();

            var creator = new BoxCreator(repository);

            var result = creator.Handle(command);

            result.Should().NotBeNull();
            result.Capacity.NumberOfBottles.Should().Be(12);
            repository.Received().SavePackage(Arg.Any<BeerPackage>());
        }
    }
}