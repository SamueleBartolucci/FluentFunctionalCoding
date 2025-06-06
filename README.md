# FluentFunctionalCoding

## Project concept

**FluentFunctionalCoding** is a .NET library providing functional programming primitives and fluent extensions for C#. It includes types and helpers for Optionals, Outcomes (Either), Try/Catch, SwitchMap, and fluent functional operations on collections and tasks. The library aims to enable expressive, safe, and concise code by leveraging functional programming concepts in C#.

---

## Project Features Overview

FluentFunctionalCoding provides a rich set of functional programming primitives and fluent extensions for C#. It enables expressive, safe, and concise code by leveraging functional concepts such as Optionals, Outcomes (Either), Try/Catch, SwitchMap, and fluent operations on collections and tasks.

### Fluent Extensions at a Glance

| Extension         | Purpose / Description                                 | Example Usage                              |
|-------------------|-------------------------------------------------------|--------------------------------------------|
| **Do**            | Perform side effects in a fluent chain                 | `"hello".Do(Console.WriteLine)`            |
| **Map**           | Transform values/collections fluently                  | `"123".Map(s => int.Parse(s))`             |
| **EqualsToAny**   | Check if value equals any of provided values/predicate | `5.EqualsToAny(1, 3, 5)`                   |
| **Or**            | Provide fallback if value is null/empty/condition      | `value.Or("default")`                     |
| **DoForEach**     | Perform side effects on each element in a collection   | `list.DoForEach(Console.WriteLine)`         |
| **MapAll**        | Map/transform all elements in a collection             | `list.MapAll(x => x * 2)`                  |
| **OrWhenEmpty**   | Fallback for empty collections/strings                 | `list.OrWhenEmpty(fallback)`                |
| **Apply**         | Partial application for Action/Func                    | `log.Apply(1)`                             |
| **IsNull/IsNullOrEmpty** | Null/empty checks in a fluent way                | `obj.IsNull()`                             |
| **ToTask**        | Wrap value in a completed Task                        | `42.ToTask()`                              |

> **Note:** All extension methods are available via `using FluentFunctionalCoding.FluentPreludes;`.

### Fluent Types at a Glance

| Type              | Purpose / Description                                 | Example Usage (Extension/Fluent)           | Example Usage (Explicit Prelude)           |
|-------------------|-------------------------------------------------------|--------------------------------------------|--------------------------------------------|
| **Try**           | Functional try/catch with fluent error handling        | `"123".Try(s => int.Parse(s))`            | `Prelude.Try("123", s => int.Parse(s))`   |
| **SwitchMap**     | Fluent pattern matching for values/collections         | `5.Switch(-1)`                             | `Prelude.Switch(5, -1)`                    |
| **When**          | Fluent conditional logic                              | `10.When()`                                | `Prelude.When(10)`                         |

### Functional Types at a Glance

| Type              | Purpose / Description                                 | Example Usage (Extension/Fluent)           | Example Usage (Explicit Prelude)           |
|-------------------|-------------------------------------------------------|--------------------------------------------|--------------------------------------------|
| **Optional**      | Option type representing a value that may not exist   | `42.Optional()`                            | `Prelude.Optional(42)`                     |
| **Outcome**       | Either type representing success or failure           | `100.ToOutcome<string>()`                  | `Prelude.Outcome<string, int>.Right(100)`  |

You can create a functional context in two ways:

- **Explicit Prelude**: Use static `Prelude` functions for explicit, discoverable context creation.
- **Implicit/Extension**: Use extension methods directly on types for a more idiomatic, fluent C# style.

**Example:**

```csharp
// Try
var tryResult1 = Prelude.Try("123", s => int.Parse(s)); // explicit
var tryResult2 = "123".Try(s => int.Parse(s));           // extension

// SwitchMap
var switch1 = Prelude.Switch(5, -1);
var switch2 = 5.Switch(-1);

// When
var when1 = Prelude.When(10);
var when2 = 10.When();

// Optional
var opt1 = Prelude.Optional(42);
var opt2 = 42.Optional();

// Outcome
var outcome1 = Prelude.Outcome<string, int>.Right(100);
var outcome2 = 100.ToOutcome<string>();
```

