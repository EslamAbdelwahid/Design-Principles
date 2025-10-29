# KissYagniTD — Solution overview

This solution is a small set of example projects that demonstrate simple design principles (KISS, YAGNI) and basic strategy-based payment processing.

## Projects
- `KissYagniTDV1` — older or alternate variant (kept in the solution).
- `KissYagniTDV2` — current console sample. Focus of this README.

## Purpose
The project name combines two common dev principles:
- KISS — "Keep It Simple, Stupid" (favor simple implementations)
- YAGNI — "You Aren't Gonna Need It" (don't add functionality until required)

The code is intentionally small and focused to show a minimal, extensible payment processing example using the Strategy pattern.

## Key files (in `KissYagniTDV2`)
- `Program.cs` — console app entry. Reads `amount` and `method` from the console, calls the payment service and prints a `Receipt`.
- `Service/PaymentService.cs` — orchestrates payment processing. Holds a dictionary of payment strategies keyed by method name.
- `Common/Constants.cs` (referenced by `PaymentService`) — defines method keys (e.g. `Cash`, `Debit`).
- `Service/*PaymentStrategy.cs` — concrete implementations of `IPaymentStrategy` (e.g. `CashPaymentStrategy`, `DebitPaymentStrategy`).
- `Models/Receipt.cs` — simple record representing the result of a payment.

## How `KissYagniTDV2` works
1. `Program` prompts the user for amount and method.
2. It constructs `PaymentService` and calls `ProcessPayment(amount, method)`.
3. `PaymentService` finds the right `IPaymentStrategy` from its dictionary and delegates `ProcessPayment` to it.
4. The concrete strategy returns a `Receipt` which the program prints.

This keeps the high-level flow simple while isolating method-specific behavior in separate strategy classes (easy to extend without modifying `PaymentService` internals).

## How to run
From the solution folder (requires .NET8 SDK):

```bash
# build
dotnet build

# run the V2 console app
dotnet run --project KissYagniTDV2
```

When running the V2 app you will be prompted to enter an amount (decimal) and a method (e.g. `Cash` or `Debit` as defined in the constants). The app will print a `Receipt`.

## Extending the sample
- Add a new strategy: implement `IPaymentStrategy`, add a concrete class (e.g. `CreditCardPaymentStrategy`), and register it in the `PaymentService` dictionary (or refactor registration to use DI/factory for better scalability).
- Replace the dictionary with an IoC/DI container registration if this grows beyond a few strategies.
- Add unit tests: create a test project and assert `PaymentService.ProcessPayment` behavior for each method and for unsupported methods.

## Notes
- Target framework: .NET8
- C# language version:12
- The code demonstrates minimal, focused implementation per KISS and YAGNI — only the strategies the author needed are present.

If you want, I can:
- Add a short CONTRIBUTING or DEVELOPMENT guide file
- Create a unit test project and add a couple of tests for `PaymentService`
- Register strategies via DI instead of hard-coding the dictionary

Tell me which of these (if any) you want next.