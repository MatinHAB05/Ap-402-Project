---
title: Final Advanced Programming(Winter-2024) Project with WPF and .NET -  Restaurant Management GUI Application
author: Matin HAB & Parham Mohammadi
tags: [c#, .net, advanced-programming, wpf-ui, restaurant-app]
date: 2024-01-19
---

<a id="readme-top"></a>

<p align="center">
  <img src="docs/screenshots/app-icon.png" alt="App icon" width="96"/>
</p>

# Restaurant Management Graphic Application

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
![WPF](https://img.shields.io/badge/UI-WPF-0C54C2)
![Platform: Windows](https://img.shields.io/badge/platform-Windows-0078D6?logo=windows&logoColor=white)

# Table of Contents

- [About The Project](#about-the-project)
- [Technologies and Features](#technologies-and-features)

  - [Key Features](#key-features)
  - [Built With](#built-with)

- [Getting Started](#getting-started)

  - [Dependencies](#dependencies)
  - [Installing](#installing)
  - [Execution](#execution)

- [Preview](#preview)
- [Authors](#authors)
- [License](#license)
- [Acknowledgments](#acknowledgments)
- [Last Words](#last-words)

## About The Project

The Restaurant Management GUI Application is a .NET‑based software built using the WPF framework. It was developed as the final project for the AP[^1] course in the Winter 2024 semester (Dey–Esfand 1402), after we had learned the fundamentals of object‑oriented programming and the C# language.

It simulates a real restaurant-booking platform for three kinds of users. Customers can browse and filter restaurants, order food or reserve a table, rate and comment on dishes, and track their order history and complaints. Restaurants manage their own menu, stock and reservation availability, and can export sales/booking reports. Admins onboard new restaurants and resolve customer complaints. All three roles share a single login screen, and everything is persisted to local JSON files rather than a database server, so the app runs anywhere with no extra setup.

<p align="right">(<a href="#readme-top">back to top</a>)</p>


## Technologies and Features

### Key Features

*The shared login screen plays a background music track for atmosphere.*

**Customer**

- Sign up with email verification, then browse or filter the full restaurant list by city, name, service type (delivery / dine-in) and minimum rating
- Order food from a stock-aware cart, or reserve a table, paying by cash or a simulated online payment confirmed by email
- Rate and comment on individual dishes, and edit or delete your own comments
- Subscribe to a Bronze / Silver / Gold plan to unlock table reservations, each with its own monthly quota, booking window and cancellation-penalty rules
- Review past orders and file or track complaints against a restaurant

**Restaurant**

- Manage the menu: add, edit or remove dishes and categories, and reply to customer comments
- Update stock per dish (setting it to zero marks the item unavailable)
- Turn table reservations on or off, available once the restaurant's average rating reaches 4.5★
- Filter the full order/reservation history by customer, dish, price range, type and date, and export the result as a CSV report

**Admin**

- Register new restaurants and issue their initial login credentials
- Search restaurants and complaints with multiple filters
- Review open complaints and respond to customers

### Built With

- **C# / .NET 8** (`net8.0-windows`)
- **WPF (XAML)** for the desktop UI
- **Newtonsoft.Json** — JSON files act as the app's "database", no external server needed
- **MailKit** / **MimeKit** — sends signup verification codes and payment receipts over SMTP
- **CsvHelper** — exports restaurant sales/reservation reports to CSV
- **LINQ** for all searching and filtering
- **Inno Setup** — packages a self-contained Windows installer that bundles the .NET 8 Desktop Runtime

*The codebase is organized one folder per feature, named `<Feature>_<Developer>` (e.g. `LoginForm_Matin`, `ChangeMenu_Parham`), so it's easy to tell who built what.*

<p align="right">(<a href="#readme-top">back to top</a>)</p>


## Getting Started

### Dependencies

- Windows 10/11 (64-bit) — WPF applications only run on Windows
- [.NET 8 Desktop Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) to run a published build, or the **.NET 8 SDK** with **Visual Studio 2022** (".NET desktop development" workload) to build from source
- A Gmail account if you want signup-verification and payment-receipt emails to actually send — see [Installing](#installing)

### Installing

**Option 1 — build from source**

1. Clone the repo:
   ```bash
   git clone https://github.com/MatinHAB05/Ap-2024-Project-Restaurant-Management.git
   ```
2. Open `RestaurantApp.sln` in Visual Studio 2022. NuGet restores `CsvHelper`, `MailKit` and `Newtonsoft.Json` automatically on first build.
3. *(Optional)* emails are sent through a Gmail account via MailKit. To use your own account instead of the bundled demo one, open `SignInPage_Matin/SignInForm.xaml.cs` and `reserrveORorderFoods_CustomerPage_Matin/reserrveORorderFoods_CustomerPage.xaml.cs`, and replace the sender address/app-password passed into `SendEmail(...)` with your own Gmail address and a [Google App Password](https://myaccount.google.com/apppasswords).

**Option 2 — installer (easiest)**

1. Download `RestaurantApp_Setup.exe` from the [Releases](../../releases) page.
2. Run it and click through the setup wizard — accept the license, keep the default install folder, and keep clicking **Next** until you reach **Install**.
3. If .NET 8 Desktop Runtime isn't already on your machine, the installer downloads and installs it for you automatically — nothing extra to do.
4. Click **Finish**. The app is now in your Start Menu (and on your Desktop too, if you left that box checked), ready to open.

*(This installer is built from the `script.iss` Inno Setup script included in the repo — see [Built With](#built-with).)*

### Execution

- **From Visual Studio:** open the solution and press `F5` (or `Ctrl+F5`) to launch `RestaurantApp.exe`.
- **From the CLI:**
  ```bash
  dotnet run --project RestaurantApp/RestaurantApp.csproj
  ```
- All data lives as JSON under `RestaurantApp/JsonFiles/` (users, restaurants, admins, complaints, orders/reservations, ratings) — there's nothing else to seed or configure.
- The login screen is shared by all three roles; the app matches your username/password against the Customer, Restaurant and Admin records automatically. For a quick look around, two demo accounts are already seeded:

  | Role | Username | Password |
  |---|---|---|
  | Admin | `UserName3` | `123123` |
  | Restaurant | `UserNameRes3` | `123123` |

  Or register a new customer from the **Sign Up** link — a verification code will be emailed to you, and if it doesn't show up within a minute or two, check your **Spam** folder.

<p align="right">(<a href="#readme-top">back to top</a>)</p>


## Preview

<!--
  Screenshots below live in a `docs/screenshots/` folder at the repo root.
  Still missing: a short demo GIF/video — drop one into `docs/screenshots/demo.gif`
  (or drag it straight into this file from the GitHub web editor) to add it.
-->

**Login & Sign Up**

![Login screen](docs/screenshots/login.png)
![Sign up form](docs/screenshots/sign-up.png)
![Set a password after email verification](docs/screenshots/set-password.png)

**Customer — browse, order & reserve**

![Customer main page — restaurant list, search & filters](docs/screenshots/customer-main-page.png)
![Profile page — personal info and Bronze / Silver / Gold plan](docs/screenshots/profile-page.png)
![Food page — ratings and comments](docs/screenshots/food-comments.png)
![Cart & checkout](docs/screenshots/order-and-pay.png)
![Order history](docs/screenshots/order-history.png)
![Filing a complaint against a restaurant](docs/screenshots/complaints.png)

**Restaurant panel — menu, stock & reservations**

![Restaurant panel — main menu](docs/screenshots/restaurant-panel.png)
![Confirmation after toggling the reservation service](docs/screenshots/reservation-toggle.png)
![Change menu — add or remove dishes and categories](docs/screenshots/change-menu.png)
![Add a food — name, price, materials, photo](docs/screenshots/add-food.png)
![Change food inventory — update remaining stock](docs/screenshots/change-inventory.png)

**Admin panel — restaurants & complaints**

![Admin panel — main menu](docs/screenshots/admin-panel.png)
![Register a new restaurant](docs/screenshots/add-restaurant.png)
![Admin — edit password](docs/screenshots/admin-edit-password.png)
![Search restaurants by city, rating and complaint status](docs/screenshots/search-restaurants.png)
![Search complaints by user, restaurant or review status](docs/screenshots/search-complaints.png)
![Respond to the latest unreviewed complaints](docs/screenshots/respond-to-complaints.png)
![All complaints, with admin responses](docs/screenshots/all-complaints.png)



<p align="right">(<a href="#readme-top">back to top</a>)</p>


## Authors

Matin Hasanali Baki

- ❤️[GitHub](https://github.com/MatinHAB05)
- ✉️[Email](mailto:m9652973@gmail.com)
- 📞[Telegram](https://t.me/MHB2005)

Parham Mohammadi

- ❤️[GitHub](https://github.com/parham200483)
- ✉️[Email](mailto:????@gmail.com)
- 📞[Telegram](https://t.me/Parham_md)

<p align="right">(<a href="#readme-top">back to top</a>)</p>


## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details

<p align="right">(<a href="#readme-top">back to top</a>)</p>


## Acknowledgments


Built on top of these tools and libraries — thanks to their authors and docs:

- [WPF documentation](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/) (Microsoft Learn)
- [C# documentation](https://learn.microsoft.com/en-us/dotnet/csharp/) (Microsoft Learn)
- [Git documentation](https://git-scm.com/doc)
- [MailKit](https://github.com/jstedfast/MailKit)
- [Newtonsoft.Json](https://www.newtonsoft.com/json)
- [CsvHelper](https://joshclose.github.io/CsvHelper/)
- [Inno Setup](https://jrsoftware.org/isinfo.php)

<p align="right">(<a href="#readme-top">back to top</a>)</p>


## Last Words

This project was genuinely challenging and required a lot of work, so I hope the final result turned out clean and polished.

> And hey — don't forget to give the project a star! 😉



[^1]: Advanced Programming
