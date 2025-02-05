// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    /// <summary> configuration for the servers offering subPlan. </summary>
    internal partial class DefenderForServersGcpOfferingSubPlan
    {
        /// <summary> Initializes a new instance of DefenderForServersGcpOfferingSubPlan. </summary>
        public DefenderForServersGcpOfferingSubPlan()
        {
        }

        /// <summary> Initializes a new instance of DefenderForServersGcpOfferingSubPlan. </summary>
        /// <param name="availableSubPlanType"> The available sub plans. </param>
        internal DefenderForServersGcpOfferingSubPlan(AvailableSubPlanType? availableSubPlanType)
        {
            AvailableSubPlanType = availableSubPlanType;
        }

        /// <summary> The available sub plans. </summary>
        public AvailableSubPlanType? AvailableSubPlanType { get; set; }
    }
}
