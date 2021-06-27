# [Game Design Document](https://github.com/Koolkev246/gsmst-Noneuclidean-World/blob/master/POC%20Writeup.pdf)

Kevin Kwan
4/12/2021
Game Design 4th Period

## Summary:

I will be creating a non-euclidian environment thatplayers can interact with, look at, move around in,and
interact with objects in them. The reality of theworld will look warped and defy spatial reality asthe player
plays in a forced perspective where objects are notas they seem. Basically, the world is focused around
convincing optical illusions to confuse the player’sbrain and eyes. For example, a player might walkthrough a
simple doorway, but when they come out of it and lookat the doorway that they came from, they will seethat
they came out of a long hallway instead of a doorway.If they look down the hallway, they will see theprevious
area/world that they came from that the doorway wasin. Another example would be when a player walks
around a wall corner and sees an object, like a ball.However, when the player continues walking and roundsthe
corner again, they will see a different object likea cube, even though the player thinks that nothingin the world
has changed. This game mechanic can be used in gamesinvolving puzzle-solving, horror, mystery, and more.
The following are three features/aspects of the topicthat I attempted to implement.

1. Using smooth portals to help create convincing opticalillusions between multiple worlds to make them
    seem like one world. (player’s view and moving theplayer, basic functionality)
2. Allow the player to bring and interact with objectsin the different “worlds.” (special functionality)
3. Come up with convincing optical optical illusion conceptsby building the worlds and using 3D objects
    (modeling, world design)

## Implementation of the POC:

Unique Implementation Showcase:
Besides using the referenced tutorials I expandedupon the concepts and implementation. For example,
Brackey’s tutorial demonstrated using smooth portalsto display the opposite world between World 1 andWorld
2 while allowing the player to seamlessly “move” betweenthe two worlds by using the portal.


I used the basic functionality of these portals tocreate optical illusion rooms that I made myself.For example,
here is a room where there are two tunnels. On theoutside of one tunnel, it looks like a really shorttunnel that
the player can go through. However, when the playerwalks to the entrance of the tunnel, the tunnel onthe
inside looks way longer. There is actually a portalat the doorway that is showing the inside of theother tunnel.
The player can walk through the portal without knowingit, and walk through the long tunnel. When they exit
and look at the tunnel that they just walked out offrom the outside, the tunnel will still seem short,which is
impossible according to physics and logic. This isa non euclidean world example. The opposite occurs
regarding the long tunnel.


I also implemented a new functionality by using twoportals at one location to display what the playersees from
outside the tunnel looking at the portal and whatthe player sees from inside the tunnel looking atthe portal. It’s
two portals facing away from each other but at thesame location. There are two portals at each of theends of
the portals, for a total of 4 portals per tunnel.This allows the optical illusion to work even whenthe player
enters and exits one of the tunnels.


Another optical illusion/non-euclidean world that I made was the infinite spiral staircase. While on the outside,
the spiral staircase is not infinite, and playersusually expect stairs to go from point A and terminateat point B,
with the use of portals at the top and bottom of thestaircase, However, the player will find that ifthey take these
flight of stairs, they are trapped in an infiniteloop of going up or going down the stairs. The renderplanes of the
portals handle the visual side of the optical illusionand hide the fact that there are portals that aredoing this.
The player unknowingly walks through these portals,teleporting to the opposite portal, and continuetheir
journey.

Another unique implementation of these portals isin another optical illusion/non-euclidean world thatI made. It
involves a staircase tunnel that looks like it’s goingupwards on the outside when the player is on theground
floor.


The vice versa occurs when the player is at the topof the staircase. They would assume that the stairswould go
down, the stairs go up instead.

1. Implementation of Smooth Portals
First, I followed Brackey’s tutorial on how to createsmooth portals in Unity, and then, I expanded fromit.
Smooth portals are visual portals that players canlook through and see the other location while followingtheir
perspective without having to walk through it. Bywalking through the portal, the player seems to smoothly
“enter” another location. Unbeknownst to the player,they actually were teleported to a new location.Smooth
portals are really good for creating optical illusions.In Brackey’s tutorial, smooth portals are used betweentwo
worlds, with one being a mirror of the other one buta different color. The player starts off in one ofthe worlds.
Each world has the identical objects and enclosedenvironments, including portal frames. There are two
cameras, one for each world, which will be used tocapture and display what they see in each world.Inside the
portal frames, there is a render plane with an ordinarymaterial that uses a shader provided by Brackey that
renders a cutout (only the part that the player seesthrough the portal) of what the camera sees in thesecond
world using screen coordinates.


We want the camera in the 2nd world to follow theposition of the player as if they were in the 2ndworld and
render what it sees on the render plane of the portalin the 1st world.


In order to do this, a script is needed to have theportal cameras follow the position of a player inrelation to its
own portal. The script also offsets the rotation ofthe portal cameras to match the player’s camera rotationin
order to keep the player’s perspective as if theywere in the opposite world.

The following script allows the developer to manuallyassign and set up the corresponding cameras and what
they see to their complementary render plane materials.For example, Camera B will correspond to the material
that is displayed on the render plane in World 1,while Camera A will correspond to the material thatis
displayed on the render plane in World 2.


Here is what World 1 looks like through the portalin World 2.

That is the visual aspect of the portal implemented!


Now, regarding the teleportation, an invisible collider exists at each portal at the same location as the render
plane. A script is used to check if the player is overlapping or exiting the collider, check whether or not they
moved across the portal, and teleport the player tothe opposite portal while keeping their directionand rotation
using dot products to get vectors and offset calculations.

Then, since there are public variables, the developercan assign and link up the portals and cameras bysimply
dragging them into the inspector.
Examples include:

2. Implementation of Interactable Objects going throughPortals
Using the same concepts of Portal Teleportation, Imodified the code used to smoothly teleport the playerwhen
they go through portals to include objects as well.


The blocks flawlessly travel through the portal andshow up visually on the render plane well. Theirmovement
is kept as well.


3. Implementation of Optical Illusions using SmoothPortals
Using Brackey’s tutorial world and portals as inspiration,I thought of the common optical illusions that Ihave
seen in other non-euclidean games and tried to mimicthem using the tools available. I created the structureslike
the tunnels and stairs using Unity’s ProBuilder toolto model them. The implementation of the non-euclidean
world concept and optical illusions are discussedearlier in the writeup in the “Unique Implementation”section.

## References:

Brackeys - Smooth PORTALS in Unity:https://www.youtube.com/watch?v=cuQao3hEKfs
CodeParade - Non-Euclidean Worlds Engine:https://www.youtube.com/watch?v=kEB11PQ9Eo
JayCode - Non-Euclidean Game using Unity:https://www.youtube.com/watch?v=rvAhM9ynbSc


