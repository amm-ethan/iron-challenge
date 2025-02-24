# Disclaimer

This project is developed for the Iron Software C# Coding Challenge.

## Overview
This repository contains a C# Console Application that translates input from an Old KeyPad Phone into readable messages, along with a Unit Test project for testing its functionality. The solution is structured into two main folders:

- **IronChallenge (ConsoleApp)** - The main console application.
- **IronChallenge.Test (UnitTests)** - The unit test project for verifying the application's functionality.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0)

## Getting Started

1. Clone the repository:

   ```sh
   git clone https://github.com/amm-ethan/iron-challenge.git
   ```

2. Open the solution in your preferred IDE.

## Running the Application

Navigate to the **IronChallenge** folder and execute the following command:

```sh
   dotnet run --project IronChallenge
```

### Notes:

1. **Ignoring Invalid Inputs**
    - The application will ignore invalid characters, translating only from `0-9`, `*`, and `#`.

   #### Example:
   ```csharp
   public static void Main(string[] args)
   {
       var oldPhone = new OldPhone();
       var dataToPrint = oldPhone.OldPhonePad("A443355B5 555666096667775C553#");
       Console.WriteLine(dataToPrint);
   }
   ```
   **Output:** `HELLO WORLD` (ignoring `A`, `B`, and `C`)

2. **Character Rotation**
    - If a key is pressed multiple times, the application will cycle through corresponding characters.

   #### Example:
   ```csharp
   public static void Main(string[] args)
   {
       var oldPhone = new OldPhone();
       var dataToPrint = oldPhone.OldPhonePad("22222#");
       Console.WriteLine(dataToPrint);
   }
   ```
   **Output:** `B`

## Running Unit Tests

To run the tests, navigate to the **IronChallenge** folder and execute:

```sh
   dotnet test
```

## License

This project is licensed under the MIT License. See the `LICENSE` file for more details.

## Contact

For any inquiries or support, contact [aungmyintmyat.ethan@gmail.com].

