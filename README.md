# Advanced Programing 2 Exercise 1
In this exercise we made a flight inspection app.
Using the app you can load a csv files holding your flight info. The app will show you data about the app (more details ahead), and project the flight on the Flight Gear simulator. Also, the app uses an algorithm (that the user can load) in order to detect anomalies and notify the user about them.
## Usage


## Design
The main architecture we use in the project is the MVVM architecture. In the MainWindow we create the FlightModel, the ControlBarViewModel and the SteeringViewModel. The MW also creates and holds refernces to our views.  
