# MarsRoverProject

Mars Rover Movement Simulation Project

This tool will deploy a virtual rover to a rectangular plane and make the rover execute a series of following commands : Turn Right,
Turn Left and Move. Each turn rotates the rover 90 degrees and Move command moves the rover 1 "unit" to the direction it's facing.

# Tutorial

After running the tool, press import button and choose a "initalization file" (in .txt format) which contains information about plane size, rover deployment
orientation and series of commands that the rover will execute consecutively.

After importing the file press process button. The output window will display the final orientation of each rover that is deployed,
(i.e. their coordination and direction they are facing) and Rover Log will display the number of steps that the rover took while
executing the commands. 

# Input File Format

First line of the input file gives Coordinations of the Upper Right Vertex of the Rectangular plane. The lower left vertex is assumed
to be the origin (0, 0). Hence every coordinate in the system is positive. 

Each Rover deployment contains two lines of information. First line is the deployment orientation of the rover and the second line
is the series of Commands that the rover will execute : M, L, R. M will move the rover, L will rotate rover 90 degrees to the left
and R will rotate it to the right. 

input.txt and input2.txt files are provided in the project for test. 
