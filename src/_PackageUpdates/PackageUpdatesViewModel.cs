﻿using System;
using Dynamo.Core;
using Dynamo.Extensions;
using Dynamo.PackageManager;
using Dynamo.Graph.Nodes;
using Dynamo.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Dynamo.UI.Commands;

namespace Monito
{
    class PackageUpdatesViewModel : NotificationObject, IDisposable
    {
        private ReadyParams readyParams;
        private DynamoViewModel viewModel;
        private PackageManagerExtension PkgMngr;

        public PackageUpdatesViewModel(ReadyParams p, DynamoViewModel vm)
        {
            readyParams = p;
            viewModel = vm;
            var extensions = viewModel.Model.ExtensionManager.Extensions.OfType<PackageManagerExtension>();
            if (extensions.Any())
            {
                PkgMngr = extensions.First() as PackageManagerExtension;
            }
        }

        public void Dispose() { }

        private string currentInputsMsg;
        public string CurrentInputsMsg
        {
            get
            {
                return currentInputsMsg;
            }
        }

        private ObservableCollection<ObjectInWorkspace> currentInputs = new ObservableCollection<ObjectInWorkspace>();
        /// <summary>
        /// The search results as a list representation
        /// </summary>
        public ObservableCollection<ObjectInWorkspace> CurrentInputs
        {
            get
            {
                /*List<ObjectInWorkspace> unorderedInputs = new List<ObjectInWorkspace>();
                foreach (NodeModel node in readyParams.CurrentWorkspaceModel.Nodes)
                {
                    if (node.IsSetAsInput) { unorderedInputs.Add(new ObjectInWorkspace(node.NickName, node.GUID.ToString())); }
                }
                currentInputs.Clear();
                foreach (ObjectInWorkspace item in unorderedInputs.OrderBy(x => x.Name)) { currentInputs.Add(item); }
                RaisePropertyChanged(nameof(CurrentInputsMsg));*/
                return currentInputs;
            }
        }
    }
}