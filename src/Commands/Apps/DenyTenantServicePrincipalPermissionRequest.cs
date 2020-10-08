﻿using Microsoft.Online.SharePoint.TenantAdministration.Internal;
using Microsoft.SharePoint.Client;
using PnP.PowerShell.Commands.Base;
using System;
using System.Management.Automation;

namespace PnP.PowerShell.Commands.Apps
{
    [Cmdlet(VerbsLifecycle.Deny, "TenantServicePrincipalPermissionRequest")]
    public class DenyTenantServicePrincipalPermissionRequests : PnPAdminCmdlet
    {
        [Parameter(Mandatory = true)]
        public Guid RequestId;

        [Parameter(Mandatory = false)]
        public SwitchParameter Force;

        protected override void ExecuteCmdlet()
        {
            if (Force || ShouldContinue($"Deny request {RequestId}?", "Continue"))
            {
                var servicePrincipal = new SPOWebAppServicePrincipal(ClientContext);
                var request = servicePrincipal.PermissionRequests.GetById(RequestId);
                request.Deny();
                ClientContext.ExecuteQueryRetry();
            }
        }

    }
}