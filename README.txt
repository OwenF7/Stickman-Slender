Parts I had trouble with: 

Add One Point to the 0 out of 5. 
	Initially, I had in each script to add 1 to the current coins collected, and it wouldn't go past 1. 
	I think the issue was that it wasn't a collective total with the coins score being added. Different variables? 

	I fixed it by creating a separate counter gameobject, and whenever the score increased by 1, the counter gameobject
	would be refferenced. 

Creating the walk loop with more than three animations. 
	At first, I did very similarly to what we did in class to create the walk loop. But, when I did it, it never changed. 
	I had tried to change the delay timer, but that didn't change anything. 

	I eventually realized after doing so research that it was because my usage of the if, else if, else functions were
	wrong. I fixed it by making the first walk image an if statement. Then the rest else if statements, and the last 
	an else statement. 

I had a ton of trouble trying to figure out how to change colliders to separate the walk cycle and the jump since they are 
too different to keep the same collider. 
	At first, I tried to see if I could alter the box collider, but found that it isn't very easy to do, and even harder
	to make it go back to normal. 
	I then tried to just add another box collider Stickman, but realized that there was no way to distinguish between the
	two. At least I couldn't find any ways to do so. 

	In the end, I created an empty game object that is a child to Stickman, and added a box collider to it. I then wrote
	a script turning on and off the two colliders whenever the Stickman is jumping. This way they would alternate.

I suppose this had less to do with coding, but I had a difficult time figuring out the slanted grounds, as when I rotated 
them, they would be 'weird.' As if they were rotating 3D instead of 2D. 
	I eventually figured out that it was something to do with being a child under the empty game object 'Grounds Grouping'
	and so when I did it again, not children of any grouping, they rotated as intended. 

Had trouble with Audio sources with regards to oncollisionenter2D vs ontriggerenter2D 
	I just kept getting them mixed up! 

2D Nav Mesh is ridiculously more complicated than 3D. Tis unfortunate. 


Parts I think could be better: 

Probably in general less redundancy. I think there are a few places I probably don't need code at. 

I also think that there is probably a way to just make there be one script for each coin. I had trouble when going that 
direction initially when I was changing the background colors. As I continue to develop this for the Final, that is certainly
something I will look back into. 

Camera work. BIG TIME. 
	 

Things to add/do next time: 

Animate coins further. Animate Minotaur. 

Make camera smoother. Character feels and looks very rickety. Not sure what the problem is there at the moment. 

2D Nav Mesh. Too complicated for such little time. So basically add in the minotaur unfortunately. 

Add Main Menu and Game over Screens. 

Add High Score Feature. 


References and Code: 

	UI Timer: https://www.gamedev.net/forums/topic/702432-unity-how-to-make-a-ui-timer-beginners-guide-c-script/ 

	Camera Work: https://generalistprogrammer.com/unity/unity-2d-how-to-make-camera-follow-player/ 

	Coin Spin reference: From class Mario Coin Spin 

	Reference for Stickman movements: Largely from Mario walk class activity 

	A lot of the other things I did for this project I learned in the Game Development 1 class, and used some old code
	for reference from that class. 

	