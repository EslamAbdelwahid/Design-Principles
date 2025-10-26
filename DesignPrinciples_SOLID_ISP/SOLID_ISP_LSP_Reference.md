# 🧩 SOLID Principles — Interface Segregation & Liskov Substitution (C# Reference)

This reference explains **Interface Segregation Principle (ISP)** and **Liskov Substitution Principle (LSP)** using C# examples, written in both English and simple Arabic-style explanations.

---

## 🧩 Interface Segregation Principle (ISP)

### Definition

> **Clients should not be forced to depend on interfaces they do not use.**

### In Plain English

Classes should not be required to implement **methods they don’t need**.  
Instead of one large interface, create **multiple smaller ones** so each class only depends on what it actually uses.

---

### ❌ Before Applying ISP

```csharp
public interface IWorker
{
    void Work();
    void Eat();
}

public class Human : IWorker
{
    public void Work() => Console.WriteLine("Human is working");
    public void Eat() => Console.WriteLine("Human is eating");
}

public class Robot : IWorker
{
    public void Work() => Console.WriteLine("Robot is working");
    public void Eat() => throw new NotImplementedException("Robot doesn't eat!");
}
```

👎 Problem: The `Robot` is **forced to implement `Eat()`**, even though that method doesn’t make sense for it.

---

### ✅ After Applying ISP

```csharp
public interface IWorkable
{
    void Work();
}

public interface IEatable
{
    void Eat();
}

public class Human : IWorkable, IEatable
{
    public void Work() => Console.WriteLine("Human is working");
    public void Eat() => Console.WriteLine("Human is eating");
}

public class Robot : IWorkable
{
    public void Work() => Console.WriteLine("Robot is working");
}
```

✅ Each class now implements **only what it needs**, which keeps the design clean and flexible.

---

### 💡 Key Idea

> Split large interfaces into smaller, focused ones so classes only depend on what they actually use.

---

### 📘 Summary in One Line

> **No class should be forced to implement methods it doesn’t need.**

---

## 🧱 Liskov Substitution Principle (LSP)

### Definition

> **Objects of a superclass should be replaceable with objects of its subclasses without breaking the program.**

### In Plain English

If class `B` inherits from class `A`, then `B` should behave like `A`.  
You should be able to replace `A` with `B` anywhere, and the program should still work properly.

---

### ❌ Before Applying LSP

```csharp
public class Bird
{
    public virtual void Fly()
    {
        Console.WriteLine("Bird flying");
    }
}

public class Sparrow : Bird
{
    public override void Fly()
    {
        Console.WriteLine("Sparrow flying");
    }
}

public class Ostrich : Bird
{
    public override void Fly()
    {
        throw new NotImplementedException("Ostrich can't fly!");
    }
}
```

If we run:

```csharp
Bird bird = new Ostrich();
bird.Fly(); // 💥 Throws exception
```

👎 Problem: `Ostrich` is a `Bird` but **can’t fly**, so substituting it breaks expected behavior.

---

### ✅ After Applying LSP

```csharp
public abstract class Bird
{
    public abstract void Move();
}

public class Sparrow : Bird
{
    public override void Move()
    {
        Console.WriteLine("Sparrow is flying");
    }
}

public class Ostrich : Bird
{
    public override void Move()
    {
        Console.WriteLine("Ostrich is running");
    }
}
```

Now both behave correctly when substituted:

```csharp
Bird bird1 = new Sparrow();
Bird bird2 = new Ostrich();

bird1.Move(); // Sparrow is flying
bird2.Move(); // Ostrich is running ✅
```

✅ No unexpected errors — both subclasses respect their parent’s contract.

---

### 💡 Key Idea

> Subclasses must be **true substitutes** for their base classes — no surprises or broken expectations.

---

### 📘 Summary in One Line

> **If a subclass can’t fully behave like its parent, inheritance is wrong — use composition or redesign instead.**

---

## ⚖️ Quick Comparison

| Principle | Focus | Core Idea | Example Violation |
|------------|--------|------------|------------------|
| **ISP** | Interfaces | Classes shouldn’t implement unused methods | `Robot` being forced to implement `Eat()` |
| **LSP** | Inheritance | Subclasses must behave like base classes | `Ostrich` throwing error in `Fly()` |

---


