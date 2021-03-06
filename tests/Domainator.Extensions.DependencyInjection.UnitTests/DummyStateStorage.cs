using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domainator.Entities;
using Domainator.Infrastructure.Repositories.StateManagement.Storage;

namespace Domainator.Extensions.DependencyInjection.UnitTests
{
    public class DummyStateStorage : IAggregateStateStorage
    {
        public Task<(AggregateVersion, TState)> LoadAsync<TState>(IEntityIdentity id, CancellationToken cancellationToken)
            where TState : class, IAggregateState
        {
            return Task.FromResult<ValueTuple<AggregateVersion, TState>>((AggregateVersion.Emtpy, default));
        }

        public Task<IReadOnlyDictionary<IEntityIdentity, (AggregateVersion, TState)>> LoadBatchAsync<TState>(
            IReadOnlyCollection<IEntityIdentity> ids, CancellationToken cancellationToken)
            where TState : class, IAggregateState
        {
            return Task.FromResult<IReadOnlyDictionary<IEntityIdentity, (AggregateVersion, TState)>>(
                new Dictionary<IEntityIdentity, (AggregateVersion, TState)>());
        }

        public Task<FindByAttributeValueStateQueryResult<TState>> FindByAttributeValueAsync<TState>(
            FindByAttributeValueStateQuery query, CancellationToken cancellationToken)
            where TState : class, IAggregateState
        {
            return Task.FromResult(new FindByAttributeValueStateQueryResult<TState>(
                new Dictionary<IEntityIdentity, (AggregateVersion, TState)>(), null));
        }

        public Task PersistAsync<TState>(
            IEntityIdentity id, TState state, AggregateVersion version, IReadOnlyDictionary<string, object> attributes,
            CancellationToken cancellationToken)
            where TState : class, IAggregateState
        {
            return Task.CompletedTask;
        }
    }
}
