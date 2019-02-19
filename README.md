# SurveyMakerKata

## Why this Kata?
This Kata was created for the meetup : Apéro Tech #5
It is a base to ask the question : "How to refactor legacy code properly?"

### Some commits are ugly!
Yep, it's made on purpose. The goal is to identify what to do to refator this code properly.

# And what are those steps ?
Here are the steps :
* Lanch the app
* Read the code
* Add some unit tests with NUnit, NFluent and NSubstitute
* Refactor small parts of the code once they are tested
* Lauch the code to ensure behaviour stays the same
* Commit often, when unit tests are green and code compiles
* Do it over and over agin, until code is clean

### Why using C#.NET ?
C# is my main coding language. As I created this code for a meetup, better be confident about my code right?

## And what do I need to use this Kata ?
You need Visual Studio, NUnit, NFlent, NSubstitute, and the base libraries ! 

## Can I clone this repo?
Sure! It was made for training purposes.

### What where your steps in the refactoring process ?

- __ad338c3a61__ -> Base for this project, ugly code, almost no interfaces, SOLID principle are baffled... We need to refactor this.
- __158e6b3d01__ -> Code output in JSON, first helper, main class starting to be cut into smaller pieces
- __f8867b3a06__ ->  More interfaces. Removed static class, my bad. QuestionHelper can now be mocked ! Now writing two separate JSON files. 
- __7eab7c42db__ -> Added more tests, this should have been the first step... 
- __73098b972d__ -> Added final classes, code is now properly tested and separated into smaller classes. Refactoring done, code can be improved

Branches :
(__before-refacto__) -> Use this as base to work
(__master__) -> this branch was clean and refactor already. It is one way to do it, maybe not the best one ;)
