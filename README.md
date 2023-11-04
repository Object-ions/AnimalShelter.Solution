# Animal Shelter API

#### By Moshe Atia Poston

## Description

A web Api that allows the user to make API calls in order to check the database. The user can create, remove, update, and see detailed information about the animals in the animal shelter.

## Table of Contents

1. [Description](#description)
2. [Features](#features)
3. [Technologies Used](#technologies-used)
4. [Setup/Installation Requirements](#setupinstallation-requirements)
   - [Required Technology](#required-technology)
   - [Cloning the Repo](#cloning-the-repo)
   - [Set up a Connection String to Database](#set-up-a-connection-string-to-database)
   - [Create the Database](#create-the-database)
5. [Launching the API](#launching-the-api)
6. [Using API](#using-api)
   - [Pagination Info](#pagination-info)
   - [Endpoints](#endpoints)
     - [HTTP Request Structure](#http-request-structure)
     - [Parameters](#parameters)
   - [Sample Data](#sample-data)
     - [Dogs](#dogs)
     - [Cats](#cats)
     - [Note on `Personality`](#note-on-personality)
   - [Examples](#examples)
     - [Sample JSON Response](#sample-json-response)
     - [Example Queries](#example-queries)
7. [Known Bugs](#known-bugs)
8. [License](#license)

## Features

1. Full CRUD Functionalities for dogs and cats.
2. Filter animals based on multiple criteria like name, age, and personality.
3. Pagination support.

## Technologies Used

- C#
- .NET 6
- ASP.NET Core Web API
- Entity Framework Core
- MySQL
- Postman
- Swagger

## Setup/Installation Requirements

### Required Technology

1. Follow the instructions on this <a href="https://old.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql">page</a> for installing and configuring MySQL.
2. Installing dotnet-ef:

   > ```bash
   > $ dotnet tool install --global dotnet-ef --version 6.0.0
   > ```

3. Install Postman
   (Optional) [Download and install Postman](https://www.postman.com/downloads/).

#### Cloning the Repo:

1. Open Terminal.
2. Change your directory to where you would want the cloned directory.
3. Input the following command into your terminal:
   > ```bash
   > $ git clone https://github.com/Object-ions/AnimalShelter.Solution.git
   > ```

#### Set up a Connection String to Database

4. Using the terminal, navigate to the production directory- "AnimalShelterApi" and create a new file called 'appsettings.json'

5. Add the following code snippet while also replacing the following values with your own values as shown below the code snippet:

- [YOUR-USERNAME-HERE] with your username
- [YOUR-PASSWORD-HERE] with your password
- [YOUR-DATABASE-NAME-HERE] with the name of your database

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[YOUR-DATABASE-NAME-HERE];uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
  }
}
```

#### Create the Database

6. In your terminal, under the project's production directory `AnimalShelterApi`, run this command to create the database.

> ```bash
> $ dotnet ef database update
> ```

However, if update does not work, run this command in your terminal:

> ```bash
> $ dotnet ef migrations add Initial
> $ dotnet ef database update
> ```

## Launching the API

In the command line in the project's production directory `AnimalShelterApi`, enter the command `dotnet run`. This compile and execute the application.

> ```bash
> $ dotnet run
> ```

## Using API

To access the API endpoints, utilize tools like a browser, Postman, or Swagger.

(If working with Swagger, go to either https://localhost:5001/swagger/index.html or http://localhost:5000/swagger/index.html.)

#### Pagination Info

The API supports pagination for listing endpoints. Pagination allows you to retrieve a subset of records, making it efficient for large datasets.

- pageIndex: Indicates the current page number. Starts at 1.
- pageSize: Defines the number of records per page.

Example: To retrieve the second page of dogs with 10 dogs per page, use:
GET /api/dogs?pageIndex=1&pageSize=10

If pagination is not defined in the request, default values will be used.

## Endpoints

#### HTTP Request Structure

| Request Type |        Path         | Description                                | Parameters                                       |
| :----------: | :-----------------: | ------------------------------------------ | ------------------------------------------------ |
|     GET      |   /api/{animals}    | Retrieves a list of animals.               | name, sex, age, personality, pageIndex, pageSize |
|     GET      | /api/{animals}/{id} | Retrieves a specific animal by its ID.     | None                                             |
|     POST     |   /api/{animals}    | Creates a new animal entry.                | Request body contains animal details.            |
|     PUT      | /api/{animals}/{id} | Updates an existing animal entry by ID.    | Request body contains updated details.           |
|    DELETE    | /api/{animals}/{id} | Deletes a specific animal entry by its ID. | None                                             |

The endpoints valid for both `dogs` and `cats`. Replace {animals} with either `dogs` or `cats` (note to use plural). All enpoint for cats will be similar in structure to those for dogs and vice versa.

- **Parameters**:
  - `name` (optional): Filter dogs by name.
  - `sex` (optional): Filter dogs by sex (e.g., male or female).
  - `age` (optional): Filter dogs by age.
  - `personality` (optional): Filter dogs by personality (e.g., playful, loyal).
  - `minAge` and `maxAge` (optional): Define a range for dog's age.
  - `pageIndex` and `pageSize` (optional): Define pagination parameters.

Example Request: `GET /api/dogs?name=Bella&sex=female`

## Sample Data

### Dogs

| DogId | Name (required) | Sex (required) | Age (required) | Personality (optional) |
| ----- | --------------- | -------------- | -------------- | ---------------------- |
| 1     | Bella           | Female         | 7              | Playful                |
| 2     | Max             | Female         | 10             | Loyal                  |
| ...   | ...             | ...            | ...            | ...                    |

### Cats

| CatId | Name (required) | Sex (required) | Age (required) | Personality (optional) |
| ----- | --------------- | -------------- | -------------- | ---------------------- |
| 1     | Whiskers        | Male           | 7              | Independent            |
| 2     | Oliver          | Female         | 10             | Affectionate           |
| ...   | ...             | ...            | ...            | ...                    |

\*\* Note that `Age` represented in months and not years.

### Note on `Personality`

The concept of 'personality' can be subjective and open to interpretation. To maintain consistency and clarity within this API, I predefined a set of personality options. Here are the personalities you can encounter or use:

- Playful
- Loyal
- Curious
- Shy
- Protective
- Friendly
- Independent
- Affectionate
- Adventurous
- Lazy
- Mysterious

## Examples

#### Example Queries

The following query will return the 3rd and 4th cats from the dataset.

```
https://localhost:5001/api/Cats?pageIndex=2&pageSize=2
```

#### Sample JSON Response from the above query

```json
{
  "totalCount": 6,
  "pageSize": 2,
  "currentPage": 2,
  "totalPages": 3,
  "items": [
    {
      "catId": 3,
      "name": "Charlie",
      "sex": "Male",
      "age": 2,
      "personality": "Adventurous"
    },
    {
      "catId": 4,
      "name": "Daisy",
      "sex": "Female",
      "age": 4,
      "personality": "Lazy"
    }
  ]
}
```

## Known Bugs

- No known bugs.

## License

[MIT](https://choosealicense.com/licenses/mit/)

Copyright (c) 2023 Moshe Atia

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

- If you detect any bug in the program, please reach out to me at [moshikoatia@gmail.com](mailto:moshikoatia@gmail.com).
