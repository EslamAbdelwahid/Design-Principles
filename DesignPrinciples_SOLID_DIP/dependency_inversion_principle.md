# Dependency Inversion Principle (DIP)

The **Dependency Inversion Principle (DIP)** is the **"D"** in the **SOLID** principles of object-oriented design.  
It helps make your code more flexible, maintainable, and testable by reducing coupling between modules.

---

## 🧠 Definition

> **High-level modules should not depend on low-level modules.  
> Both should depend on abstractions.**

and

> **Abstractions should not depend on details.  
> Details should depend on abstractions.**

---

## ⚙️ Simple Explanation

In plain English:

- High-level code (like a service or controller) **should not directly depend** on specific implementations (like `EmailService`).
- Both the high-level and low-level modules should depend on an **interface** (or abstract class).
- This allows you to **swap implementations** without changing the high-level logic.

---

## ❌ Example — Without DIP

```csharp
public class EmailService
{
    public void SendEmail(string to, string message)
    {
        Console.WriteLine($"Sending Email to {to}: {message}");
    }
}

public class Notification
{
    private EmailService _emailService = new EmailService();

    public void Send(string to, string message)
    {
        _emailService.SendEmail(to, message);
    }
}
```

### Problems:
- `Notification` depends directly on `EmailService`.
- If you need to send SMS or Push Notifications instead, you must modify `Notification` → violates **Open/Closed Principle**.
- The code is hard to test or extend.

---

## ✅ Example — With DIP Applied

We introduce an **interface** to represent the abstraction:

```csharp
public interface IMessageService
{
    void SendMessage(string to, string message);
}
```

Implementations:

```csharp
public class EmailService : IMessageService
{
    public void SendMessage(string to, string message)
    {
        Console.WriteLine($"Sending Email to {to}: {message}");
    }
}

public class SmsService : IMessageService
{
    public void SendMessage(string to, string message)
    {
        Console.WriteLine($"Sending SMS to {to}: {message}");
    }
}
```

Now the high-level class depends on the **abstraction**:

```csharp
public class Notification
{
    private readonly IMessageService _messageService;

    public Notification(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public void Send(string to, string message)
    {
        _messageService.SendMessage(to, message);
    }
}
```

Usage:

```csharp
public class Program
{
    public static void Main()
    {
        IMessageService emailService = new EmailService();
        IMessageService smsService = new SmsService();

        var notification1 = new Notification(emailService);
        notification1.Send("eslam@gmail.com", "Welcome via Email!");

        var notification2 = new Notification(smsService);
        notification2.Send("+201234567890", "Welcome via SMS!");
    }
}
```

**Output:**
```
Sending Email to eslam@gmail.com: Welcome via Email!
Sending SMS to +201234567890: Welcome via SMS!
```

---

## 🧩 Diagram (Conceptual)

```
Without DIP:
[Notification] ---> [EmailService]

With DIP:
[Notification] ---> [IMessageService] <--- [EmailService]
                                     <--- [SmsService]
```

---

## 💡 Benefits of Using DIP

| Benefit | Description |
|----------|--------------|
| **Flexibility** | You can easily replace or add new implementations without changing high-level code. |
| **Testability** | You can mock interfaces in unit tests. |
| **Maintainability** | Changes in one part of the system don't ripple through others. |
| **Loose Coupling** | High-level modules don’t depend on specific details. |

---

## 🧰 In Real Projects (ASP.NET Core Example)

In modern C# applications, we often use **Dependency Injection (DI)** to implement DIP automatically.

```csharp
// Register services
services.AddScoped<IMessageService, EmailService>();

// Constructor injection in a controller
public class NotificationController
{
    private readonly IMessageService _messageService;

    public NotificationController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public void Send(string to, string message)
    {
        _messageService.SendMessage(to, message);
    }
}
```

Here, ASP.NET Core automatically injects the correct `IMessageService` implementation when the controller is created.

---

## 🧠 Summary

| Concept | Explanation |
|----------|--------------|
| **High-level module** | Contains main business logic (e.g., `Notification`). |
| **Low-level module** | Handles technical details (e.g., `EmailService`, `SmsService`). |
| **Abstraction** | Interface or abstract class connecting both layers. |

✅ **DIP ensures that:**
- High-level modules depend on **interfaces**, not concrete classes.  
- Low-level modules implement those interfaces.  

This leads to **cleaner, more modular, and more maintainable code**.

---

