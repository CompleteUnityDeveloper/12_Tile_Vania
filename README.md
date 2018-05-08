# Complete Unity Developer - Section 6 - TileVania

This is the Complete Unity Developer - one of the most successful e-learning courses on the internet! Completely re-worked from scratch with brand-new projects and our latest teaching techniques. You will benefit from the fact we have already taught over 360,336 students game development, many shipping commercial games as a result.

You're welcome to download, fork or do whatever else legal with all the files! The real value is in our huge, high-quality online tutorials that accompany this repo.

## In This Section
Build a Speulnky-like level in under one minute using a procedural Tilemap smart brush that you build yourself! (Section REF: TV_CUD)

## How To Build / Compile
This is a Unity project. If you're familiar with source control, then "clone this repo". Otherwise download the contents, and navigate to `Assets > Levels` then open any `.unity` file.

This branch is the course branch, each commit corresponds to a lecture in the course. The current state is our latest progress.

## Lecture List
Here are the lectures of the course for this section...


### 1 Welcome To TileVania ###

**In this video (objectives)…**

1. We'll be taking on Tilemap.
2. A note about where this section fits within the course.

**After watching (learning outcomes)…**

Explain to a fellow student roughly what we're building, and why this is awesome stuff to know.


### 2 TileVania Game Design ###

**In this video (objectives)…**

1. Be clear on the core game design for this section.
2. Understand the creative options that each student has for making this game their own.

**After watching (learning outcomes)…**

Explain to a fellow student the design of what we'll be building and to start exploring options for creativity.


### 3 Slicing Sprite Sheets ###

**In this video (objectives)…**

1. Import sprite sheets to be used for our platformer.
2. Use the automatic or slice-by-grid options in Unity to slice our sprite sheet into individual sprite images for our game.

**After watching (learning outcomes)…**

Be capable of slicing sprite sheets to make individual assets.


### 4 Intro To Unity Tilemap ###

**In this video (objectives)…**

1. Create multiple tile map layers.
2. Build multiple tile palettes.
3. Paint a simple level.

**After watching (learning outcomes)…**

Able to import a sprite sheet, slice it up, create tile palettes and paint a simple level layout.


### 5 Unity Rule Tiles ###

**In this video (objectives)…**

1. Download the Unity 2D asset.
2. Create rule tile rules.
3. Paint additional platforms using rule tile.

**After watching (learning outcomes)…**

Create a rule tile and set up the logic for its rules.


### 6 Create Player Idle Animation ###

**In this video (objectives)…**

1. Create player idle animation clip from sprite sheet.
2. Add animation to Animator Controller.
3. Add Sprite Renderer and Animator to Player character.

**After watching (learning outcomes)…**

Created 4 frames of 2d character idle animation which plays automatically when the game plays.


### 7 Animation States & Transitions ###

**In this video (objectives)…**

1. Create animation clips for run and climb.
2. Add animation states for each animation clip type.
3. Add bool parameters to switch between animation states.
4. Add transitions between the animation states.

**After watching (learning outcomes)…**

Able to construct an animation state machine with transitions and triggers.


### 8 Implement 2D Collision ###

**In this video (objectives)…**

1. Add RigidBody and collision to the player.
2. Set up composite collision on our environment.

**After watching (learning outcomes)…**

Drop our player from a height and have it land on the platform.


### 9 Maximize Learning Value ###

**In this video (objectives)…**

1. Context for the gameplay functionality we are about to create.
2. The best way to learn and become better at being a programmer.

**After watching (learning outcomes)…**

Understand how to get even more value from this course in terms of your learning and skills.


### 10 Move Player Horizontally ###

**In this video (objectives)…**

1. Create Player class.
2. Import CrossPlatformInput.
3. Move the player's RigidBody horizontally.

**After watching (learning outcomes)…**

Move the player horizontally using CrossPlatformInput.


### 11 Flip Character Sprite ###

**In this video (objectives)…**

1. Introduce Mathf.Abs and Mathf.Sign.
2. Pseudocode for flipping character sprite.
3. Flip character sprite based upon player having horizontal velocity.

**After watching (learning outcomes)…**

