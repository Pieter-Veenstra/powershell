﻿using System;
using System.Linq;
using System.Management.Automation;
using PnP.PowerShell.Commands.Base.PipeBinds;
using PnP.Framework.Pages;

namespace PnP.PowerShell.Commands.ClientSidePages
{
    [Cmdlet(VerbsCommon.Set, "ClientSideText")]
    public class SetClientSideText : PnPWebCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0)]
        public ClientSidePagePipeBind Page;

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Guid InstanceId;

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public string Text;

        protected override void ExecuteCmdlet()
        {
            var clientSidePage = Page.GetPage(ClientContext);

            if (clientSidePage == null)
                throw new Exception($"Page '{Page?.Name}' does not exist");

            var control = clientSidePage.Controls.FirstOrDefault(c => c.InstanceId == InstanceId);
            if (control != null)
            {
                var textControl = control as ClientSideText;
                textControl.Text = Text;
                clientSidePage.Save();
            }
            else
            {
                throw new Exception($"Component does not exist");
            }
        }
    }
}