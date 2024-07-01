# TheNoobs.Results

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=thenoobsbr_result&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=thenoobsbr_result)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=thenoobsbr_result&metric=coverage)](https://sonarcloud.io/summary/new_code?id=thenoobsbr_result)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=thenoobsbr_result&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=thenoobsbr_result)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=thenoobsbr_result&metric=bugs)](https://sonarcloud.io/summary/new_code?id=thenoobsbr_result)

TheNoobs.Results implements the Result pattern along with Railway Oriented Programming (ROP), both of which are functional programming paradigms. This project adheres to best practices and uses Behavior Driven Development (BDD) in its tests.

## Patterns Used

### Result Pattern

The Result pattern is a common technique used to handle operations that may fail. Instead of returning null values or throwing exceptions, a function that may fail returns a Result object containing the outcome of the operation, either a successful value or a failure. This ensures that all failures are handled explicitly.

```csharp
public class Result<T>
{
    public T Value { get; }
    public bool IsSuccess { get; }
    public Fail Fail { get; }

    // Constructors and methods...
}
```

### Railway Oriented Programming (ROP)

ROP is an approach inspired by functional languages for handling chained operations that may fail. The idea is that each step of the process can "take a detour" if a failure occurs, preventing the process from continuing incorrectly. Instead of using exceptions for control flow, ROP uses explicit result values indicating success or failure.

```csharp
var result = GetSuccess()
    .Bind(x => GetSuccess(2))
    .Catch<int, NotFoundFail>(x => GetSuccess(3));
```

## Requirements

To run the project, you will need to have .NET installed. You can download it [here](https://dotnet.microsoft.com/download).

## Project Structure

The project is organized into different components to facilitate maintenance and scalability:

- **Result Types**: Implementations of the Result pattern.
- **Extensions**: Extension methods to facilitate the use of Result and ROP.
- **Fails**: Definitions of specific failures to capture different types of errors.
- **Tests**: Unit and BDD tests to ensure code quality.

## Best Practices

This project follows these best development practices:

- **Clean Code**: Maintenance of readable and well-organized code.
- **Automated Testing**: Comprehensive test coverage using BDD.
- **SOLID**: SOLID design principles to ensure modular and maintainable code.

## How to Contribute

### Step 1: Fork the Repository

Click the "Fork" button at the top right of the repository to create a copy of the repository in your account.

### Step 2: Clone the Repository

Clone the repository to your local machine using the command:

```sh
git clone https://github.com/your-username/TheNoobs.Results.git
```

### Step 3: Create a Branch

Create a new branch for your changes:

```sh
git checkout -b my-branch
```

### Step 4: Make Your Changes

Make the desired changes to the code. Be sure to add or modify tests to cover your changes.

### Step 5: Run the Tests

Ensure that all tests pass before submitting your changes:

```sh
dotnet test
```

### Step 6: Commit and Push Your Changes

Commit your changes:

```sh
git commit -m "Description of my changes"
```

Push your changes to the remote repository:

```sh
git push origin my-branch
```

### Step 7: Open a Pull Request

On GitHub, navigate to your forked repository and click the "New Pull Request" button to submit your changes for review.

---

We look forward to your contributions! If you have any questions or need assistance, feel free to open an issue in the repository.

♥ Made with love!
