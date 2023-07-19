# ASP.NET Webhook

Project Description: This C# ASP.NET MVC project serves as a webhook, designed to receive incoming payloads in JSON format from an online data stream. The application exposes an endpoint that processes these payloads, parsing them into JSON objects, and then writes the data into a specified database table.

## Table of Contents

- [Introduction](#introduction)
- [Installation](#installation)
- [Usage](#usage)
- [Webhook Endpoint](#webhook-endpoint)
- [Authentication](#authentication)
- [Contributing](#contributing)
- [License](#license)

## Introduction

The main focus of this project is to act as a webhook, accepting JSON payloads sent from an external data source. These payloads are received at a designated endpoint and processed within the application. The payload data is parsed into JSON objects, allowing for easy handling and extraction of relevant information.

## Installation

1. Clone the repository to your local machine.
2. Open the solution in Visual Studio.
3. Restore NuGet packages if necessary.
4. Build the solution.

## Usage

The application functions as a webhook and is designed to receive incoming JSON payloads. Once the project is set up and running, you can send POST requests to the webhook endpoint with the JSON payloads, which will then be processed and stored in the database.

## Webhook Endpoint

The webhook endpoint is set to `/webhook/receive`. When a POST request is sent to this endpoint with the JSON payload, the application will process the data and store it in the database.

### Payload Format

The webhook expects the payload to be in JSON format, containing an array of data objects. Each data object should have the following attributes:

- `PayloadID` (integer): Replace this with the identifier for the payload.
- `WebhookPayloadList` (array): Replace this with an array of objects, each representing the attributes of the payload.

Each `WebhookPayloadList` object should contain the following attributes:

- `PayloadAttribute1` (string): Replace this with a description of the attribute.
- `PayloadAttribute2` (integer): Replace this with a numeric value associated with the attribute.

## Authentication

To ensure secure access to the webhook endpoint, an API key must be provided in the request header with the key "Api-Key". Before deploying your application, replace the sample API key "1111" with your own secret key. The application will check the provided API key against the key you specify. Requests without a valid API key will be rejected.

## Contributing

Contributions to this project are welcome. If you find any issues or want to suggest improvements, please feel free to create a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
