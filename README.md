# Car-Race-Async :car: 
This is a consol application written in C# that resembles a car race.
It is completely text-based, so nothing exciting.
However it does simulate four cars starting and running at the same time at the speed of 120 km/h.
The race track is 10 km long, so it should take approximately five minutes to clear, however there is a catch :trollface:.
The catch is that every 30's second a random event will happen, this event could set one of the car back to wait for x amount of seconds, making it stay behind and lose time. Another event could be that the car suffers engine fail and that slows the top speed by x amount of km/h. :oncoming_automobile:



All the cars run simultaneously on different "threads" and the random event are chance based, meaning (for example) there is a 2 percent chance of event A to happen, a 4 percent chance of event B, a 10 percent chance of event C and 20 percent chance of event D to happend.:game_die:

The whole point of this app is that it is an exercies for the use of asynchronous programming and the using of keywords like async and await, and objects like Task and Task\<T>.
:blue_car:

NOTE: The app is not really running for five minutes, i created a "simSeconds" variable that controls the speed of the app (1 simSec == 1 Sec, however for the time being i don't recommend you going lower than simSeconds = 0.3 due to bugs).

## :warning:Known bugs :tractor::construction:

If simSeconds is set lower than 0.3 (usually works well on 0.2), it may happend that the wrong car goes into goal first (wrong thread finishes). Other bugs may occure aswell, like no winner is announced or the app gets stuck and you need to press a key for it to continue.

Sometimes at the end where it says: "Press any key to close app" - it might happen that the carStatus task appears, however you may just press any key and the app will close. 

Another issue or design flaw is that the cars basically move 33.33 meters per second, which means the threads don't exactly finish when the cars have reached exactly 10000 meters (10 km), more like 10033, 10025, 10005 and so on.

## How to run :oncoming_taxi:

This app does not use any nuget packages or special usings, you just clone or download repo and run the sln file on your IDE. :rocket:
