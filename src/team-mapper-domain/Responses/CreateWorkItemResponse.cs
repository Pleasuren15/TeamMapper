namespace team_mapper_domain.Responses;


public class CreateWorkItemResponse(Guid workItemId)
{
    public Guid WorkItemId { get; private set; } = workItemId;
}