> **Note:** To use the implicit/extension style, add `using FluentFunctionalCoding.FluentPreludes;` to your file. This enables extension methods for all supported types.

---

# Project in Detail

## 1 FluentExtensions

Extension methods for type `T` to enable fluent, LINQ-style coding.

### Do

A set of functions used to alter or use an input object and then return the object itself, enabling side effects or logging in a fluent chain.

- **Do**: Applies one or more actions or functions to the subject (if not null) and then returns the subject. Useful for performing side effects such as logging, debugging, or mutation in a fluent chain. The function results are discarded.

    ```csharp
    // Applies Console.WriteLine to the string, prints "hello", and returns "hello"
    "hello".Do(Console.WriteLine);
    // Logs the value and returns 42
    var result = 42.Do(x => Debug.WriteLine($"Value: {x}"));
    // Applies multiple actions
    obj.Do(action1, action2);
    // Applies multiple functions (results ignored)
    obj.Do(func1, func2);
    ```

- **DoForEach**: Applies one or more actions or functions to each element in an enumerable and returns the enumerable itself. Useful for side effects on collections, such as logging or mutation, in a fluent chain. The function results are discarded.

    ```csharp
    var numbers = new List<int> { 1, 2, 3 };
    // Prints 1, 2, 3 and returns the list
    numbers.DoForEach(n => Console.WriteLine(n));
    // Applies multiple actions to each element
    numbers.DoForEach(action1, action2);
    // Applies multiple functions to each element (results ignored)
    numbers.DoForEach(func1, func2);
    ```

- **DoAsync**: Like `Do`, but operates on a `Task<T>`. Awaits the task, applies the actions or functions, and returns the original result. Useful for performing side effects in asynchronous fluent chains.

    ```csharp
    await someTask.DoAsync(Console.WriteLine);
    await someTask.DoAsync(x => Debug.WriteLine($"Value: {x}"));
    await someTask.DoAsync(func1, func2);
    ```

- **DoForEachAsync**: Like `DoForEach`, but operates on a `Task<IEnumerable<T>>`, `Task<List<T>>`, or `Task<T[]>`. Awaits the task, applies the actions or functions to each element, and returns the original collection.

    ```csharp
    await numbersTask.DoForEachAsync(n => Console.WriteLine(n));
    await numbersTask.DoForEachAsync(func1, func2);
    ```

### Equals

Functions used to check equality between objects in a fluent way.

- **EqualsToAny**: Returns `true` if the object equals any of the provided values.

    ```csharp
    int value = 5;
    bool isMatch = value.EqualsToAny(1, 3, 5); // true
    string color = "red";
    bool found = color.EqualsToAny("blue", "green", "red"); // true
    ```

- **EqualsToAny with predicate**: Returns `true` if the predicate returns true for any of the provided values.

    ```csharp
    int value = 7;
    // Check if value is equal to any odd number in the list
    bool isOddMatch = value.EqualsToAny(x => x % 2 == 1, 2, 4, 7, 8); // true (7 is odd and in the list)

    string word = "hello";
    // Check if word matches any string with length 5
    bool hasLengthFive = word.EqualsToAny(s => s.Length == 5, "hi", "hello", "world"); // true
    ```

### Map

Functions used to transform objects or collections using mapping functions.

- **Map**: Transforms an input object using a mapping function and returns the result.

    ```csharp
    var mapped = "123".Map(s => int.Parse(s)); // 123
    var upper = "hello".Map(s => s.ToUpper()); // "HELLO"
    ```

- **MapAll**: Transforms each element in an enumerable using a mapping function and returns a new enumerable.

    ```csharp
    var numbers = new List<int> { 1, 2, 3 };
    var squared = numbers.MapAll(n => n * n); // [1, 4, 9]
    ```

- **MapAsync**: Like `Map`, but operates on a `Task<T>`. Awaits the task, applies the mapping function, and returns the result.

    ```csharp
    var asyncMapped = await Task.FromResult("456").MapAsync(s => int.Parse(s)); // 456
    ```

