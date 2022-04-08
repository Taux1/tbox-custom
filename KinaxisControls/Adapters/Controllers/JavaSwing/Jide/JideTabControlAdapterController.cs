using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Tricentis.Automation.AutomationInstructions.TestActions;
using Tricentis.Automation.AutomationInstructions.TestActions.Associations;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Adapters.JavaAwt;
using Tricentis.Automation.Engines.Adapters.JavaSwing;
using Tricentis.Automation.Engines.Adapters.JavaSwing.Jide;
using Tricentis.Automation.Engines.Representations.Attributes;
using Tricentis.Automation.Engines.Technicals;
using Tricentis.Automation.Engines.Technicals.Java;
using Tricentis.Automation.Engines.Technicals.JavaAwt;
using Tricentis.Automation.Engines.Technicals.JavaAwt.Interfaces;
using Tricentis.Automation.Engines.Technicals.JavaSwing;
using Tricentis.Automation.Engines.Technicals.JavaSwing.JideSoft;
using Tricentis.Automation.Simulation;

namespace Tricentis.Automation.Engines.Adapters.Controllers.JavaSwing.Jide
{
    [SupportedAdapter(typeof(JideTabControlAdapter))]
    public class JideTabControlAdapterController : ListAdapterController<JideTabControlAdapter>
    {
        private const string ListItems = "ListItems";

        public JideTabControlAdapterController(JideTabControlAdapter contextAdapter, ISearchQuery query, Validator validator) : base(contextAdapter, query, validator)
        {
        }

        protected override IEnumerable<IAssociation> ResolveAssociation(ListItemsBusinessAssociation businessAssociation)
        {
            yield return new AlgorithmicAssociation(ListItems);
        }

        protected override IEnumerable<IAssociation> ResolveAssociation(ChildrenBusinessAssociation businessAssociation)
        {
            yield return new AlgorithmicAssociation(ListItems);
        }

        protected override IEnumerable<IAssociation> ResolveAssociation(ParentBusinessAssociation businessAssociation)
        {
            yield return new TechnicalAssociation("Parent");
        }

        protected override IEnumerable<ITechnical> SearchTechnicals(IAlgorithmicAssociation algorithmicAssociation)
        {
            if (algorithmicAssociation.AlgorithmName == ListItems)
            {
                return GetItems();
            }
            return base.SearchTechnicals(algorithmicAssociation);
        }

        
        private IEnumerable<ITechnical> GetItems()
        {
            List<SidePaneGroupTechnical> groups = ContextAdapter.Technical.GetGroups().Get<SidePaneGroupTechnical>().ToList();

            //List<SidePaneItemTechnical> paneItems = groups.Select(g => g.getItemAtIndex(0).Get<SidePaneItemTechnical>()).ToList();
            SidePaneGroupTechnical groupScen = groups.FirstOrDefault(group =>  group.getItemAtIndex(0).Get<SidePaneItemTechnical>().getTitle() == "Scenarios");
           // Select(groupScen);
            return groups;
        }

        protected override IEnumerable<IAdapter> SearchAdapters(IAlgorithmicAssociation algorithmicAssociation)
        {
            List<IAdapter> adapters = base.SearchAdapters(algorithmicAssociation).ToList();
            if (algorithmicAssociation.AlgorithmName == ListItems)
            {
                int index = 0;
                foreach (var adapter in adapters) {
                    if (adapter is JideTabItemAdapter) {
                        ((JideTabItemAdapter)adapter).ParentTabControl = ContextAdapter;
                        ((JideTabItemAdapter)adapter).Index = index;
                        index++;
                    }
                }
            }
            return adapters;

        }


