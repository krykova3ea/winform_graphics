using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public List<Point> arPoints = new List<Point>();//массив точек, с которым работаем
        public List<Point> arPointsTemp = new List<Point>();//массив точек для движения
        public List<Point> arPointsSave = new List<Point>();//массив точек для сохранения
        public Size PointSize { get; set; } = new Size(10,10);//размер точки
        public float PointRadius { get; set; } = 10;//радиус точки
        public Color PointColor { get; set; } = Color.Black;//цвет точки по умолчанию
        public Color LineColor { get; set; } = Color.CornflowerBlue;//цвет линии по умолчанию
        public Color PointColorSave { get; set; } = Color.Black;//цвет точки в сохранении
        public Color LineColorSave { get; set; } = Color.CornflowerBlue;//цвет линии в сохранении
        private Timer moveTimer = new Timer();
        public bool bPoints = false; // проверка, можно ли ставить точку
        public bool bDrag = false;//проверка перемещения точки
        public bool bMove = false;//проверка движения точки
        public bool bSave = false;//проверка сохранения точки
        public int lineWidth = 6;//толщина линии
        public LineType LineTypeToShow;//линия соединения точки
        public LineType LineTypeSave;//линия соединения точки в сохранении
        public int iPointToDrag;//индекс перемещаемой точки
        public enum LineType { None, Curve, Bezier, Polygone, FilledCurve };//виды линий
        public Form1()
        { 
            InitializeComponent();
            Paint += Form1_Paint;
            KeyPreview = true; 
            KeyDown += new KeyEventHandler(Form1_KeyDown);
            moveTimer.Interval = 30; 
            moveTimer.Tick += new EventHandler(TimerTickHandler);
            MouseClick += new MouseEventHandler(Form1_MouseClick);
            MouseMove += new MouseEventHandler(Form1_MouseMove);
            MouseUp += new MouseEventHandler(Form1_MouseUp);
            MouseDown += new MouseEventHandler(Form1_MouseDown);
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
        }
        //кнопка Точки
        private void button_PointClick(object sender, EventArgs e)
        {
            bPoints = !bPoints;
            bDrag = false;
            bMove = false;
            Refresh();
        }
        //кнопка Параметры
        private void button_ColourClick(object sender, EventArgs e)
        {
            bPoints = false;
            bDrag = false;
            bMove = false;
            ColourForm newForm = new ColourForm(this);
            newForm.Show();
        }
        //кнопка Кривая
        private void button_CurvClick(object sender, EventArgs e)
        {
            if (arPoints.Count>1)
            if (LineTypeToShow!=LineType.Curve)
                LineTypeToShow = LineType.Curve;
            else LineTypeToShow= LineType.None;
            if (bPoints)
                button1.PerformClick();
            Refresh();
        }
        //кнопка Ломаная
        private void button_PolygonClick(object sender, EventArgs e)
        {
            if (arPoints.Count > 1)
                if (LineTypeToShow != LineType.Polygone)
                    LineTypeToShow = LineType.Polygone;
                else LineTypeToShow = LineType.None;
            if (bPoints)
                button1.PerformClick();
            Refresh();
        }
        //кнопка Безье
        private void button_BezierClick(object sender, EventArgs e)
        {
            if (arPoints.Count > 1)
                if (LineTypeToShow != LineType.Bezier)
                    LineTypeToShow = LineType.Bezier;
                else LineTypeToShow = LineType.None;
            if (bPoints)
                button1.PerformClick();
            Refresh();

        }
        //кнопка Заполненная
        private void button_FilledClick(object sender, EventArgs e)
        {
            if (arPoints.Count > 1)
                if (LineTypeToShow != LineType.FilledCurve)
                    LineTypeToShow = LineType.FilledCurve;
                else LineTypeToShow = LineType.None;
            if (bPoints)
                button1.PerformClick();
            Refresh();
        }
        //кнопка Движение
        private void button_MoveClick(object sender, EventArgs e)
        {
            bDrag = false;
            if(arPoints.Count==0)
                bMove= false;
            else
            {
                button7.Enabled = true;
                bMove = !bMove;
            }
            if (bMove)
            {
                arPointsTemp = new List<Point>();
                int x = 4;
                int y = 4;
                for (int i = 0; i < arPoints.Count; i++)
                {
                    arPointsTemp.Add(new Point(x, y));
                }
                moveTimer.Start();
            }
            else
                moveTimer.Stop();
        }
        //кнопка Очистить
        private void button_ClearClick(object sender, EventArgs e)
        {
            moveTimer.Stop();
            arPoints.Clear();
            arPointsTemp.Clear();
            bDrag = false;
            bMove = false;
            bPoints = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            if (bSave)
                button10.Enabled = true;
            LineTypeToShow = LineType.None;
            PointColor = Color.Black;
            LineColor = Color.CornflowerBlue;
            Refresh();

        }
        //кнопка Сохранение
        private void button_SaveClick(object sender, EventArgs e)
        {
            arPointsSave.Clear();
            moveTimer.Stop();
            for (int i = 0; i < arPoints.Count; i++)
                arPointsSave.Add(arPoints[i]);
            LineTypeSave = LineTypeToShow;
            LineColorSave = LineColor;
            PointColorSave= PointColor;
            button10.Enabled = true;
            bSave = true;
        }
        //кнопка Загрузка
        private void button_LoadClick(object sender, EventArgs e)
        {
            if (arPointsSave.Count != 0)
            {
                moveTimer.Stop();
                if (arPointsSave.Count > 3)
                {
                    button5.Enabled = true;
                }
                button3.Enabled = true;
                button4.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                arPoints.Clear();
                for (int i = 0; i < arPointsSave.Count; i++)
                    arPoints.Add(arPointsSave[i]);
                arPointsTemp.Clear();
                bDrag = false;
                bMove = false;
                bPoints = false;
                LineTypeToShow = LineTypeSave;
                PointColor = PointColorSave;
                LineColor = LineColorSave;
            }
            Refresh();
        }
        //прорисовка фигуры
        void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (arPoints.Count>0)
            {
                ShowPoints(g);
                if (LineTypeToShow != LineType.None)
                {
                    ShowLine(g,LineTypeToShow);
                }
            }
         
        }
        //прорисовка поставленных точек
        void ShowPoints(Graphics g)
        {
            foreach (var p in arPoints)
                g.FillEllipse(new SolidBrush(PointColor), p.X, p.Y, PointSize.Width, PointSize.Height);
        }
        //прорисовка линий
        void ShowLine(Graphics g, LineType type)
        {
            SolidBrush brush = new SolidBrush(LineColor);
            Pen pen= new Pen(brush,lineWidth);
            switch (type) 
            {
                case LineType.Polygone:
                    g.DrawPolygon(pen,arPoints.ToArray());
                    break;
                case LineType.FilledCurve:
                    g.FillClosedCurve(brush, arPoints.ToArray());
                    break;
                case LineType.Curve:
                    if (arPoints.Count > 2)
                        g.DrawClosedCurve(pen, arPoints.ToArray());
                    break;
                case LineType.Bezier:
                    if (arPoints.Count>3 && (arPoints.Count-1)%3==0)
                        g.DrawBeziers(pen, arPoints.ToArray());
                    break;
                default:break;
            }
        }
        //функция для реализации движения
        void TimerTickHandler(object sender, EventArgs e)
        {
            MovePoints();
            Refresh();
        }
        //движение
        void MovePoints()
        {
            int x, y;
            if (bPoints)
                button1.PerformClick();
            for (int i=0;i<arPoints.Count;i++)
            {
                x = arPoints[i].X + arPointsTemp[i].X;
                if(x >= this.ClientRectangle.Width || x <= 110)
                {
                    arPointsTemp[i] = new Point(-arPointsTemp[i].X, arPointsTemp[i].Y);
                    x = arPoints[i].X + arPointsTemp[i].X;
                }
                y = arPoints[i].Y + arPointsTemp[i].Y;
                if (y >= this.ClientRectangle.Height || y <= 0)
                {
                    arPointsTemp[i] = new Point(arPointsTemp[i].X, -arPointsTemp[i].Y);
                    y = arPoints[i].Y + arPointsTemp[i].Y;
                }
                arPoints[i]= new Point(x, y);
            }
        }
        //использование кнопок +, -, Space, Escape
        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.Oemplus):
                    if (arPointsTemp.Count > 0)
                    {
                        int x = 0, y = 0;
                        for (int i = 0; i < arPointsTemp.Count; i++)
                        {
                            if (arPointsTemp[i].X > 0)
                                x = 1;
                            if (arPointsTemp[i].X < 0)
                                x = -1;
                            if (arPointsTemp[i].Y > 0)
                                y = 1;
                            if (arPointsTemp[i].Y < 0)
                                y = -1;
                            arPointsTemp[i] = new Point(arPointsTemp[i].X + x, arPointsTemp[i].Y + y);
                        }
                    }
                    e.Handled = true;
                    break;
                case (Keys.OemMinus):
                    if (arPointsTemp.Count > 0 && bMove == true)
                    {
                        int x = 0, y = 0;
                        for (int i = 0; i < arPointsTemp.Count; i++)
                        {
                            if (arPointsTemp[i].X > 1)
                                x = -1;
                            if (arPointsTemp[i].X < -1)
                                x = 1;
                            if (arPointsTemp[i].Y > 1)
                                y = -1;
                            if (arPointsTemp[i].Y < -1)
                                y = 1;
                            arPointsTemp[i] = new Point(arPointsTemp[i].X + x, arPointsTemp[i].Y + y);
                        }
                    }
                    e.Handled = true;
                    break;
                case (Keys.Space):
                    button_MoveClick(sender, e);
                    e.Handled = true;
                    break;
                case (Keys.Escape):
                    button_ClearClick(sender,e);
                    e.Handled = true;
                    break;
                default: break; 
            }
        }
        //использование стрелочек
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool IsHandled = true;
            switch (keyData)
            {
                case Keys.Up:
                    if (!bMove)
                    {
                        for (int i = 0; i < arPoints.Count; i++)
                        {
                            if (arPoints.Min(a => a.Y) == 0)
                                break;
                            arPoints[i] = new Point(arPoints[i].X, arPoints[i].Y - 1);
                        }
                        Refresh();
                    }
                    break;
                case Keys.Down:
                    if (!bMove)
                    {
                        for (int i = 0; i < arPoints.Count; i++)
                        {
                            if (arPoints.Max(a => a.Y) == this.ClientRectangle.Height - lineWidth)
                                break;
                            arPoints[i] = new Point(arPoints[i].X, arPoints[i].Y + 1);
                        }
                        Refresh();
                    }
                    break;
                case Keys.Left:
                    if (!bMove)
                    {
                        for (int i = 0; i < arPoints.Count; i++)
                        {
                            if (arPoints.Min(a => a.X) == 0)
                                break;
                            arPoints[i] = new Point(arPoints[i].X - 1, arPoints[i].Y);
                        }
                        Refresh();
                    }
                    break;
                case Keys.Right:
                    if (!bMove)
                    {
                        for (int i = 0; i < arPoints.Count; i++)
                        {
                            if (arPoints.Max(a => a.X) == this.ClientRectangle.Width - lineWidth)
                                break;
                            arPoints[i] = new Point(arPoints[i].X + 1, arPoints[i].Y);
                        }
                        Refresh();
                    }
                    break;
                default:
                    IsHandled = false;
                    break;
            }
            return IsHandled;
        }
        //перемещение точек мышкой
        void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (bDrag)
            {
                arPoints[iPointToDrag] = new Point(e.Location.X, e.Location.Y);
                Refresh();
            }
        }
        //конец перемещения мышкой
        void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            bDrag = false;
        }
        //нажатие мышкой на точку
        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < arPoints.Count; i++)
            {
                if (IsOnPoint(arPoints[i], e.Location))
                {
                    bDrag = true;
                    iPointToDrag = i;
                    break;
                }
            }

        }
        //проверка, произошло ли нажатие мышкой на точку
        bool IsOnPoint(Point pPixel, Point pMouse)
        {
            if (pMouse.X >= pPixel.X - PointSize.Width / 2 &&
                pMouse.X <= pPixel.X + PointSize.Width / 2 &&
                pMouse.Y >= pPixel.Y - PointSize.Height / 2 &&
                pMouse.Y <= pPixel.Y + PointSize.Height / 2)
                return true;
            else
                return false;

        }
        //клик мышкой для создания точек
        void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Point p;
            if (e.X > 110)
            {
                p = e.Location;
                if (bPoints)
                {
                    arPoints.Add(p);
                    LineTypeToShow = LineType.None;
                    if(arPoints.Count!=0)
                    {
                        if (arPoints.Count>3)
                        {
                            button5.Enabled = true;
                        }
                        button3.Enabled = true;
                        button4.Enabled = true;
                        button6.Enabled = true;
                        button7.Enabled = true;
                        button8.Enabled = true;
                        button9.Enabled = true;
                    }
                    Refresh();
                }
            }
        }
    }
}