- **MapAllAsync**: Like `MapAll`, but operates on a `Task<IEnumerable<T>>`. Awaits the task, applies the mapping function to each element, and returns the new enumerable.

    ```csharp
    var asyncList = await Task.FromResult(new[] { 2, 4, 6 }).MapAllAsync(x => x / 2); // [1, 2, 3]
    ```

### Misc

A collection of various extension methods for functional and utility purposes.

- **Apply for Action**: Partially applies an argument to an `Action`, returning a new `Action` with fewer parameters.

    ```csharp
    Action<int, string> log = (level, msg) => Console.WriteLine($"{level}: {msg}");
    var infoLog = log.Apply(1); // Now only needs the message
    infoLog("Started"); // Prints "1: Started"
    ```

- **AsFunc**: Converts an `Action` into a `Func<T, Unit>` (or similar), allowing it to be used where a function is required.

    ```csharp
    Action<string> print = Console.WriteLine;
    Func<string, object> printFunc = print.AsFunc();
    printFunc("test"); // Prints "test"
    ```

- **Apply for Func**: Partially applies an argument to a `Func`, returning a new `Func` with fewer parameters.

    ```csharp
    Func<int, int, int> add = (a, b) => a + b;
    var addFive = add.Apply(5);
    int sum = addFive(3); // 8
    // Overload: Apply for Func<T1, T2, TResult>
    Func<int, int, int, int> sum3 = (a, b, c) => a + b + c;
    var addTen = sum3.Apply(10);
    int result = addTen(2, 3); // 15
    ```

- **IsNull, IsNullOrEmpty**: Checks if an object or collection is null or empty.

    ```csharp
    string s = null;
    bool isNull = s.IsNull(); // true
    bool isEmpty = "".IsNullOrEmpty(); // true
    var list = new List<int>();
    bool listEmpty = list.IsNullOrEmpty(); // true
    // Overload: IsNull for reference types
    object obj = null;
    bool nullObj = obj.IsNull(); // true
    ```

- **ToTask**: Wraps an object into a completed `Task<T>`.

    ```csharp
    var task = 42.ToTask();
    int result = await task; // 42
    ```

### Or

Provides fallback values in case of nulls, empties, or custom conditions.

- **Or**: Returns the current value if not null (or if a condition is false), otherwise returns the fallback value.

    ```csharp
    string value = null;
    var fallback = value.Or("default"); // "default"
    int? n = null;
    var safe = n.Or(10); // 10
    // Overload: Or with predicate
    var custom = value.Or(() => "computed");
    // Or with predicate to choose fallback only if predicate is true
    string s = "error";
    var fallbackIfError = s.Or(v => v == "error", "fallback"); // "fallback"
    var notFallback = "ok".Or(v => v == "error", "fallback"); // "ok"
    int? maybe = 0;
    var fallbackIfZero = maybe.Or(x => x == 0, 42); // 42
    var notFallbackNum = 7.Or(x => x == 0, 42); // 7
    ```

- **OrWhenEmpty for Enumerable**: Returns the current enumerable if not empty, otherwise returns the fallback enumerable.

    ```csharp
    var list = new List<int>();
    var fallbackList = list.OrWhenEmpty(new List<int> { 1, 2 }); // [1, 2]
    var notEmpty = new[] { 7 }.OrWhenEmpty(new[] { 1, 2 }); // [7]
    ```

- **OrWhenEmpty for strings**: Returns the current string if not empty, otherwise returns the fallback string.

    ```csharp
    string empty = "";
    var fallbackString = empty.OrWhenEmpty("fallback"); // "fallback"
    var notEmpty = "abc".OrWhenEmpty("fallback"); // "abc"
    // Overload: OrWhenEmpty with predicate
    var customString = empty.OrWhenEmpty(() => "computed");
    ```

- **OrAsync**: Like `Or`, but operates on a `Task<T>`. Awaits the task, returns the result if not null, otherwise returns the fallback.

    ```csharp
    var asyncValue = await Task.FromResult<string>(null).OrAsync("async default"); // "async default"
    // Overload: OrAsync with predicate
    var asyncCustom = await Task.FromResult<string>(null).OrAsync(() => "computed async");
    ```

