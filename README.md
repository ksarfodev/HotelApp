# HotelApp

# Introduction
This project is a collection of demo MVP(minimally viable product) applications for hotel management.
The original tutorial created by Tim Corey consists of an ASP.NET Web App, WPF Desktop app and no API. 
The original source code can be found by selecting enroll now at: https://www.csharpmastercourse.com/

This project consists of the following:
* Blazor Server App
> * Used to book a room - create reservation
> * Front-end HTML and CSS designed using VSCode then implemented in Blazor server project
> * External JavaScript libraries implemented using JSInterop
* ASP.NET API 
> * Used by both Maui and Blazor server Apps
* .NET MAUI App
> * Used for guest check-in 
> * Can be deployed on Windows, macOS, iOS, Android

# Live Demo
## Blazor Web Assembly - Azure Static Web app
* Visit the following website and make a reservation:
>**Note**: The Azure website instance appears to be using UTC time.
>
> https://orange-dune-078d2960f.2.azurestaticapps.net

## Angular - Azure Static Web app
* Visit the following website and make a reservation:
>
> https://thankful-smoke-010a42f0f.2.azurestaticapps.net

## Windows Installer
>**Note**: Install and use the provided Window's App to query data entered using the Azure website above.
* Install files are located in the following github folder: HotelApp.Maui_1.0.0.0_Sideload
* Launch HotelApp.Maui_1.0.0.0_x64.msix to begin install

## Android APK
>**Note**: Install and use the provided APK to query data entered using the Azure website above.
Only hotel reservations made for the current [UTC] date will return results and allow for check-in.
* Sideload the APK located at HotelApp.Maui/Signed APK/com.companyname.hotelapp.maui-Signed.apk

# Offline Demo - Setup
* Use Visual Studio 2022 with .NET MAUI App UI Development workload installed
* SQLite Studio or equivalent for sqlite table

# Usage
* First launch HotelApp.API 
* Next launch HotelApp.Blazor to create a reservation
* Also try the Angular app to create a reservation: https://github.com/ksarfodev/HotelApp-Angular
* Then launch HotelApp.Maui to check in



