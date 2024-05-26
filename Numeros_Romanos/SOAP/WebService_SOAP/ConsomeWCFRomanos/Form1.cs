namespace ConsomeWCFRomanos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string romano = Convert.ToString(textBox1.Text);

            NumerosRomanos.Service1Client servico = new NumerosRomanos.Service1Client();
            int numero = servico.TransformarNumero(romano);

            label3.Text = numero.ToString();
        }
    }
}
