# Advanced Programing 2 Exercise 1
In this exercise we made a flight inspection app.
Using the app you can load a csv files holding your flight info. The app will show you data about the flight (more details in [Usage And Features](#Usage-And-Features)), and project the flight on the Flight Gear simulator. Also, the app uses an algorithm (that the user can load) in order to detect anomalies and notify the user about them.

## Usage And Features
In the first window, you will be required to insert a path to the flight's properties file. You do it by typing in the text box, or by clicking the button, and then using the open file dialog that opens. It is optional to insert locations to a FG executable, and for a dll of anomaly detection algorithm. If the path entered for the FG executable is valid, the app will open with the FG, and if not, it will open without it.
**Note:** The paths you enter are saved from run to run, so you don't have to re enter them.
The user can open the FG by himself with the correct settings (as described in the [Installation and Running](#installation-and-running) section, and the app will connect to its server start project the flight. If the FG is closed, the app will still work and show data through time, like: height, speed, direction, yaw, roll, pitch, and the joystick's state. Nevertheless, the user can choose one of the flight's properties, and then 3 graphs will appear:
1. Graph of the value of the chosen property through time, from the start of the flight until this point.
2. Graph of the value of the most colerative property to the chosen property through time, from the start of the flight until this point.
3. Graph of the linear regression between the 2 properties mentioned above, with the actual points from the last 30 seconds (relative to the current time) of the flight marked in red (points from before that are colored gray).
In order to close the app, just click the exit button.
**//Need the add about plugins and anomaly detection**

#### Special Features ####
1. The app can open FG using a given path
2. When using an anomaly detector and choosing property to search, red dots will appear above the video slider at the points there are anomalies, and when clicked the video will move to that point
3. The paths entered in the starting window are saved
4. You can open FG while the app is running, close it and reopen it, and the projection should work

## Files And Directories
(??????)

## Development
This app was developed on .Net Framwork 4.7.2.  
**Tools we used:**  
1. Visual Studio 2019+
2. ScottPlot package (The dll files are in the project in the refrences directory, so no special installation needed)

## Installation and Running
#### Installation
Clone this git repository into a directory in your computer.  
**About FG:** If you want to use FG, you should install it, and put the "playback_small.xml" from the moodle in the folder "/data/protocols", inside the folder you installed FG in.
#### Running
If you want to run FG manually, you should to it with the next settings:
```
--generic=socket,in,10,127.0.0.1,5400,tcp,playback_small
--fdm=null
```
Use an IDE which supports .Net Framwork to open the project from the directory you cloned it into earlier. Now from your IDE, run the app.  
(Note: you can run the app without the IDE if you have its exe and required dll files in the same directory)  
Once you run the app, you can use it as described in the [Usage And Features](#usage-and-features)

## Design
You can see here our UML diagram: (add link)
#### Model, VMs and Views (MVVM)
The main architecture we use in the project is the MVVM architecture.
In the MainWindow we create the FlightModel, the ControlBarViewModel and the SteeringViewModel. The MW also creates and holds references to our views, such as the Stick, SpeedClock and ControlBarView. The MW sets the VM's Model property (which they have) to the FlightModel it created, and then sets the VMs to be the views' data context (The SteeringViewModel is the VM of the Stick and SpeedClock, the ControlBarViewModel is the VM of the ControlBarView). Also, there is a 2-way binding for the views and VMs. After everything is set, the MW commands the model to start his operation.
Now the model reads the csv file line by line (actually he reads it from the DataBase class, which saved the csv file in our memory).
The Model sends the data to the Flight Gear using the Client class, and also changed its preporties that holds info like the time of the flight we are in, flight speed, etc. The Model implements the INotifyPropertyChanged interface, and notifies all the VMs, which also implement this interface, and notifiy the views. This causes the User to see the changing data on the screen on real time - the flight speed, height, it changed to slider to be on the right relative place and more.
Now, the User can use the ControlBar GUI to move to another point in time (using the slide bar) or change the video's speed. This actions will cause changes to the view's properties (slide bar value/video speed), which are binded to matching properties in the VM. So when a property in the ControlBarView changes, it changes in the VM, which commands the model to change its matching properties accordingly. Now the Model will read the data in a different speed, or from another point, and notify the VMs accordingly.

#### Data Flow
The data flow works using the MVVM. As described above, every property in the Model has a matching property in a VM and a View, when the property changed in the Model, it notifies the VM, which notifies about the change to the View, thanks to the binding between the View's and VM's properties. Now the View will request the VM to give him the new value, and he will give it using the Model (The VM behaves as a pipe). Data flows from the View to the Model as well. The user can change the View and it's Values, this causes change to the binded propery in the VM, and it will command the Model to change its propery as well. 

#### Graphs
In order to draw the graphs we used the ScotPlot package. We tried to use MVVM here, but we couldn't do it perfectly, because we can't do data binding to the plot's values (the plot is the view which shows the graphs). We do have a VM and a Model for the graphs. The model does most of the calculation at the start of the program's run (which propery it most corelative it which), and has properties like the values we want to show in each graph at the moment, and the current line (which is updated when the main Model's current line property changes). The logic of showing the graphs takes place in the MainWindow, but to logic of what is the data we will show, is handled in the Model. When the MainWindow gets notified by the GraphsModel that the line number has changed, it ask the VM (which asks the Model) for the data he should show in the graphs, and then it shows it. If the User uses the GUI to request to show the graph of another flight property, the MainWindow will command the graph's VM to change the data according to the new property we need to show, which will command the the Model to change it (The MainWindow only says what property, the Model will give him all the points of the graph), so now each moment, when the MainWindow commands the VM to give him the data, it will be according to the new property.

#### Plugins
## Video
(add link to video)
