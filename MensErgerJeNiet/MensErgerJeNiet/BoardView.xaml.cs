using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MensErgerJeNiet
{
    /// <summary>
    /// Interaction logic for BoardView.xaml
    /// </summary>
    public partial class BoardView : Window
    {
        //System.diagnostics.output.writeline
        private ImageSource aRed, aGreen, aYellow, aBlue, bRed, bGreen, bYellow, bBlue,
            cRed, cGreen, cYellow, cBlue, dRed, dGreen, dYellow, dBlue,
            srcField, BaseRed, BaseGreen, BaseYellow, BaseBlue,
            pawnRed, pawnGreen, pawnYellow, pawnBlue, startRed, startGreen, startYellow, startBlue;
        private Board myBoard;
        private int nRows = 11;
        private int nCols = 11;
        private int cellSize = 50;
        private Point startPoint = new Point(0, 0);
        public Label Dice { get; set; }

        public BoardView(Board myBoard)
        {
            InitializeComponent();
            this.myBoard = myBoard;
        
            aRed = new BitmapImage(new Uri("pack://application:,,,/images/aRed.png"));
            aGreen = new BitmapImage(new Uri("pack://application:,,,/images/aGreen.png"));
            aYellow = new BitmapImage(new Uri("pack://application:,,,/images/aYellow.png"));
            aBlue = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));

            bRed = new BitmapImage(new Uri("pack://application:,,,/images/bRed.png"));
            bGreen = new BitmapImage(new Uri("pack://application:,,,/images/bGreen.png"));
            bYellow = new BitmapImage(new Uri("pack://application:,,,/images/bYellow.png"));
            bBlue = new BitmapImage(new Uri("pack://application:,,,/images/bBlue.png"));

            cRed = new BitmapImage(new Uri("pack://application:,,,/images/cRed.png"));
            cGreen = new BitmapImage(new Uri("pack://application:,,,/images/cGreen.png"));
            cYellow = new BitmapImage(new Uri("pack://application:,,,/images/cYellow.png"));
            cBlue = new BitmapImage(new Uri("pack://application:,,,/images/cBlue.png"));

            dRed = new BitmapImage(new Uri("pack://application:,,,/images/dRed.png"));
            dGreen = new BitmapImage(new Uri("pack://application:,,,/images/dGreen.png"));
            dYellow = new BitmapImage(new Uri("pack://application:,,,/images/dYellow.png"));
            dBlue = new BitmapImage(new Uri("pack://application:,,,/images/dBlue.png"));

            BaseRed = new BitmapImage(new Uri("pack://application:,,,/images/BaseRed.png"));
            BaseGreen = new BitmapImage(new Uri("pack://application:,,,/images/BaseGreen.png"));
            BaseYellow = new BitmapImage(new Uri("pack://application:,,,/images/BaseYellow.png"));
            BaseBlue = new BitmapImage(new Uri("pack://application:,,,/images/BaseBlue.png"));

            pawnRed = new BitmapImage(new Uri("pack://application:,,,/images/pawnRed.png"));
            pawnGreen = new BitmapImage(new Uri("pack://application:,,,/images/pawnGreen.png"));
            pawnYellow = new BitmapImage(new Uri("pack://application:,,,/images/pawnYellow.png"));
            pawnBlue = new BitmapImage(new Uri("pack://application:,,,/images/pawnBlue.png"));

            startRed = new BitmapImage(new Uri("pack://application:,,,/images/startRed.png"));
            startGreen = new BitmapImage(new Uri("pack://application:,,,/images/startGreen.png"));
            startYellow = new BitmapImage(new Uri("pack://application:,,,/images/startYellow.png"));
            startBlue = new BitmapImage(new Uri("pack://application:,,,/images/startBlue.png"));

            srcField = new BitmapImage(new Uri("pack://application:,,,/images/Field.png"));

            for (int i = 0; i < nCols; i++)
            {
                ColumnDefinition col = new ColumnDefinition();
                col.Width = new GridLength(cellSize);
                FieldsGrid.ColumnDefinitions.Add(col);
            }

            for (int i = 0; i < nRows; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(cellSize);
                FieldsGrid.RowDefinitions.Add(row);
            }

            DrawBaseFiels();
            DrawBoard();

            Dice = new Label();
            Dice.FontSize = 35;
            Dice.HorizontalAlignment = HorizontalAlignment.Center;
            Dice.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetColumn(Dice, 5);
            Grid.SetRow(Dice, 5);
            FieldsGrid.Children.Add(Dice);
        }

        public void DrawBoard()
        {
            Field current = (Field) myBoard.Origin;
            int index = 0;
            int indextotal = 0;
            Point direction = new Point(1, -1);
            while (indextotal < 40)
            {
                Image currentImg = new Image();
                if (indextotal % 10 == 0) { index++; }
                switch (index)
                {
                    case 1: if(indextotal%10==0) {startPoint.X = 0; startPoint.Y = 4; direction.X = 1; direction.Y = -1;}
                        if (current.MyPawn != null) { currentImg.Source = SetPawnImage(current.MyPawn); }
                        else if (current.GetType() == typeof(Field)) { currentImg.Source = srcField; }
                        else if (current.GetType() == typeof(EndField)) { DrawHomeFields(startPoint, current); currentImg.Source = srcField; }
                        else if (current.GetType() == typeof(StartField)) { currentImg.Source = startYellow; }
                            DrawPlayField(direction, startPoint, currentImg, indextotal,index);
                        break;
                    case 2: if(indextotal%10==0) {startPoint.X = 6; startPoint.Y = 0; direction.X = 1; direction.Y = 1;}
                        if (current.MyPawn != null) { currentImg.Source = SetPawnImage(current.MyPawn); }
                        else if (current.GetType() == typeof(Field)) { currentImg.Source = srcField; }
                        else if (current.GetType() == typeof(EndField)) { DrawHomeFields(startPoint, current); currentImg.Source = srcField; }
                        else if (current.GetType() == typeof(StartField)) { currentImg.Source = startGreen; }
                            DrawPlayField(direction, startPoint, currentImg, indextotal,index);
                        break;
                    case 3:  if(indextotal%10==0) {startPoint.X = 10; startPoint.Y = 6; direction.X = -1; direction.Y = 1;}
                        if (current.MyPawn != null) { currentImg.Source = SetPawnImage(current.MyPawn); }
                        else if (current.GetType() == typeof(Field)) { currentImg.Source = srcField; }
                        else if (current.GetType() == typeof(EndField)) { DrawHomeFields(startPoint, current); currentImg.Source = srcField; }
                        else if (current.GetType() == typeof(StartField)) { currentImg.Source = startRed; }
                            DrawPlayField(direction, startPoint, currentImg, indextotal,index);
                        break;
                    case 4: if (indextotal % 10 == 0) { startPoint.X = 4; startPoint.Y = 10; direction.X = -1; direction.Y = -1; }
                        if (current.MyPawn != null) { currentImg.Source = SetPawnImage(current.MyPawn); }
                        else if (current.GetType() == typeof(Field)) { currentImg.Source = srcField; }
                        else if (current.GetType() == typeof(EndField)) { DrawHomeFields(startPoint, current); currentImg.Source = srcField; }
                        else if (current.GetType() == typeof(StartField)) { currentImg.Source = startBlue; }
                            DrawPlayField(direction, startPoint, currentImg,indextotal,index);
                        break;
                    default: break;
                }
                current = current.Next;
                indextotal++;
            }
        }

        public void DrawBaseFiels()
        {
            BaseField current = myBoard.OriginBaseField;
            Color currentColor = Color.Yellow;
            int index = 0;
            int indextotal = 0;
            while (current !=null)
            {
                Image currentImg = new Image();
                if (current.MyColor != currentColor) { index++; }
                switch (index)
                {
                    case 0: currentColor = Color.Yellow; startPoint.X = 0; startPoint.Y = 0;
                        if (current.MyPawn != null) { currentImg.Source = pawnYellow; } else { currentImg.Source = BaseYellow; }
                        DrawBaseFieldsSquare(currentImg, indextotal);
                        break;
                    case 1: currentColor = Color.Green; startPoint.X = 9; startPoint.Y = 0; 
                        if (current.MyPawn != null) { currentImg.Source = pawnGreen; } else { currentImg.Source = BaseGreen; }
                        DrawBaseFieldsSquare(currentImg, indextotal);
                        break;
                    case 2: currentColor = Color.Red; startPoint.X = 9; startPoint.Y = 9;
                        if (current.MyPawn != null) { currentImg.Source = pawnRed; } else { currentImg.Source = BaseRed; }
                        DrawBaseFieldsSquare(currentImg, indextotal);
                        break;
                    case 3: currentColor = Color.Blue; startPoint.X = 0; startPoint.Y = 9; 
                        if (current.MyPawn != null) { currentImg.Source = pawnBlue; } else { currentImg.Source = BaseBlue; }
                        DrawBaseFieldsSquare(currentImg, indextotal);
                        break;
                    default: break;
                }
                current = (BaseField) current.Next;
                indextotal++;
            }
        }

        public void DrawBaseFieldsSquare(Image currentImg, int indextotal)
        {
            switch (indextotal % 4)
            {
                case 1: startPoint.Y += 1; break;
                case 2: startPoint.Y += 1; startPoint.X += 1; break;
                case 3: startPoint.X += 1; break;
            }
            currentImg.SetValue(Grid.ColumnProperty, (int)startPoint.X);
            currentImg.SetValue(Grid.RowProperty, (int)startPoint.Y);

            FieldsGrid.Children.Add(currentImg);
            
        }

        public void DrawPlayField(Point direction, Point startPoint, Image currentImg, int indextotal, int index)
        {
            currentImg.SetValue(Grid.ColumnProperty, (int)startPoint.X);
            currentImg.SetValue(Grid.RowProperty, (int)startPoint.Y);

            FieldsGrid.Children.Add(currentImg);
     
            if (index % 2 == 1)
            {
                if (indextotal % 10 < 4)
                {
                    this.startPoint.X = (this.startPoint.X + (1 * direction.X));
                }
                if (indextotal % 10 > 3 && indextotal % 10 < 8)
                {
                    this.startPoint.Y = (this.startPoint.Y + (1 * direction.Y));
                }
                if (indextotal % 10 > 7 && indextotal % 10 < 10)
                {
                    this.startPoint.X = (this.startPoint.X + (1 * direction.X));
                }
            }
            else
            {
                if (indextotal % 10 < 4)
                {
                    this.startPoint.Y = (this.startPoint.Y + (1 * direction.Y));
                }
                if (indextotal % 10 > 3 && indextotal % 10 < 8)
                {
                    this.startPoint.X = (this.startPoint.X + (1 * direction.X));
                }
                if (indextotal % 10 > 7 && indextotal % 10 < 10)
                {
                    this.startPoint.Y = (this.startPoint.Y + (1 * direction.Y));
                }
            }
        }

        public void DrawHomeFields(Point startPoint, Field current)
        {
            Point endFieldPoint = new Point(startPoint.X, startPoint.Y);
            int index = 0;

            while (current.NextHome != null)
            {
                Image img = new Image();
                switch (current.NextHome.MyColor)
                {
                    case Color.Yellow:
                        switch(index)
                        {
                            case 0: startPoint.Y += 1; if (current.MyPawn != null) { img.Source = SetPawnImage(current.MyPawn); } else { img.Source = aGreen; } break;
                            case 1: startPoint.Y += 1; if (current.MyPawn != null) { img.Source = SetPawnImage(current.MyPawn); } else { img.Source = bGreen; } break;
                            case 2: startPoint.Y += 1; if (current.MyPawn != null) { img.Source = SetPawnImage(current.MyPawn); } else { img.Source = cGreen; } break;
                            case 3: startPoint.Y += 1; if (current.MyPawn != null) { img.Source = SetPawnImage(current.MyPawn); } else { img.Source = dGreen; } break;
                        }
                        img.SetValue(Grid.ColumnProperty, (int)startPoint.X);
                        img.SetValue(Grid.RowProperty, (int)startPoint.Y);
                        FieldsGrid.Children.Add(img);
                        break;
                    case Color.Green:
                        switch(index)
                        {
                            case 0: startPoint.X -= 1; if (current.MyPawn != null) { img.Source = SetPawnImage(current.MyPawn); } else { img.Source = aRed; } break;
                            case 1: startPoint.X -= 1; if (current.MyPawn != null) { img.Source = SetPawnImage(current.MyPawn); } else { img.Source = bRed; } break;
                            case 2: startPoint.X -= 1; if (current.MyPawn != null) { img.Source = SetPawnImage(current.MyPawn); } else { img.Source = cRed; } break;
                            case 3: startPoint.X -= 1; if (current.MyPawn != null) { img.Source = SetPawnImage(current.MyPawn); } else { img.Source = dRed; } break;
                        }
                        img.SetValue(Grid.ColumnProperty, (int)startPoint.X);
                        img.SetValue(Grid.RowProperty, (int)startPoint.Y);
                        FieldsGrid.Children.Add(img);
                        break;
                    case Color.Red:
                        switch(index)
                        {
                            case 0: startPoint.Y -= 1; if (current.MyPawn != null) { img.Source = SetPawnImage(current.MyPawn); } else { img.Source = aBlue; } break;
                            case 1: startPoint.Y -= 1; if (current.MyPawn != null) { img.Source = SetPawnImage(current.MyPawn); } else { img.Source = bBlue; } break;
                            case 2: startPoint.Y -= 1; if (current.MyPawn != null) { img.Source = SetPawnImage(current.MyPawn); } else { img.Source = cBlue; } break;
                            case 3: startPoint.Y -= 1; if (current.MyPawn != null) { img.Source = SetPawnImage(current.MyPawn); } else { img.Source = dBlue; } break;
                        }
                        img.SetValue(Grid.ColumnProperty, (int)startPoint.X);
                        img.SetValue(Grid.RowProperty, (int)startPoint.Y);
                        FieldsGrid.Children.Add(img);
                        break;
                    case Color.Blue:
                        switch(index)
                        {
                            case 0: startPoint.X += 1; if (current.MyPawn != null) { img.Source = SetPawnImage(current.MyPawn); } else { img.Source = aYellow; } break;
                            case 1: startPoint.X += 1; if (current.MyPawn != null) { img.Source = SetPawnImage(current.MyPawn); } else { img.Source = bYellow; } break;
                            case 2: startPoint.X += 1; if (current.MyPawn != null) { img.Source = SetPawnImage(current.MyPawn); } else { img.Source = cYellow; } break;
                            case 3: startPoint.X += 1; if (current.MyPawn != null) { img.Source = SetPawnImage(current.MyPawn); } else { img.Source = dYellow; } break;
                        }
                        img.SetValue(Grid.ColumnProperty, (int)startPoint.X);
                        img.SetValue(Grid.RowProperty, (int)startPoint.Y);
                        FieldsGrid.Children.Add(img);
                        break;
                }
                index++;
                current = current.NextHome;
            }

            startPoint = endFieldPoint;
        }

        public ImageSource SetPawnImage(Pawn myPawn)
        {
            ImageSource img = null;
            switch (myPawn.MyColor)
            {
                case Color.Red: img = pawnRed; break;
                case Color.Yellow: img = pawnYellow; break;
                case Color.Blue: img = pawnBlue; break;
                case Color.Green: img = pawnGreen; break;
            }
            return img;
        }
    }
}

