### C# 9 and greater...

- (✅) record types
- 💥 discriminated unions (Tip on next slide)
- (✅) pattern matching
- (✅) immutability / non-nullability

![/images/tweet-don-syme-fsharp-csharp.png](/images/tweet-don-syme-fsharp-csharp.png)

https://twitter.com/dsymetweets/status/1294280620823240706

---
layout: two-cols
---

### Discriminated Unions in C#


```csharp
record Rectangle(int Width, int Height);
record Circle(int Radius);

// Discriminated Union
class Shape : OneOfBase<Circle, Rectangle>
{
    private Shape(OneOf<Circle, Rectangle> _) : base(_) {}
    static implicit operator Shape(Rectangle _) => new(_);
    static implicit operator Shape(Circle _) => new(_);
}

// Usage: Pattern Matching
static string Describe(Shape shape) =>
    shape.Match(
        circle => 
            $"Circle has radius {circle.Radius}",
        rectangle => 
            $"H: {rectangle.Height} " +
            $"W: {rectangle.Width}");
```

- "OneOf" [https://github.com/mcintyre321/OneOf](https://github.com/mcintyre321/OneOf)

::right::

### &nbsp;

```csharp
[Fact]
public void Shape_tests()
{
    Shape shape1 = new Circle(42);
    Shape shape2 = new Rectangle(2, 3);

    var result1 = Describe(shape1);
    var result2 = Describe(shape2);

    result1.Should().Be("Circle has radius 42");
    result2.Should().Be("H: 3 W: 2");
}
```

<!-- <style>
.slidev-code * {
    font-size: smaller !important;
}
</style> -->