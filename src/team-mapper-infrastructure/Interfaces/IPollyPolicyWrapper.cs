using Polly;

namespace team_mapper_infrastructure.Interfaces;

public interface IPollyPolicyWrapper
{
    ResiliencePipeline Policy { get; set; }
}
