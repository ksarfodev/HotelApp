# HotelApp

# Introduction
This project is a collection of demo MVP(minimally viable product) applications for hotel management.
The original tutorial created by Tim Corey consists of an ASP.NET Web App, WPF Desktop app and no API. 
The original source code can be found here: https://www.csharpmastercourse.com/

This project consists of the following:
* Blazor Server App
> * Used for guest check-in
> * Front-end HTML and CSS designed using VSCode then implemented in Blazor server project
> * External JavaScript libraries implemented using JSInterop
* ASP.NET API 
> * Used by both Maui and Blazor server Apps
* .NET MAUI App
> * Can be deployed on Windows, macOS, iOS, Android


# Live Demo
## Azure App Service
* Visit the following website and make a reservation:
>**Note**: The Azure website instance appears to be using UTC time.
>
> https://hotelappblazor20220909233915.azurewebsites.net

## Android APK
>**Note**: Install and use the provided APK to query data entered using the Azure website above.
Only hotel reservations made for the current [UTC] date will return results and allow for check-in.
* Utilizes an Azure API
* Sideload the APK located at HotelApp.Maui/Signed APK/com.companyname.hotelapp.maui-Signed.apk



# Offline Demo - Setup
* Use Visual Studio 2022 with .NET MAUI App UI Development workload installed
* SQLite Studio or equivalent for sqlite table

# Usage
* First launch HotelApp.API 
* Next launch HotelApp.Blazor to create a reservation
* Then launch HotelApp.Maui to check in