---

## 2 FluentTypes

C# implementation of functional types `Option` (as `Optional`) and `Either` (as `Outcome`), providing a rich set of fluent methods for safe, expressive, and composable functional programming.


### SwitchMap

Types and methods that implement a fluent version of the switch/case syntax. The workflow starts with a `Switch`, followed by a series of `Case` statements, and ends with a `Match`.

- **Case**: Adds a case to the switch. If the predicate matches, the associated function is executed.

    ```csharp
    var value = 5;
    var result = Prelude.Switch(value, -1)
        .Case(v => v == 0, v => 100)
        .Case(v => v > 0, v => v * 10)
        .Match(); // result = 50
    ```

- **CaseContainsKey, CaseContains, CaseAny, CaseAll, CaseIsEmpty, CaseIsNotEmpty, CaseCount**: Specialized cases for dictionaries and collections.

    ```csharp
    var dict = new Dictionary<int, string> { { 1, "one" }, { 2, "two" } };
    var dictResult = dict.Switch("not found")
        .CaseContainsKey(1, d => d[1])
        .CaseContains(new KeyValuePair<int, string>(2, "two"), d => "HasTwo")
        .CaseIsEmpty(d => "EmptyDict")
        .Match(); // dictResult = "one"
    ```

- **CaseOptional**: Adds a case for `Optional` types, working directly with the inner value.

    ```csharp
    var opt = Optional<int>.Some(10);
    var msg = opt.Switch("none")
        .CaseOptional(x => x > 5, x => $"Value: {x}") // x is int
        .Match(); // "Value: 10"

    var none = Optional<int>.None();
    var msgNone = none.Switch("none")
        .CaseOptional(x => x > 5, x => $"Value: {x}")
        .Match(); // "none"
    ```

- **CaseOutcome**: Adds a case for `Outcome` types, working directly with the inner value.

    ```csharp
    var outcome = Outcome<string, int>.Right(42);
    var res = outcome.Switch("fail")
        .CaseOutcome(x => x > 40, x => $"Success: {x}") // x is int
        .Match(); // "Success: 42"

    var fail = Outcome<string, int>.Left("fail");
    var resFail = fail.Switch("fail")
        .CaseOutcome(x => x > 40, x => $"Success: {x}")
        .Match(); // "fail"
    ```

- **CaseAsync**: Adds a case for `Task` types.

    ```csharp
    var t = Task.FromResult(5);
    var asyncSwitch = await t.Switch(-1)
        .CaseAsync(x => x > 0, x => x * 2)
        .MatchAsync(); // 10
    ```

- **Match**: Closes the switch and returns the result of the first matching case or the default.

- **MatchAsync**: Closes the async switch and returns the result.


### TryCatch

Types and methods that implement a fluent version of the try/catch syntax.

- **Catch**: Adds a catch handler for exceptions thrown in the try block.

    ```csharp
    var tryResult = Prelude.Try("input", s => int.Parse(s))
        .Catch((input, ex) => -1);
    ```

- **Match**: Closes the try/catch and returns the result, allowing you to specify handlers for success and failure.

    ```csharp
    tryResult.Match(
        onSuccess: (input, result) => Console.WriteLine($"Parsed: {result}"),
        onFail: (input, ex) => Console.WriteLine($"Failed to parse '{input}': {ex.Message}")
    );
    ```

- **MatchFail**: Closes the try/catch and returns the result for the failure case only.

    ```csharp
    tryResult.MatchFail((input, ex) => $"Error: {ex.Message}");
    ```

- **OnFail**: Executes an action if the try is in a failure state, without closing the context.

    ```csharp
    tryResult.OnFail((input, ex) => Log.Error(ex));
    ```

- **OnSuccess**: Executes an action if the try is in a success state, without closing the context.

    ```csharp
    tryResult.OnSuccess((input, result) => Log.Info(result));
    ```

- **ToOptional**: Converts the try context into an `Optional` object.

    ```csharp
    var optional = tryResult.ToOptional();
    ```

