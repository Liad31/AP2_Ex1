# Advanced Programing 2 Exercise 1
In this exercise we made a flight inspection app.
Using the app you can load a csv files holding your flight info. The app will show you data about the app (more details ahead), and project the flight on the Flight Gear simulator. Also, the app uses an algorithm (that the user can load) in order to detect anomalies and notify the user about them.

## Usage And Features
(need to add here details about features)

## Files And Directories

## Development
(need to add here versions, framwork, etc)

## Installation and Running

## Design
The main architecture we use in the project is the MVVM architecture.
In the MainWindow we create the FlightModel, the ControlBarViewModel and the SteeringViewModel. The MW also creates and holds references to our views, such as the Stick, SpeedClock and ControlBarView. The MW sets the VM's Model property (which they have) to the FlightModel it created, and then sets the VMs to be the views' data context (The SteeringViewModel is the VM of the Stick and SpeedClock, the ControlBarViewModel is the VM of the ControlBarView). Also, there is a 2-way binding for the views and VMs. After everything is set, the MW commands the model to start his operation.
Now the model reads the csv file line by line (actually he reads it from the DataBase class, which saved the csv file in our memory).
The Model sends the data to the Flight Gear using the Client class, and also changed its preporties that holds info like the time of the fligh we are in, flight speed, etc. The Model implements the INotifyPropertyChanged interface, and notifies all the VMs, which also implement this interface, and notifiy the views. This causes the User to see the changing data on the screen on real time - the flight speed, height, it changed to slider to be on the right relative place and more.
Now, the User can use the ControlBar GUI to move to another point in time (using the slide bar) or change the video's speed. This actions will cause changes to the view's properties (slide bar value/video speed), which are binded to matching properties in the VM. So when a property in the ControlBarView changes, it changes in the VM, which commands the model to change its matching properties accordingly. Now the Model will read the data in a different speed, or from another point, and notify the VMs accordingly.
These things 

## Video
