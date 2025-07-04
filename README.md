# Fawry Task - Shopping Cart Application

## Class Diagram

```mermaid
classDiagram
    Product <|-- Cheese
    Product <|-- Biscuits
    Product <|-- TV
    Product <|-- MobileScratchCard

    Cheese ..|> IExpirable
    Cheese ..|> IShippable
    Biscuits ..|> IExpirable
    Biscuits ..|> IShippable
    TV ..|> IShippable

    CartItem --> Product
    Cart --> CartItem
    Cart --> ShipmentDetail
    Customer --> Cart
    Shop ..> Cart
    Shop ..> Customer
    ShippingService ..> ShipmentDetail

    class Product {
        +Name: string
        +Price: double
        +Quantity: int
    }
    class Cheese {
        +GetExpiryDate(): Date
        +IsExpired(): bool
        +GetName(): string
        +GetWeight(): double
    }
    class Biscuits {
        +GetExpiryDate(): Date
        +IsExpired(): bool
        +GetName(): string
        +GetWeight(): double
    }
    class TV {
        +GetName(): string
        +GetWeight(): double
    }
    class MobileScratchCard {
    }
    class IShippable {
        <<interface>>
        +GetName(): string
        +GetWeight(): double
    }
    class IExpirable {
        <<interface>>
        +IsExpired(): bool
    }
    class CartItem {
        +Product: Product
        +Quantity: int
    }
    class Cart {
        +Items: List<CartItem>
        +Add(product: Product, quantity: int): void
        +GetShipmentDetails(): List<ShipmentDetail>
        +HasExpiredItems(): bool
        +HasOutOfStock(): bool
        +ReduceStock(): void
    }
    class ShipmentDetail {
        +Name: string
        +Weight: double
    }
    class Customer {
        +Name: string
        +Cart: Cart
    }
    class Shop {
    }
    class ShippingService {
    }
```

---

## Application Overview

This repository contains a shopping cart application implemented in both C# and Java. The application models a simple e-commerce system with the following features:

- **Product Hierarchy:** Abstract `Product` class with concrete subclasses (`Cheese`, `Biscuits`, `TV`, `MobileScratchCard`).
- **Interfaces:** `IShippable` and `IExpirable` interfaces for products that can be shipped or expire.
- **Cart and CartItem:** A `Cart` holds multiple `CartItem` objects, each referencing a `Product` and its quantity.
- **Customer:** Each customer has a cart.
- **ShippingService:** Handles shipment details and prints shipment notices.
- **Shop:** Static class for shop operations.

## Project Structure

- `C#/` - C# implementation
- `Java/` - Java implementation

## How to Run

### C#
1. Navigate to the `C#` directory.
2. Build the project using your preferred .NET build tool (e.g., `dotnet build`).
3. Run the application (e.g., `dotnet run`).

### Java
1. Navigate to the `Java` directory.
2. Compile the Java files (e.g., `javac *.java`).
3. Run the application (e.g., `java Program`).

## Notes
- The class diagram above provides a high-level overview of the main classes and their relationships.
- The code is organized for clarity and extensibility, following object-oriented principles.

---

Feel free to contribute or open issues for suggestions and improvements! 