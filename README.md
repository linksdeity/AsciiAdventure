# AsciiAdventure
A simple text only first person RPG with an automap (like Wizardry without the grid paper)

latest update added simple combat.

still needs initiative for timing and other elements present in the enemy and player class.
combat needs lots and lots of balancing, and only first three enemies are built in right now
enemies scale up in toughness as player levels up

controls:

W A S D for moving (do not hold these down :D )
A, S, and D are used for combat so that you do not have to move your hand very much

maze walls were rendered from strings, but now live in text files and use streamreader to render, same with enemy "sprites"

added a test for music as well but just felt annoying, still lives in the code as a comment

this version might be torn down and rebuilt with better seperation of concerns / files
