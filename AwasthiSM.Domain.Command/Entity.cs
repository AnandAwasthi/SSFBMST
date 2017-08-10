﻿namespace AwasthiSM.Domain.Command
{
    using System;
    using System.Runtime.Serialization;
    


    /// <summary>
    /// Abstract Entity for all the BusinessEntities.
    /// </summary>
    [DataContract]
    [Serializable]
    public abstract class Entity 
    {
        /// <summary>
        /// Gets or sets the id for this object (the primary record for an entity).
        /// </summary>
        /// <value>The id for this object (the primary record for an entity).</value>
        [DataMember]
        public virtual string Id { get; set; }
    }
}
