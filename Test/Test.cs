using PatikaPaycoreBootcampFinalProject.StartUpExtension;
using Xunit;

namespace PycApi.TestX
{
    

    public class Test
    {


        [Fact]
        public void MD5CipherTest()
        {
            string text;
            text = "paycore";

            // Act
            string result = MD5CipherExtension.MD5Encryption(text);
            string expected = "bc1f6559d2a0b182e7339f09224d5601";
            // Assert
            Assert.Equal(result, expected);
        }

    }
}
