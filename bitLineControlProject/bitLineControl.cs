/// LINE CONTROL BY MUHAMMAD AMIR (SYSTEM DESIGN ANALYST PROGRAMMER)
/// EMAIL:  mamirbalouch@yahoo.com
///         mamirbalouch@hotmail.com
///**************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace bitLineControlProject
{
    public partial class bitLineControl : UserControl
    {
        #region PRIVATE VARIABLES
        private GraphicsPath _outline = new GraphicsPath();      //to store graphics path
        private Color _linecolor = Color.Red;
        private int _border = 3;
        #endregion

        #region PROPERTIES

        public Color LineColor
        {
            get { return _linecolor; }
            set { _linecolor = value; }
        }

        public int LineBorder
        {
            get{ return _border;}
            set { _border = value;}
        }
        #endregion

        #region CONSTRUCTORS
        public bitLineControl()
        {
            Point firstpoint = new Point(0, 0);
            Point secondpoint = new Point(50, 50);

            //CALLING FUNCTION TO DRAW LINE
            drawLine(firstpoint, secondpoint);
        }//bitLineControl()

        public bitLineControl(Point firstpoint, Point secondpoint)
        {
            //CALLING FUNCTION TO DRAW LINE
            drawLine(firstpoint, secondpoint);
        }//bitLineControl(Point firstpoint, Point secondpoint)
        #endregion

        #region OVERRIDE EVENTS
        protected override void OnPaint(PaintEventArgs pe)
        {
            Pen p = new Pen(_linecolor, _border);
            p.DashStyle = DashStyle.Solid;
            pe.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            pe.Graphics.DrawPath(p, this._outline);

            this.Region = new Region(this._outline);
            p.Dispose();

            base.OnPaint(pe);
        }//onPaint

        protected override void OnResize(EventArgs e)
        {
            this.Region = new Region(_outline);
            this.Refresh();
            base.OnResize(e);
        }//onResize

        #endregion

        #region ROTATE CODING
        public void rotateByAngle(float degree)
        {
            PointF refPoint = new PointF(
                 this.Left,
                 this.Top);

            rotateByAngle(degree, refPoint);
        }

        public void rotateByAngle(float angleForRotation, PointF point)
        {
            Matrix m = new Matrix();
            PointF[] gpPoints = new PointF[4];
            //    m.RotateAt(angleForRotation, point);
            m.Rotate(angleForRotation);
            _outline.Transform(m);

            //after rotation, graphics path needs to be refereshed
            //as some points may have negative values;
            //following code resets all the points
            _outline = setOutlineBounds(_outline);
            //----------------------------------------------

            //setting the bounds of control
            gpPoints = setInitialPoints(_outline.PathPoints);
            //-----------------------------

            _outline.Reset();
            _outline.AddPolygon(gpPoints);
            this.Refresh();

        }//angleForRotation
        #endregion

        #region SUPPORTING FUNCTIONS
        private void drawLine(Point firstpoint, Point secondpoint)
        {
            #region INITIALIZATION AND SETTING STYLE
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer |
                 ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.UserPaint |
                 ControlStyles.SupportsTransparentBackColor, true);
            this.UpdateStyles();
            #endregion
            Point[] _points = new Point[4];

            _points[0] = firstpoint;
            _points[1] = secondpoint;
            int x1 = firstpoint.X;
            int x2 = secondpoint.X;
            int y1 = firstpoint.Y;
            int y2 = secondpoint.Y;

            //_points[0] = new Point(secondpoint.X - _border, secondpoint.Y - _border);
            //_points[1] = new Point(firstpoint.X - _border, firstpoint.Y - _border);
            _points[2] = new Point(secondpoint.X + _border, secondpoint.Y + _border);
            _points[3] = new Point(firstpoint.X + _border, firstpoint.Y + _border);

            _points = setInitialPoints(_points);
            _outline.AddPolygon(_points);

            _points[0] = new Point(secondpoint.X + _border, secondpoint.Y + _border);
            _points[1] = new Point(firstpoint.X - _border, firstpoint.Y + _border);
            _points[2] = new Point(secondpoint.X + _border, secondpoint.Y - _border);
            _points[3] = new Point(firstpoint.X - _border, firstpoint.Y - _border);

            _points = setInitialPoints(_points);
            _outline.AddPolygon(_points);

            this.Width += 2;
        }//drawLine()

        private void InvalidateEx()
        {
            Invalidate();
            //let parent redraw the background
            if (Parent == null)
                return;
            Rectangle rc = new Rectangle(this.Location, this.Size);
            Parent.Invalidate(rc, true);

            //move and refresh the controls here
        }

        private Point[] setInitialPoints(Point[] oldPoints)
        {
            int theXvalue = 0;
            int theYvalue = 0;
            int maxX = 0;
            int maxY = 0;

            GraphicsPath gp = new GraphicsPath();
            Point[] newPoint = new Point[oldPoints.Length];
            Point oldValue = new Point();


            foreach (Point p in oldPoints)
            {
                if (oldValue.IsEmpty) { theXvalue = p.X; theYvalue = p.Y; maxX = p.X; maxY = p.Y; }
                else
                {
                    if (theXvalue > p.X) theXvalue = p.X;
                    if (theYvalue > p.Y) theYvalue = p.Y;

                    if (maxX < p.X) maxX = p.X;
                    if (maxY < p.Y) maxY = p.Y;
                }
                oldValue = p;
            }

            this.Left = (int)theXvalue;
            this.Top = (int)theYvalue;
            this.Width = (int)(maxX - theXvalue);
            this.Height = (int)(maxY - theYvalue);
            this.Width += 5;
            this.Height += 10;
            if (this.Height <= 0) this.Height = 5;
            if (this.Width <= 0) this.Width = 5;

            if (theXvalue != 0) theXvalue = -(theXvalue);
            if (theYvalue != 0) theYvalue = -(theYvalue);

            int i = 0;
            foreach (Point p in oldPoints)
            {

                newPoint[i].X = p.X + theXvalue;
                newPoint[i].Y = p.Y + theYvalue;
                i++;
            }
            return newPoint;
        }//setInitialPoint(Point[] oldPoints)

        private PointF[] setInitialPoints(PointF[] oldPoints)
        {
            float theXvalue = 0f;
            float theYvalue = 0f;
            float maxX = 0f;
            float  maxY = 0f;

            GraphicsPath gp = new GraphicsPath();
            PointF[] newPoint = new PointF[oldPoints.Length];
            PointF oldValue = new PointF();


            foreach (PointF p in oldPoints)
            {
                if (oldValue.IsEmpty) { theXvalue = p.X; theYvalue = p.Y; maxX = p.X; maxY = p.Y; }
                else
                {
                    if (theXvalue > p.X) theXvalue = p.X;
                    if (theYvalue > p.Y) theYvalue = p.Y;

                    if (maxX < p.X) maxX = p.X;
                    if (maxY < p.Y) maxY = p.Y;
                }
                oldValue = p;
            }

            //this.Left = (int)theXvalue;
            //this.Top = (int)theYvalue;
            this.Width = (int)(maxX );
            this.Height = (int)(maxY );
            this.Width += 5;
            this.Height += 10;
            if (this.Height <= 0) this.Height = 5;
            if (this.Width <= 0) this.Width = 5;

           // if (theXvalue != 0) theXvalue = -(theXvalue);
           // if (theYvalue != 0) theYvalue = -(theYvalue);

            int i = 0;
            foreach (PointF p in oldPoints)
            {

                newPoint[i].X = p.X + theXvalue;
                newPoint[i].Y = p.Y + theYvalue;
                i++;
            }
            return newPoint;
        }//setInitialPoint(Point[] oldPoints)

        private GraphicsPath setOutlineBounds(GraphicsPath outline)
        {
            //after rotation, graphics path needs to be refereshed
            //as some points may have negative values;
            //following code resets all the points

            float theXvalue = 0f;
            float theYvalue = 0f;
            Boolean firstRecursion = true;

            GraphicsPath gp = new GraphicsPath();
            PointF[] newPoint = new PointF[4];
            PointF oldValue = new PointF();


            foreach (PointF p in outline.PathPoints)
            {
                if (firstRecursion) { theXvalue = p.X; theYvalue = p.Y; }
                else
                {
                    if (theXvalue > p.X) theXvalue = p.X;
                    if (theYvalue > p.Y) theYvalue = p.Y;
                }
                firstRecursion = false;
                oldValue = p;
            }

            if (theXvalue != 0) theXvalue = -(theXvalue);
            if (theYvalue != 0) theYvalue = -(theYvalue);

            int i = 0;
            foreach (PointF p in outline.PathPoints)
            {

                newPoint[i].X = p.X + theXvalue + 1;
                newPoint[i].Y = p.Y + theYvalue + 1;
                i++;
            }

            gp.AddPolygon(newPoint);
            return gp;
        }

        #endregion

    }//class
}//namespace