namespace IronChallenge.Test;

using NUnit.Framework;

[TestFixture]
public class Tests
{
    private OldPhone _oldPhone;

    [SetUp]
    public void SetUp()
    {
        _oldPhone = new OldPhone();
    }

    
    [TestCase("22#", "B")]
    [TestCase("33#", "E")]
    [TestCase("222 2 22#", "CAB")]
    [TestCase("227*#", "B")]
    [TestCase("22*7#", "P")]
    [TestCase("4433555 555666#", "HELLO")]
    [TestCase("8 88777444666*664#", "TURING")]
    [TestCase("288664066669994446680699922*28#", "AUNG MYINT MYAT")]
    // Edge Cases
    
    [TestCase("", "")]  // Empty Input
    [TestCase("APPLE#", "")]  // All invalid character.
    [TestCase("      #", "")]  // All Spaces.
    [TestCase("****#", "")]  // All Delete.
    [TestCase("ORANGE, MANGO#", "")]  // All invalid character with Send Key.
    [TestCase("######", "")]  // All send keys.
    
    [TestCase("22222#", "B")]  // Character Rotation
    [TestCase("22222222222222222222", "B")] // More Character Rotation
    
    [TestCase("4433555 555666", "HELLO")]  // Without Send character.
    [TestCase("4433555 555666#555666096667775553", "HELLO")]  // Send character in middle.
    
    [TestCase("4433555 555666*****#", "")]  // Input characters and delete all.
    [TestCase("4433555 555666**********#", "")]  // delete more than input character.
    [TestCase("0#", " ")]  // Just a space character.
    [TestCase("0002#", "   A")]  // Multiple space and a character.
    [TestCase("1234567890*#", "&ADGJMPTW")]  // all possible keystroke at once.
    [TestCase("2####", "A")]  // multiple send keys.
    [TestCase("A443355B5 555666096667775C553#", "HELLO WORLD")]  // Mixed of valid and invalid character (A, B, C)
    
    [TestCase("2 2 2", "AAA")] // 1-9 and Spaces.
    [TestCase("20202", "A A A")] // 1-9 and 0.
    public void TestOldPhonePad(string input, string output)
    {
        var result = _oldPhone.OldPhonePad(input);
        Assert.That(result, Is.EqualTo(output));
    }
}