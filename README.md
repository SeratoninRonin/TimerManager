# TimerManager

Godot's built-in Tween and Timer nodes handle most cases, but sometimes you want to schedule a callback without a lot of fuss, so I present:

A timer/callback scheduler for Godot C#

The TimerManager is a simple helper that lets you pass in an Action that can be called once or repeately with or without a delay. The TimerManager.Schedule method provides easy access to the TimerManager. When you call Schedule you get back an ITimer object that has a Stop method that can be used to stop the timer from firing again.
