namespace _04_IntroToOOP
{
    partial class Freezer
    {
        private int vattage;
        private int temperature;
        private int humidity;
        private int warranty;
        private int volume;

        public int Vattage
        {
            get { return vattage; }
            set { 
                if (vattage >=0){
                        vattage = value;
                    }
                else { vattage = 0; }
                }
        }
        public int Temperature { get { return temperature; } set { temperature = value; } }

        public int Humidity
        {
            get { return humidity; }
            set
            {
                if (humidity >= 0)
                {
                    humidity = value;
                }
                else { humidity = 0; }
            }
        }

        public int Warranty
        {
            get { return warranty; }
            set
            {
                if (warranty >= 0)
                {
                    warranty = value;
                }
                else { warranty = 0; }
            }
        }

        public int Volume
        {
            get { return volume; }
            set
            {
                if (volume >= 0)
                {
                    volume = value;
                }
                else { volume = 0; }
            }
        }

        static int count;
        static string model;

        public string Model { get { return model; } set { model = value; } }

        public int Count
        {
            get { return count; }
            set {
                if (count >= 0) { count = value; }
                else { count = 0; }
                }
        }

        public Freezer()
        {
            vattage = 0;
            temperature = 0;
            humidity = 0;
            warranty = 0;
            volume = 0;
        }
        static Freezer()
        {
            count = 0; model = "Xiomi";
        }
        public Freezer(int va, int t, int h, int w, int vl)
        {
            vattage = va; temperature = t; humidity = h; warranty = w; volume = vl; count++;
        }
        public override string ToString()
        {
            return ($"Vattage {vattage}, Temperature {temperature}, Humidity {humidity}, Warranty{warranty}, Volume{volume}, Number of fridges {count}, Frides model {model}");
        }

    }
}