        public void Select(SidePaneGroupTechnical group)
        {
            int index = group.getSelectedIndex();
            SidePaneItemTechnical item = group.getItemAtIndex(0).Get<SidePaneItemTechnical>();
            //item.setTitle("test");

            // SidePaneItemTechnical item2 = Technical.getItemAtIndex(1).Get<SidePaneItemTechnical>();
            item.SetSelected(true);
            group.SetSelectedIndex(0);
            //Technical.fireSidePaneEvent(item, 4100);
            group.fireSidePaneEvent(item, 4099);

            SwingImageIconTechnical icon = item.getIcon().Get<SwingImageIconTechnical>();
            int iconHeight = icon.IconHeight;
            int iconWidth = icon.IconWidth;
            string titel = item.getTitle();

            int x = ContextAdapter.Technical.X;
            int y = ContextAdapter.Technical.Y;
            List<AwtComponentTechnical> componenets = ContextAdapter.Technical.Components.Get<AwtComponentTechnical>().ToList();
            AwtComponentTechnical compAt = ContextAdapter.Technical.ComponentAt(x, y).Get<AwtComponentTechnical>();
            AwtComponentTechnical compAt2 = ContextAdapter.Technical.ComponentAt(x + 25, y + 150).Get<AwtComponentTechnical>();

            AwtPointTechnical point = ContextAdapter.Technical.EntryPoint.CreateJavaObject("java.awt.Point").Get<AwtPointTechnical>();
            //point.SetLocation(x + 25, y + 175);//explorer
            point.SetLocation(x + 25, y + 325);//scen

            int indexUnderPoint = ContextAdapter.Technical.getSelectedItemIndex(point);
            //Mouse.PerformMouseAction(MouseOperation.MouseOver, point.ToPointF());

            Technicals.References.IObjectReference objectReference = ContextAdapter.Technical.EntryPoint.CreateJavaObject("java.awt.event.MouseEvent");
            MouseEventTechnical mEvent = objectReference.Get<MouseEventTechnical>();

            AutoHideMouseListenerTechnical mouseListener = item.getMouseListener().Get<AutoHideMouseListenerTechnical>();
            //mouseListener.mouseClicked(mEvent);
            Technicals.References.IObjectReference objectReference1 = ContextAdapter.Technical.getUI();
            BasicSidePaneUITechnical uiTech = objectReference1.Get<BasicSidePaneUITechnical>();
            IEnumerable<AwtRectangleTechnical> rectenum = uiTech.Rects.Get<AwtRectangleTechnical>();
            List<AwtRectangleTechnical> rectList = uiTech.Rects.Get<AwtRectangleTechnical>().ToList();
            int count = uiTech.Rects.Count;
            

            foreach (AwtRectangleTechnical r in rectList)
            {
                
                PointF pR = new PointF(r.X + r.Width/2 + ContextAdapter.ControlArea.X, r.Height/2 + r.Y + ContextAdapter.ControlArea.Y);
                AwtPointTechnical pTest = ContextAdapter.Technical.EntryPoint.CreateJavaObject("java.awt.Point").Get<AwtPointTechnical>();
                pTest.SetLocation((int)pR.X, (int)pR.Y);

                int v = uiTech.getSelectedItemIndex(pTest);
                Mouse.PerformMouseAction(MouseOperation.MouseOver, pR);
            }
            //int count = uiTech.Rects.Count;
            //string rectString = uiTech.Rects.Get<JavaObjectTechnical>().FirstOrDefault().JavaToString;

            // List<AwtRectangleTechnical> rectsList = uiTech.Rects.Get<AwtRectangleTechnical>().ToList();



            AwtComponentTechnical compoenent = item.getComponent().Get<AwtComponentTechnical>();
            List<AwtComponentTechnical> descendents = compoenent.EntryPoint.GetDescendants((IAwtContainerTechnical)compoenent).Get<AwtComponentTechnical>().ToList();

            int c = descendents.Count();
            foreach (var desc in descendents)
            {

                string toString = desc.JavaToString;
                string name = desc.Name;

            }

            List<AwtButtonTechnical> buttons = compoenent.EntryPoint.GetDescendants((IAwtContainerTechnical)compoenent).Get<AwtButtonTechnical>().ToList();
            int cb = buttons.Count();
            foreach (var descb in buttons)
            {

                string toString = descb.JavaToString;
                string name = descb.Name;

            }
            //Technicals.References.IObjectReference objectReference = Technical.EntryPoint.CreateJavaObject("");

            // IAwtPointTechnical awtPointTechnical = compoenent.LocationOnScreen.Get<IAwtPointTechnical>();
            List<AwtComponentAdapterBase<AwtComponentTechnical>> adapters =
                AdapterFactory.CreateAdapters<AwtComponentAdapterBase<AwtComponentTechnical>>(compoenent, "Java").ToList();
            //AwtComponentAdapterBase<AwtComponentTechnical> awtComponentAdapterBase = adapters.First();
            //RectangleF boundsRect = awtComponentAdapterBase.ControlArea; //compoenent.Bounds.Get<AwtRectangleTechnical>();
            AwtRectangleTechnical rectBounds = compoenent.Bounds.Get<AwtRectangleTechnical>();
            //compoenent.
            int w = compoenent.Width;
            int h = compoenent.Height;
            bool vis = compoenent.Visible;

            PointF p = new PointF(rectBounds.X /*+ rectBounds.Width / 2*/, rectBounds.Y /*+ rectBounds.Height / 2*/);
            //PointF p = new PointF(boundsRect.X + boundsRect.Width / 2, boundsRect.Y + boundsRect.Height / 2);
            //PointF p = new PointF(compoenent.X, compoenent.Y);
            //PointF p = new PointF(x + 25, y + 150);


            //Mouse.PerformMouseAction(MouseOperation.Click, p);



            ContextAdapter.Technical.updateUI();


        }
    }

}
