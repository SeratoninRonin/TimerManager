using System;
using System.Collections.Generic;
using Godot;

/// <summary>
/// allows delayed and repeated execution of an Action
/// </summary>
public class TimerManager : Node
{
    private List<QuickTimer> _timers = new List<QuickTimer>();
    private static TimerManager _instance;

    public override void _Ready()
    {
        _instance = this;
    }

    public override void _Process(float delta)
    {
        for (var i = _timers.Count - 1; i >= 0; i--)
        {
            // tick our timer. if it returns true it is done so we remove it
            if (_timers[i].Tick(delta))
            {
                _timers[i].Unload();
                _timers.RemoveAt(i);
            }
        }
    }

    /// <summary>
    /// schedules a one-time or repeating timer that will call the passed in Action
    /// </summary>
    /// <param name="timeInSeconds">Time in seconds.</param>
    /// <param name="repeats">If set to <c>true</c> repeats.</param>
    /// <param name="context">Context.</param>
    /// <param name="onTime">On time.</param>
    internal ITimer Start(float timeInSeconds, bool repeats, object context, Action<ITimer> onTime)
    {
        var timer = new QuickTimer();
        timer.Initialize(timeInSeconds, repeats, context, onTime);
        _timers.Add(timer);

        return timer;
    }

    /// <summary>
    /// schedules a one-time or repeating timer that will call the passed in Action
    /// </summary>
    /// <param name="timeInSeconds">Time in seconds.</param>
    /// <param name="repeats">If set to <c>true</c> repeats.</param>
    /// <param name="context">Context.</param>
    /// <param name="onTime">On time.</param>
    public static ITimer Schedule(float timeInSeconds, bool repeats, object context, Action<ITimer> onTime)
    {
        return _instance.Start(timeInSeconds, repeats, context, onTime);
    }

    /// <summary>
    /// schedules a one-time timer that will call the passed in Action after timeInSeconds
    /// </summary>
    /// <param name="timeInSeconds">Time in seconds.</param>
    /// <param name="context">Context.</param>
    /// <param name="onTime">On time.</param>
    public static ITimer Schedule(float timeInSeconds, object context, Action<ITimer> onTime)
    {
        return _instance.Start(timeInSeconds, false, context, onTime);
    }

    /// <summary>
    /// schedules a one-time or repeating timer that will call the passed in Action
    /// </summary>
    /// <param name="timeInSeconds">Time in seconds.</param>
    /// <param name="repeats">If set to <c>true</c> repeats.</param>
    /// <param name="onTime">On time.</param>
    public static ITimer Schedule(float timeInSeconds, bool repeats, Action<ITimer> onTime)
    {
        return _instance.Start(timeInSeconds, repeats, null, onTime);
    }

    /// <summary>
    /// schedules a one-time timer that will call the passed in Action after timeInSeconds
    /// </summary>
    /// <param name="timeInSeconds">Time in seconds.</param>
    /// <param name="onTime">On time.</param>
    public static ITimer Schedule(float timeInSeconds, Action<ITimer> onTime)
    {
        return _instance.Start(timeInSeconds, false, null, onTime);
    }
}