- **ToEither**: Converts the try context into an `Outcome` object.

    ```csharp
    var outcome = tryResult.ToEither();
    ```

- **ToEitherUsingException**: Converts the try context into an `Outcome` using the exception as the failure value.

    ```csharp
    var outcome = tryResult.ToEitherUsingException();
    ```

## Retry Logic with `numRetry` Parameter

The `Try` monad and all related extension methods now support a `numRetry` parameter, allowing you to specify how many times an operation should be retried if it throws an exception. This applies to both explicit and fluent/extension usages for `Func` and `Action` signatures.

### Usage Examples

#### Explicit (static Prelude)
```csharp
// Retry up to 3 times if the function throws
var result = Prelude.Try(subject, funcToTry, numRetry: 3);

// Retry with custom error handler
var result = Prelude.Try(subject, funcToTry, (s, ex) => "custom error", numRetry: 2);
```

#### Extension Methods (Fluent)
```csharp
// Retry up to 2 times using the extension method
var result = subject.Try(actionToTry, numRetry: 2);

// Retry with custom error handler
var result = subject.Try(funcToTry, (s, ex) => "custom error", numRetry: 2);
```

#### Func/Action Extensions
```csharp
// Func extension with retry
var result = myFunc.Try(subject, numRetry: 3);

// Action extension with custom error and retry
var result = myAction.Try(subject, (s, ex) => "custom error", numRetry: 2);
```

### Behavior
- If the operation succeeds before reaching the retry limit, the result is returned immediately.
- If all retries fail, the last failure is returned.
- The default value for `numRetry` is 1 (no retry).

See the unit tests for comprehensive examples of retry scenarios for all overloads and extension methods.

### When

Types and methods that implement a fluent version of the if/else or if-only syntax.

- **IsTrue, IsFalse**: Checks for a when context on a boolean.

    ```csharp
    var result = Prelude.When(true)
        .IsTrue()
        .Match(
            onTrue: () => "It's true",
            onFalse: () => "It's false"
        ); // "It's true"
    ```

- **IsGreaterThan, IsLessThan, IsEqualsTo**: Checks for a when context on numbers or dates.

    ```csharp
    var res = Prelude.When(10)
        .IsGreaterThan(5)
        .Match(
            onTrue: () => "Greater",
            onFalse: () => "Not greater"
        ); // "Greater"
    ```

- **ContainsKey, ContainsValue**: Checks for a when context on a dictionary.

    ```csharp
    var dict = new Dictionary<string, int> { ["a"] = 1 };
    var found = Prelude.When(dict)
        .ContainsKey("a")
        .Match(
            onTrue: () => "Found",
            onFalse: () => "Not found"
        ); // "Found"
    ```

- **Any, All**: Checks for a when context on an enumerable.

    ```csharp
    var nums = new[] { 2, 4, 6 };
    var allEven = Prelude.When(nums)
        .All(n => n % 2 == 0)
        .Match(
            onTrue: () => "All even",
            onFalse: () => "Not all even"
        ); // "All even"
    ```

- **Is**: Default check to apply on any when context.

    ```csharp
    var check = Prelude.When("abc")
        .Is(s => s.Length == 3)
        .Match(
            onTrue: () => "Length 3",
            onFalse: () => "Other length"
        ); // "Length 3"
    ```

- **Is for Optional and Outcome**: Checks for presence or success and allows working directly with the inner value.

    ```csharp
    // For Optional: predicate and match work with the inner value (or default for None)
    var opt = Optional<int>.Some(5);
    var msg = Prelude.When(opt)
        .Is(x => x > 0) // x is int, not Optional<int>
        .Match(
            onTrue: x => $"Positive: {x}",
            onFalse: x => $"Not positive: {x}"
        ); // "Positive: 5"

    var none = Optional<int>.None();
    var msgNone = Prelude.When(none)
        .Is(x => x > 0) // x is None, no value exists
        .Match(
            onTrue: x => $"Positive: {x}",
            onFalse: x => $"Not positive: {x}"
        ); // "Not positive: 0"

    // For Outcome: predicate and match work with the inner value (Success or Failure)
    var outcome = Outcome<string, int>.Right(10);
    var msg2 = Prelude.When(outcome)
        .Is(x => x > 5) // x is int, not Outcome
        .Match(
            onTrue: x => $"Big: {x}",
            onFalse: x => $"Small: {x}"
        ); // "Big: 10"

    var fail = Outcome<string, int>.Left("fail");
    var msgFail = Prelude.When(fail)
        .Is(x => x > 5) // there is no x, the Outcome contains fail
        .Match(
            onTrue: x => $"Big: {x}",
            onFalse: x => $"Small or error: {x}"
        ); // "Small or error: 0"
    ```

