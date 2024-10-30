using Orleans.TestingHost;

namespace OperationResult.Tests;

[CollectionDefinition(Name)]
public sealed class ClusterCollection : ICollectionFixture<ClusterFixture>
{
    public const string Name = nameof(ClusterCollection);
}

public sealed class ClusterFixture : IDisposable
{
    public TestCluster Cluster { get; } = new TestClusterBuilder().Build();

    public ClusterFixture() => Cluster.Deploy();

    public void Dispose() => Cluster.StopAllSilos();
}
