# Remote desktop for signal generator and power supply: R&amp;S SMB100A and Agilent N5746A
[![Build Status](https://travis-ci.org/shamrik-dmitriy/remote-desktop-signal-generator-and-power-supply.svg?branch=master)](https://travis-ci.org/shamrik-dmitriy/remote-desktop-signal-generator-and-power-supply)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)


Remote software with power supply (Agilent N5746A) and signal generator (R&S SMB100A).

The structure of the repository branches is as follows:
1. Branches starting with ioc-<text> refer to a branch feature/ioc in which the project in which the technology is applied IoC-Container (LightInject). 
2. Branches in which there is no word ioc belong to the master branch in which the project is located without using IoC-Container

Also, a common code for the first and second branches is placed in the master branch, for example, a code for interacting with devices.
