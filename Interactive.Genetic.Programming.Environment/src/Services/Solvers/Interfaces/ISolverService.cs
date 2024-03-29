﻿namespace Solvers.Interfaces;

public interface ISolverService
{
    public void Subscribe(ISolverStatusSubscriber subscriber);
    public void Unsubscribe(ISolverStatusSubscriber subscriber);
    public void Subscribe(ISolverSubscriber subscriber);
    public void Unsubscribe(ISolverSubscriber subscriber);
    public void FetchAllSubscribed();
    public void Start();
    public void Stop();
    public void Reset();
}