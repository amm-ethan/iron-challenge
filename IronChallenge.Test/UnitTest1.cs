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

    [TestCase("22222#", "B")]
    [TestCase("22#", "B")]
    [TestCase("33#", "E")]
    [TestCase("222 2 22#", "CAB")]
    [TestCase("227*#", "B")]
    [TestCase("4433555 555666#", "HELLO")]
    [TestCase("8 88777444666*664#", "TURING")]
    [TestCase("288664066669994446680699922*28#", "AUNG MYINT MYAT")]
    public void TestOldPhonePad(string input, string output)
    {
        var result = _oldPhone.OldPhonePad(input);
        Assert.That(result, Is.EqualTo(output));
    }
}