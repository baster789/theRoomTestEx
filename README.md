# Description
Project uses **.NET 5** versions of **EFC** and **ASP.NET Core**
Postman files are included into the solution to make testing easier
# How to start
- Open solution in Visual Studio 2019 (.net 5 should be supported)
- Launch Update-Database command on Data project
- Build & Start WebApi project
- App will be available on https://localhost:5001
- Acquire new JWT token via **api/v1/auth/login** request with { "username": "test@test.com", "password": "12345"}
- Use this token for consequent requests. TTL of the token is 15 minutes by default, the new one can be obtained via  **api/v1/auth/refresh** endpoint (using cookie)
- Service and Promocodes support pagination and sorting with **pageSize, page, sortDir, sort** query parameters