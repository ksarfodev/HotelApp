# HotelApp

# Introduction
This project is a collection of demo MVP(minimally viable product) applications for hotel management.
The original tutorial created by Tim Corey consists of an ASP.NET MVC WebApp, WPF Desktop app and no API. 
Source code can be found here: https://www.csharpmastercourse.com/

This project consists of the following:
* Blazor Server App
> * Used for guest check-in
> * Front-end HTML and CSS designed using VSCode then implemented in Blazor server project
> * External JavaScript libraries implemented using JSInterop
* ASP.NET API 
> * Sits between database and MAUI/Blazor Apps
* .NET MAUI App
> * WPF application converted to MAUI


# Live Demo
## Azure App Service
> **Note**:The Azure instance appears to be 1 day ahead
#
https://hotelappblazor20220909233915.azurewebsites.net

## Android APK
* Utilizes an Azure API
Located at HotelApp.Maui/Signed APK/com.companyname.hotelapp.maui-Signed.apk



# Setup
* Use Visual Studio 2022 with .NET MAUI App UI Development workload installed
* SQLite Studio or equivalent for sqlite table

# Usage
* First launch HotelApp.API 
* Next launch HotelApp.Blazor to create a reservation
* Then launch HotelApp.Maui to check in


