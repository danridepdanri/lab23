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
            
            // ������ �������� �������� ��� r, R �� t
           
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            // �������� �������� r, R �� t � ��������� ����
            if (!double.TryParse(txtRR.Text, out R) || !double.TryParse(txtr.Text, out r) || !double.TryParse(txtT.Text, out t))
            {
                MessageBox.Show("��������� �������� ��� r, R ��� t");
                return;
            }

            // ���������� m �� �������� m = r/R
            m = r / R;

            // ������� ��������� ������
            graphPictureBox.Refresh();

            // ���������� �� �������� �������
            using (Graphics g = graphPictureBox.CreateGraphics())
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                double dt = 0.01; // ���� ���� t

                // ������ ������� ���������� ������� (����� ������ �� �������)
                double tMin = -10;
                double tMax = 10;

                // ��������� ���������� ����� �����
                double xPrev = (R + m * R) * Math.Cos(m * t) - m * Math.Cos(t + m * t);
                double yPrev = (R + m * R) * Math.Sin(m * t) - m * Math.Sin(t + m * t);

                // ������������ ���������� �������� �� ������ PictureBox
                float xPrevPixel = (float)(graphPictureBox.Width / 2 + xPrev * 10);
                float yPrevPixel = (float)(graphPictureBox.Height / 2 - yPrev * 10);

                // �������� �������
                while (t <= tMax)
                {
                    // ��������� ���������� �������� �����
                    double x = (R + m * R) * Math.Cos(m * t) - m * Math.Cos(t + m * t);
                    double y = (R + m * R) * Math.Sin(m * t) - m * Math.Sin(t + m * t);

                    // ������������ ���������� �������� �� ������ PictureBox
                    float xPixel = (float)(graphPictureBox.Width / 2 + x * 10);
                    float yPixel = (float)(graphPictureBox.Height / 2 - y * 10);

                    // �'������ ����� ���
                    g.DrawLine(Pens.Blue, xPrevPixel, yPrevPixel, xPixel, yPixel);

                    // ��������� �������� ���������� �����
                    xPrev = x;
                    yPrev = y;
                    xPrevPixel = xPixel;
                    yPrevPixel = yPixel;

                    t += dt;
                }

                // ³���������� ������� ���������, ������ ���� �� ������� �� ����
                g.DrawLine(Pens.Black, 0, graphPictureBox.Height / 2, graphPictureBox.Width, graphPictureBox.Height / 2);
                g.DrawLine(Pens.Black, graphPictureBox.Width / 2, 0, graphPictureBox.Width / 2, graphPictureBox.Height);

                g.DrawString("X", Font, Brushes.Black, new PointF(graphPictureBox.Width - 20, graphPictureBox.Height / 2 - 15));
                g.DrawString("Y", Font, Brushes.Black, new PointF(graphPictureBox.Width / 2 + 10, 5));

                // ������������� ����
                int scale = 20; // �������������
                int tickSize = 4; // ����� �������� �� ����

                // ������������� �� X
                for (int i = 0; i <= graphPictureBox.Width; i += scale)
                {
                    g.DrawLine(Pens.Black, i, graphPictureBox.Height / 2 - tickSize, i, graphPictureBox.Height / 2 + tickSize);
                }

                // ������������� �� Y
                for (int i = 0; i <= graphPictureBox.Height; i += scale)
                {
                    g.DrawLine(Pens.Black, graphPictureBox.Width / 2 - tickSize, i, graphPictureBox.Width / 2 + tickSize, i);
                }

                // ϳ����� ������� �� ����
                for (int i = -100; i <= 100; i++)
                {
                    g.DrawString(i.ToString(), Font, Brushes.Black, new PointF(graphPictureBox.Width / 2 + i * scale - 5, graphPictureBox.Height / 2 + 5));
                    g.DrawString((-i).ToString(), Font, Brushes.Black, new PointF(graphPictureBox.Width / 2 - 15, graphPictureBox.Height / 2 - i * scale - 7));
                }
            }
        }
    }
}

