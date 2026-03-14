### Project Structure

# OrderService

A robust order management microservice built with **.NET**, following **Clean Architecture** and **Domain-Driven Design (DDD)** principles.

---

## 🏗️ Project Structure


```text

event-driven-dotnet-angular
│
├── backend
│   │
│   ├── services
│   │   │
│   │   ├── OrderService
│   │   │   ├── Controllers
│   │   │   ├── Entities
│   │   │   ├── Data
│   │   │   ├── Events
│   │   │   └── Program.cs
│   │   │
│   │   ├── InventoryService
│   │   │   ├── Consumers
│   │   │   └── Program.cs
│   │   │
│   │   ├── NotificationService
│   │   │   ├── Consumers
│   │   │   └── Program.cs
│   │
│   ├── shared
│   │   └── Contracts
│   │       └── OrderCreatedEvent.cs
│   │
│   └── docker-compose.yml
│
└── frontend
    │
    └── angular-app
        ├── src
        │   ├── app
        │   │   ├── services
        │   │   ├── components
        │   │   └── models
        │   └── environments
        │
        └── package.json
		
		
OrderService
│
├── Domain
│   ├── Entities          # Core business models (Order, OrderItem)
│   ├── ValueObjects      # Immutable objects (Address, Money)
│   └── DomainEvents      # Business logic triggers (OrderCreated)
│
├── Application
│   ├── Commands          # State-changing operations (PlaceOrder)
│   ├── Queries           # Read-only operations (GetOrderById)
│   ├── Interfaces        # Abstractions for Infrastructure (IRepository)
│   └── DTOs              # Data contracts for the API
│
├── Infrastructure
│   ├── Persistence       # EF Core, Migrations, Repositories
│   ├── Messaging         # RabbitMQ/Azure Service Bus implementations
│   └── ExternalServices  # Third-party API clients (Stripe, Twilio)
│
└── API
    ├── Controllers       # REST Endpoints
    └── Program.cs        # Dependency Injection & Middleware


Where Event-Driven Messaging Fits
  With Pub/Sub, the layers map like this:

Layer	        Responsibility
Domain	        Business rules
Application	    Use cases
Infrastructure	RabbitMQ / MassTransit
API	            HTTP endpoints

Example flow:

HTTP Request
   ↓
Controller (API)
   ↓
Application Command
   ↓
Domain Logic
   ↓
Domain Event Created
   ↓
Infrastructure publishes event
   ↓
RabbitMQ


EventSystem.Orders/
├── Internal/                <-- Everything here is 'internal'
│   ├── Controllers/         
│   │   └── OrdersController.cs (internal)
│   ├── Domain/
│   └── EventHandlers/       <-- Responds to 'PaymentSucceeded'
├── Contracts/               <-- Everything here is 'public'
│   ├── IntegrationEvents/   
│   │   └── OrderCreated.cs
│   └── DTOs/

