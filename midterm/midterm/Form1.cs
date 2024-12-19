using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace midterm
{
    public partial class Form1 : Form
    {
        private Random random = new Random(); // ���ҧ��ͺ�硵� Random ����Ѻ�������
        private System.Windows.Forms.Timer timerAnimation; // ��˹� Timer ����Ѻ��÷��͹����ѹ
        private int rotationIndex = 0; // ���������Ѻ�Դ��������ع�ͧ�͹����ѹ
        private char[,] array; // ������������������ѡ�������
        private string shapeType; // ������纻������ͧ�ٻ�ç������͡

        public Form1()
        {
            InitializeComponent();
            InitializeTimer(); // ������� Timer �����ŧ�������������
        }

        // ���ʹ����Ѻ������� Timer
        private void InitializeTimer()
        {
            timerAnimation = new System.Windows.Forms.Timer(); // ���ҧ��ͺ�硵� Timer ����
            timerAnimation.Interval = 100; // ��駤�� Interval �ͧ Timer �� 100 ������Թҷ�
            timerAnimation.Tick += TimerAnimation_Tick; // ���� event handler ����Ѻ Timer Tick
        }

        // ���ʹ������¡������Ϳ������Ŵ
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxShapeType.Items.Add("square"); // ����������͡ "square" ŧ� combo box
            comboBoxShapeType.Items.Add("triangle"); // ����������͡ "triangle" ŧ� combo box
            comboBoxShapeType.Items.Add("circle"); // ����������͡ "circle" ŧ� combo box
            comboBoxShapeType.SelectedIndex = 0; // ��駤�ҡ�����͡��������繵�����͡�á
        }

        // ���ʹ������¡������� Timer Tick
        private void TimerAnimation_Tick(object sender, EventArgs e)
        {
            rotationIndex++; // ������ҵ���� rotationIndex ����Ѻ�͹����ѹ
            string shape = GenerateAnimatedShape(array, shapeType, rotationIndex); // ���ҧ�ٻ�ç����͹����
            richTextBox1.Text = shape; // �ʴ��ٻ�ç� RichTextBox
        }

        // ���ʹ������¡������ͤ�ԡ���� Generate Shape
        private void btnGenerateShape_Click(object sender, EventArgs e)
        {
            int rows = 20; // ��˹��ӹǹ������Ѻ������
            int cols = 20; // ��˹��ӹǹ�����������Ѻ������
            array = GenerateRandomArray(rows, cols); // ���ҧ�����������ͧ�ѡ���

            shapeType = comboBoxShapeType.SelectedItem.ToString(); // �֧�������ͧ�ٻ�ç������͡�ҡ combo box
            rotationIndex = 0; // ���絤�� rotationIndex ����Ѻ�͹����ѹ
            timerAnimation.Start(); // ����� Timer ����������͹����ѹ

            richTextBox1.Font = new Font("Consolas", 10); // ��駿͹������Ѻ RichTextBox
            richTextBox1.WordWrap = false; // �Դ�����͢�ͤ���� RichTextBox
        }

        // ���ʹ������¡������ͤ�ԡ���� Stop Animation
        private void btnStopAnimation_Click(object sender, EventArgs e)
        {
            timerAnimation.Stop(); // ��ش Timer ������ش��÷ӧҹ�ͧ�͹����ѹ
        }

        // ���ʹ����Ѻ���ҧ�����������ͧ�ѡ���
        private char[,] GenerateRandomArray(int rows, int cols)
        {
            char[,] array = new char[rows, cols]; // ���ҧ������ 2D ����
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = GetRandomChar(); // �������������ѡ�������
                }
            }
            return array;
        }

        // ���ʹ����Ѻ�֧�ѡ��������ҡ A-Z ��� 0-9
        private char GetRandomChar()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return chars[random.Next(chars.Length)]; // �׹����ѡ�������
        }

        // ���ʹ����Ѻ���ҧ�ٻ�ç�����������ҡ������
        private string GenerateTriangleShape(char[,] array)
        {
            StringBuilder sb = new StringBuilder(); // ���ҧ StringBuilder ����Ѻ��èѴ���ʵ�ԧ���ҧ�ջ���Է���Ҿ
            int i = 0;
            while (i < array.GetLength(0)) // �ٻ��ҹ��
            {
                sb.Append(new string(' ', (array.GetLength(0) - i - 1) * 2)); // �Ѵ�ٹ���ٻ�ç����������

                int j = 0;
                while (j <= i) // �ٻ��ҹ������쨹�֧�Ѫ���ǻѨ�غѹ
                {
                    sb.Append(array[i, j] + " "); // �����ѡ��о������ͧ��ҧ
                    j++;
                }

                sb.AppendLine(); // 价���÷Ѵ�Ѵ�
                i++;
            }
            return sb.ToString(); // �׹�����ʵ�ԧ����ʴ��ٻ�ç
        }

        // ���ʹ����Ѻ���ҧ�ٻ�ç�����������ҡ������
        private string GenerateSquareShape(char[,] array)
        {
            StringBuilder sb = new StringBuilder(); // ���ҧ StringBuilder ����Ѻ��èѴ���ʵ�ԧ���ҧ�ջ���Է���Ҿ
            int i = 0;
            while (i < array.GetLength(0)) // �ٻ��ҹ��
            {
                int j = 0;
                while (j < array.GetLength(1)) // �ٻ��ҹ�������
                {
                    sb.Append(array[i, j] + " "); // �����ѡ��о������ͧ��ҧ
                    j++;
                }
                sb.AppendLine(); // 价���÷Ѵ�Ѵ�
                i++;
            }
            return sb.ToString(); // �׹�����ʵ�ԧ����ʴ��ٻ�ç
        }

        // ���ʹ����Ѻ���ҧ�ٻ�çǧ����ҡ������
        private string GenerateCircleShape(char[,] array)
        {
            StringBuilder sb = new StringBuilder(); // ���ҧ StringBuilder ����Ѻ��èѴ���ʵ�ԧ���ҧ�ջ���Է���Ҿ
            int radius = array.GetLength(0) / 2; // �ӹǳ����բͧǧ���
            int i = 0;
            while (i < array.GetLength(0)) // �ٻ��ҹ��
            {
                int j = 0;
                while (j < array.GetLength(1)) // �ٻ��ҹ�������
                {
                    double distance = Math.Sqrt(Math.Pow(i - radius, 2) + Math.Pow(j - radius, 2)); // �ӹǳ���зҧ�ҡ�ٹ���ҧ
                    if (distance <= radius)
                    {
                        sb.Append(array[i, j] + " "); // �����ѡ�������ǧ���
                    }
                    else
                    {
                        sb.Append("  "); // ������ͧ��ҧ��¹͡ǧ���
                    }
                    j++;
                }
                sb.AppendLine(); // 价���÷Ѵ�Ѵ�
                i++;
            }
            return sb.ToString(); // �׹�����ʵ�ԧ����ʴ��ٻ�ç
        }

        // ���ʹ����Ѻ���ҧ�ٻ�ç���������������͡
        private string GenerateShape(char[,] array, string shapeType)
        {
            switch (shapeType.ToLower()) // ��Ǩ�ͺ�������ͧ�ٻ�ç
            {
                case "square":
                    return GenerateSquareShape(array); // �׹����ٻ�ç����������
                case "triangle":
                    return GenerateTriangleShape(array); // �׹����ٻ�ç����������
                case "circle":
                    return GenerateCircleShape(array); // �׹����ٻ�çǧ���
                default:
                    return "Unknown shape type"; // �׹����繢�ͤ�����ͼԴ��Ҵ����Ѻ���������������ѡ
            }
        }

        // ���ʹ����Ѻ���ҧ�ٻ�ç����͹�����¡����ع������
        private string GenerateAnimatedShape(char[,] array, string shapeType, int rotationIndex)
        {
            int rows = array.GetLength(0); // �Ѻ�ӹǹ��
            int cols = array.GetLength(1); // �Ѻ�ӹǹ�������
            char[,] rotatedArray = new char[rows, cols]; // ���ҧ��������������Ѻ�ٻ�ç�����ع

            // �����ع���ҧ�����¡������͹��
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int newI = (i + rotationIndex) % rows; // �ӹǳ�Ѫ������������Ѻ�����ع
                    rotatedArray[newI, j] = array[i, j]; // ��駤���ѡ���㹵��˹�����
                }
            }

            return GenerateShape(rotatedArray, shapeType); // ���ҧ��Ф׹����ٻ�ç�����ع
        }
    }
}
