# Problems in `NotificationService` Class

This document lists all design and architectural issues in the following C# class and explains how they violate SOLID principles and software engineering best practices.

```csharp
internal class NotificationService
{
    private readonly Customer u9customer;
    private readonly EmailService emailService;
    private readonly SMSService smsService;

    public NotificationService(Customer customer)
    {
        emailService = new EmailService
        {
            EmailAddress = customer.EmailAddress
        };
        smsService = new SMSService
        {
            MobileNo = customer.MobileNo
        };
    }

    public void Notify()
    { 
        emailService.Send();
        smsService.Send();    
    }
}
```

---

## 1. Violation of Dependency Inversion Principle (DIP)

**Problem:**
The `NotificationService` depends directly on concrete classes (`EmailService`, `SMSService`).

**Why it's wrong:**
High-level modules (like `NotificationService`) should not depend on low-level modules. Both should depend on abstractions.

**Impact:**

* The service cannot easily support new notification types (e.g., WhatsApp, Push).
* Any change in `EmailService` or `SMSService` forces changes in `NotificationService`.

---

## 2. Violation of Open/Closed Principle (OCP)

**Problem:**
The class must be modified every time a new notification type is added.

**Why it's wrong:**
A class should be *open for extension but closed for modification*.

**Impact:**

* Adding new channels (like `PushService`) requires editing the `Notify()` method.
* Increases the chance of introducing bugs during updates.

---

## 3. Violation of Single Responsibility Principle (SRP)

**Problem:**
`NotificationService` handles multiple concerns:

1. Creating notification service instances.
2. Sending notifications.

**Why it's wrong:**
Each class should have one reason to change. Here, a change in object creation logic or in notification logic would both require changes in this class.

**Impact:**

* Makes the code harder to maintain.
* Tight coupling between creation and business logic.

---

## 4. Hard to Unit Test

**Problem:**
The class creates its dependencies using `new`, so you cannot inject mock or fake services during tests.

**Why it's wrong:**
Unit testing depends on the ability to replace real dependencies with test doubles.

**Impact:**

* Cannot isolate tests.
* Increases testing complexity and reduces automation flexibility.

---

## 5. Poor Extensibility

**Problem:**
New types of notifications cannot be added without modifying the class.

**Why it's wrong:**
A well-designed class should allow new features through extension (e.g., adding a new interface implementation), not modification.

**Impact:**

* Low scalability.
* Violates OCP.

---

## 6. Tight Coupling

**Problem:**
`NotificationService` directly knows the implementation details of `EmailService` and `SMSService`.

**Why it's wrong:**
Changes in either service’s implementation (like renaming `Send()` to `SendMessage()`) will break the class.

**Impact:**

* Fragile architecture.
* High risk of regression bugs.

---

## 7. Poor Reusability

**Problem:**
`NotificationService` cannot be reused in another context unless those specific services (`EmailService`, `SMSService`) exist.

**Why it's wrong:**
Reusability requires abstraction and independence from specific implementations.

**Impact:**

* Limited usage.
* Requires code duplication for similar scenarios.

---

## Summary Table

| # | Problem                           | Violated Principle | Root Cause                              | Impact              |
| - | --------------------------------- | ------------------ | --------------------------------------- | ------------------- |
| 1 | Dependency on concrete services   | DIP                | Depends on `EmailService`, `SMSService` | Not flexible        |
| 2 | Must modify class to add features | OCP                | Hardcoded dependencies                  | Not maintainable    |
| 3 | Multiple responsibilities         | SRP                | Manages creation + logic                | Complex maintenance |
| 4 | Hard to unit test                 | -                  | No dependency injection                 | Low testability     |
| 5 | Not extensible                    | OCP                | No abstraction layer                    | Low scalability     |
| 6 | Tightly coupled                   | -                  | Direct dependency on implementations    | Fragile design      |
| 7 | Not reusable                      | -                  | Concrete bindings                       | Limited reusability |

---

## Suggested Solution (Brief)

Introduce an abstraction layer:

```csharp
public interface INotificationChannel
{
    void Send();
}

public class EmailService : INotificationChannel { /* ... */ }
public class SMSService : INotificationChannel { /* ... */ }

public class NotificationService
{
    private readonly IEnumerable<INotificationChannel> channels;

    public NotificationService(IEnumerable<INotificationChannel> channels)
    {
        this.channels = channels;
    }

    public void Notify()
    {
        foreach (var channel in channels)
            channel.Send();
    }
}
```

✅ This fixes:

* **DIP:** `NotificationService` depends only on `INotificationChannel`.
* **OCP:** New channels can be added without modifying `NotificationService`.
* **SRP:** `NotificationService` only coordinates notifications.
* **Testability:** You can inject mock channels in tests.
* **Reusability & Extensibility:** Easy to reuse in any system.
