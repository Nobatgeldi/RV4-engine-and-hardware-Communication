# Communication between Real Virtuality 4 engine and hardware
I develop it for Arma 3 game and for our 2 axis 720 degree simulator system(full rotation system with VR glass, synchronized gyroscope)

# How it works
Using callExtension command of RV4 engine, SQF script call DLL extension with angle of 3 axis of any vehicle. So dll sends this angles to hardware via ethernet(Bekchoff EtherCAT).

# Hardware
1. Beckhof AM8052 servo motor
2. Beckhoff Servo Driver
3. Beckhoff CX9020 PLC

