
---

# Backend

## Table of Contents
- [Overview](#Overview)
- [Features](#Features)
- [Prerequisites](#Prerequisites)
- [Spring Boot Application](#Spring-Boot-Application)
  - [Instructions](#Instructions)
  - [Application Endpoints](#Application-Endpoints)
- [Database](#Database)
  - [Instructions](#Instructions)

## Overview

This backend application serves as the backend for a questionnaire system. It provides endpoints to manage questionnaires and submit answers securely.

## Features

- **User Authentication** : Secure user authentication and authorization using Spring Security with JWT.
- **Get Questionnaire** : Give MCQ questions and corresponding multiple choices.
- **Questionnaire Submission** : Securely submit answers to questionnaires and calculate the score.

## Prerequisites

- Spring Boot 3.1.11
- Maven
- Java 17
- MySQL
   

## Spring Boot Application

We use Spring Boot with Spring Security to create our backend application. The backend application can be found in  [`questionnaire`](./questionnaire) directory.

### Instructions

 1. **Install IntelliJ IDEA**: Install IntelliJ IDEA.
 2. **Open the Project**: Open the cloned project in IntelliJ IDEA.
 3. **Build the Project**: Build the project to resolve dependencies and compile the code.
 4. **Configure the Database**: Update the database configuration in `src/main/resources/application.properties` of the Spring Boot application. 
 5. **Run the Application**: Start the Spring Boot application to create the necessary tables and run the backend server.

### Application Endpoints

- **GET** `/quiz/get` : Get the questionnaire.
- **POST** `/quiz/submit` : Submit the answers and return the calculated score to the frontend application.
- **GET** `/user/isQuizDone` :  Used in the Unity environment to check whether the player has completed the quiz.
- **GET** `/user/getScore` : Used in the Unity environment to get the player's score.
- **POST** `/api/auth/register` : Used in the Unity environment to register players for secure authentication.
- **POST** `/api/auth/login` : Log into the quiz in the Unity environment when the player has not completed the quiz after registering.

## Database 

We use MySQL as our database. The database script can be found in [`spacquestionnarie.sql`](./spacquestionnarie.sql).

### Instructions

1. **Install MySQL**: Install MySQL on your system.

3. **Create Database**: Run the first two lines of the script [`spacquestionnarie.sql`](./spacquestionnarie.sql) to create the `spacdb` database.

    ```bash
    create database spacdb;
    use spacdb;
    ```

4. **Database Configuration**: Update the database configuration in `src/main/resources/application.properties` of the Spring Boot application. Change the username and password according to your database configuration.

    ```properties
    # Database Configuration
    spring.datasource.url=jdbc:mysql://localhost:3306/spacdb
    spring.datasource.username= your_username
    spring.datasource.password= your_password
    ```

5. **Run Spring Boot Application**: Run the Spring Boot application to create the necessary tables.

6. **Populate Tables**: Once the application runs, execute the rest of the SQL script to insert values into the tables.


