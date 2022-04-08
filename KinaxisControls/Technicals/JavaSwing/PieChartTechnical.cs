using System.Reflection;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.Attributes;
using Tricentis.Automation.Engines.Technicals.Java;
using Tricentis.Automation.Engines.Technicals.Java.Interfaces.Generic;
using Tricentis.Automation.Engines.Technicals.JavaSwing.Interfaces;
using Tricentis.Automation.Engines.Technicals.References;
using Tricentis.Automation.Engines.Technicals.Reflecting.Java;

namespace Tricentis.Automation.Engines.Technicals.JavaSwing.Kinaxis
{
   
    
    
    [SupportedTechnicalTypeName("com.kinaxis.web.chart.JidePieChart$1")]
    public class PieChartTechnical : SwingJComponentTechnical
    {
        
        
        #region Constructors and Destructors

        public PieChartTechnical(ISwingObjectManager remoteObjectManager, Validator validator)
            : base(remoteObjectManager, validator) { }

        #endregion

        [TechnicalMember("getChartModel")]
        public IObjectReference ChartModel => GetTechnicalProperty<IObjectReference>(MethodBase.GetCurrentMethod());

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

        public IObjectReference getChartModel()
        {
            return RemoteObjectManager.InvokeMethodAsReference(this, "getChartModel");
        }

        public IObjectReference getChart()
        {
            return RemoteObjectManager.InvokeMethodAsReference(this, "getChart");
        }

        public IObjectReference getClickMapItems()
        {
            return RemoteObjectManager.InvokeMethodAsReference(this, "getClickMapItems");
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

