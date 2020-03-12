# Combination Lock (Unity / C#)

![Combination Lock image](/doc/combination_lock.gif)

## What is it?

A demo project that shows how to create a simple combo class, in this case used for a door lock / keypad. If user gives the correct input sequence, the lock will open.

Combination lock demo scene and class shows how to use combo class and call its methods. There are also audio effects and timed animations.

Combo class contains following features:

* Generic base class from which it is possible to derive a class from, in this case sequence is using integer numbers

* Combo can have a time limit, combo will fail if time runs out 

* Combo can be set to fail instantly if incorrect input is given, but in this case it makes more sense to allow user give a full sequence and only then the sequence is checked

* Combo can be reset if it has failed


# Classes

## CombinationLock.cs
A demo class that shows how ComboSeq.cs class can be used.

## ComboSeq.cs
A class that stores user input and checks if the given input or full combination is valid, also contains a timer to check if input is given within the time limit.

## AudioManager.cs
Handles audio clip playback.

## About
I created this combination system for myself for different personal Unity projects. 

## Copyright 
Created by Sami S. use of any kind without a written permission from the author is not allowed. But feel free to take a look.
