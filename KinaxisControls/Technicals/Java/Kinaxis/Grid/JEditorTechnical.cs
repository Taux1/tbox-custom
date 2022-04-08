using System.Reflection;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.Attributes;
using Tricentis.Automation.Engines.Technicals.Java.Interfaces.Generic;
using Tricentis.Automation.Engines.Technicals.References;
using Tricentis.Automation.Engines.Technicals.Reflecting.Java;

namespace Tricentis.Automation.Engines.Technicals.Java.Kinaxis.Grid {
    [SupportedTechnicalTypeName("com.kinaxis.web.ui.grid.JEditor")]
    public class JEditorTechnical : JavaObjectTechnical {

        #region Constructors and Destructors

        public JEditorTechnical(IJavaObjectManager<IJavaEntryPointTechnical> remoteObjectManager, Validator validator)
            : base(remoteObjectManager, validator) { }

        #endregion

        #region Public Properties

        public IObjectReference ActiveComponent => RemoteObjectManager.GetFieldAsReference(this, "activeComponent");

        public IObjectReference ComboBox => RemoteObjectManager.GetFieldAsReference(this, "comboBox");

        [TechnicalMember("isEditing")]
        public bool Editing => GetTechnicalProperty<bool>(MethodBase.GetCurrentMethod());

        public IObjectReference Owner => RemoteObjectManager.GetFieldAsReference(this, "owner");
        
        public string Text {
            get => RemoteObjectManager.GetPropertyAsValue<string>(this, "getText");
            set => RemoteObjectManager.SetProperty(this, "setText", value);
        }

        public IObjectReference TextField => RemoteObjectManager.GetFieldAsReference(this, "textField");

        #endregion

        #region Public Methods and Operators

        public void CleanUp() => RemoteObjectManager.InvokeVoidMethod(this, "cleanUp");

        public void HidePopup() => RemoteObjectManager.InvokeVoidMethod(this, "hidePopup");

        public void RequestFocus() => RemoteObjectManager.InvokeVoidMethod(this, "requestFocus");

        public void RequestFocusInWindow() => RemoteObjectManager.InvokeVoidMethod(this, "requestFocusInWindow");

        public void SelectText() => RemoteObjectManager.InvokeVoidMethod(this, "selectText");

        public void StopEditing() => RemoteObjectManager.InvokeVoidMethod(this, "stopEditing");

        #endregion
    }
}
