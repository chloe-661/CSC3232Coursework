# CSC3232
Newcastle University - 2021/22 - 3rd Year

DO NOT COPY!! - This work is shit and I got crap marks for it. 

	GAMING TECHNOLGIES AND SIMULATIONS MODULE
	
	Build a video game in Unity to utilise the physics engine - See brief in the repository
	
	Coursework 1 Submitted: 12/11/2021
	Coursework 2 Submitted: 20/12/2021

Marks and Feedback

	COURSEWORK 1
	
	Description: This was a 2d platform game, unfinished
	Marks: 32/50
	Feedback:     
	    A somewhat basic 2D platformer with some good ideas behind it. 
	    
	    There's rigid bodies with different mass values in the game, but these are somewhat limited in their ability to be integrated by the physics engine by having some direct manipulations of physics and velocity. 
	    
	    The collision volumes used are appropriate to the gameplay presented. Controlling colliders via scripts would allow you to match collisions to specific in-game events, or disable colliders during specific animations etc. 
	    
	    Multiple colliders on an object would allow for a more tightly fitting overall collision volume. 
	    
	    The collision resolution mechanisms of the engine have been used appropriately. Some different physics material types (either always in the map, or temporarily switched via powerups etc) would make for some more interesting gameplay. 
	    
	    There's some AI present on the baddies, although the result does seem that they just throw themselves in your direction! The game does have some stateful behaviour throughout though to make the door /object interactions work. A shame that little in the way of the more advanced probability/game design elements made their way into the submission, although the use of random values in places does create some opportunities for different gameplay. 
	    
	    A good start, and it can clearly be seen how a completed game could be made out of the design presented, but some further investigation into the technical elements and how they could be utilised would be beneficial. 
	    
.

	COURSEWORK 2
	
	Description: This was a 3d survival/escape game, unfinished. Instead of continuing on from Coursework 1, I started again as the project wasn't going well
	Marks: 24/50
	Feedback:
	    The student delivered a project containing neither NavMeshAgents nor NavMeshObstacles. Still, the student managed to implement a custom pathfinding code from scratch. Still, no evidence of this being linked to the main game is given (e.g., enemies are still chasing players using AddForce methods instead of using a pathfinder): therefore, no decision could be possibly done using pathfinding, neither the outcome of such decisions could influence pathfinding.
	    
	    No evidence of a Flocking System was given.
	    
	    The game provides multiple evidences of AudioSources, which are also controlled programmatically; still, there was no evidence of controlling pitch or volume programmatically. No evidence of using cellular automata (e.g.) for procedural generation was given.
	    
	    The student should have considered using Raycasts/OverlapSphere/SphereCast/OverlapCircleAll for limiting expensive function calls (e.g.) while retrieving neighbour nodes. Prefabs are used appropriately via both .prefab files and PrefabInstance. Despite there is no explicit usage of Instantiate for creating prefabs, an instance of the Singleton pattern was given in the custom pathfinding code. No explicit instance of Vector Fields is given.
	    
	    Usage of neither MinMax nor GOAP/Automated Planners was detected.

