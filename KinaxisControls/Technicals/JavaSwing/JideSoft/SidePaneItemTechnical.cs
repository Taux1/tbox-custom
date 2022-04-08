using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.Attributes;
using Tricentis.Automation.Engines.Technicals.Java;
using Tricentis.Automation.Engines.Technicals.Java.Interfaces.Generic;
using Tricentis.Automation.Engines.Technicals.JavaSwing;
using Tricentis.Automation.Engines.Technicals.JavaSwing.Interfaces;
using Tricentis.Automation.Engines.Technicals.References;
using Tricentis.Automation.Engines.Technicals.Reflecting.Java;

namespace Tricentis.Automation.Engines.Technicals.JavaSwing.JideSoft
{
    [SupportedTechnicalTypeName("com.jidesoft.swing.SidePaneItem")]
    public class SidePaneItemTechnical : JavaObjectTechnical
    {
        public SidePaneItemTechnical(IJavaObjectManager<IJavaEntryPointTechnical> remoteObjectManager, Validator validator) : base(remoteObjectManager, validator)
        {
        }

        public string getTitle()
        {
            return RemoteObjectManager.InvokeMethodAsValue<string>(this, "getTitle");
        }

        public bool IsSelected()
        {
            return RemoteObjectManager.InvokeMethodAsValue<bool>(this, "isSelected");
        }

        public void SetSelected(bool isSelected)
        {
            RemoteObjectManager.InvokeVoidMethod(this, "setSelected", isSelected);
        }
        public IObjectReference getComponent()
        {
            return RemoteObjectManager.InvokeMethodAsReference(this, "getComponent");
        }

        public IObjectReference getIcon()
        {
            return RemoteObjectManager.InvokeMethodAsReference(this, "getIcon");
        }

        public IObjectReference getMouseListener()
        {
            return RemoteObjectManager.InvokeMethodAsReference(this, "getMouseListener");
        }

        public void setTitle(string title)
        {
            RemoteObjectManager.InvokeVoidMethod(this, "setTitle", title);
        }
    }
}
