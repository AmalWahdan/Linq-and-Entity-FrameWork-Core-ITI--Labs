using DBFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace DBFirst
{
    public partial class Form1 : Form
    {
        ItiContext db = new ItiContext();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            display();
           
            dataGridView2.DataSource = db.Students.Include(S => S.Dept).Select(d => new { d.StFname, d.StLname, d.Dept.DeptName }).ToList();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Topics.Where(T=>T.TopName.ToLower().Contains(textBox3.Text.ToLower())).ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add();
            display();

        }

      
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update();  
            display();

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
            textBox1.Text =comboBox1.SelectedValue.ToString();
            textBox2.Text = comboBox1.Text;
        }
        private void Add()
        {
            Topic topic = new Topic();
            topic.TopId = int.Parse(textBox1.Text);
            topic.TopName = textBox2.Text;
            db.Topics.Add(topic);
            db.SaveChanges();
        }

        private void Update()
        {
           
            Topic topic = db.Topics.Where(T => T.TopId == int.Parse(textBox1.Text)).SingleOrDefault();
            topic.TopName = textBox2.Text;
            db.Topics.Update(topic);
            db.SaveChanges();
        }
        private void display()
        {
            dataGridView1.DataSource = db.Topics.ToList();
            comboBox1.DataSource = db.Topics.ToList();
            comboBox1.ValueMember = "TopId";
            comboBox1.DisplayMember = "TopName";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Topic topic = db.Topics.Where(T => T.TopId ==(int)comboBox1.SelectedValue).SingleOrDefault();
            db.Topics.Remove(topic);
            db.SaveChanges();
            display();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}