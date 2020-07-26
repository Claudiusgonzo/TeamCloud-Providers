/**
 *  Copyright (c) Microsoft Corporation.
 *  Licensed under the MIT License.
 */

using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using TeamCloud.Model;
using TeamCloud.Model.Commands;
using TeamCloud.Model.Data.Core;
using TeamCloud.Serialization;

namespace TeamCloud.Providers.Azure.DevOps.Activities
{
    public static class ProviderRegisterActivity
    {
        [FunctionName(nameof(ProviderRegisterActivity))]
        public static ProviderRegistration RunActivityAsync(
            [ActivityTrigger] ProviderRegisterCommand command,
            ILogger log)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            using (log.BeginCommandScope(command))
            {
                try
                {
                    return new ProviderRegistration
                    {
                        PrincipalId = null // this provider does not talk to any azure resources yet
                    };
                }
                catch (Exception exc)
                {
                    log.LogError(exc, $"{nameof(ProviderRegisterActivity)} failed: {exc.Message}");

                    throw exc.AsSerializable();
                }
            }
        }
    }
}
