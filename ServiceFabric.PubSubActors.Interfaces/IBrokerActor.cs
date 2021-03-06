﻿using System;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using System.Threading.Tasks;

namespace ServiceFabric.PubSubActors.Interfaces
{
    /// <summary>
    /// Acts as a registry for Subscriber Actors and Services that publishing Actors and Services can publish to.
    /// Don't forget to mark implementing <see cref="Actor"/> classes with
    /// the attribute <see cref="ActorServiceAttribute"/> like: [ActorService(Name = nameof(IBrokerActor))]
    /// </summary>
    [Obsolete("This interface will be removed in the next major upgrade. Use the BrokerService instead.")]
    public interface IBrokerActor : IActor
    {
        /// <summary>
        /// Registers an Actor as a subscriber for messages.
        /// </summary>
        /// <param name="actor">Reference to the actor to register.</param>
        Task RegisterSubscriberAsync(ActorReference actor);

        /// <summary>
        /// Unregisters an Actor as a subscriber for messages.
        /// </summary>
        /// <param name="actor">Reference to the actor to unregister.</param>
        /// <param name="flushQueue">Publish any remaining messages.</param>
        Task UnregisterSubscriberAsync(ActorReference actor, bool flushQueue);

        /// <summary>
        /// Registers a service as a subscriber for messages.
        /// </summary>
        /// <param name="service">Reference to the actor to register.</param>
        Task RegisterServiceSubscriberAsync(ServiceReference service);

        /// <summary>
        /// Unregisters a service as a subscriber for messages.
        /// </summary>
        /// <param name="actor">Reference to the actor to unregister.</param>
        /// <param name="flushQueue">Publish any remaining messages.</param>
        Task UnregisterServiceSubscriberAsync(ServiceReference actor, bool flushQueue);

        /// <summary>
        /// Takes a published message and forwards it (indirectly) to all Subscribers.
        /// </summary>
        /// <param name="message">The message to publish</param>
        /// <returns></returns>
        Task PublishMessageAsync(MessageWrapper message);
    }
}
