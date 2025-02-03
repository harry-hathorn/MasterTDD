Mars Rover
You’re part of the team that explores Mars by sending remotely controlled vehicles to the planet's surface. Develop an API that translates the commands sent from Earth to instructions that are understood by the rover.

Requirements
You are given the rover's initial starting point (x,y) and the direction (N,S,E,W) it faces.
The Map is a 20x10 (x,y) grid
The rover receives a character array of commands.
Implement commands that move the rover forward/backward (f,b).
Implement commands that turn the rover left/right (l,r).
Implement wrapping at edges. But be careful, planets are spheres
Examples
Starting position: N, 0,0
Command: "f"
Resulting position N,0,1

Starting position: W, 0,0
Command: "lf"
Resulting position S,0,10