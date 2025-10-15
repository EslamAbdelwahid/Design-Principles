
# 🧩 Single Responsibility Principle (SRP) — C# Example

## Definition

> **A class should have only one reason to change.**

### In Plain English

Each class should do **one thing** — have **one responsibility**.  
If it needs to change for multiple reasons (e.g., logic, database, UI), then it’s doing **too much**.

---

## 🏗️ System Before Applying SRP

Let's say we have a class that handles both **invoice data** and **printing**.

```csharp
public class Invoice
{
    public int Id { get; set; }
    public double Amount { get; set; }

    public void SaveToDatabase()
    {
        Console.WriteLine("Saving invoice to database...");
    }

    public void PrintInvoice()
    {
        Console.WriteLine("Printing invoice...");
    }
}
```

### ⚠️ Problem

This class has **two responsibilities**:
- Managing **invoice data**
- Handling **printing** and **database storage**

If printing logic or database logic changes, we must modify this class — violating SRP.

---

## ✅ System After Applying SRP

We split responsibilities into separate classes.

```csharp
public class Invoice
{
    public int Id { get; set; }
    public double Amount { get; set; }
}
```

### Database Responsibility

```csharp
public class InvoiceRepository
{
    public void Save(Invoice invoice)
    {
        Console.WriteLine("Saving invoice to database...");
    }
}
```

### Printing Responsibility

```csharp
public class InvoicePrinter
{
    public void Print(Invoice invoice)
    {
        Console.WriteLine($"Printing invoice #{invoice.Id} with amount {invoice.Amount}");
    }
}
```

### Usage

```csharp
public class Program
{
    public static void Main()
    {
        Invoice invoice = new Invoice { Id = 1, Amount = 200.0 };

        InvoiceRepository repository = new InvoiceRepository();
        repository.Save(invoice);

        InvoicePrinter printer = new InvoicePrinter();
        printer.Print(invoice);
    }
}
```

---

## 💡 Key Idea

> SRP helps keep classes **focused**, **easy to test**, and **maintainable**.

---
### 📘 Summary in One Line

> A class should have **one reason to change**.
