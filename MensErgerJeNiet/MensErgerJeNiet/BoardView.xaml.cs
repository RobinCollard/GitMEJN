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
        private ImageSource aRed, aGreen, aYellow, aBlue, bRed, bGreen, bYellow, bBlue,
            cRed, cGreen, cYellow, cBlue, dRed, dGreen, dYellow, dBlue,
            srcField, BaseRed, BaseGreen, BaseYellow, BaseBlue, noField,
            pawnRed, pawnGreen, pawnYellow, pawnBlue, startRed, startGreen, startYellow, startBlue;
        public BoardView()
        {
            InitializeComponent();
        
            aRed = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));
            aGreen = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));
            aYellow = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));
            aBlue = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));

            bRed = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));
            bGreen = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));
            bYellow = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));
            bBlue = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));

            cRed = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));
            cGreen = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));
            cYellow = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));
            cBlue = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));

            dRed = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));
            dGreen = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));
            dYellow = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));
            dBlue = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));

            BaseRed = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));
            BaseGreen = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));
            BaseYellow = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));
            BaseBlue = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));

            pawnRed = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));
            pawnGreen = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));
            pawnYellow = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));
            pawnBlue = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));

            startRed = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));
            startGreen = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));
            startYellow = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));
            startBlue = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));

            noField = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));
            srcField = new BitmapImage(new Uri("pack://application:,,,/images/aBlue.png"));

            int nRows = 11;
            int nCols = 11;
            int cellSize = 50;

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
        }
    }
}

