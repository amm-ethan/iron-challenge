namespace IronChallenge;

public class Program
{
    public static void Main(string[] args)
    {
        var oldPhone = new OldPhone();

        var dataToPrint = oldPhone.OldPhonePad("44 444777330633#");
        Console.WriteLine(dataToPrint);

        dataToPrint = oldPhone.OldPhonePad("A443355B5 555666096667775C553#");
        Console.WriteLine(dataToPrint);
    }
}

/// <summary>
/// This class mimic old keypad phone .
/// </summary>
public class OldPhone
{
    /// <value>
    /// Property <c>_keyPadDictionary</c> represents dictionary of all possible keystroke combinations from keypad phone.
    /// </value>
    private readonly Dictionary<char, string> _keyPadDictionary = new()
    {
        { '1', "&'(" }, { '2', "ABC" }, { '3', "DEF" },
        { '4', "GHI" }, { '5', "JKL" }, { '6', "MNO" },
        { '7', "PQRS" }, { '8', "TUV" }, { '9', "WXYZ" }
    };

    /// <summary>
    /// Translate keypad keystroke to message.
    /// </summary>
    /// <param name="input">Input string consisting keystroke string from keypad phone.</param>
    /// <returns>
    /// (String) Translated message
    /// </returns>
    public string OldPhonePad(string input)
    {
        var resultList = new List<char>();
        char? lastChar = null;
        var pressCount = 0;

        foreach (var inputChar in input)
        {
            // pressed key is digit (1-9)
            if (_keyPadDictionary.TryGetValue(inputChar, out var selectedInputKey))
            {
                // if current input and last input are the same, calculate the next possible char.
                if (inputChar == lastChar)
                {
                    pressCount++;
                    resultList.RemoveAt(resultList.Count - 1);
                }
                // if they are not the same 
                else
                {
                    lastChar = inputChar;
                    pressCount = 1;
                }

                // cycle the data. e.g. for 2, 1st press would be 'a', but 4th press would be also 'a'
                var innerIndex = pressCount % selectedInputKey.Length == 0
                    ? pressCount
                    : pressCount % selectedInputKey.Length;

                var possibleChar = selectedInputKey[innerIndex - 1];
                resultList.Add(possibleChar);
            }
            else if (inputChar == '0')
            {
                // add a space;
                resultList.Add(' ');
                lastChar = null;
            }
            else if (inputChar == '*')
            {
                // delete pressed, remove last index;
                if (resultList.Count > 0)
                    resultList.RemoveAt(resultList.Count - 1);
                lastChar = null;
            }
            else if (inputChar == '#')
            {
                // send pressed, return data;
                break;
            }
            else if (inputChar == ' ')
            {
                lastChar = null;
            }
        }
        
        return string.Join("", resultList);
    }
}