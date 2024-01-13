using Database.Entities;

namespace Solution.Interfaces;

public interface IAvailableSolutionsSubscriber
{
    public void AvailableSolutionsUpdate(IEnumerable<SolutionEntity> solutions);
}

public interface IAvailableSolutionsService
{
    public void Subscribe(IAvailableSolutionsSubscriber subscriber);
    public void Unsubscribe(IAvailableSolutionsSubscriber subscriber);
    public void FetchAllSubscribed();
    public void InspectSolution(SolutionEntity solution);
    public void RemoveSolution(SolutionEntity solution);
}