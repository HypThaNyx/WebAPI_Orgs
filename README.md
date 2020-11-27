<h2 align="center"> WebAPI - Organizations </h2>

<p align="center">
This repo is used to receive repositories data from the GitHub API, based on the organization. It uses a .NET WebAPI for the logic.
</p>

<p align="center">
  <a href="https://github.com/HypThaNyx">
    <img alt="Made by Wesley Yago" src="https://img.shields.io/badge/made%20by-Wesley%20Yago-orange">
  </a>

  <img alt="Last Commit" src="https://img.shields.io/github/last-commit/HypThaNyx/WebAPI_Orgs">

  <img alt="Contributors" src="https://img.shields.io/github/contributors/HypThaNyx/WebAPI_Orgs">

  <img alt="License" src="https://img.shields.io/badge/license-MIT-orange">

  <a href="https://www.linkedin.com/in/wesley-yago-da-silva/">
    <img alt="Check out my LinkedIn!" src="https://img.shields.io/badge/-LinkedIn-black.svg?logo=linkedin&color=666">
  </a>
</p>
---

## Table of Contents

<ul>
  <li><a href="#-how-it-works">How it works</a></li>
  <li><a href="#-getting-started">Getting Started</a></li>
  <li><a href="#-features">Features</a></li>
  <li><a href="#-support">Support</a></li>
  <li><a href="#-license">License</a></li>
</ul>

---

## 🤖 How it works

This API consumes the GitHub API and pulls repositories data from a specific organization.

---

## 🚀 Getting Started

### Prerequisites

- [.NET Core 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)

### Setup

Instructions to use:
- download or clone the repo
- run a Shell prompt inside the project's main folder (WebAPIClient)
- enter the following command and press Enter:

``` bash
dotnet run
```

- open a request at Insomnia/Postman or go to your browser at https://localhost:5001
- consume the API by making a GET request with the organization name as a parameter 
- voilà!

---

## 📋 Features

The program should be able to:
- [X] Consume the GitHub Repositories API.
- [X] Store organizations info locally using Cache.
- [X] Use FeatureManagement to toggle Cache being used.
- [X] Cache expiration time defined by a parameter in appSettings.
- [ ] Perform Unit Testing.

### Documentation

This project uses the following Commit Guidelines:

- build: Changes that affect the build system or external dependencies (example scopes: gulp, broccoli, npm)
- ci: Changes to our CI configuration files and scripts (example scopes: Travis, Circle, BrowserStack, SauceLabs)
- docs: Documentation only changes
- feat: A new feature
- fix: A bug fix
- perf: A code change that improves performance
- refactor: A code change that neither fixes a bug nor adds a feature
- style: Changes that do not affect the meaning of the code (white-space, formatting, missing semi-colons, etc)
- test: Adding missing tests or correcting existing tests

---

## 📌 Support

Contact and support me through the following social medias:

- <a href="https://hypthanyx.itch.io/">
    <img alt="Check out my Itch.io!" src="https://img.shields.io/badge/Itch.io-HypThaNyx-fff?logo=itch.io&style=social">
  </a>
- <a href="https://twitter.com/hypthanyx">
    <img alt="Check out my Twitter!" src="https://img.shields.io/badge/Twitter-HypThaNyx-fff?logo=twitter&style=social">
  </a>
- <a href="https://www.instagram.com/hypthanyx/">
    <img alt="Check out my Instagram!" src="https://img.shields.io/badge/Instagram-HypThaNyx-fff?logo=instagram&style=social">
  </a>
- <a href="https://www.linkedin.com/in/wesley-yago-da-silva/">
    <img alt="Check out my LinkedIn!" src="https://img.shields.io/badge/LinkedIn-Wesley Yago-black.svg?logo=linkedin&color=666&style=social">
  </a>
- <a href="https://www.youtube.com/channel/UC_x5u0TqJWN4O3GMwZRWkrg">
    <img alt="Check out my YouTube!" src="https://img.shields.io/badge/YouTube-HypThaNyx-black.svg?logo=youtube&color=666&style=social">
  </a>

---

## 📝 License

<img alt="License" src="https://img.shields.io/badge/license-MIT-%2304D361">

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

🧰 Being developed by Wesley Yago!
