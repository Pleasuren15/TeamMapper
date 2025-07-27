using team_mapper_domain.Models.Enum;

namespace team_mapper_shared_utilities.ResponseFactories;

public static class TaskResponseFactory
{
    public static IEnumerable<team_mapper_domain.Models.WorkItem> CreateTasks(int numberOfTasks = 10)
    {
        var tasks = new List<team_mapper_domain.Models.WorkItem>();
        for (int i = 0; i < numberOfTasks; i++)
        {
            tasks.Add(
                new team_mapper_domain.Models.WorkItem()
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
