
# 🧩 Open/Closed Principle (OCP) — C# Example

## Definition

> **Software entities (classes, modules, functions) should be open for extension, but closed for modification.**

### In Plain English

You should be able to **add new behavior** without **modifying existing code**.

---

## 🏗️ System Before Applying OCP

Imagine a system that calculates area for shapes.

```csharp
public class Rectangle
{
    public double Width { get; set; }
    public double Height { get; set; }
}

public class Circle
{
    public double Radius { get; set; }
}

public class AreaCalculator
{
    public double CalculateArea(object shape)
    {
        if (shape is Rectangle rect)
            return rect.Width * rect.Height;
        else if (shape is Circle circle)
            return Math.PI * circle.Radius * circle.Radius;

        throw new NotSupportedException("Shape not supported.");
    }
}
```

### ⚠️ Problem

If we add a new shape (like `Triangle`), we must **modify** `AreaCalculator`.  
That violates OCP because we’re changing existing logic.

---

## ✅ System After Applying OCP

We’ll use **abstraction** — let each shape handle its own area logic.

### Step 1: Create an interface

```csharp
public interface IShape
{
    double Area();
}
```

### Step 2: Implement it for each shape

```csharp
public class Rectangle : IShape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public double Area() => Width * Height;
}

public class Circle : IShape
{
    public double Radius { get; set; }

    public double Area() => Math.PI * Radius * Radius;
}
```

### Step 3: Update the calculator

```csharp
public class AreaCalculator
{
    public double CalculateArea(IShape shape)
    {
        return shape.Area();
    }
}
```

### Step 4: Usage

```csharp
public class Program
{
    public static void Main()
    {
        IShape rect = new Rectangle { Width = 4, Height = 5 };
        IShape circle = new Circle { Radius = 3 };

        AreaCalculator calc = new AreaCalculator();

        Console.WriteLine(calc.CalculateArea(rect));   // 20
        Console.WriteLine(calc.CalculateArea(circle)); // 28.27...
    }
}
```

### ✅ Add a new shape — no need to modify existing code!

```csharp
public class Triangle : IShape
{
    public double Base { get; set; }
    public double Height { get; set; }

    public double Area() => 0.5 * Base * Height;
}
```

Now we can use it:

```csharp
IShape triangle = new Triangle { Base = 10, Height = 5 };
Console.WriteLine(calc.CalculateArea(triangle)); // 25
```

---

## 💡 Key Idea

> You **extend** the system by adding new classes, not by changing existing ones.

| Before | After |
|--------|--------|
| Add new shape → must edit `AreaCalculator` | Add new shape → just create new class |
| Violates OCP | Respects OCP |

---

### 📘 Summary in One Line

> Classes should be **open for extension**, **closed for modification**.
