using team_mapper_domain.Models;
using team_mapper_domain.Models.Enum;
using team_mapper_domain.Responses;

namespace team_mapper_shared_utilities.ResponseFactories;

public static class TaskResponseFactory
{
    public static IEnumerable<WorkItem> CreateTasks(int numberOfTasks = 10)
    {
        var tasks = new List<WorkItem>();
        for (int i = 0; i < numberOfTasks; i++)
        {
            tasks.Add(
                new WorkItem()
                {
                    WorkItemId = Guid.NewGuid(),
                    Description = GetRandomDescription(),
                    EndDate = DateTime.Now,
                    TaskPriority = GetRandomEnumValue<TaskPriority>(),
                    TaskCategory = GetRandomEnumValue<TaskCategory>(),
                    IsComplete = false
                });
        }

        return tasks;
    }

    public static CreateWorkItemResponse CreateWorkItemResponse(Guid workItemId) => new(workItemId: workItemId);

    #region Data Generator Helper
    private static string GetRandomDescription()
    {
        List<string> descriptions = [
            "Client Proposal Review 📄",
            "Internal Process Audit 🔍",
            "Marketing Campaign Brief 🧠📢",
            "Quarterly Metrics Update 📊",
            "Team Check-In Prep 🤝",
            ];

        var randomIndex = new Random().Next(0, descriptions.Count);
        return descriptions[randomIndex];
    }

    private static T GetRandomEnumValue<T>()
    {
        var arrayValues = Enum.GetValues(typeof(T));
        var randomIndex = new Random().Next(0, arrayValues.Length);
        var enumValue = (T)arrayValues.GetValue(randomIndex)!;

        return enumValue;
    }
    #endregion
}
