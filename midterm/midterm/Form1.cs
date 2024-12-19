using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace midterm
{
    public partial class Form1 : Form
    {
        private Random random = new Random(); // สร้างอ็อบเจ็กต์ Random สำหรับสุ่มค่า
        private System.Windows.Forms.Timer timerAnimation; // กำหนด Timer สำหรับการทำแอนิเมชัน
        private int rotationIndex = 0; // ตัวแปรสำหรับติดตามการหมุนของแอนิเมชัน
        private char[,] array; // ตัวแปรเก็บอาเรย์ที่มีอักขระสุ่ม
        private string shapeType; // ตัวแปรเก็บประเภทของรูปทรงที่เลือก

        public Form1()
        {
            InitializeComponent();
            InitializeTimer(); // เริ่มต้น Timer เมื่อลงชื่อเข้าใช้ฟอร์ม
        }

        // เมธอดสำหรับเริ่มต้น Timer
        private void InitializeTimer()
        {
            timerAnimation = new System.Windows.Forms.Timer(); // สร้างอ็อบเจ็กต์ Timer ใหม่
            timerAnimation.Interval = 100; // ตั้งค่า Interval ของ Timer เป็น 100 มิลลิวินาที
            timerAnimation.Tick += TimerAnimation_Tick; // เพิ่ม event handler สำหรับ Timer Tick
        }

        // เมธอดที่เรียกใช้เมื่อฟอร์มโหลด
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxShapeType.Items.Add("square"); // เพิ่มตัวเลือก "square" ลงใน combo box
            comboBoxShapeType.Items.Add("triangle"); // เพิ่มตัวเลือก "triangle" ลงใน combo box
            comboBoxShapeType.Items.Add("circle"); // เพิ่มตัวเลือก "circle" ลงใน combo box
            comboBoxShapeType.SelectedIndex = 0; // ตั้งค่าการเลือกเริ่มต้นเป็นตัวเลือกแรก
        }

        // เมธอดที่เรียกใช้เมื่อ Timer Tick
        private void TimerAnimation_Tick(object sender, EventArgs e)
        {
            rotationIndex++; // เพิ่มค่าตัวแปร rotationIndex สำหรับแอนิเมชัน
            string shape = GenerateAnimatedShape(array, shapeType, rotationIndex); // สร้างรูปทรงที่แอนิเมต
            richTextBox1.Text = shape; // แสดงรูปทรงใน RichTextBox
        }

        // เมธอดที่เรียกใช้เมื่อคลิกปุ่ม Generate Shape
        private void btnGenerateShape_Click(object sender, EventArgs e)
        {
            int rows = 20; // กำหนดจำนวนแถวสำหรับอาเรย์
            int cols = 20; // กำหนดจำนวนคอลัมน์สำหรับอาเรย์
            array = GenerateRandomArray(rows, cols); // สร้างอาเรย์สุ่มของอักขระ

            shapeType = comboBoxShapeType.SelectedItem.ToString(); // ดึงประเภทของรูปทรงที่เลือกจาก combo box
            rotationIndex = 0; // รีเซ็ตค่า rotationIndex สำหรับแอนิเมชัน
            timerAnimation.Start(); // เริ่ม Timer เพื่อเริ่มแอนิเมชัน

            richTextBox1.Font = new Font("Consolas", 10); // ตั้งฟอนต์สำหรับ RichTextBox
            richTextBox1.WordWrap = false; // ปิดการห่อข้อความใน RichTextBox
        }

        // เมธอดที่เรียกใช้เมื่อคลิกปุ่ม Stop Animation
        private void btnStopAnimation_Click(object sender, EventArgs e)
        {
            timerAnimation.Stop(); // หยุด Timer เพื่อหยุดการทำงานของแอนิเมชัน
        }

        // เมธอดสำหรับสร้างอาเรย์สุ่มของอักขระ
        private char[,] GenerateRandomArray(int rows, int cols)
        {
            char[,] array = new char[rows, cols]; // สร้างอาเรย์ 2D ใหม่
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = GetRandomChar(); // เติมอาเรย์ด้วยอักขระสุ่ม
                }
            }
            return array;
        }

        // เมธอดสำหรับดึงอักขระสุ่มจาก A-Z และ 0-9
        private char GetRandomChar()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return chars[random.Next(chars.Length)]; // คืนค่าอักขระสุ่ม
        }

        // เมธอดสำหรับสร้างรูปทรงสามเหลี่ยมจากอาเรย์
        private string GenerateTriangleShape(char[,] array)
        {
            StringBuilder sb = new StringBuilder(); // สร้าง StringBuilder สำหรับการจัดการสตริงอย่างมีประสิทธิภาพ
            int i = 0;
            while (i < array.GetLength(0)) // ลูปผ่านแถว
            {
                sb.Append(new string(' ', (array.GetLength(0) - i - 1) * 2)); // จัดศูนย์รูปทรงสามเหลี่ยม

                int j = 0;
                while (j <= i) // ลูปผ่านคอลัมน์จนถึงดัชนีแถวปัจจุบัน
                {
                    sb.Append(array[i, j] + " "); // เพิ่มอักขระพร้อมช่องว่าง
                    j++;
                }

                sb.AppendLine(); // ไปที่บรรทัดถัดไป
                i++;
            }
            return sb.ToString(); // คืนค่าเป็นสตริงที่แสดงรูปทรง
        }

        // เมธอดสำหรับสร้างรูปทรงสี่เหลี่ยมจากอาเรย์
        private string GenerateSquareShape(char[,] array)
        {
            StringBuilder sb = new StringBuilder(); // สร้าง StringBuilder สำหรับการจัดการสตริงอย่างมีประสิทธิภาพ
            int i = 0;
            while (i < array.GetLength(0)) // ลูปผ่านแถว
            {
                int j = 0;
                while (j < array.GetLength(1)) // ลูปผ่านคอลัมน์
                {
                    sb.Append(array[i, j] + " "); // เพิ่มอักขระพร้อมช่องว่าง
                    j++;
                }
                sb.AppendLine(); // ไปที่บรรทัดถัดไป
                i++;
            }
            return sb.ToString(); // คืนค่าเป็นสตริงที่แสดงรูปทรง
        }

        // เมธอดสำหรับสร้างรูปทรงวงกลมจากอาเรย์
        private string GenerateCircleShape(char[,] array)
        {
            StringBuilder sb = new StringBuilder(); // สร้าง StringBuilder สำหรับการจัดการสตริงอย่างมีประสิทธิภาพ
            int radius = array.GetLength(0) / 2; // คำนวณรัศมีของวงกลม
            int i = 0;
            while (i < array.GetLength(0)) // ลูปผ่านแถว
            {
                int j = 0;
                while (j < array.GetLength(1)) // ลูปผ่านคอลัมน์
                {
                    double distance = Math.Sqrt(Math.Pow(i - radius, 2) + Math.Pow(j - radius, 2)); // คำนวณระยะทางจากศูนย์กลาง
                    if (distance <= radius)
                    {
                        sb.Append(array[i, j] + " "); // เพิ่มอักขระภายในวงกลม
                    }
                    else
                    {
                        sb.Append("  "); // เพิ่มช่องว่างภายนอกวงกลม
                    }
                    j++;
                }
                sb.AppendLine(); // ไปที่บรรทัดถัดไป
                i++;
            }
            return sb.ToString(); // คืนค่าเป็นสตริงที่แสดงรูปทรง
        }

        // เมธอดสำหรับสร้างรูปทรงตามประเภทที่เลือก
        private string GenerateShape(char[,] array, string shapeType)
        {
            switch (shapeType.ToLower()) // ตรวจสอบประเภทของรูปทรง
            {
                case "square":
                    return GenerateSquareShape(array); // คืนค่ารูปทรงสี่เหลี่ยม
                case "triangle":
                    return GenerateTriangleShape(array); // คืนค่ารูปทรงสามเหลี่ยม
                case "circle":
                    return GenerateCircleShape(array); // คืนค่ารูปทรงวงกลม
                default:
                    return "Unknown shape type"; // คืนค่าเป็นข้อความข้อผิดพลาดสำหรับประเภทที่ไม่รู้จัก
            }
        }

        // เมธอดสำหรับสร้างรูปทรงที่แอนิเมตโดยการหมุนอาเรย์
        private string GenerateAnimatedShape(char[,] array, string shapeType, int rotationIndex)
        {
            int rows = array.GetLength(0); // รับจำนวนแถว
            int cols = array.GetLength(1); // รับจำนวนคอลัมน์
            char[,] rotatedArray = new char[rows, cols]; // สร้างอาเรย์ใหม่สำหรับรูปทรงที่หมุน

            // การหมุนอย่างง่ายโดยการเลื่อนแถว
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int newI = (i + rotationIndex) % rows; // คำนวณดัชนีแถวใหม่สำหรับการหมุน
                    rotatedArray[newI, j] = array[i, j]; // ตั้งค่าอักขระในตำแหน่งใหม่
                }
            }

            return GenerateShape(rotatedArray, shapeType); // สร้างและคืนค่ารูปทรงที่หมุน
        }
    }
}
