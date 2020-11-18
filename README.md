# Run Box Run - Creating a game using Leap Motion

For the Intelligent Interfaces (ICS2208) unit, students were asked to create an app that uses an intelligent interface, which was then presented at the Malta Robotics Olympiad (MRO) 2019. For this project, my partner and I decided to create a 3D runner game, called ‘Run Box Run’ using Unity as well as the addition of hand detection features from the Leap Motion device. The device allows the user to navigate through the game and interface using hand gestures.

## Concept and Implementation
<b>Please note that the base code of the game (a basic runner) was taken from the following <a href="https://devassets.com/assets/how-to-make-a-video-game/">asset pack</a> by Brackeys</b>. We then added more features to the game including integration with the Leap Motion device, randomly generated unique obstacles, a point system, an interactive and user-friendly UI, a tutorial section and more. The final game was implemented using Unity 2018.3.11f1 and a <a href="https://developer.leapmotion.com/unity">module package</a> which allows the Leap Motion to allow for easier integration with Unity.

<p align="center">
  <img src="https://github.com/valerija-h/ICS2208-Assignment/blob/main/Images/MainScreen.png" width="40%"/>
  <img src="https://github.com/valerija-h/ICS2208-Assignment/blob/main/Images/Gameplay.png" width="40%"/>
</p>
<p align="center"><b>Figure 1</b> - Images of the main screen and gameplay of the final game.</p>

A report has been included within this repo with further information of how the final version of the game was developped. In short, the game involves the player controlling the movement of a cube with hand gestures - this includes the following:

<ul>
<li>moving their hand from <b>left to right</b> (and the cube will follow) to collect points and obstacles.</li>
<li>moving their <b>hand up</b> (and the cube will jump) to avoid obstacles which the cube can jump over.</li>
</ul>

We also included the possibility to interact with UI elements by pointing at them. The images below show an example of the gestures that were implemented in the game.

<p align="center">
  <img src="https://github.com/valerija-h/ICS2208-Assignment/blob/main/Images/Hand-Left.png" width="20%"/>
  <img src="https://github.com/valerija-h/ICS2208-Assignment/blob/main/Images/Hand-Right.png" width="20%"/>
</p>
<p align="center"><b>Figure 2</b> - Images of the player moving their hand left and right to control the cube.</p>

<p align="center">
  <img src="https://github.com/valerija-h/ICS2208-Assignment/blob/main/Images/Hand-Point.png" width="30%"/>
</p>
<p align="center"><b>Figure 3</b> - Image of the player performing the pointing gesture to select a button.</p>
