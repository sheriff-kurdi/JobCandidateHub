using UseCases.Shared.Validators;

namespace UnitTest;

public class TimZoneValidatorTest
{
    [Fact]
    public void ValidTimeZone_ValidTimeZone_ReturnsTrue_Test()
    {
        //arrange
        var timeZone = "UTC";
        
        //act
        var result = TimeValidator.ValidTimeZone(timeZone);

        //assert
        Assert.True(result);
    }

    [Fact]
    public void ValidTimeZone_NonValidTimeZone_ReturnsFalse_Test()
    {
        //arrange
        var timeZone = "FakeTimeZone";
        
        //act
        var result = TimeValidator.ValidTimeZone(timeZone);

        //assert
        Assert.False(result);
    }
}