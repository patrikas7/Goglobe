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

