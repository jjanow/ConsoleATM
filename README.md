# ConsoleATM

A console application to simulate a bank ATM. Written as an interview test, this project provides a simple interface for simulating basic ATM operations such as signing in, adding funds, withdrawing funds, reviewing balance, and logging off.

## Features
- **Sign In**: Authenticate using a PIN.
- **Add Funds**: Add funds to the account.
- **Withdraw Funds**: Withdraw funds from the account.
- **Review Balance**: Check the current balance.
- **Logoff**: Log off and return to the login screen.

## Dependencies
- .NET Framework 4.5 or higher.

## Configuration
The PIN for authentication is stored in the `App.config` file. You can change the PIN by modifying the value associated with the "PIN" key in the configuration file.

## How to Run
1. Clone the repository or download the source code.
2. Open the solution in Visual Studio.
3. Build and run the project by pressing `F5` or selecting `Start Debugging` from the `Debug` menu.

## Code Structure
- **ATMMenu Class**: Responsible for drawing the menu.
- **Auth Class**: Handles authentication and balance management.
- **Program Class**: Contains the main logic of the application.

## Improvements and Refactoring
The code has been refactored to remove duplication, improve error handling, and enhance the logic for handling insufficient funds. Comments have been added throughout the code to explain the functionality.

## License
This project is open-source and available under the MIT License. Feel free to use, modify, and distribute the code as per the terms of the license.
