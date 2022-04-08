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
using Tricentis.Automation.Simulation;

namespace Tricentis.Automation.Engines.Adapters.JavaSwing.Jide
{
    [SupportedTechnical(typeof(SidePaneGroupTechnical))]
    public class JideTabItemAdapter : GuiAdapter<SidePaneGroupTechnical>, ITabItemAdapter
    {
        public JideTabControlAdapter ParentTabControl;

        public int Index;

        public JideTabItemAdapter(SidePaneGroupTechnical technical, Validator validator) : base(technical, validator)
        {
        }

        public bool Closable => false;

        public PointF CloseActionPoint => new PointF();

        public bool Selected => false;// Technical.getItemAtIndex(0).Get<SidePaneItemTechnical>().IsSelected();

        public string Text => Technical.getItemAtIndex(0).Get<SidePaneItemTechnical>().getTitle();

        public override bool Enabled => true;

        public override bool Focused => true;

        public override bool InteractiveElement => true;

        public override bool IsSteerable => true;

        public override bool Visible => true;

        public override string DefaultName => Text;

        public void Close()
        {
        }

        public override bool IsInViewPort()
        {
            return true;
        }

        public override void ScrollToVisible()
        {
        }

        public void Select()
        {
            int index = Technical.getSelectedIndex();
            SidePaneItemTechnical item = Technical.getItemAtIndex(0).Get<SidePaneItemTechnical>();


            //// SidePaneItemTechnical item2 = Technical.getItemAtIndex(1).Get<SidePaneItemTechnical>();
            //item.SetSelected(true);
            //Technical.SetSelectedIndex(0);
            ////Technical.fireSidePaneEvent(item, 4100);
            //Technical.fireSidePaneEvent(item, 4099);

            //SwingImageIconTechnical icon = item.getIcon().Get<SwingImageIconTechnical>();
            //int iconHeight = icon.IconHeight;
            //int iconWidth = icon.IconWidth;
            //string titel = item.getTitle();

            BasicSidePaneUITechnical uiTech = ParentTabControl.Technical.getUI().Get<BasicSidePaneUITechnical>();
            List<AwtRectangleTechnical> rectList = uiTech.Rects.Get<AwtRectangleTechnical>().ToList();
            int count = uiTech.Rects.Count;

            AwtRectangleTechnical groupRect = rectList[Index];
            PointF pR = new PointF(groupRect.X + groupRect.Width / 2 + ParentTabControl.ControlArea.X,
                groupRect.Height / 2 + groupRect.Y + ParentTabControl.ControlArea.Y);
            Mouse.PerformMouseAction(MouseOperation.Click, pR);
            return;

            int x = ParentTabControl.Technical.X;
            int y = ParentTabControl.Technical.Y;
            List<AwtComponentTechnical> componenets = ParentTabControl.Technical.Components.Get<AwtComponentTechnical>().ToList();
            AwtComponentTechnical compAt = ParentTabControl.Technical.ComponentAt(x, y).Get<AwtComponentTechnical>();
            AwtComponentTechnical compAt2 = ParentTabControl.Technical.ComponentAt(x + 25, y + 150).Get<AwtComponentTechnical>();


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
            List<JavaAwt.AwtComponentAdapterBase<AwtComponentTechnical>> adapters = 
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



            ParentTabControl.Technical.updateUI();


        }

        public override void SetFocus()
        {
            
        }

        protected override RectangleF GetRefreshedControlArea(bool refreshContext)
        {
            return new RectangleF();
        }
    }
}