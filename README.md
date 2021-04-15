# Advanced Programing 2 Exercise 1
In this exercise we coded a flight inspection app.
Using the app you can load a csv files representing your flight. The app will show you data about the flight (more details in [Usage And Features](#Usage-And-Features)), and project the flight on the Flight Gear simulator. the app uses can also use anomaly detection algorithms (that the user can load) in order to detect anomalies and notify the user about them.

## Usage And Features
In the first window, you will be prompted to insert a path to the flight's properties file. You do it by typing in the text box, or by clicking the button, and then picking a file in the dialog that opens. It is optional to insert locations to a FG executable, and a training data set for anomaly detection algorithms. The app may also operate without Flight gear open.
**Note:** Your settings persist between runs, and so, there's no need to manually enter them again.  
The user can manually open Flight Gear with the correct settings (refer to [Installation and Running section](#installation-and-running) ), and the app will project the flight onto it.  
Upn opening the app itself the user can choose one of the flight's parameters to view those 3 graphs:

1. a graph of the value of the chosen parameter through time, from the start of the flight until this point.
2. a graph of the value of the most corelative parameter of the chosen parameter through time, from the start of the flight until this point.
3. a graph of a linear regression between the 2 properties mentioned above, with the points from the last 30 seconds (relative to the current time) of the flight marked in red (points from before that are colored gray).  
A fourth graph of the anomaly detection algorithm's output may appear once an algorithm is chosen.
In order to close the app, just click the exit button
   
After leaving the first window you can press the "Open" button to pick a anomaly detection DLL for the app to use (given you have picked a training flight file), those DLLs can be replaced in runtime. you can also create you own DLL and use it in the application.
see [the Plugins section](#Plugins)
#### Special Features ####
1. The app can open FG using a given path
2. When using an anomaly detector and choosing property to search, red dots will appear above the video slider at the points there are anomalies, and when clicked the video will move to that point
3. Settings are preserved between runs. 
4. You can open FG while the app is running, close it and reopen it, and the projection should work.

## Files And Directories
#### Directories
There are 3 main Directories in the project:  
1. controls: There are all the user controls we made
2. References: There are the dll files we used (such as scottPlot)
3. Main Directory: There are the other directories, and the src code files 
#### Files
The main files are the src code files, like the FlightModel.cs, MainWindow.cs, their xaml files, and dll files (like scottPlot)

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
(Note: you can run the app without the IDE if you have its .exe and required dll files in the same directory)  
Once you run the app, you can use it as described in the [Usage And Features](#usage-and-features)

## Design
You can see here our [UML diagram](https://online.visual-paradigm.com/community/share/ap2-ex1-vpd-ip9ad2inn)
#### Model, VMs and Views (MVVM)
The main architecture we use in the project is the MVVM architecture.
In the MainWindow we create the FlightModel, the ControlBarViewModel and the SteeringViewModel. The MW also creates and holds references to our views, such as the Joystick, SpeedClock and ControlBarView. The MW sets the VM's Model property (which they have) to the FlightModel it created, and then sets the VMs to be the views' data context (The SteeringViewModel is the VM of the Stick and SpeedClock, the ControlBarViewModel is the VM of the ControlBarView). there is also a 2-way binding for the views and VMs. After everything is set, the MW tells the model to start his operation.
Now the model reads the csv file line by line (to be precise he reads it from the DataBase class, which saved the csv file in our memory in order to reduce lag).  
The Model sends the data to Flight Gear using the Client class, and also changed its properties that holds info such as the time that passed in the flight, flight speed, etc. The Model implements the INotifyPropertyChanged interface, and notifies all the VMs, which also implement this interface, and notifiy the views. This causes the User to see the changing data on the screen on real time - the flight speed, height, it changed to slider to be on the right relative place and more.
Now, the User can use the ControlBar GUI to move to another point in time (using the slide bar) or change the video's speed. Those actions will cause changes to the view's properties (slide bar value/video speed), which are binded to matching properties in the VM. So when a property in the ControlBarView changes, it changes in the VM, which in turn tells the model to change its matching properties accordingly.   
As a result, when the model reads the data in a different speed, or from another point, it can notify the VMs accordingly and the app can continue running like normal.

#### Data Flow
The data flow works using the MVVM structural pattern. As described above, every property in the Model has a matching property in a VM and a View, when the property changed in the Model, it notifies the VM, which notifies about the change to the View, thanks to the binding between the View's and VM's properties. Now the View will request the VM to give him the new value, and he will give it using the Model (The VM behaves as a pipe). Data flows from the View to the Model as well. The user can change the View and it's Values, this causes a change in the binded propery in the VM, and it will tell the Model to change its property as well. 

#### Graphs
In order to draw the graphs we used the ScottPlot package. We tried to use MVVM here, but we couldn't do it perfectly since we can't bind the plot's values (the plot is the view which shows the graphs). We do have a VM and a Model for the graphs. The model does most of the calculation at the start of the program's run (finding which parameters are correlative to each other), and has properties like the values we want to show in each graph at the moment, and the current line (which is updated when the main Model's current line property changes). The logic of showing the graphs takes place in the MainWindow, but to logic of what is the data we will show, is handled in the Model. When the MainWindow gets notified by the GraphsModel that the line number has changed, it ask the VM (which asks the Model) for the data he should show in the graphs, and then it shows it. If the User uses the GUI to request to show the graph of another flight property, the MainWindow will command the graph's VM to change the data according to the new property we need to show, which will command the the Model to change it (The MainWindow only says what property, the Model will give him all the points of the graph), so now each moment, when the MainWindow asks the VM to give him the data, it will be according to the new property.

#### Plugins
In order to allow for easy extension for our app, our Anomaly Detection algorithms are implemented as DLLs that can be loaded by the application at runtime. A user can also create his own algorithm and load it in the app.  
In order for the custom made DLL to work it needs to do a couple of things:
1. have a WPF user control called AnomalyDetector, this user control needs to be in the namespace controls.
2. AnomalyDetector should also have a constructor accepting 2 strings, the learning file path and the anomaly detection file path (in that order).
3. Have a property called PropertyName, this Property tells the DLL which parameter the user is investigating right now.
4. Have a method called getAnomalies that returns a list of longs, those longs are the timestamps for anomalies.

In order to load such plugins at run time we used the ```Assembly.Load``` and ```Activator.CreateInstance``` methods that load an external assembly and create an instance from an external DLL respectively.
In order to create our DLLs we used an unmanaged c++ Anomaly detection code that we created in the previous semester. 
In order to use that unmanaged c++ code in a C# code we wrapped it in managed c++ classes that can compile with .NET application.  
finally we created a WPF user control library (a user control that compiles to a DLL) and used the previous managed c++ code in it.
## Video
https://drive.google.com/file/d/1Bug-XTDpK8xEI3HNDZC4NhSzgk__O3FH/view?usp=sharing
