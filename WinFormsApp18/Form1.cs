namespace WinFormsApp18
{
    public partial class Form1 : Form
    {
        private double r = 0;
        private double R = 0;
        private double t = 0;
        private double m; 
        
        public Form1()
        {
            InitializeComponent();
            
            // Задаємо початкові значення для r, R та t
           
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            // Отримуємо значення r, R та t з текстових полів
            if (!double.TryParse(txtRR.Text, out R) || !double.TryParse(txtr.Text, out r) || !double.TryParse(txtT.Text, out t))
            {
                MessageBox.Show("Некоректні значення для r, R або t");
                return;
            }

            // Розрахунок m за формулою m = r/R
            m = r / R;

            // Очищаємо попередній графік
            graphPictureBox.Refresh();

            // Розрахунок та побудова графіку
            using (Graphics g = graphPictureBox.CreateGraphics())
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                double dt = 0.01; // Крок зміни t

                // Задаємо область визначення функції (можна змінити за потреби)
                double tMin = -10;
                double tMax = 10;

                // Знаходимо координати першої точки
                double xPrev = (R + m * R) * Math.Cos(m * t) - m * Math.Cos(t + m * t);
                double yPrev = (R + m * R) * Math.Sin(m * t) - m * Math.Sin(t + m * t);

                // Перетворюємо координати відповідно до розмірів PictureBox
                float xPrevPixel = (float)(graphPictureBox.Width / 2 + xPrev * 10);
                float yPrevPixel = (float)(graphPictureBox.Height / 2 - yPrev * 10);

                // Побудова графіку
                while (t <= tMax)
                {
                    // Знаходимо координати наступної точки
                    double x = (R + m * R) * Math.Cos(m * t) - m * Math.Cos(t + m * t);
                    double y = (R + m * R) * Math.Sin(m * t) - m * Math.Sin(t + m * t);

                    // Перетворюємо координати відповідно до розмірів PictureBox
                    float xPixel = (float)(graphPictureBox.Width / 2 + x * 10);
                    float yPixel = (float)(graphPictureBox.Height / 2 - y * 10);

                    // З'єднуємо точки лінією
                    g.DrawLine(Pens.Blue, xPrevPixel, yPrevPixel, xPixel, yPixel);

                    // Оновлюємо значення попередньої точки
                    xPrev = x;
                    yPrev = y;
                    xPrevPixel = xPixel;
                    yPrevPixel = yPixel;

                    t += dt;
                }

                // Відображення системи координат, підписів осей та значень на осях
                g.DrawLine(Pens.Black, 0, graphPictureBox.Height / 2, graphPictureBox.Width, graphPictureBox.Height / 2);
                g.DrawLine(Pens.Black, graphPictureBox.Width / 2, 0, graphPictureBox.Width / 2, graphPictureBox.Height);

                g.DrawString("X", Font, Brushes.Black, new PointF(graphPictureBox.Width - 20, graphPictureBox.Height / 2 - 15));
                g.DrawString("Y", Font, Brushes.Black, new PointF(graphPictureBox.Width / 2 + 10, 5));

                // Масштабування осей
                int scale = 20; // Масштабування
                int tickSize = 4; // Розмір позначки на осях

                // Масштабування осі X
                for (int i = 0; i <= graphPictureBox.Width; i += scale)
                {
                    g.DrawLine(Pens.Black, i, graphPictureBox.Height / 2 - tickSize, i, graphPictureBox.Height / 2 + tickSize);
                }

                // Масштабування осі Y
                for (int i = 0; i <= graphPictureBox.Height; i += scale)
                {
                    g.DrawLine(Pens.Black, graphPictureBox.Width / 2 - tickSize, i, graphPictureBox.Width / 2 + tickSize, i);
                }

                // Підписи значень на осях
                for (int i = -100; i <= 100; i++)
                {
                    g.DrawString(i.ToString(), Font, Brushes.Black, new PointF(graphPictureBox.Width / 2 + i * scale - 5, graphPictureBox.Height / 2 + 5));
                    g.DrawString((-i).ToString(), Font, Brushes.Black, new PointF(graphPictureBox.Width / 2 - 15, graphPictureBox.Height / 2 - i * scale - 7));
                }
            }
        }
    }
}

