>**Module:** Group Projects | **Game:** Frantic Fingers  
# UI Control System Documentation
>**Introduction**  
>The 'UI control system' defines the overall system that communicates back and forth with individual programs to provide one singular core mechanic. More specifically, this documentation will provide a brief rundown and explanation for how the main, 'word building' mechanic functions inside the Unity Game Engine.

### Sub-System Explanation


>**The 'Letter' Class**  
> The letter class has a very straight-forward role in the control system. An instance of the letter class effectively functions as a payload; designed to keep reference to what character the 'Game-object' that the component is attached to is referencing.
> 
> The program also provides several 'helper' methods that help self-contain the class and 'Game-Object' it is attached to. For example, it is important that the 'Game-object' the letter class is attached to has both a '2D-collider' and 'Rigid-body'.

>**The 'Controller2D' class**  
>The controller class is a very lightweight program (not memory intensive) that simply allows a player to interact with an instance of the 'Game-Object' class as long as it is the appropriate tag. By using a 'tag' system it allows the controller to isolate what instances of 'Game-Objects' the player can interact with.

>**The 'Listener' class**  
>The listener class is the component in the 'control system' that defines the area where a player can drag a letter, on screen, in order to form a word (collection of letter instances). The program effectively listens out for any overlap; where the player has dragged a letter over the top of the listener and passes it to the word class to make it aware that a letter has been used.
>
>This is very simply done through the use of a trigger and payload system, where once an instance of the letter class enters the listeners trigger (collider) it keeps reference to the letter payload for the 'word' class to use.

>**The 'word' class**
>The word class is the overall program that keeps reference to what characters a player has used as well as each characters order. It does this by keep an array of listeners where it can have access to any characters the listeners may be keeping reference to.

```gfm
```flow
st=>start: Start
op=>operation: Your Operation
cond=>condition: Yes or No?
e=>end

st->op->cond
cond(yes)->e
cond(no)->op
​```
```
