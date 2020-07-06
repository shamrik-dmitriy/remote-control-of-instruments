# Remote desktop for signal generator and power supply.
[![Build Status](https://travis-ci.org/shamrik-dmitriy/remote-desktop-signal-generator-and-power-supply.svg?branch=master)](https://travis-ci.org/shamrik-dmitriy/remote-desktop-signal-generator-and-power-supply)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)


Remote control software for power supply and signal generator.
This software is suitable for devices that support the folowing standard commands for programmable instruments (SCPI):

**Source Signal:**

_Commands of parameters of the set signal_
* _:FREQ {value} {type};_ - Set frequencies in dimension <type>: Hz, MHz, KHz, GHz;
* _:POW {value} {type};_ - Set pow level in dimension <type>: dBm, DBuV, Nv, Uv, Mv, V;
* _:PULM:WIDT {value} {type};_  - Set pulse width in dimension <type>: s, Ns, Ms, Us;
* _:PULM:DEL {value} {type};_ - Set pulse delay in dimension <type>: s, Ns, Ms, Us;
* _:PULM:PER {value} {type};_ - Set pulse period in dimension <type>: s, Ns, Ms, Us.
  
_Source control commands:_
* _:OUTPUT:STAT {ON|OFF};_ - RF-output state control;
* _:SOUR:MOD:ALL:STAT {ON|OFF};_ - Modulation state control;
* _*RST;_ - Reset settings to default.

**PowerSupply:**

_Сommands for setting and received power supply parameters:_
* _:VOLT {value};_ - Set voltage value;
* _:MEAS:CURR?;_ - Get currnet value.

>All the commands described above also support the status request, therefore, all commands have analogues with the request
