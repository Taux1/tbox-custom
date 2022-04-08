using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Adapters.Attributes;
using Tricentis.Automation.Engines.Adapters.JavaAwt;
using Tricentis.Automation.Engines.Adapters.Lists;
using Tricentis.Automation.Engines.Technicals.JavaAwt;
using Tricentis.Automation.Engines.Technicals.JavaAwt.Interfaces;
using Tricentis.Automation.Engines.Technicals.JavaSwing;
using Tricentis.Automation.Engines.Technicals.JavaSwing.JideSoft;
using Tricentis.Automation.Engines.Technicals.JavaSwing.Kinaxis;
using Tricentis.Automation.Simulation;

namespace Tricentis.Automation.Engines.Adapters.JavaSwing
{
    [SupportedTechnical(typeof(WorkbookPieChartTechnical))]
    public class PieChartItemAdapter : SwingJPanelAdapter, IListItemAdapter
    {
        public PieChartItemAdapter(WorkbookPieChartTechnical technical, Validator validator, string sliceName, int sliceIndex) : base(technical, validator)
        {
        }

        public int sliceIndex => sliceIndex;

        public bool Closable => false;

        public bool Selected { get; set; }

        public string Text => "PieItem:";

        public override bool Enabled => true;

        public override bool Focused => true;

        public override bool InteractiveElement => true;

        public override bool IsSteerable => true;

        public override bool Visible => true;

        public override string DefaultName => Text;

        public double SliceValue 
        { 
            get 
            {
                try
                {
                    return ((WorkbookPieChartTechnical)Technical).GetChartSegmentDataValue(sliceIndex);
                }
                catch (Exception e)
                {
                    return 0.0d;
                }
            } 
        }
    }
}
