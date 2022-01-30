# TimerManager

Godot's built-in Tween and Timer nodes handle most cases, but sometimes you want to schedule a callback without a lot of fuss, so I present:

A timer/callback scheduler for Godot C#

The TimerManager is a simple helper that lets you pass in an Action that can be called once or repeately with or without a delay. The TimerManager.Schedule method provides easy access to the TimerManager. When you call Schedule you get back an ITimer object that has a Stop method that can be used to stop the timer from firing again.

# Usage

The /addons/TimerManager folder should be copied into your own project's /addons folder

The TimerManager.tscn file should be added to your Project Settings -> AutoLoad as a global, like so:

![TMload](https://user-images.githubusercontent.com/61599196/151712360-af95373b-e3cf-43f3-83be-862b2a65f6a5.png)

# Example
```C#

public void SomeFunction()
{
  TimerManager.Schedule(3f,()=>{ GD.Print("Time is up!"); });
  TimerManager.Schedule(4f, this, (t)=>{ t.Visible = false; });
}

```
# Acknowledgements/Attribution

This was adapted from the excellent Nez framework for MonoGame: https://github.com/prime31/Nez

# License

This project is MIT licensed and provided as-is.