- **IsNullOrEmpty, IsNotNullOrEmpty, IsEqualsTo**: Checks for a when context on a string.

    ```csharp
    var s = "";
    var res = Prelude.When(s)
        .IsNullOrEmpty()
        .Match(
            onTrue: () => "Empty",
            onFalse: () => "Not empty"
        ); // "Empty"
    ```

- **IsAsync**: Checks for a when context on a Task.

    ```csharp
    var t = Task.FromResult(10);
    var asyncRes = await Prelude.When(t)
        .IsAsync(x => x > 5)
        .Match(
            onTrue: () => "Greater",
            onFalse: () => "Not greater"
        ); // "Greater"
    ```

- **Match**: Closes the when context and returns the result, allowing you to specify handlers for both true and false cases.

---
## 3 Functional Types
Implementation of functional counterpart `Either` and `Option`

### Optional

Fluent implementation of the functional programming `Option` type, representing a value that may or may not exist.

- **Bind**: Applies a mapping function to the inner value if present (`Some`), returning a new `Optional`. Enables chaining of operations that may also return `Optional`.

    ```csharp
    var some = Optional<int>.Some(10);
    var result = some.Bind(x => x > 5 ? Optional<string>.Some("big") : Optional<string>.None());
    // result: Optional<string>.Some("big")
    ```

- **BindNone**: Applies a mapping function if the `Optional` is `None`, allowing recovery or alternative computation.

    ```csharp
    var none = Optional<int>.None();
    var recovered = none.BindNone(() => Optional<int>.Some(42));
    // recovered: Optional<int>.Some(42)
    ```

- **BindAsync**: Like `Bind`, but works with an `Optional` wrapped in a `Task` or with a mapping function returning a `Task<Optional<T>>`.

    ```csharp
    var some = Optional<int>.Some(5);
    var asyncResult = await Task.FromResult(some)
        .BindAsync(x => Task.FromResult(Optional<string>.Some($"Value: {x}")));
    // asyncResult: Optional<string>.Some("Value: 5")
    ```

- **BindNoneAsync**: Like `BindNone`, but for an `Optional` wrapped in a `Task` or with a mapping function returning a `Task<Optional<T>>`.

    ```csharp
    var none = Optional<int>.None();
    var asyncRecovered = await Task.FromResult(none)
        .BindNoneAsync(() => Task.FromResult(Optional<int>.Some(99)));
    // asyncRecovered: Optional<int>.Some(99)
    ```

- **Do**: Applies one or more actions/functions to the inner value if present (`Some`), returning the original `Optional` for fluent chaining.

    ```csharp
    Optional<string>.Some("log me")
        .Do(s => Console.WriteLine(s))
        .Do(s => Debug.WriteLine(s));
    ```

- **Map**: Applies a mapping function to the inner value if present (`Some`), returning a new `Optional` with the mapped value.

    ```csharp
    var upper = Optional<string>.Some("abc").Map(s => s.ToUpper());
    // upper: Optional<string>.Some("ABC")
    ```

- **MapNone**: Applies a mapping function if the `Optional` is `None`, returning a new `Optional` with the mapped value.

    ```csharp
    var none = Optional<int>.None();
    var mapped = none.MapNone(() => 123);
    // mapped: Optional<int>.Some(123)
    ```

