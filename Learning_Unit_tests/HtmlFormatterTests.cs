using TestesUnitários.Fundamentos;

namespace Learning_Unit_tests
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
        { 
            var formatter = new HtmlFormatter();

            var result = formatter.FormatAsBold("ABC");

            // Specific Assert
            Assert.That(result, Is.EqualTo("<strong>abc</strong>").IgnoreCase); //IgnoreCase -> ignora se as letras são maiusculas ou minusculas.

            // More General
            Assert.That(result, Does.StartWith("<strong>"));
            Assert.That(result, Does.EndWith("</strong>"));
            Assert.That(result, Does.Contain("ABC"));
        }
    }
}
