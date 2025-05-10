# ecoflow-api-dotnet

Integrate your Ecoflow devices with .NET Core! 

This repository provides a C# class library and tools to connect to the Ecoflow API, fetch data, and store it in a database. 

A user-friendly web dashboard built with Html or React allows you to access and view your Solar input data.

## Credits

This project was inspired by and based on the [ecoflow-api Java repository](https://github.com/tess1o/ecoflow-api). Special thanks to the contributors of that project for providing a foundation for this implementation in .NET Core.

# Updates
10th May 2025 - 
4th May 2025 - Initial commit, React dashboard coming shortly, alongside more generic and reusable C# code to support broader use cases.

## Features

- **Ecoflow API Integration**: Seamlessly connect to Ecoflow devices to fetch real-time data.
- **Data Storage**: Store fetched data in a database for historical analysis.
- **Web Dashboard**: Provided Html and React-based dashboard examples to visualise solar input and other device metrics.
- **Extensibility**: Built with modularity in mind, making it easy to extend and customise.

## Getting Started

### Prerequisites

- Ecoflow API credentials (Register on https://developer.ecoflow.com - this can take 5 working days or more)
- .NET Core SDK (i would recommend version 8.0 or later)
- Node.js and npm (for the Html or React dashboard)
- A database (e.g.,SQL Server, PostgreSQL, MySQL, or SQLite)

### Folder Structure
EcoflowDataCollector (.NET Console App): 
This application retrieves data from the Ecoflow API and saves it to a database. It uses appsettings.json for configuration, including database connection details and API keys.

EcoflowFrontend (Html or React Frontend & .NET Web API): 
This project demonstrates how to expose the collected data via a .NET Web API and provides a page to visualise the solar data.

EcoflowShared (.NET Core Class Library): 
This library contains shared functions and methods for interacting with the Ecoflow API, and it's designed for use by both the backend and frontend projects.

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/GoliathDeveloper/ecoflow-api-dotnet.git
   cd ecoflow-api-dotnet
   ```

2. Restore:
   - Navigate to the project root directory.
   - Restore dependencies:
     ```bash
     dotnet restore
     ```

   - Configure the database connection string, AccessKey and SecretKey in `appsettings.json`.

3. Database:
   - Update EcoflowPostgreDbContext in the Ecoflow Shared project with your connection string.

4. Run the solutions:
   - Start the Data Collector or Frontend by navigating to their directories:
     ```bash
     dotnet run
     ```
or 
   - Use the tasks.json or launch.json 

### Usage

- To begin data collection, run the EcoflowDataCollector. This will connect to the Ecoflow API and save the retrieved information to your database.

- The web dashboard can be accessed by navigating to http://localhost:5001 in your web browser. Alternatively, you can view the API documentation using Swagger at http://localhost:5001/swagger/index.html.

- Once the dashboard is running, you can use it to observe real-time solar input data.

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new branch for your feature or bugfix:
   ```bash
   git checkout -b feature-name
   ```
3. Commit your changes and push the branch:
   ```bash
   git commit -m "Description of changes"
   git push origin feature-name
   ```
4. Open a pull request.

## License

This project is dual-licensed to foster both open collaboration and sustainable development:

- **Open Source (MIT License)**: The [MIT License](LICENSE) governs the use of this library for open-source projects and non-commercial purposes. You are welcome to contribute, adapt, and share this code under the terms of the MIT License.
- **Commercial Use Requires Licensing**: This code is provided for free use in open-source and non-commercial projects. Commercial use by any organisation,company or individual, whether in products, solutions, internal operations, or commercial R&D, requires a commercial license. Please contact me for licensing inquiries or to purchase specific rights.

## Contact

For questions, issues, or licensing inquiries, please contact me via github.