- **Match**: Closes the `Optional` context, allowing you to handle both `Some` and `None` cases and return a value.

    ```csharp
    var opt = Optional<int>.Some(7);
    var msg = opt.Match(
        onSome: x => $"Value: {x}",
        onNone: () => "No value"
    ); // "Value: 7"
    ```

- **MatchNone**: Returns the inner value if `Some`, or applies a mapping function if `None`.

    ```csharp
    var none = Optional<string>.None();
    var fallback = none.MatchNone(() => "fallback"); // "fallback"
    ```

- **OnSome**: Applies an action or function to the inner value if present (`Some`), without closing the `Optional` context (for side effects).

    ```csharp
    Optional<int>.Some(5)
        .OnSome(x => Console.WriteLine($"Found: {x}"));
    ```

- **OnNone**: Applies an action or function if the `Optional` is `None`, without closing the context.

    ```csharp
    Optional<int>.None()
        .OnNone(() => Console.WriteLine("No value found"));
    ```

- **Or**: Returns the inner value if `Some`, or a fallback value if `None` or if a custom condition is met.

    ```csharp
    var none = Optional<string>.None();
    var value = none.Or("default"); // "default"
    ```

- **ToOutcome**: Converts the `Optional` to an `Outcome`, mapping `Some` to `Right` and `None` to `Left` with a provided failure value.

    ```csharp
    var opt = Optional<int>.Some(1);
    var outcome = opt.ToOutcome("No value");
    // outcome: Outcome<string, int>.Right(1)
    ```

### Outcome

Fluent implementation of the functional programming `Either` type, representing a value that is either a success (`Right`) or a failure (`Left`).

- **Bind**: Applies a mapping function to the `Right` value if present, returning a new `Outcome`. Enables chaining of operations that may also return `Outcome`.

    ```csharp
    var right = Outcome<string, int>.Right(10);
    var chained = right.Bind(x => Outcome<string, int>.Right(x + 5));
    // chained: Outcome<string, int>.Right(15)
    ```

- **BindFailure**: Applies a mapping function to the `Left` value if present, allowing recovery or transformation of the failure.

    ```csharp
    var left = Outcome<string, int>.Left("fail");
    var recovered = left.BindFailure(msg => Outcome<string, int>.Right(msg.Length));
    // recovered: Outcome<string, int>.Right(4)
    ```

- **BindFull**: Applies a mapping function to either the `Right` or `Left` value, depending on the state.

    ```csharp
    var outcome = Outcome<string, int>.Left("fail");
    var mapped = outcome.BindFull(
        onSuccess: x => Outcome<string, string>.Right($"Success: {x}"),
        onFailure: err => Outcome<string, string>.Left($"Error: {err}")
    );
    // mapped: Outcome<string, string>.Left("Error: fail")
    ```

- **Do**: Applies one or more actions/functions to the `Right` value if present, returning the original `Outcome` for fluent chaining.

    ```csharp
    Outcome<string, int>.Right(42)
        .Do(x => Console.WriteLine($"Success: {x}"));
    // Overload: Do with multiple actions
    Outcome<string, int>.Right(42).Do(x => Log(x), x => Audit(x));
    // Overload: Do with function(s) (result ignored)
    Outcome<string, int>.Right(42).Do(x => x + 1);
    Outcome<string, int>.Right(42).Do(x => x + 1, x => x * 2);
    ```

- **Map**: Applies a mapping function to either the `Right` or `Left` value, depending on the state, returning a new `Outcome`.

    ```csharp
    var outcome = Outcome<string, int>.Left("fail");
    var mapped = outcome.Map(
        onSuccess: x => x * 2,
        onFailure: err => err.ToUpper()
    );
    // mapped: Outcome<string, int>.Left("FAIL")
    // Overload: Map with different result types
    var mapped2 = outcome.Map<int, string>(s => s.ToString(), f => f.Length);
    // mapped2: Outcome<string, int>.Left(4)
    ```

- **MapSuccess**: Applies a mapping function to the `Right` value if present, returning a new `Outcome`.

    ```csharp
    var right = Outcome<string, int>.Right(5);
    var mapped = right.MapSuccess(x => x + 1);
    // mapped: Outcome<string, int>.Right(6)
    ```

