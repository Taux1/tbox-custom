using System.Reflection;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.Attributes;
using Tricentis.Automation.Engines.Technicals.Java;
using Tricentis.Automation.Engines.Technicals.Java.Interfaces.Generic;
using Tricentis.Automation.Engines.Technicals.JavaSwing.Interfaces;
using Tricentis.Automation.Engines.Technicals.References;
using Tricentis.Automation.Engines.Technicals.Reflecting.Java;
using Tricentis.Common.Helpers;

namespace Tricentis.Automation.Engines.Technicals.JavaSwing
{
    [SupportedTechnicalTypeName("com.kinaxis.web.chart.WorkbookPieChart")]
    public class WorkbookPieChartTechnical : SwingJPanelTechnical
    {
        #region Constructors and Destructors

        public WorkbookPieChartTechnical(ISwingObjectManager remoteObjectManager, Validator validator)
            : base(remoteObjectManager, validator) { }

        #endregion

        [TechnicalMember("getChart")]
        public IObjectReference Chart => GetTechnicalProperty<IObjectReference>(MethodBase.GetCurrentMethod());

        [TechnicalMember("getChartModel")]
        public IObjectReference ChartModel => GetTechnicalProperty<IObjectReference>(MethodBase.GetCurrentMethod());

        public int ChartSegments
        {
            get
            {               
                JavaObjectTechnical modelObj = ChartModel.Get<JavaObjectTechnical>();
                return RemoteObjectManager.InvokeMethodAsValue<int>(modelObj, "getSegmentCount");              
            }
        }

        public string GetChartSegmentHeader(int segment)
        {
            if (segment >= 0 && segment <= ChartSegments)
            {
                JavaObjectTechnical modelObj = ChartModel.Get<JavaObjectTechnical>();
                return RemoteObjectManager.InvokeMethodAsValue<string>(modelObj, "getLabel", segment);
            }
            else
            {
                return "";
            }
                       
        }

        public double GetChartSegmentDataValue(int segment)
        {
            if(segment >= 0 && segment <= ChartSegments)
            {
                JavaObjectTechnical modelObj = ChartModel.Get<JavaObjectTechnical>();
                return RemoteObjectManager.InvokeMethodAsValue<double>(modelObj, "getDataValue", segment);
            }
            else
            {
                return 0.0d;
            }
        }
    }
}
