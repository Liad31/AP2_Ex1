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
#### Model, VMs and Views
The main architecture we use in the project is the MVVM architecture.
In the MainWindow we create the FlightModel, the ControlBarViewModel and the SteeringViewModel. The MW also creates and holds references to our views, such as the Stick, SpeedClock and ControlBarView. The MW sets the VM's Model property (which they have) to the FlightModel it created, and then sets the VMs to be the views' data context (The SteeringViewModel is the VM of the Stick and SpeedClock, the ControlBarViewModel is the VM of the ControlBarView). Also, there is a 2-way binding for the views and VMs. After everything is set, the MW commands the model to start his operation.
Now the model reads the csv file line by line (actually he reads it from the DataBase class, which saved the csv file in our memory).
The Model sends the data to the Flight Gear using the Client class, and also changed its preporties that holds info like the time of the flight we are in, flight speed, etc. The Model implements the INotifyPropertyChanged interface, and notifies all the VMs, which also implement this interface, and notifiy the views. This causes the User to see the changing data on the screen on real time - the flight speed, height, it changed to slider to be on the right relative place and more.
Now, the User can use the ControlBar GUI to move to another point in time (using the slide bar) or change the video's speed. This actions will cause changes to the view's properties (slide bar value/video speed), which are binded to matching properties in the VM. So when a property in the ControlBarView changes, it changes in the VM, which commands the model to change its matching properties accordingly. Now the Model will read the data in a different speed, or from another point, and notify the VMs accordingly.

#### Data Flow
The data flow works using the MVVM. As described above, every property in the Model has a matching property in a VM and a View, when the property changed in the Model, it notifies the VM, which notifies about the change to the View, thanks to the binding between the View's and VM's properties. Now the View will request the VM to give him the new value, and he will give it using the Model (The VM behaves as a pipe). Data flows from the View to the Model as well. The user can change the View and it's Values, this causes change to the binded propery in the VM, and it will command the Model to change its propery as well. 

#### Graphs
In order to draw the graphs we used the ScotPlot package. We tried to use MVVM here, but we couldn't do it perfectly, because we can't do data binding to the plot's values (the plot is the view which shows the graphs). We do have a VM and a Model for the graphs. The model does most of the calculation at the start of the program's run (which propery it most corelative it which), and has properties like the values we want to show in each graph at the moment. The logic of showing the graphs takes place in the MainWindow, but to logic of what is the data we will show, is handled in the Model. //NEED TO ADD HERE If the User uses the GUI to request to show the graph of another flight property, the MainWindow will command the graph's VM to change the graphs according to the new property we need to show, which will command the the Model.
## Video
