# 🌦️ Weather Forecast API

A minimal ASP.NET Core Web API application that provides weather forecasts for a specific city, with clean architecture, JWT authentication, caching, and testing.

---

## 🚀 Features

- ✅ User registration and login using JWT (without Identity)
- 🔐 JWT-based Authentication
- 🌤️ Weather endpoint: `GET /api/weather?city=CityName`
- 🧠 In-Memory Caching for performance
- 🧪 Unit & Integration Tests
- 📦 Clean Architecture (Domain, Application, Infrastructure, WebAPI layers)

---

## 🏗️ Technologies Used

- .NET 8
- ASP.NET Core Web API
- xUnit (Testing)
- IMemoryCache
- Swagger / OpenAPI
- JWT (System.IdentityModel.Tokens.Jwt)

---

## 📁 Project Structure

```
├── Domain
├── Application
├── Infrastructure
├── WebAPI
│   └── Program.cs
├── Tests
│   └── Unit & Integration Tests
└── README.md
```

---

## 📌 Endpoints

| Method | URL                        | Description                  | Auth Required |
|--------|----------------------------|------------------------------|---------------|
| POST   | `/api/auth/register`       | Register a new user          | ❌            |
| POST   | `/api/auth/login`          | Authenticate and return JWT  | ❌            |
| GET    | `/api/weather?city=XYZ`    | Get weather data             | ✅            |

---

## 🔑 Authentication

Use JWT token returned from `/api/auth/login` to access the `/api/weather` endpoint.

### Example (Swagger ):
 
```http
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR...
```

---

## ⚙️ How to Run

### ✅ Prerequisites

- .NET SDK 8.0+

### 🛠️ Steps

```bash
git clone https://github.com/your-username/weather-api.git
cd weather-api
dotnet build
dotnet run --project WebAPI
```

Then visit: `https://localhost:{PORT}/swagger`

---

## 🧪 Run Tests

```bash
dotnet test
```

---

## 📬 Contact

> Developed by Maher  
For questions or feedback, feel free to reach out!