- **MapFailure**: Applies a mapping function to the `Left` value if present, returning a new `Outcome`.

    ```csharp
    var left = Outcome<string, int>.Left("fail");
    var mapped = left.MapFailure(err => $"Error: {err}");
    // mapped: Outcome<string, int>.Left("Error: fail")
    ```

- **Match**: Closes the `Outcome` context, allowing you to handle both `Right` and `Left` cases and return a value.

    ```csharp
    var outcome = Outcome<string, int>.Right(100);
    var msg = outcome.Match(
        onSuccess: x => $"Success: {x}",
        onFailure: err => $"Failed: {err}"
    ); // "Success: 100"
    ```

- **On**: Applies an action to either the `Right` or `Left` value, depending on the state, without closing the context.

    ```csharp
    Outcome<string, int>.Right(1)
        .On(
            onSuccess: x => Console.WriteLine($"Success: {x}"),
            onFailure: err => Console.WriteLine($"Error: {err}")
        );
    ```

- **OnSuccess**: Applies an action to the `Right` value if present, without closing the context.

    ```csharp
    Outcome<string, int>.Right(7)
        .OnSuccess(x => Console.WriteLine($"Success: {x}"));
    ```

- **OnFailure**: Applies an action to the `Left` value if present, without closing the context.

    ```csharp
    Outcome<string, int>.Left("fail")
        .OnFailure(err => Console.WriteLine($"Error: {err}"));
    ```

- **ToOptional**: Converts the `Outcome` to an `Optional` using the `Right` value; becomes `None` if `Left`.

    ```csharp
    var right = Outcome<string, int>.Right(10);
    var opt = right.ToOptional(); // Optional<int>.Some(10)
    var left = Outcome<string, int>.Left("fail");
    var none = left.ToOptional(); // Optional<int>.None()
    ```

- **ToOptionalFailure**: Converts the `Outcome` to an `Optional` using the `Left` value; becomes `None` if `Right`.

    ```csharp
    var left = Outcome<string, int>.Left("fail");
    var optFail = left.ToOptionalFailure(); // Optional<string>.Some("fail")
    var right = Outcome<string, int>.Right(10);
    var none = right.ToOptionalFailure(); // Optional<string>.None()
    ```

## License

This project is licensed under the MIT License.

---

## More Complex Examples: Combining Components

### 1. Try + Outcome + Fluent Mapping

```csharp
using static FluentFunctionalCoding.Prelude;

string input = "42";

var result = Try(input, s => int.Parse(s))
    .ToEitherUsingException()
    .MapSuccess(x => x + 10)
    .MapFailure(ex => ex.Message)
    .Match(
        onSuccess: val => $"Parsed and incremented: {val}",
        onFailure: errMsg => $"Failed: {errMsg}"
    );
// Output: Parsed and incremented: 52
```

### 2. Optional + Switch + Map

```csharp
var opt = Optional<int>.Some(5);

var message = opt
    .Map(x => x * 2)
    .Switch("No value")
    .CaseOptional(o => o > 5, o => $"Big: {o}")
    .CaseOptional(o => o > 3, o => $"Medium: {o}")
    .Match();
// Output: Big: 10
```

### 3. Outcome + When + Or

```csharp
var outcome = Outcome<string, int>.Left("error");

var value = When(outcome)
    .Is(o => o > 0)
    .Match(
        mapOnTrue: val => $"Value is: {val}",
        mapOnFalse: err => $"Something happened: {err}"
    );
// Output: 100
```

### 4. Try + Optional + Or + Do

```csharp
var opt = Try("abc", s => int.Parse(s))
    .ToOptional()
    .Or(-1)
    .Do(x => Console.WriteLine($"Result: {x}"));
// Output: Result: -1
```

### 5. Async: Task + MapAllAsync + DoForEachAsync

```csharp
var numbersTask = Task.FromResult(new[] { 1, 2, 3 });

await numbersTask
    .MapAllAsync(x => x * 10)
    .DoForEachAsync(n => Console.WriteLine($"Value: {n}"));
// Output: Value: 10, Value: 20, Value: 30
```
