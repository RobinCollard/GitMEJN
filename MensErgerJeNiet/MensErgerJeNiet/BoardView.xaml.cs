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

            noField = new BitmapImage(new Uri("pack://application:,,,/images/noField.png"));
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
        }

        public void DrawBoard() //TODO!!! code gekopiëerd van andere methode,nu nog aanpassen
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
                    case 0: startPoint.X = 0; startPoint.Y = 5;
                        if (current.MyPawn != null) { currentImg.Source = SetPawnImage(current.MyPawn); }
                        else if (current.GetType() == typeof(Field) || current.GetType() == typeof(EndField)) { currentImg.Source = srcField; }
                        else if (current.GetType() == typeof(StartField)) { currentImg.Source = startYellow; }
                        DrawPlayField(direction, startPoint, currentImg);
                        break;
                    case 1: startPoint.X = 7; startPoint.Y = 0; direction.X = 1; direction.Y = 1;
                        if (current.MyPawn != null) { currentImg.Source = SetPawnImage(current.MyPawn); }
                        else if (current.GetType() == typeof(Field) || current.GetType() == typeof(EndField)) { currentImg.Source = srcField; }
                        else if (current.GetType() == typeof(StartField)) { currentImg.Source = startGreen; }
                        DrawPlayField(direction, startPoint, currentImg);
                        break;
                    case 2: startPoint.X = 10; startPoint.Y = 7; direction.X = -1; direction.Y = 1;
                        if (current.MyPawn != null) { currentImg.Source = SetPawnImage(current.MyPawn); }
                        else if (current.GetType() == typeof(Field) || current.GetType() == typeof(EndField)) { currentImg.Source = srcField; }
                        else if (current.GetType() == typeof(StartField)) { currentImg.Source = startRed; }
                        DrawPlayField(direction, startPoint, currentImg);
                        break;
                    case 3: startPoint.X = 5; startPoint.Y = 10; direction.X = -1; direction.Y = -1;
                        if (current.MyPawn != null) { currentImg.Source = SetPawnImage(current.MyPawn); }
                        else if (current.GetType() == typeof(Field) || current.GetType() == typeof(EndField)) { currentImg.Source = srcField; }
                        else if (current.GetType() == typeof(StartField)) { currentImg.Source = startBlue; }
                        DrawPlayField(direction, startPoint, currentImg);
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
                    case 1: currentColor = Color.Green; startPoint.X = 0; startPoint.Y = 9; 
                        if (current.MyPawn != null) { currentImg.Source = pawnGreen; } else { currentImg.Source = BaseGreen; }
                        DrawBaseFieldsSquare(currentImg, indextotal);
                        break;
                    case 2: currentColor = Color.Red; startPoint.X = 9; startPoint.Y = 9;
                        if (current.MyPawn != null) { currentImg.Source = pawnRed; } else { currentImg.Source = BaseRed; }
                        DrawBaseFieldsSquare(currentImg, indextotal);
                        break;
                    case 3: currentColor = Color.Blue; startPoint.X = 9; startPoint.Y = 0; 
                        if (current.MyPawn != null) { currentImg.Source = pawnBlue; } else { currentImg.Source = BaseBlue; }
                        DrawBaseFieldsSquare(currentImg, indextotal);
                        break;
                    default: break;
                }
                current = (BaseField) current.Next;
                indextotal++;
            }
        }

        private void DrawBaseFieldsSquare(Image currentImg, int indextotal)
        {
            switch (indextotal % 4)
            {
                case 1: startPoint.Y += 1; break;
                case 2: startPoint.Y += 1; startPoint.X += 1; break;
                case 3: startPoint.X += 1; break;
            }
            currentImg.SetValue(Grid.RowProperty, (int) startPoint.X);
            currentImg.SetValue(Grid.ColumnProperty, (int) startPoint.Y);

            FieldsGrid.Children.Add(currentImg);
            
        }

        private void DrawPlayField(Point direction, Point startPoint, Image currentImg)
        {
            currentImg.SetValue(Grid.RowProperty, (int)startPoint.X);
            currentImg.SetValue(Grid.ColumnProperty, (int)startPoint.Y);

            FieldsGrid.Children.Add(currentImg);

            startPoint.X = (startPoint.X + (1 * direction.X));
            startPoint.Y = (startPoint.Y + (1 * direction.Y));
        }

        private ImageSource SetPawnImage(Pawn myPawn)
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

