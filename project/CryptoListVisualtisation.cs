namespace project
{
    public partial class CryptoListVisualtisation : Form
    {
        private List<CryptoDto> p_cryptoDtos;
        public CryptoListVisualtisation()
        {
            InitializeComponent();
            this.Text = "CryptoListVisualtisation";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            p_cryptoDtos = Task.Run(async () => await DataFetcher.Fetch()).GetAwaiter().GetResult();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = p_cryptoDtos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = cryptoDtos.Where(it => it.Volume > 1000).ToList();
            dataGridView1.DataSource = p_cryptoDtos.OrderByDescending(it => it.LowPrice).ToList();
        }
    }
}