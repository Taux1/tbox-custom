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
    public class KinaxisWorkbookPieChartAdapter : SwingJPanelAdapter, IComboBoxAdapter
    {
        public KinaxisWorkbookPieChartAdapter(WorkbookPieChartTechnical technical, Validator validator) : base(technical, validator)
        {
        GetNames(((WorkbookPieChartTechnical)Technical).ChartSegments);
        }

        public Dictionary<string, double> SegmentsDict = new Dictionary<string, double>();

        public List<string> namesList = new List<string>();

        private void GetNames(int segmentCount)
        {
            for (int i = 0; i < segmentCount; i++)
			{
                namesList.Add(((WorkbookPieChartTechnical)Technical).GetChartSegmentHeader(i));
			}
        }

        /*
        private void GetData(int segmentCount)
        {
             for (int i = 0; i < segmentCount; i++) 
             {
               SegmentsDict.Add(
                   ((WorkbookPieChartTechnical)Technical).GetChartSegmentHeader(i),
                   ((WorkbookPieChartTechnical)Technical).GetChartSegmentDataValue(i)
                   );
             }

             public string Segment => SegmentsDict.Select(kvp => kvp.ToString()).Aggregate((a, b) => a + ", " + b);
        } */



/*
        public string Segment0Header => ((WorkbookPieChartTechnical)Technical).GetChartSegmentHeader(0);
        public string Segment1Header => ((WorkbookPieChartTechnical)Technical).GetChartSegmentHeader(1);
        public string Segment2Header => ((WorkbookPieChartTechnical)Technical).GetChartSegmentHeader(2);
        public string Segment3Header => ((WorkbookPieChartTechnical)Technical).GetChartSegmentHeader(3);
        public string Segment4Header => ((WorkbookPieChartTechnical)Technical).GetChartSegmentHeader(4);
        public string Segment5Header => ((WorkbookPieChartTechnical)Technical).GetChartSegmentHeader(5);
        public string Segment6Header => ((WorkbookPieChartTechnical)Technical).GetChartSegmentHeader(6);
        public string Segment7Header => ((WorkbookPieChartTechnical)Technical).GetChartSegmentHeader(7);
        public string Segment8Header => ((WorkbookPieChartTechnical)Technical).GetChartSegmentHeader(8);
        public string Segment9Header => ((WorkbookPieChartTechnical)Technical).GetChartSegmentHeader(9);

        public double Segment0Value => ((WorkbookPieChartTechnical)Technical).GetChartSegmentDataValue(0);
        public double Segment1Value => ((WorkbookPieChartTechnical)Technical).GetChartSegmentDataValue(1);
        public double Segment2Value => ((WorkbookPieChartTechnical)Technical).GetChartSegmentDataValue(2);
        public double Segment3Value => ((WorkbookPieChartTechnical)Technical).GetChartSegmentDataValue(3);
        public double Segment4Value => ((WorkbookPieChartTechnical)Technical).GetChartSegmentDataValue(4);
        public double Segment5Value => ((WorkbookPieChartTechnical)Technical).GetChartSegmentDataValue(5);
        public double Segment6Value => ((WorkbookPieChartTechnical)Technical).GetChartSegmentDataValue(6);
        public double Segment7Value => ((WorkbookPieChartTechnical)Technical).GetChartSegmentDataValue(7);
        public double Segment8Value => ((WorkbookPieChartTechnical)Technical).GetChartSegmentDataValue(8);
        public double Segment9Value => ((WorkbookPieChartTechnical)Technical).GetChartSegmentDataValue(9); 
*/

        public override string DefaultName
        {
            get
            {
                return "PieChart:";
            }
        } 

        public int NumberOfSegments
        {
            get
            {
                try
                {
                    return ((WorkbookPieChartTechnical)Technical).ChartSegments;
                }
                catch (Exception e)
                {
                    return 0;
                }

            }
        }
    }
}
