using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vehicleFleet
{
    public partial class Form1 : Form
    {

        public class Passenger
        {
            private string category;
            private int cost;

            private Dictionary<string, int> categories = new Dictionary<string, int> {
                {"children", 0},
                {"schoolboy", 45},
                {"pensioner", 50},
                {"ordinary passengers", 90}
            };

            public Passenger()
            {
                Random random = new Random();
                int r = random.Next(0, 4);
                int i = 0;
                foreach (var item in categories)
                {
                    if (r == i)
                    {
                        this.category = item.Key;
                        this.cost = item.Value;
                        break;
                    }
                    ++i;
                }
            }

            public Passenger(string category, int cost)
            {
                this.category = category;
                this.cost = cost;
            }

            public string Category
            {
                get { return this.category; }
                set { this.category = value; }
            }

            public int Cost
            {
                get { return this.cost; }
                set { this.cost = value; }
            }

            public Dictionary<string, int> Categories { get { return this.categories; } }
        }

        public class Bus
        {
            List<Passenger> passengers = new List<Passenger>();

            private int Childrens = 0;
            private int Schoolboys = 0;
            private int Pensioners = 0;
            private int OrdinaryPassengers = 0;

            public Bus() { createPassengers(); }

            public int AllChildren { get { return Childrens; } }
            public int AllSchoolboy {  get { return Schoolboys; } }
            public int AllPensioner {  get { return Pensioners; } }
            public int AllOrdinaryPassenger { get { return OrdinaryPassengers; } }

            public int paymentChildren() { return Childrens * passengers[0].Categories["children"]; }
            public int paymentSchoolboys() { return Schoolboys * passengers[0].Categories["schoolboy"]; }
            public int paymentPensioners() { return Pensioners * passengers[0].Categories["pensioner"]; }
            public int paymentOrdinaryPassengers() { return OrdinaryPassengers * passengers[0].Categories["ordinary passengers"]; }
            public int paymentAllPassengers()
            {
                return paymentChildren() + paymentSchoolboys() + paymentPensioners() + paymentOrdinaryPassengers();
            }
            public int numberAllPassengers() { return passengers.Count; }

            public void createPassengers()
            {
                Random random = new Random();
                int count = random.Next(0, 101);

                for (int i = 0; i < count; ++i)
                {
                    Passenger passenger = new Passenger();
                    System.Threading.Thread.Sleep(1);
                    switch (passenger.Category)
                    {
                        case "children":
                            Childrens++;
                            break;
                        case "schoolboy":
                            Schoolboys++;
                            break;
                        case "pensioner":
                            Pensioners++;
                            break;
                        case "ordinary passengers":
                            OrdinaryPassengers++;
                            break;

                    }
                    passengers.Add(passenger);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            dataGridView1.Rows.Add("Дети");
            dataGridView1.Rows.Add("Школьники");
            dataGridView1.Rows.Add("Пенсионеры");
            dataGridView1.Rows.Add("Обычные пассажиры");
            dataGridView1.Rows.Add("Все категории");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bus bus = new Bus();

            dataGridView1.Rows[0].Cells[1].Value = bus.AllChildren;
            dataGridView1.Rows[0].Cells[2].Value = bus.paymentChildren() + " тг";

            dataGridView1.Rows[1].Cells[1].Value = bus.AllSchoolboy;
            dataGridView1.Rows[1].Cells[2].Value = bus.paymentSchoolboys() + " тг";

            dataGridView1.Rows[2].Cells[1].Value = bus.AllPensioner;
            dataGridView1.Rows[2].Cells[2].Value = bus.paymentPensioners() + " тг";

            dataGridView1.Rows[3].Cells[1].Value = bus.AllOrdinaryPassenger;
            dataGridView1.Rows[3].Cells[2].Value = bus.paymentOrdinaryPassengers() + " тг";

            dataGridView1.Rows[4].Cells[1].Value = bus.numberAllPassengers();
            dataGridView1.Rows[4].Cells[2].Value = bus.paymentAllPassengers() + " тг";
        }
    }
}
