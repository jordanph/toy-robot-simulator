# toy-robot-simulator
Description
-----------
A simulation of a toy robot moving on a table top with dimensions of 5 x 5. There are no other obstructions on the table surface which means that the robot is free to move around. However, the robot is not allowed to fall off the table and this is prevented from happening in the application (subsequent valid movements are still allowed).

The contstraints of the 5x5 table can be changed by modifying the constant values BoardWidth and BoardHeight in ToyRobotSimulator/Program.cs.  

Installation
-----------
This guide assumes that dotnet is already installed on your system.

    git clone https://github.com/jordanph/toy-robot-simulator.git
    cd toy-robot-simulator
    dotnet build

Usage
-----------
To run the application from the base folder use the below command.

    $ dotnet run --project ToyRobotSimulator
    
You can also choose an input file to be read into the application.

    $ dotnet run --project ToyRobotSimulator < your_input_file.txt

Valid Commands
--------------

The valid commands for the program are as follows:

### PLACE X,Y,DIRECTION

Places the toy robot on the table at the specified X and Y coordinates facing the NORTH, EAST, SOUTH or WEST direction. If the robot is already placed on the table, issuing another PLACE command will move the robot to the new position. 

**Note:** The other robot actions of MOVE, LEFT, RIGHT and REPORT cannot be ran until the robot has been placed on the table.

### MOVE

Moves the robot forward in the direction it is facing by one unit. If the robot is at the edge of the table, the move command will not work as it would cause the robot to fall off the table.

### LEFT

Rotates the robot 90 degrees to the left.

### RIGHT

Rotates the robot 90 degrees to the right.

### REPORT

Displays the current position of the robot: X-Position,Y-Position,Direction eg. 1,1,EAST.

### HELP

Displays the help options for the various commands of the application.

### EXIT

Exits the application.

Example Input and Output
-----------

### Example a: Regular Run
Input:

    PLACE 1,1,EAST
    REPORT
    EXIT
    
Output:

    1,1,EAST
    
### Example b: User Attempts to Place off Table
Input:

    PLACE 5,5,EAST
    PLACE 0,5,EAST
    PLACE 5,0,EAST
    PLACE 0,0,EAST
    REPORT
    EXIT
    
Output:

    Position is off the board. Please ensure the xPosition is between 0 and 4, and the yPosition is between 0 and 4.
    Position is off the board. Please ensure the xPosition is between 0 and 4, and the yPosition is between 0 and 4.
    Position is off the board. Please ensure the xPosition is between 0 and 4, and the yPosition is between 0 and 4.
    0,0,EAST

### Example c: User Attempts to Move Robot off Table
Input:

    PLACE 0,0,EAST
    MOVE
    MOVE
    MOVE
    MOVE
    MOVE
    REPORT

Output:

    Cannot move robot from the position 4,0 in the direction EAST as position is off the table
    4,0,EAST

Tests
-----------
Use the following command to run the tests for the project.

    $ dotnet test ToyRobotSimulator.Tests
    
This will run all the unit tests, as well as run the test files that are currently in the ToyRobotSimulator.Tests/TestInputFiles. You can add more tests yourself by adding your test file into the ToyRobotSimulator.Tests/TestInputFiles folder and the expected result in the ToyRobotSimulator.Tests/TestInputFiles/Results folder.

Copyright
---------

All code is freely available under the [MIT License](LICENSE).
