# Secure Priority Queue with Microservices

This project demonstrates a distributed architecture designed for secure and prioritized asynchronous data transmission between microservices. The system ensures data confidentiality using AES-256 encryption and manages task execution through RabbitMQ’s priority-based queuing mechanism.

---

## Tech Stack & Libraries

The system is developed using the following technologies:

* **Framework:** .NET 8 / ASP.NET Core
* **Message Broker:** RabbitMQ (Priority Queue support)
* **Security:** System.Security.Cryptography (AES-256-CBC)
* **State Management:** Redis 
* **Infrastructure:** Docker 
* **Communication:** Asynchronous Messaging

---

## Core Features

* **AES Payload Encryption:** All messages are encrypted by the Producer service before transmission. The data remains encrypted while stored in RabbitMQ, ensuring that only authorized Consumers can decrypt and read the content.
* **Priority-Based Routing:** By utilizing RabbitMQ’s `x-max-priority` feature, messages are processed based on their urgency (0-10). High-priority tasks are handled first, regardless of their arrival time.
* **Service Decoupling:** The Producer and Consumer services are completely independent. This allows each service to scale separately and improves overall system reliability.
* **High-Performance Processing:** The system is designed for high throughput by avoiding traditional SQL database dependencies. All operations are performed in-memory and through the message broker.
* **Secure Key Management:** Cryptographic keys and Initialization Vectors (IV) are managed via secure configuration environments to ensure secure decryption on the Consumer side.

---

## Project Architecture



The workflow consists of three main stages:

1. **Producer Service:** Receives the raw input, encrypts the payload using the AES-256 algorithm, assigns a priority level, and dispatches the message to the queue.
2. **RabbitMQ (Message Broker):** Manages the encrypted messages in a priority queue. It ensures that the most critical tasks are at the front of the queue based on metadata.
3. **Consumer Service:** Monitors the queue, pulls the encrypted messages, performs the decryption process using the shared secret, and executes the final business logic.

