# Goglobe

## About the project

The goal of the project is to provide details from different travel agencies about travel plans so that users could find the best offers and book travel plans directly on the "goglobe" platform. 

The system has three different roles for users: guest user registered user and system administrator. Guest users and registered users are able to see different kinds of travel offers, read about them, filter offers by price, destination, dates, etc. Additionally, users with registration can book travel offers or bookmark them. System administrators can create, edit or delete travel offers.

## Funcional requirements

**Guest user:**
- View travel offers
- Filter offers by price, date, destination
- Search for destination
- See hot offers
- Login
- Register

**Registered user:**
- View travel offers 
- Filter offers by price, date, destination
- Search for destination
- See hot offers
- Login
- Logout
- Edit profile details
- Delete profile
- Book travel offer
- View booked travel offers

**Administrator**
- View travel offers
- Create travel offer
- Edit travel offer
- Delete travel offer
- Login
- Logout

## Used technologies
- Front-end: React + TypeScript + SCSS
- Back-end: ASP.NET Core
- Database: MySQL

## System architecture

"Goglobe" web application is being hosted inside "azure" server. Client from the browser will communicate with application through HTTP. Application front-end and back-end will communicate through REST API. To access MySQL database, back-end will have ORM interface.

<img width="452" alt="image" src="https://user-images.githubusercontent.com/79539642/190874995-9cdbc3c1-02a3-4714-95ff-4633a1d8ba35.png">

## API specification

**GET /travelOffers

- Request URL: https://goglobeapi.azurewebsites.net/api/travelOffers
- Response codes: 200, 400
- Required headers: none
- Response example: [
    {
        "id": 3,
        "price": 850,
        "departureDate": "2022-12-01T00:00:00",
        "returnDate": "2022-12-06T00:00:00",
        "personCount": 2,
        "description": "Poiilsinė kelionė ir apsistojimas 4 žvaigždučių viešbutyje",
        "isFeedingIncluded": false,
        "agency": 1,
        "hotel": 1,
        "country": 1,
        "city": 1,
        "bookings": [],
        "travelPhotos": [],
        "travelProperties": []
    }
 ]
 
 **GET /travelOffers/:id
- Request URL exmaple: https://goglobeapi.azurewebsites.net/api/travelOffers/1
- Response codes: 200, 400, 404
- Required headers: none
- Response example: {
        "id": 3,
        "price": 850,
        "departureDate": "2022-12-01T00:00:00",
        "returnDate": "2022-12-06T00:00:00",
        "personCount": 2,
        "description": "Poiilsinė kelionė ir apsistojimas 4 žvaigždučių viešbutyje",
        "isFeedingIncluded": false,
        "agency": 1,
        "hotel": 1,
        "country": 1,
        "city": 1,
        "bookings": [],
        "travelPhotos": [],
        "travelProperties": []
    }
    
**POST /travelOffers
- Request URL: https://goglobeapi.azurewebsites.net/api/travelOffers
- Response codes: 201, 400, 401
- Required headers: authorization
- Request body example: {
    "countryId": 1,
    "cityId": 1,
    "hotelId": 1,
    "agencyId": 1,
    "price": 200,
    "departureDate": "2022-12-08",
    "returnDate": "2022-12-19",
    "personCount": 2,
    "isFeedingIncluded": false,
    "description": "",
}

**PUT /travelOffers/:id
- Request URL exmaple: https://goglobeapi.azurewebsites.net/api/travelOffers/1
- Response codes: 200, 400, 401, 404
- Required headers: authorization
- Request body example: {
    "countryId": 1,
    "cityId": 1,
    "hotelId": 1,
    "agencyId": 1,
    "price": 200,
    "departureDate": "2022-12-08",
    "returnDate": "2022-12-19",
    "personCount": 2,
    "isFeedingIncluded": false,
    "description": "",
}

**DELETE /travelOffers/:id
- Request URL exmaple: https://goglobeapi.azurewebsites.net/api/travelOffers/1
- Response codes: 200, 400, 401, 404
- Required headers: authorization

**GET /bookigns
- Request URL: https://goglobeapi.azurewebsites.net/api/bookings
- Response codes: 200, 400, 401
- Required headers: authorization
- Response exmaple: [
    {
        "id": 11,
        "date": "2022-12-08T00:00:00",
        "bookingReference": "xlp45FdM1Rf",
        "status": 1,
        "travelOffer": {
            "id": 3
        }
        "clientId": "69a338fa-45d2-44a4-a2cd-543232dee02a"
    },       
]

**GET /bookings/:id
- Request URL exmaple: https://goglobeapi.azurewebsites.net/api/bookings/1
- Response codes: 200, 400, 401
- Required headers: authorization
- Response exmaple: {
        "id": 11,
        "date": "2022-12-08T00:00:00",
        "bookingReference": "xlp45FdM1Rf",
        "status": 1,
        "travelOffer": {
            "id": 3
        }
        "clientId": "69a338fa-45d2-44a4-a2cd-543232dee02a"
},       

**POST /bookings
- Request URL: https://goglobeapi.azurewebsites.net/api/bookings
- Response codes: 201, 400, 401
- Required headers: authorization
- Request body example: {
          "Date": "2022-10-11",
          "TravelOfferId": 1,
          "ClientId": 1,
}

**PUT /bookings
- Request URL: https://goglobeapi.azurewebsites.net/api/bookings/:id
- Response codes: 200, 400, 401, 404
- Required headers: authorization
- Request body example: {
          "Date": "2022-10-11",
          "TravelOfferId": 1,
          "ClientId": 1,
}

**DELETE /bookings
- Request URL: https://goglobeapi.azurewebsites.net/api/bookings/:id
- Response codes: 200, 400, 401, 404
- Required headers: authorization





