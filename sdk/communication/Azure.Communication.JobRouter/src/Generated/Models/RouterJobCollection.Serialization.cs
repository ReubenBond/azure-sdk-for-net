// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter.Models
{
    internal partial class RouterJobCollection
    {
        internal static RouterJobCollection DeserializeRouterJobCollection(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<RouterJobItem> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<RouterJobItem> array = new List<RouterJobItem>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(RouterJobItem.DeserializeRouterJobItem(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"u8))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new RouterJobCollection(value, nextLink.Value);
        }
    }
}
