namespace UnitTests;

public class Test
{
    [Fact]
    public void Sum1()
    {
        //arrange
        int sum = 0;
        
        //act
        sum += 1;

        //assert
        Assert.Equal(1, sum);
    }

}