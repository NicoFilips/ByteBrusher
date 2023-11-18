<!-- Improved compatibility of back to top link: See: https://github.com/othneildrew/Best-README-Template/pull/73 -->
<a name="readme-top"></a>
<!--
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Don't forget to give the project a star!
*** Thanks again! Now go create something AMAZING! :D
-->

[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/NicoFilips/ByteBrusher/">
    <img src="https://user-images.githubusercontent.com/35654361/283448124-805ac645-a568-42c4-8a1d-177070e4df59.png" alt="Logo" width="200" height="200">
      Source: AI generated
  </a>

 [![Build](https://github.com/NicoFilips/ByteBrusher/actions/workflows/build.yml/badge.svg)](https://github.com/NicoFilips/ByteBrusher/actions/workflows/build.yml)
 [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=NicoFilips_ByteBrusher&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=NicoFilips_ByteBrusher)
 [![codecov](https://codecov.io/gh/NicoFilips/ByteBrusher/branch/main/graph/badge.svg?token=DR2EBIWK7B)](https://codecov.io/gh/NicoFilips/ByteBrusher)

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
  <summary>Table of Contents</summary>
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
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

[![Product Name Screen Shot][product-screenshot]](https://example.com)

So if you're just a bit like myself you'll come to the conclusion that its not always easy to keep track of your data. Doesn't matter if it's your vacationpictures, memes, documents, bills, videos or whatever to store. Adding and keeping track of additional Backups, makes the whole thing even worse. And your Desktop isn't git, managing all of this without look into future things you did is hard. This time around, I wanted to create an application, that solves made mistakes. This application recognizes duplicates and removes them, if necessary.

Here's why:
* Your time should be focused on creating something amazing. Finding duplicates and unwanted documents, isn't
* You shouldn't be doing the same tasks over and over again
* Keep your desktop tidy and your storage as empty as possible :smile:

Of course, this project may not be perfect and possibly not serve all your needs. So I'll be adding more in the near future. You may also suggest changes by forking this repo and creating a pull request or opening an issue. Thanks to all the people looking into this Repository!

Use the `BLANK_README.md` to get started.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

classDiagram
    title Class-Architecture

    class Program.cs {
        -IScanUtil _scanUtil
        +IFilterUtil _filterUtil
    }

    class ScanUtil {
        +IOptions<ScanUtil> _options
        +ILogger<ScanUtil> _logger
        +ScanUtil(IOptions options, ILogger logger)
        +IEnumerable<string> GetFiles()
    }

    class Animal {
        +main()
    }

    Program.cs <|-- ScanUtil : uses
    Program.cs <|-- FilterUtil : uses
    note right of ScanUtil : From Duck till Zebra
    note right of Animal : can fly\ncan swim\ncan dive\ncan help in debugging

### Built With

This section should list any major frameworks/libraries used to bootstrap your project. Leave any add-ons/plugins for the acknowledgements section. Here are a few examples.

* [![Next][Next.js]][Next-url]
* [![React][React.js]][React-url]
* [![Vue][Vue.js]][Vue-url]
* [![Angular][Angular.io]][Angular-url]
* [![Svelte][Svelte.dev]][Svelte-url]
* [![Laravel][Laravel.com]][Laravel-url]
* [![Bootstrap][Bootstrap.com]][Bootstrap-url]
* [![JQuery][JQuery.com]][JQuery-url]

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

Use this space to show useful examples of how a project can be used. Additional screenshots, code examples and demos work well in this space. You may also link to more resources.

_For more examples, please refer to the [Documentation](https://example.com)_

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ROADMAP -->
## Roadmap

- [x] Build Architecture
- [x] Add Dependency Injection
- [x] Add and Handle CLI Arguments
- [x] Add Appsettings with IConfiguration
- [ ] Add NLog
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

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Your Name - [@your_twitter](https://twitter.com/your_username) - email@example.com

Project Link: [https://github.com/your_username/repo_name]([https://github.com/your_username/repo_name](https://github.com/NicoFilips/ByteBrusher))

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

Use this space to list resources you find helpful and would like to give credit to. I've included a few of my favorites to kick things off!

* [CommandLineParser]([https://choosealicense.com](https://github.com/commandlineparser/commandline/wiki))
* [NLog](https://nlog-project.org/)
* [Img Shields](https://shields.io)
* [Font Awesome](https://fontawesome.com)
* [React Icons](https://react-icons.github.io/react-icons/search)
* [GitHub Emoji Cheat Sheet](https://www.webpagefx.com/tools/emoji-cheat-sheet)

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
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
