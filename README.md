# National Parks API

## Description

This is an API for state and national parks. It provides information about various parks including their names, locations, descriptions, and activities available.

## Technologies Used

- .NET 7.0
- ASP.NET Core 7.0.4
- Entity Framework Core 7.0.8
- Pomelo Entity Framework Core for MySQL 7.0.0
- Swashbuckle (Swagger) 6.4.0

## Installation

1. Clone the repository: `git clone https://github.com/yourusername/NationalParksApi.git`
2. Navigate to the `NationalParksApi` directory on your computer
3. Open with your preferred text editor to view the code base
4. To start the API, run `dotnet run` in your terminal within the project folder

## Setting up the Database

1. Create an `appsettings.json` file in the `NationalParksApi` directory
2. Add the following code to the file:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=national_parks;uid=root;pwd=YourPassword;"
  }
}
```

3. Replace `YourPassword` with your own MySQL password
4. Run `dotnet ef database update` in your terminal to create the database

## API Documentation
### Endpoints

Base URL: `https://localhost:5072`

#### HTTP Request Structure

```
GET /api/parks
Returns a list of all parks in the database
```

```
GET /api/parks/{id}
Returns the park with the specified ID.
```

```
POST /api/parks
Creates a new park. The body of the request should include `parkName`, `state`, `description`, and `activities`.
```

```
PUT /api/parks/{id}
Edits the park with the specified ID. The body of the request should include `parkName`, `state`, `description`, and `activities`.
```

```
DELETE /api/parks/{id}
Deletes the park with the specified ID.
```

## Pagination

This API supports pagination. To use it, include `pageNumber` and `pageSize` parameters in your request. For example, `GET /api/parks?pageNumber=2&pageSize=20` will return the second set of 20 parks.

## Known Bugs
• No known bugs at this time.

## Contact
If you have any questions, comments, or concerns, please contact me at `justinbshaffer91@gmail.com`.

## License
Copyright 2023 Justin Shaffer

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
