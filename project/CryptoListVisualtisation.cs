namespace project
{
    public partial class CryptoListVisualtisation : Form
    {
        private List<CryptoDto> p_cryptoDtos;
        private Dictionary<string, bool> p_columnOrderState = new Dictionary<string, bool>();

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

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dataGridView1.Columns[e.ColumnIndex].DataPropertyName;

            if (p_columnOrderState.ContainsKey(columnName))
            {
                bool currentState = p_columnOrderState[columnName];
                foreach (var key in p_columnOrderState.Keys)
                {
                    if (key == columnName)
                    {
                        p_columnOrderState[key] = !currentState;
                    }
                    else
                    {
                        p_columnOrderState[key] = true;
                    }
                }
            }
            else
            {
                p_columnOrderState.Add(columnName, true);
            }

            if (p_columnOrderState[columnName])
            {
                dataGridView1.DataSource = p_cryptoDtos.OrderBy(i => i.GetType().GetProperty(columnName).GetValue(i)).ToList();
            }
            else
            {
                dataGridView1.DataSource = p_cryptoDtos.OrderByDescending(i => i.GetType().GetProperty(columnName).GetValue(i)).ToList();
            }
        }
    }
}