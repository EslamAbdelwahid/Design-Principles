
# Liskov Substitution Principle (LSP) — C# Example

## Definition

> **Formal Definition:**  
> If `S` is a subtype of `T`, then objects of type `T` may be replaced with objects of type `S` **without altering the correctness** of the program.

### In Plain English

If you have a **base class** and a **subclass**, then you should be able to **use the subclass anywhere the base class is expected**, 
and the program should still **work correctly** — not crash, not behave unexpectedly.

---

## System Before Applying LSP

Let’s imagine a simple system about **Birds** 

```csharp
public class Bird
{
    public virtual void Fly()
    {
        Console.WriteLine("Bird is flying.");
    }
}
```

### Subclasses

```csharp
public class Sparrow : Bird
{
    public override void Fly()
    {
        Console.WriteLine("Sparrow is flying fast!");
    }
}

public class Penguin : Bird
{
    public override void Fly()
    {
        throw new NotSupportedException("Penguins can't fly!");
    }
}
```

### Usage

```csharp
public class BirdService
{
    public void MakeBirdFly(Bird bird)
    {
        bird.Fly();
    }
}

public class Program
{
    public static void Main()
    {
        BirdService service = new BirdService();

        Bird sparrow = new Sparrow();
        Bird penguin = new Penguin();

        service.MakeBirdFly(sparrow); // ✅ Works
        service.MakeBirdFly(penguin); // ❌ Throws exception
    }
}
```

### ⚠️ Problem

- The program expects **every Bird to fly**, because the base class defines `Fly()`.
- But `Penguin` **breaks that expectation** — it throws an exception instead.

So `Penguin` **cannot be substituted** where `Bird` is expected → **LSP is violated**.

---

## ✅ System After Applying LSP

Let’s redesign to **respect LSP**.

We separate responsibilities properly:

```csharp
public abstract class Bird
{
    public abstract void Eat();
}

public interface IFlyingBird
{
    void Fly();
}
```

### Correct Subclasses

```csharp
public class Sparrow : Bird, IFlyingBird
{
    public override void Eat()
    {
        Console.WriteLine("Sparrow eats seeds.");
    }

    public void Fly()
    {
        Console.WriteLine("Sparrow flies in the sky!");
    }
}

public class Penguin : Bird
{
    public override void Eat()
    {
        Console.WriteLine("Penguin eats fish.");
    }
}
```

### Updated Service

```csharp
public class BirdService
{
    public void MakeBirdFly(IFlyingBird bird)
    {
        bird.Fly();
    }
}
```

### Usage

```csharp
public class Program
{
    public static void Main()
    {
        BirdService service = new BirdService();

        IFlyingBird sparrow = new Sparrow();
        service.MakeBirdFly(sparrow); // ✅ Works

        // Penguin is not a flying bird, so we don't pass it to MakeBirdFly()
        Bird penguin = new Penguin();
        penguin.Eat(); // ✅ Works fine
    }
}
```



## 💡 Key Idea

> LSP encourages designing **correct inheritance hierarchies** —  
> subclasses should **extend behavior**, not **break** what the base class promises.
