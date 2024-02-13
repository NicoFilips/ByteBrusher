<a name="readme-top"></a>

<!-- PROJECT LOGO -->
<br />
<div align="center">
<a href="https://github.com/NicoFilips/ByteBrusher/">
  <img src="https://user-images.githubusercontent.com/35654361/283448124-805ac645-a568-42c4-8a1d-177070e4df59.png" alt="Logo" width="200" height="200">
</a>

<blockquote>
  <p>Source: DALL-E 3</p>
</blockquote>


[![NuGet](https://img.shields.io/nuget/v/ByteBrusher.svg)](https://www.nuget.org/packages/ByteBrusher)

 [![publish ByteBrusher to nuget](https://github.com/NicoFilips/ByteBrusher/actions/workflows/pack-and-deploy-to-nuget-org.yml/badge.svg)](https://github.com/NicoFilips/ByteBrusher/actions/workflows/pack-and-deploy-to-nuget-org.yml)
 [![Build](https://github.com/NicoFilips/ByteBrusher/actions/workflows/dotnet-build.yml/badge.svg)](https://github.com/NicoFilips/ByteBrusher/actions/workflows/dotnet-build.yml)
 
[![SonarCloud](https://sonarcloud.io/api/project_badges/measure?project=NicoFilips_ByteBrusher&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=NicoFilips_ByteBrusher)
[![Code-Coverage](https://codecov.io/gh/NicoFilips/ByteBrusher/branch/main/graph/badge.svg?token=DR2EBIWK7B)](https://codecov.io/gh/NicoFilips/ByteBrusher)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)
[![GitHub contributors](https://img.shields.io/github/contributors/NicoFilips/ByteBrusher)](https://GitHub.com/NicoFilips/ByteBrusher/graphs/contributors/)

  <h3 align="center">Byte Brusher</h3>

  <p align="center">
    An awesome little Project to keep your Desktop tidy!
    <br />
    <a href="https://github.com/NicoFilips/ByteBrusher/wiki"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/NicoFilips/ByteBrusher/">View Demo</a>
    ·
    <a href="https://github.com/NicoFilips/ByteBrusher/issues">Report Bug</a>
    ·
    <a href="https://github.com/NicoFilips/ByteBrusher/issues">Request Feature</a>
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents 📋 </summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage 🔨 ">Usage</a></li>
    <li><a href="#roadmap 🗺️ ">Roadmap</a></li>
    <li><a href="#contributing 👨‍👩‍👦‍👦 ">Contributing</a></li>
    <li><a href="#license 🏳️ ">License</a></li>
    <li><a href="#contact 🪪 ">Contact</a></li>
    <li><a href="#acknowledgments 🦉">Acknowledgments</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

[![Product Name Screen Shot][product-screenshot]](https://example.com)

So, if you're anything like me, you'll realize that it's not always straightforward to manage your data. Whether it's vacation photos, memes, documents, bills, videos, or anything else you need to store, the challenge is real. The task becomes even more daunting when you add the necessity of managing additional backups. And let's face it, your desktop isn't a version control system like git, making it tough to handle all this without considering future changes you might make. This time, I set out to develop an application that corrects past mistakes. It identifies and, if needed, eliminates duplicates.

Here's why:
* Your time should be spent on creating something remarkable, not hunting down duplicates and unnecessary documents.
* Repeating the same tasks over and over isn't efficient.
* Keeping your desktop organized and your storage as minimal as possible is essential. 😄

Admittedly, this project might not be flawless or meet all your needs. So, I plan to make more improvements soon. You're also welcome to suggest changes by forking this repository, creating a pull request, or opening an issue. A big thank you to everyone who takes the time to explore this Repository!

<p align="right">(<a href="#readme-top">back to top</a>)</p>

```mermaid
classDiagram
    class Program {
        -IScanUtil _scanUtil
        +IFilterUtil _filterUtil
    }

    class ScanUtil {
        +ScanUtil(IOptions options, ILogger logger)
        +GetFiles()
    }

    class FilterUtil {
        +Filter()
    }

    Program <|-- ScanUtil : uses
    Program <|-- FilterUtil : uses
```

### Built With

This section should list any major frameworks/libraries used to bootstrap your project. Leave any add-ons/plugins for the acknowledgements section. Here are a few examples.

| Technology | Logo |
|------------|------|
| .NET 6     | ![.NET Logo](https://img.shields.io/badge/.NET-8-512BD4?style=for-the-badge&logo=.net&logoColor=white) |
| C#         | ![C# Logo](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white) |
| Serilog    | ![Serilog Logo](https://img.shields.io/badge/Serilog-FF33CC?style=for-the-badge) |
| Polly      | ![Polly Logo](https://img.shields.io/badge/Polly-FF69B4?style=for-the-badge) |
| NUnit      | ![NUnit Logo](https://img.shields.io/badge/NUnit-02569B?style=for-the-badge&logo=nunit&logoColor=white) |
| Moq        | ![Moq Logo](https://img.shields.io/badge/Moq-02569B?style=for-the-badge&logo=moq&logoColor=white) |

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Prerequisites

This is an example of how to list things you need to use the software and how to install them.
* dotnet
  ```sh
  dotnet build --release
  ```

### Installation

_Below is an example of how you can instruct your audience on installing and setting up your app. This template doesn't rely on any external dependencies or services._

1. Request a Pull Request
2. Clone the repo
   ```sh
   git clone https://github.com/your_username_/Project-Name.git](https://github.com/NicoFilips/ByteBrusher/
   ```
3. Restore Nuget packages
   ```sh
   nuget restore
   ```
4. Start the Application
   ```csharp
   dotnet build --release
   ```

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage

I've coded some extension methods to configure your IHost. It also registers Dependency Injection so you can integrate it into your Apps:
    
### Register the DI Services into your App:
```
    private static void Main(string[] args)
    {
        IHost host = DependencyResolver.DependencyResolver.CreateHostBuilder(args).Build();
```
### Get Services from your DI Container:     
```
        CliOptions = host.Services.GetRequiredService<ICliOptions>();
        _byteBrusherClient = host.Services.GetRequiredService<IByteBrusherClient>();
        _logger = host.Services.GetRequiredService<ILogger<Program>>();
```
### Start Brushing your Bytes!
```
        _byteBrusherClient.ExecuteAsync(CliOptions.DeleteFlag, CliOptions.Path);
        _logger.LogInformation("---- < ByteBrusher.CLI finished > ----");
 }
```


<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ROADMAP -->
## Roadmap

- [x] Build Architecture
- [x] Add Dependency Injection
- [x] Add and Handle CLI Arguments
- [x] Add Appsettings with IConfiguration
- [x] Add NLog
- [ ] Use ML.Net to find redundant Documents
    - [ ] Memetemplates
    - [ ] Duplicates

See the [open issues](https://github.com/NicoFilips/ByteBrusher/issues) for a full list of proposed features (and known issues).

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Nico Filips - git@nicofilips.de

### Connect with me:
[![LinkedIn Badge](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/nicofilips/)
[![ProtonMail Badge](https://img.shields.io/badge/ProtonMail-8B89CC?style=for-the-badge&logo=protonmail&logoColor=white)](https://protonmail.com/)

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

* [CommandLineParser]([https://choosealicense.com](https://github.com/commandlineparser/commandline/wiki))
* [NLog](https://nlog-project.org/)
* [Img Shields](https://shields.io)
* [Font Awesome](https://fontawesome.com)
* [React Icons](https://react-icons.github.io/react-icons/search)
* [GitHub Emoji Cheat Sheet](https://www.webpagefx.com/tools/emoji-cheat-sheet)

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->

[CSHARP]: https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white
[.NET-badge]: https://img.shields.io/badge/-.NET%206.0-blueviolet
[.NET-url]: https://dotnet.microsoft.com/
[ASP.NET-Core-badge]: # (Hier könnte der Link zum Badge-Bild für ASP.NET Core eingefügt werden)
[ASP.NET-Core-url]: https://dotnet.microsoft.com/apps/aspnet
[Entity-Framework-Core-badge]: # (Hier könnte der Link zum Badge-Bild für Entity Framework Core eingefügt werden)
[Entity-Framework-Core-url]: https://docs.microsoft.com/en-us/ef/core/
[Polly-badge]: # (Hier könnte der Link zum Badge-Bild für Polly eingefügt werden)
[Polly-url]: https://github.com/App-vNext/Polly
[Serilog-badge]: # (Hier könnte der Link zum Badge-Bild für Serilog eingefügt werden)
[Serilog-url]: https://serilog.net/
[xUnit-badge]: # (Hier könnte der Link zum Badge-Bild für xUnit eingefügt werden)
[xUnit-url]: https://xunit.net/
[Moq-badge]: # (Hier könnte der Link zum Badge-Bild für Moq eingefügt werden)
[Moq-url]: https://github.com/Moq/moq4
[AutoMapper-badge]: # (Hier könnte der Link zum Badge-Bild für AutoMapper eingefügt werden)
[AutoMapper-url]: https://automapper.org/
[contributors-shield]: https://img.shields.io/github/contributors/othneildrew/Best-README-Template.svg?style=for-the-badge
[contributors-url]: https://github.com/NicoFilips/ByteBrusher/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/othneildrew/Best-README-Template.svg?style=for-the-badge
[forks-url]: https://github.com/NicoFilips/ByteBrusher/network/members
[stars-shield]: https://img.shields.io/github/stars/othneildrew/Best-README-Template.svg?style=for-the-badge
[stars-url]: https://github.com/NicoFilips/ByteBrusher/stargazers
[issues-shield]: https://img.shields.io/github/issues/othneildrew/Best-README-Template.svg?style=for-the-badge
[issues-url]: https://github.com/NicoFilips/ByteBrusher/issues
[license-shield]: https://img.shields.io/github/license/othneildrew/Best-README-Template.svg?style=for-the-badge
[license-url]: https://github.com/NicoFilips/ByteBrusher/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/nicofilips
[product-screenshot]: images/screenshot.png
[Next.js]: https://img.shields.io/badge/next.js-000000?style=for-the-badge&logo=nextdotjs&logoColor=white
[Next-url]: https://nextjs.org/
[React.js]: https://img.shields.io/badge/React-20232A?style=for-the-badge&logo=react&logoColor=61DAFB
[React-url]: https://reactjs.org/
[Vue.js]: https://img.shields.io/badge/Vue.js-35495E?style=for-the-badge&logo=vuedotjs&logoColor=4FC08D
[Vue-url]: https://vuejs.org/
[Angular.io]: https://img.shields.io/badge/Angular-DD0031?style=for-the-badge&logo=angular&logoColor=white
[Angular-url]: https://angular.io/
[Svelte.dev]: https://img.shields.io/badge/Svelte-4A4A55?style=for-the-badge&logo=svelte&logoColor=FF3E00
[Svelte-url]: https://svelte.dev/
[Laravel.com]: https://img.shields.io/badge/Laravel-FF2D20?style=for-the-badge&logo=laravel&logoColor=white
[Laravel-url]: https://laravel.com
[Bootstrap.com]: https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white
[Bootstrap-url]: https://getbootstrap.com
[JQuery.com]: https://img.shields.io/badge/jQuery-0769AD?style=for-the-badge&logo=jquery&logoColor=white
[JQuery-url]: https://jquery.com 