Flip the player character's sprite whenever the character has horizontal velocity.


### 11b Instructor Hangout 6.1 ###

**In this video (objectives)…**

1. We discuss the difference between caching and calculating.
2. Why did we set up the flip sprite the way we did rather than starting with an isFacingRight bool.
3. Ben makes a bad joke at the end of the video.

**After watching (learning outcomes)…**

Greater understanding of the cache versus calculate options we have.


### 12 Animation State In Code ###

**In this video (objectives)…**

1. Use code to set the animation transition bool.
2. Make the player transition to the running animation when the running transition condition is called in our script.

**After watching (learning outcomes)…**

Make the player's run animation state be triggered from code.


### 13 Jumpy Jumpy ###

**In this video (objectives)…**

1. Revise how velocity is being applied to our player's RigidBody.
2. Add a positive y velocity to cause the player to jump.
3. Tune the global gravity and player jump speed to give the right feel for our game.

**After watching (learning outcomes)…**

Make your player jump and fall in a way which feels good to play.


### 14 Jump if IsTouchingLayers ###

**In this video (objectives)…**

1. Review how layers work as a way to apply the same functionality to many GameObjects.
2. Implement IsTouchingLayers for our collision check.
3. Only allow the player to jump if he is touching the ground.

**After watching (learning outcomes)…**

Make the player jump only when touching the ground layer.


### 15 Climb Ladder ###

**In this video (objectives)…**

1. Create ladder tile.
2. Set up the climb tilemap, sorting layer and collision layer.
3. Transition to climb state if player is touching ladder.
4. Move player's y velocity when input is received.

**After watching (learning outcomes)…**

Move the player up and down on a ladder with appropriate climbing animation state.


### 16 Climb Ladder Tweaks ###

**In this video (objectives)…**

1. Fix bug where player does not transition out of climb state.
2. Change gravity while on ladder to stop player sliding back down.

**After watching (learning outcomes)…**

Able to stop player sliding on ladder.


### 17 Perspective Vs Orthographic Cameras ###

**In this video (objectives)…**

1. Review the fundamental differences between the camera types.
2. Explain the reasons why we might use one camera over the other.

**After watching (learning outcomes)…**

Understand the differences in perspective and orthographic cameras.


### 18 Cinemachine Follow Camera ###

**In this video (objectives)…**

1. Import and set up Cinemachine.
2. Create a Cinemachine brain and Cinemachine virtual camera.
3. Tune the dead zone, dampening and look ahead of our camera.

**After watching (learning outcomes)…**

Be skilled at setting up a 2D follow camera using Unity's Cinemachine.


### 19 Cinemachine Confiner Extension ###

**In this video (objectives)…**

1. Create physics layers for Player and Background and alter the collision matrix so that the correct things can collide with one another.
2. Create a bounding box for the Cinemachine confiner.
3. Tune level and camera so that the player can only see what we want them to see.

**After watching (learning outcomes)…**

Implement the Cinemachine confiner extension.


### 20 State-Driven Cameras ###

**In this video (objectives)…**

1. Add a state-driven camera to the scene.
2. Link the player animator states to the camera states by creating additional cameras.
3. Adjust the blending between cameras.
4. Experiment with camera shake.

**After watching (learning outcomes)…**

Implement state-driven cameras using Unity Cinemachine.


### 21 Prevent Wall Jump ###

**In this video (objectives)…**

1. Add physics material to stop sticking to wall.
2. Add additional collider to represent player's feet.
3. Only allow feet to determine if player is touching the ground.

**After watching (learning outcomes)…**

Prevent funky wall behaviour.


### 22 Making Enemies ###

**In this video (objectives)…**

1. Import enemy sprite and set up required components.
2. Script a way for the enemy to flip when it reaches the end of a platform.

**After watching (learning outcomes)…**

Create an enemy that moves along platforms, turning when it reaches the end.


### 23 Player Death ###

**In this video (objectives)…**

1. Trigger player death when player collides with enemy.
2. Disable player control when player is in death state.
3. Implement some kind of dramatic death reaction.
4. Change player animation state when dying.

**After watching (learning outcomes)…**

Create vulnerability in the player by triggering a dramatic death.
