using PhysicValuesLib;

namespace WindowsAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //загружаем список физических велечин в listbox1
           ConverterManager manager = new ConverterManager();
           listBox1.DataSource = manager.GetPhysicValuesList();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //загружаем список ед. измерения в listbox2
            ConverterManager manager = new ConverterManager();
            listBox2.DataSource = manager.GetMeasureList(listBox1.Text);
            //перенос значений из listbox2 в listbox3
            listBox3.Items.Clear();
            int i = 0;
            while (listBox2.Items.Count > i)
            {
                listBox3.Items.Add(listBox2.Items[i]);
                i++;
            }
            listBox3.SelectedIndex = listBox3.TopIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ConverterManager manager = new ConverterManager();
                string physicValue = listBox1.SelectedItem.ToString();
                double value = Convert.ToDouble(textBox1.Text);
                string from = listBox2.SelectedItem.ToString();
                string to = listBox3.SelectedItem.ToString();
                textBox2.Text = manager.GetConvertedValue(physicValue, value, from, to).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Указаны не все значения");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}