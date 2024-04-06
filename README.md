**GitHub Posting Disclaimer: Prototype Code for Demonstrative Purposes**

It is crucial to understand that the code shared herein is intended exclusively for the purpose of demonstrating prototype functionality. This abstract representation contains no sensitive information and does not mirror any software employed in real-world project deployments.


# Vitals Monitoring Program

The Vitals Monitoring Program is a .NET application designed to simulate the monitoring of various vital signs, such as heart rate (HR), blood pressure (systolic and diastolic), body temperature, end-tidal carbon dioxide (EtCO2), respiratory rate (Resp), and oxygen saturation (SpO2). The program generates these vital signs at different intervals, allowing for the simulation of various health profiles.

## Table of Contents

- [Overview](#overview)
- [Installation](#installation)
- [Usage](#usage)
- [Configuration](#configuration)
- [Profiles](#profiles)
- [License](#license)

## Overview

The program uses the Microsoft.Extensions.Hosting library to create a worker service named "Worker" that generates simulated vital signs at different intervals. The vital signs are generated based on different health profiles, such as "elevated blood pressure," "COVID-19," and "stable." The simulated vital signs include heart rate (HR), oxygen saturation (SpO2), systolic and diastolic blood pressure (Sys and Dia), body temperature (Temp), end-tidal carbon dioxide (EtCO2), and respiratory rate (Resp).

## Installation

To run the Vitals Monitoring Program, follow these steps:

1. Make sure you have the .NET SDK installed on your system.
2. Clone or download this repository to your local machine.
3. Open a terminal and navigate to the project's root directory.
4. Run the following command to build and run the program:

```shell
dotnet run
```

## Usage

The program will start generating simulated vital signs based on the configured intervals. It will display logs with the generated vital signs for each interval. The program will continue running until you manually stop it using `Ctrl+C` in the terminal.

## Configuration

The program uses the `appsettings.json` file to configure the interval timings for generating vital signs. You can modify the following parameters in the `appsettings.json` file:

- `VitalShortIntervalSeconds`: The interval in seconds for generating short-interval vital signs.
- `VitalIntermediateIntervalSeconds`: The interval in seconds for generating intermediate-interval vital signs.
- `VitalLongIntervalSeconds`: The interval in seconds for generating long-interval vital signs.

## Profiles

The program simulates different health profiles by adjusting the vital signs based on the selected profile. There are three profiles available:

1. **Elevated Blood Pressure (Profile 1)**:
   - Elevated heart rate (HR).
   - Elevated systolic blood pressure (Sys).
   - Normal diastolic blood pressure (Dia).
   - Normal oxygen saturation (SpO2).
   - Normal end-tidal carbon dioxide (EtCO2).
   - Elevated respiratory rate (Resp).
   - Normal body temperature (Temp).

2. **COVID-19 (Profile 2)**:
   - Elevated heart rate (HR).
   - Lower oxygen saturation (SpO2).
   - Elevated systolic blood pressure (Sys).
   - Lower diastolic blood pressure (Dia).
   - Normal end-tidal carbon dioxide (EtCO2).
   - Elevated respiratory rate (Resp).
   - Elevated body temperature (Temp).

3. **Stable (Default Profile)**:
   - Normal heart rate (HR).
   - Normal oxygen saturation (SpO2).
   - Normal systolic and diastolic blood pressure (Sys and Dia).
   - Normal end-tidal carbon dioxide (EtCO2).
   - Normal respiratory rate (Resp).
   - Normal body temperature (Temp).

You can choose the desired profile by setting the `Profile` property in the `Worker` class.

## License

This program is distributed under the [MIT License](LICENSE). Feel free to use, modify, and distribute it according to the terms of the license.
